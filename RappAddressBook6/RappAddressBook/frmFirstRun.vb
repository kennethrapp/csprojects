Option Strict On
Imports System.IO

Public Class frmFirstRun
    ' itse 2334 
    ' addressbook revisited
    ' kenneth rapp

    ' first run form finds and sets the inital file
    Private BaseDir As String = Directory.GetCurrentDirectory + "\"
    Private DefaultDir As String = "AddressBook"
    Private DefaultDataFileName As String = "default.csv"


    Private Sub frmFirstRun_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnUseSelectedFile.Enabled = False
        BuildDefaults()
        LoadCSVFiles()
    End Sub

    Private Sub BuildDefaults()

        ' if the directory and/or default file doesn't exist, create them 
        ' then attempt to load at least the default to allow selection.
        ' should check what the permissions for the folder and file
        ' need to be. 

        Try
            If Not Directory.Exists(BaseDir + DefaultDir + "\") Then
                Directory.CreateDirectory(BaseDir + DefaultDir + "\")
            End If
            Try
                If Not File.Exists(BaseDir + DefaultDir + "\" + DefaultDataFileName) Then
                    ' create an empty file
                    Dim f As StreamWriter = File.CreateText(BaseDir + DefaultDir + "\" + DefaultDataFileName)
                    f.Close()

                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString) ' cannot create the file
            End Try
        Catch ex As Exception
            MessageBox.Show(ex.ToString) 'cannot create the directory
        End Try
    End Sub

    ' load any csv files from the directory and add them to the list.
    Private Sub LoadCSVFiles()
        lstFiles.Items.Clear()
        Try
            Dim csvfiles As String() = Directory.GetFiles(BaseDir + DefaultDir + "\", "*.csv")
            For Each csvfile In csvfiles
                Dim basefile As String = Path.GetFileNameWithoutExtension(csvfile)
                lstFiles.Items.Add(basefile)
            Next
        Catch ex As Exception
            MessageBox.Show("Files weren't found.")
            Application.Exit()
        End Try

    End Sub

    ' exit everything
    Private Sub btnExitFirstRun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExitFirstRun.Click
        Me.Close()
        Application.Exit()
    End Sub

    ' file selected, enable the button
    Private Sub lstFiles_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstFiles.SelectedIndexChanged
        btnUseSelectedFile.Enabled = (lstFiles.SelectedIndex > -1)
    End Sub

    ' send the name of the selected file to the parent form and exit
    Private Sub btnUseSelectedFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUseSelectedFile.Click
        If lstFiles.SelectedIndex > -1 Then
            frmMain.CurrentFileName = BaseDir + DefaultDir + "\" + DefaultDataFileName
            Me.Close()
        Else
            btnUseSelectedFile.Enabled = False
        End If

    End Sub

End Class