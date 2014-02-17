<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog = New System.Windows.Forms.SaveFileDialog()
        Me.PrintPreviewDialog = New System.Windows.Forms.PrintPreviewDialog()
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PreviesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UpdateEntryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InsertEntryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SearchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ByNameToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.StatusBarText = New System.Windows.Forms.ToolStripStatusLabel()
        Me.grpPrimary = New System.Windows.Forms.Panel()
        Me.btnEntryNext = New System.Windows.Forms.Button()
        Me.btnEntryPrev = New System.Windows.Forms.Button()
        Me.grpEntries = New System.Windows.Forms.GroupBox()
        Me.lstAllEntries = New System.Windows.Forms.ListBox()
        Me.grpName = New System.Windows.Forms.GroupBox()
        Me.txtInputLastName = New System.Windows.Forms.TextBox()
        Me.txtInputFirstName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grpAddress = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtInputZIP = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtInputState = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtInputStreet = New System.Windows.Forms.TextBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.grpContact = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtInputPhone = New System.Windows.Forms.TextBox()
        Me.txtInputEmail = New System.Windows.Forms.TextBox()
        Me.PrintDocument = New System.Drawing.Printing.PrintDocument()
        Me.MenuStrip.SuspendLayout()
        Me.StatusStrip.SuspendLayout()
        Me.grpPrimary.SuspendLayout()
        Me.grpEntries.SuspendLayout()
        Me.grpName.SuspendLayout()
        Me.grpAddress.SuspendLayout()
        Me.grpContact.SuspendLayout()
        Me.SuspendLayout()
        '
        'OpenFileDialog
        '
        Me.OpenFileDialog.FileName = "OpenFileDialog"
        '
        'PrintPreviewDialog
        '
        Me.PrintPreviewDialog.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog.Enabled = True
        Me.PrintPreviewDialog.Icon = CType(resources.GetObject("PrintPreviewDialog.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog.Name = "PrintPreviewDialog"
        Me.PrintPreviewDialog.Visible = False
        '
        'MenuStrip
        '
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.SearchToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(725, 24)
        Me.MenuStrip.TabIndex = 0
        Me.MenuStrip.Text = "MenuStrip"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveToolStripMenuItem, Me.PrintToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(101, 22)
        Me.SaveToolStripMenuItem.Text = "Save "
        '
        'PrintToolStripMenuItem
        '
        Me.PrintToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PreviesToolStripMenuItem})
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(101, 22)
        Me.PrintToolStripMenuItem.Text = "Print"
        '
        'PreviesToolStripMenuItem
        '
        Me.PreviesToolStripMenuItem.Name = "PreviesToolStripMenuItem"
        Me.PreviesToolStripMenuItem.Size = New System.Drawing.Size(112, 22)
        Me.PreviesToolStripMenuItem.Text = "Preview"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(101, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UpdateEntryToolStripMenuItem, Me.InsertEntryToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'UpdateEntryToolStripMenuItem
        '
        Me.UpdateEntryToolStripMenuItem.Name = "UpdateEntryToolStripMenuItem"
        Me.UpdateEntryToolStripMenuItem.Size = New System.Drawing.Size(138, 22)
        Me.UpdateEntryToolStripMenuItem.Text = "Update Entry"
        '
        'InsertEntryToolStripMenuItem
        '
        Me.InsertEntryToolStripMenuItem.Name = "InsertEntryToolStripMenuItem"
        Me.InsertEntryToolStripMenuItem.Size = New System.Drawing.Size(138, 22)
        Me.InsertEntryToolStripMenuItem.Text = "Insert Entry"
        '
        'SearchToolStripMenuItem
        '
        Me.SearchToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ByNameToolStripMenuItem})
        Me.SearchToolStripMenuItem.Name = "SearchToolStripMenuItem"
        Me.SearchToolStripMenuItem.Size = New System.Drawing.Size(52, 20)
        Me.SearchToolStripMenuItem.Text = "Search"
        '
        'ByNameToolStripMenuItem
        '
        Me.ByNameToolStripMenuItem.Name = "ByNameToolStripMenuItem"
        Me.ByNameToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.ByNameToolStripMenuItem.Text = "By Name"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(40, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StatusBarText})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 364)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(725, 22)
        Me.StatusStrip.TabIndex = 1
        Me.StatusStrip.Text = "StatusStrip1"
        '
        'StatusBarText
        '
        Me.StatusBarText.Name = "StatusBarText"
        Me.StatusBarText.Size = New System.Drawing.Size(10, 17)
        Me.StatusBarText.Text = " "
        '
        'grpPrimary
        '
        Me.grpPrimary.Controls.Add(Me.btnEntryNext)
        Me.grpPrimary.Controls.Add(Me.btnEntryPrev)
        Me.grpPrimary.Controls.Add(Me.grpEntries)
        Me.grpPrimary.Controls.Add(Me.grpName)
        Me.grpPrimary.Controls.Add(Me.grpAddress)
        Me.grpPrimary.Controls.Add(Me.btnCancel)
        Me.grpPrimary.Controls.Add(Me.btnSave)
        Me.grpPrimary.Controls.Add(Me.grpContact)
        Me.grpPrimary.Location = New System.Drawing.Point(0, 27)
        Me.grpPrimary.Name = "grpPrimary"
        Me.grpPrimary.Size = New System.Drawing.Size(725, 332)
        Me.grpPrimary.TabIndex = 22
        '
        'btnEntryNext
        '
        Me.btnEntryNext.Location = New System.Drawing.Point(115, 289)
        Me.btnEntryNext.Name = "btnEntryNext"
        Me.btnEntryNext.Size = New System.Drawing.Size(75, 23)
        Me.btnEntryNext.TabIndex = 41
        Me.btnEntryNext.Text = "Next"
        Me.btnEntryNext.UseVisualStyleBackColor = True
        '
        'btnEntryPrev
        '
        Me.btnEntryPrev.Location = New System.Drawing.Point(34, 289)
        Me.btnEntryPrev.Name = "btnEntryPrev"
        Me.btnEntryPrev.Size = New System.Drawing.Size(75, 23)
        Me.btnEntryPrev.TabIndex = 40
        Me.btnEntryPrev.Text = "Prev"
        Me.btnEntryPrev.UseVisualStyleBackColor = True
        '
        'grpEntries
        '
        Me.grpEntries.Controls.Add(Me.lstAllEntries)
        Me.grpEntries.Location = New System.Drawing.Point(34, 20)
        Me.grpEntries.Name = "grpEntries"
        Me.grpEntries.Size = New System.Drawing.Size(386, 263)
        Me.grpEntries.TabIndex = 34
        Me.grpEntries.TabStop = False
        Me.grpEntries.Text = "View Entries"
        '
        'lstAllEntries
        '
        Me.lstAllEntries.FormattingEnabled = True
        Me.lstAllEntries.Location = New System.Drawing.Point(16, 18)
        Me.lstAllEntries.Name = "lstAllEntries"
        Me.lstAllEntries.Size = New System.Drawing.Size(355, 225)
        Me.lstAllEntries.TabIndex = 16
        '
        'grpName
        '
        Me.grpName.Controls.Add(Me.txtInputLastName)
        Me.grpName.Controls.Add(Me.txtInputFirstName)
        Me.grpName.Controls.Add(Me.Label2)
        Me.grpName.Controls.Add(Me.Label1)
        Me.grpName.Location = New System.Drawing.Point(426, 20)
        Me.grpName.Name = "grpName"
        Me.grpName.Size = New System.Drawing.Size(265, 83)
        Me.grpName.TabIndex = 31
        Me.grpName.TabStop = False
        Me.grpName.Text = "Name"
        '
        'txtInputLastName
        '
        Me.txtInputLastName.Location = New System.Drawing.Point(72, 52)
        Me.txtInputLastName.MaxLength = 65
        Me.txtInputLastName.Name = "txtInputLastName"
        Me.txtInputLastName.Size = New System.Drawing.Size(175, 20)
        Me.txtInputLastName.TabIndex = 5
        '
        'txtInputFirstName
        '
        Me.txtInputFirstName.Location = New System.Drawing.Point(72, 25)
        Me.txtInputFirstName.MaxLength = 65
        Me.txtInputFirstName.Name = "txtInputFirstName"
        Me.txtInputFirstName.Size = New System.Drawing.Size(175, 20)
        Me.txtInputFirstName.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Last Name"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "First Name"
        '
        'grpAddress
        '
        Me.grpAddress.Controls.Add(Me.Label5)
        Me.grpAddress.Controls.Add(Me.txtInputZIP)
        Me.grpAddress.Controls.Add(Me.Label4)
        Me.grpAddress.Controls.Add(Me.txtInputState)
        Me.grpAddress.Controls.Add(Me.Label3)
        Me.grpAddress.Controls.Add(Me.txtInputStreet)
        Me.grpAddress.Location = New System.Drawing.Point(426, 109)
        Me.grpAddress.Name = "grpAddress"
        Me.grpAddress.Size = New System.Drawing.Size(265, 88)
        Me.grpAddress.TabIndex = 32
        Me.grpAddress.TabStop = False
        Me.grpAddress.Text = "Address"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(142, 57)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(24, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "ZIP"
        '
        'txtInputZIP
        '
        Me.txtInputZIP.Location = New System.Drawing.Point(172, 54)
        Me.txtInputZIP.MaxLength = 16
        Me.txtInputZIP.Name = "txtInputZIP"
        Me.txtInputZIP.Size = New System.Drawing.Size(75, 20)
        Me.txtInputZIP.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(47, 57)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "State"
        '
        'txtInputState
        '
        Me.txtInputState.Location = New System.Drawing.Point(85, 54)
        Me.txtInputState.MaxLength = 2
        Me.txtInputState.Name = "txtInputState"
        Me.txtInputState.Size = New System.Drawing.Size(40, 20)
        Me.txtInputState.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(44, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Street"
        '
        'txtInputStreet
        '
        Me.txtInputStreet.Location = New System.Drawing.Point(85, 19)
        Me.txtInputStreet.MaxLength = 65
        Me.txtInputStreet.Name = "txtInputStreet"
        Me.txtInputStreet.Size = New System.Drawing.Size(162, 20)
        Me.txtInputStreet.TabIndex = 5
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(616, 289)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 39
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(535, 289)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 38
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'grpContact
        '
        Me.grpContact.Controls.Add(Me.Label6)
        Me.grpContact.Controls.Add(Me.Label7)
        Me.grpContact.Controls.Add(Me.txtInputPhone)
        Me.grpContact.Controls.Add(Me.txtInputEmail)
        Me.grpContact.Location = New System.Drawing.Point(426, 203)
        Me.grpContact.Name = "grpContact"
        Me.grpContact.Size = New System.Drawing.Size(265, 80)
        Me.grpContact.TabIndex = 33
        Me.grpContact.TabStop = False
        Me.grpContact.Text = "Contact"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(47, 49)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(32, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Email"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(41, 26)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(38, 13)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Phone"
        '
        'txtInputPhone
        '
        Me.txtInputPhone.Location = New System.Drawing.Point(85, 19)
        Me.txtInputPhone.MaxLength = 25
        Me.txtInputPhone.Name = "txtInputPhone"
        Me.txtInputPhone.Size = New System.Drawing.Size(162, 20)
        Me.txtInputPhone.TabIndex = 8
        '
        'txtInputEmail
        '
        Me.txtInputEmail.Location = New System.Drawing.Point(85, 46)
        Me.txtInputEmail.MaxLength = 25
        Me.txtInputEmail.Name = "txtInputEmail"
        Me.txtInputEmail.Size = New System.Drawing.Size(162, 20)
        Me.txtInputEmail.TabIndex = 10
        '
        'PrintDocument
        '
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(725, 386)
        Me.Controls.Add(Me.StatusStrip)
        Me.Controls.Add(Me.MenuStrip)
        Me.Controls.Add(Me.grpPrimary)
        Me.MainMenuStrip = Me.MenuStrip
        Me.Name = "frmMain"
        Me.Text = "Address Book"
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.grpPrimary.ResumeLayout(False)
        Me.grpEntries.ResumeLayout(False)
        Me.grpName.ResumeLayout(False)
        Me.grpName.PerformLayout()
        Me.grpAddress.ResumeLayout(False)
        Me.grpAddress.PerformLayout()
        Me.grpContact.ResumeLayout(False)
        Me.grpContact.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveFileDialog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents PrintPreviewDialog As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UpdateEntryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InsertEntryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SearchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ByNameToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents grpPrimary As System.Windows.Forms.Panel
    Friend WithEvents grpEntries As System.Windows.Forms.GroupBox
    Friend WithEvents grpName As System.Windows.Forms.GroupBox
    Friend WithEvents txtInputLastName As System.Windows.Forms.TextBox
    Friend WithEvents txtInputFirstName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents grpAddress As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtInputZIP As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtInputState As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtInputStreet As System.Windows.Forms.TextBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents grpContact As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtInputPhone As System.Windows.Forms.TextBox
    Friend WithEvents txtInputEmail As System.Windows.Forms.TextBox
    Friend WithEvents lstAllEntries As System.Windows.Forms.ListBox
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusBarText As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintDocument As System.Drawing.Printing.PrintDocument
    Friend WithEvents PreviesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnEntryNext As System.Windows.Forms.Button
    Friend WithEvents btnEntryPrev As System.Windows.Forms.Button

End Class
