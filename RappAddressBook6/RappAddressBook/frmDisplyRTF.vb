Option Strict On
Imports System.IO


Public Class frmDisplyRTF
    ' itse 2334 
    ' addressbook revisited
    ' kenneth rapp

    ' display something from an rtf file
    Private Sub About_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnCloseAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCloseAbout.Click
        Me.Close()
    End Sub

    ' make sure the file exists in bin/debug
    ' otherwise just close the dialog
    Protected Friend Sub New(ByRef filename As String)
        InitializeComponent()
        If File.Exists(Directory.GetCurrentDirectory + "/" + filename) Then
            Dim filepath As String = Directory.GetCurrentDirectory + "/" + filename
            Dim rtbcontrol As New System.Windows.Forms.RichTextBox
            rtbcontrol = rtbAbout
            rtbcontrol.LoadFile(filepath)
            ShowDialog()

        Else
            Me.Close()
        End If



    End Sub
End Class