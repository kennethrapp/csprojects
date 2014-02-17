<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDisplyRTF
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
        Me.rtbAbout = New System.Windows.Forms.RichTextBox()
        Me.btnCloseAbout = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'rtbAbout
        '
        Me.rtbAbout.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.rtbAbout.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.rtbAbout.Location = New System.Drawing.Point(12, 12)
        Me.rtbAbout.Name = "rtbAbout"
        Me.rtbAbout.ReadOnly = True
        Me.rtbAbout.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.rtbAbout.Size = New System.Drawing.Size(459, 249)
        Me.rtbAbout.TabIndex = 0
        Me.rtbAbout.Text = ""
        '
        'btnCloseAbout
        '
        Me.btnCloseAbout.Location = New System.Drawing.Point(12, 267)
        Me.btnCloseAbout.Name = "btnCloseAbout"
        Me.btnCloseAbout.Size = New System.Drawing.Size(459, 23)
        Me.btnCloseAbout.TabIndex = 1
        Me.btnCloseAbout.Text = "Close"
        Me.btnCloseAbout.UseVisualStyleBackColor = True
        '
        'frmAbout
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(483, 300)
        Me.Controls.Add(Me.btnCloseAbout)
        Me.Controls.Add(Me.rtbAbout)
        Me.Name = "frmAbout"
        Me.Text = "About"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rtbAbout As System.Windows.Forms.RichTextBox
    Friend WithEvents btnCloseAbout As System.Windows.Forms.Button
End Class
