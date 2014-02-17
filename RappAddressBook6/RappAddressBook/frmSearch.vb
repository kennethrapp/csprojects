Option Strict On
Public Class frmSearch
    ' itse 2334 
    ' addressbook revisited
    ' kenneth rapp

    ' search form - handles searching by name

    Private Sub frmSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub



    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        lstBoxResults.Items.Clear()

        Dim searchTerm As String = txtSearch.Text.ToLower.Trim
        Dim resultsfound As Integer = 0

        Dim format As String = "{0, 6} {1, -10} {2,-10}"

        lstBoxResults.Items.Add(String.Format(format, "Record", "Last Name", "First Name"))


        ' iterate the items 
        For Each entry As AddressBookEntry In frmMain.AddressBook
            Dim test = (entry.lastName + entry.firstName).ToLower.Trim
            If test.Contains(searchTerm) Then
                lstBoxResults.Items.Add(String.Format(format, (resultsfound + 1).ToString, entry.lastName, entry.firstName))
                resultsfound += 1
            End If
        Next



        lstBoxResults.Items.Add(" ... found" + (resultsfound).ToString + " results")

    End Sub

    Private Sub btnCancelSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelSearch.Click
        Me.Close()
    End Sub
End Class