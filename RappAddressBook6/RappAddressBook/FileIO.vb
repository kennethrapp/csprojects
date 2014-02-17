Imports System.IO

Public Class FileIO
    Dim inputFile As StreamReader
    Dim outputFile As StreamWriter
    Dim inDialog As System.Windows.Forms.OpenFileDialog
    Dim outDialog As System.Windows.Forms.SaveFileDialog
    Dim fileName As String


    Public Sub New(ByRef fn As String)
        filename = fn


    End Sub

    ' return whether the file exists or not
    Public Function FileExists(ByVal file As String) As Boolean
        Return False
    End Function



End Class
