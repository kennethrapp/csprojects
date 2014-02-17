Option Strict On
Imports System.IO


Public Class frmMain
    ' itse 2334 
    ' addressbook revisited
    ' kenneth rapp
    Protected Friend CurrentFileName As String
    Protected Friend AddressBook As New List(Of AddressBookEntry)
    Private EditMode As Boolean = False
    Private CurrentEntryPointer As Integer = 0
    Private Status As String = ""

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        MenuStrip.Enabled = False

        btnEntryNext.Enabled = False
        btnEntryPrev.Enabled = False
        ' the firstrun form will create the default
        ' folder and addressbook if they don't exist
        ' and allow the user to select a file, 
        ' returning the filename.
        Dim FirstRun As New frmFirstRun
        FirstRun.ShowDialog()

        ' if the filename passed wasn't empty
        If Not String.IsNullOrEmpty(CurrentFileName) Then

            ' and the file exists, open it
            If File.Exists(CurrentFileName) Then

                Try
                    Dim infile As StreamReader

                    infile = File.OpenText(CurrentFileName)

                    ' for each line, split by commas
                    ' and attempt to add it as an AddressBookEntry
                    ' to the AddressBook list
                    Do While Not infile.EndOfStream
                        Dim ln As String = infile.ReadLine
                        Dim items As String() = ln.Split(CChar(","))
                        If items.Length = 8 Then
                            Dim entry As New AddressBookEntry
                            entry.Load(items)
                            AddressBook.Add(entry)
                        End If
                    Loop

                    infile.Close()
                    UpdateLayout()
                Catch ex As Exception
                    MessageBox.Show(ex.ToString)
                End Try
              

            End If
        End If
    End Sub

    Private Function GetCurrentEntryPointer() As Integer
        Return CurrentEntryPointer
    End Function

    ' update the layout
    Private Sub UpdateLayout()

        lstAllEntries.Items.Clear()

        ' no entries exist...
        ' activate the data entry fields, and 
        ' only the save entry button
        If AddressBook.Count = 0 Then
            MessageBox.Show("This addressbook is empty. Please add an entry...")
            CurrentEntryPointer = 0
            AllowDataEntry(True)
            SetWriterNavigation(True, False)
        Else

            ' parse and add the address book entries
            For Each e As AddressBookEntry In AddressBook
                lstAllEntries.Items.Add(e.List())
            Next

            Dim p As Integer = GetCurrentEntryPointer()
            DisplayAddressBookItem(p) ' display the item
            SetWriterNavigation(False, False)
            MenuStrip.Enabled = True
        End If

        StatusBarText.Text = Status

    End Sub

    ' display the address book item in the form
    Private Sub DisplayAddressBookItem(ByRef i As Integer)

        ClearEditForm() 'clear the edit form
        SetReadOnly(True) ' set to readonly

        If (i >= AddressBook.Count) Then
            i = AddressBook.Count - 1
        End If

        Dim CurrentEntry As AddressBookEntry = AddressBook.Item(i)

        txtInputEmail.Text = CurrentEntry.email
        txtInputFirstName.Text = CurrentEntry.firstName
        txtInputLastName.Text = CurrentEntry.lastName
        txtInputPhone.Text = CurrentEntry.phoneNumber
        txtInputState.Text = CurrentEntry.state
        txtInputStreet.Text = CurrentEntry.address
        txtInputZIP.Text = CurrentEntry.zipcode

        StatusBarText.Text = "Displaying Entry " + (i + 1).ToString + " of " + (AddressBook.Count()).ToString

        btnEntryPrev.Enabled = (i > 0)
        btnEntryNext.Enabled = (i < AddressBook.Count - 1)

        lstAllEntries.SelectedIndex = i
    End Sub


    Private Sub ClearEditForm()
        txtInputEmail.Text = ""
        txtInputFirstName.Text = ""
        txtInputLastName.Text = ""
        txtInputPhone.Text = ""
        txtInputState.Text = ""
        txtInputStreet.Text = ""
        txtInputZIP.Text = ""
    End Sub

    Private Sub SetWriterNavigation(ByVal enSave As Boolean, ByVal enCancel As Boolean)
        btnSave.Enabled = enSave
        btnCancel.Enabled = enCancel
    End Sub

    Private Sub AllowEntryList(ByVal en As Boolean)
        grpEntries.Enabled = en
    End Sub

    Private Sub AllowDataEntry(ByVal en As Boolean)
        grpName.Enabled = en
        grpAddress.Enabled = en
        grpContact.Enabled = en
    End Sub

    ' set the display fields as readonly or not
    Private Sub SetReadOnly(ByVal em As Boolean)
        txtInputEmail.ReadOnly = em
        txtInputFirstName.ReadOnly = em
        txtInputLastName.ReadOnly = em
        txtInputPhone.ReadOnly = em
        txtInputState.ReadOnly = em
        txtInputStreet.ReadOnly = em
        txtInputZIP.ReadOnly = em
  
    End Sub

    ' creates a new address book entry, or edits an existing entry.
    ' if index is not passed or is not a valid index in the addressbook
    ' array, a new entry is created.
    Private Sub CreateNewEntry(Optional ByRef index As Integer = -1)

        If grpAddress.Enabled = True And grpContact.Enabled = True And grpName.Enabled = True Then

            ' required fields are first name, last name and either phone or email
            Dim FName As String = txtInputFirstName.Text.ToString
            Dim LName As String = txtInputLastName.Text.ToString
            Dim Phone As String = txtInputPhone.Text.ToString
            Dim State As String = txtInputState.Text.ToString
            Dim Street As String = txtInputStreet.Text.ToString
            Dim Email As String = txtInputEmail.Text.ToString
            Dim Zip As String = txtInputZIP.Text.ToString

            If String.IsNullOrWhiteSpace(FName) Or
                String.IsNullOrWhiteSpace(LName) Then
                MessageBox.Show("First Name, Last Name are required fields")

            ElseIf String.IsNullOrWhiteSpace(Phone) And
                String.IsNullOrWhiteSpace(Email) Then
                MessageBox.Show("Either Phone or Email must be provided")

            Else

                Dim NewAddressBookEntry As AddressBookEntry = New AddressBookEntry

                NewAddressBookEntry.firstName = FName
                NewAddressBookEntry.lastName = LName
                NewAddressBookEntry.address = Street
                NewAddressBookEntry.phoneNumber = Phone
                NewAddressBookEntry.state = State
                NewAddressBookEntry.zipcode = Zip
                NewAddressBookEntry.email = Email

                If index > -1 And index < AddressBook.Count Then
                    AddressBook.RemoveAt(index)
                End If

                AddressBook.Add(NewAddressBookEntry)
                UpdateLayout()
            End If
        End If

        EditMode = False

    End Sub

    ' save the contents of the address book to the current csv file. 
    Private Sub SaveToFile()
        If Not String.IsNullOrEmpty(CurrentFileName) Then
            ' and the file exists, open it
            If File.Exists(CurrentFileName) Then
                Dim outfile As New StreamWriter(CurrentFileName)
                Dim csvout As String = ""
                For Each entry As AddressBookEntry In AddressBook
                    csvout += entry.ToString() + vbCrLf
                Next
                outfile.Write(csvout)
                outfile.Close()
                StatusBarText.Text = "File saved."
            End If
        End If
    End Sub

    ' save an entry (new or updated)
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If EditMode Then
            CreateNewEntry(GetCurrentEntryPointer())
        Else
            CreateNewEntry(-1)
        End If
        SaveToFile()
    End Sub

    ' update an entry
    Private Sub UpdateEntryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateEntryToolStripMenuItem.Click
        DisplayAddressBookItem(GetCurrentEntryPointer())
        SetReadOnly(False)
        SetWriterNavigation(True, True)
        EditMode = True
        StatusBarText.Text = "Updating an entry..."
    End Sub

    ' set the current item
    Private Sub lstAllEntries_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstAllEntries.SelectedIndexChanged
        CurrentEntryPointer = lstAllEntries.SelectedIndex
        DisplayAddressBookItem(GetCurrentEntryPointer())
    End Sub

    ' create a new entry
    Private Sub InsertEntryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InsertEntryToolStripMenuItem.Click
        ClearEditForm()
        SetReadOnly(False)
        SetWriterNavigation(True, True)
        EditMode = False
        StatusBarText.Text = "Creating a new entry..."
    End Sub

    ' cancel the current operation
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        ClearEditForm()
        SetReadOnly(True)
        SetWriterNavigation(False, False)
        DisplayAddressBookItem(GetCurrentEntryPointer())
    End Sub

    ' save the addressbook to a csv file
    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        SaveToFile()
    End Sub

    ' open the search by name form
    Private Sub ByNameToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ByNameToolStripMenuItem.Click
        Dim frmSearch As New frmSearch
        frmSearch.ShowDialog()
    End Sub

    ' open the about form
    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        Dim frmAbout As New frmDisplyRTF("About.rtf")
    End Sub

    'print button
    Private Sub PrintToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripMenuItem.Click
        PrintDocument.Print()
    End Sub

    ' print preview button
    Private Sub PreviesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PreviesToolStripMenuItem.Click
        PrintPreviewDialog.Document = PrintDocument
        PrintPreviewDialog.ShowDialog()
    End Sub


    'print preview
    Private Sub PrintDocument_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument.PrintPage

        Dim gr As Graphics = e.Graphics
        Dim fontCourierNew24 As New Font("Courier New", 24, FontStyle.Bold)
        Dim fontCourierNew12 As New Font("Courier New", 12)
        Dim fontTNR32Bold As New Font("Times New Roman", 32, FontStyle.Bold)

        Dim bluePen As New Pen(Color.DarkBlue, 4)

        Dim horizontalPrintLocation As Single = e.MarginBounds.Left
        Dim verticalPrintLocation As Single = e.MarginBounds.Top

        Print(gr, fontTNR32Bold, horizontalPrintLocation, verticalPrintLocation, "Addressbook Data")
        verticalPrintLocation += fontTNR32Bold.Height + 10
        PrintHR(gr, horizontalPrintLocation, verticalPrintLocation, bluePen, e.MarginBounds.Width, 4)

        For Each ABentry As AddressBookEntry In AddressBook

            ' print the name
            Dim hstr As String = "Name: " + ABentry.lastName + ", " + ABentry.firstName
            Print(gr, fontCourierNew24, horizontalPrintLocation, verticalPrintLocation, hstr)
            verticalPrintLocation += fontCourierNew24.Height + 6
            ' address ln 1      phone ln 1
            ' address ln 2      email

            Print(gr, fontCourierNew12, horizontalPrintLocation, verticalPrintLocation, "Address: " + ABentry.address)
            horizontalPrintLocation += 400
            Print(gr, fontCourierNew12, horizontalPrintLocation, verticalPrintLocation, "Phone:" + ABentry.phoneNumber)
            horizontalPrintLocation = e.MarginBounds.Left
            verticalPrintLocation += fontCourierNew12.Height + 3

            Print(gr, fontCourierNew12, horizontalPrintLocation, verticalPrintLocation, "City, State, ZIP" + ABentry.city + ", " + ABentry.state + "," + ABentry.zipcode)
            horizontalPrintLocation += 400
            Print(gr, fontCourierNew12, horizontalPrintLocation, verticalPrintLocation, "Email: " + ABentry.email)
            horizontalPrintLocation = e.MarginBounds.Left
            verticalPrintLocation += fontCourierNew12.Height + 3

            PrintHR(gr, horizontalPrintLocation, verticalPrintLocation, bluePen, e.MarginBounds.Width, 4)

        Next

    End Sub

    Private Sub Print(ByRef gr As Graphics, ByRef font As Font, ByRef hpl As Single, ByRef vpl As Single, ByVal str As String)
        Dim lineHeight As Single = font.GetHeight
        gr.DrawString(str, font, Brushes.Black, hpl, vpl)

    End Sub

    ' print a 'horizontal rule' 
    Private Sub PrintHR(ByRef gr As Graphics, ByRef hpl As Single, ByRef vpl As Single, ByRef pen As Pen, ByVal w As Integer, ByVal h As Integer)
        vpl += h * 2
        gr.DrawLine(pen, h, vpl, w, vpl)
        vpl += h * 2
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click

        ' display a messagebox dialog asking if they want to
        ' save the current configuration, then close.
        Dim SaveResult = MessageBox.Show("Do you wish to save before closing?", "Close", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

        If SaveResult = DialogResult.Yes Then
            SaveToFile()
            Me.Close()
        ElseIf SaveResult = DialogResult.No Then
            Me.Close()
        End If

    End Sub

    ' advance the counter, wrapping around by modulus, and display the address book item.
    ' the list and prev/next buttons should update.
    Private Sub btnEntryNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEntryNext.Click
        CurrentEntryPointer = CurrentEntryPointer + 1 Mod (AddressBook.Count - 1)
        DisplayAddressBookItem(GetCurrentEntryPointer())
    End Sub

    ' decrement the counter blah blah modulus blah blah update
    Private Sub btnEntryPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEntryPrev.Click
        CurrentEntryPointer = CurrentEntryPointer - 1 Mod (AddressBook.Count - 1)
        DisplayAddressBookItem(GetCurrentEntryPointer())
    End Sub
End Class