Imports System.IO

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        isiListFile()
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        PictureBox2.BackgroundImage = Bitmap.FromFile(Application.StartupPath & "\gbr\" & ListBox1.SelectedItem.ToString)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Button1.Text = "On" Then
            Button1.Text = "Off"

            AxVLCPlugin21.playlist.add(TextBox1.Text)
            AxVLCPlugin21.playlist.play()
        Else
            Button1.Text = "On"
            AxVLCPlugin21.playlist.stop()

        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Clipboard.Clear()
        AxVLCPlugin21.video.takeSnapshot()
        Dim tgljam As String = Now
        Dim sFile = Dir(Application.StartupPath & "\*.bmp")
        Dim filebMp As String = ""
        Do Until sFile = ""
            filebMp = sFile
            sFile = Dir()
        Loop

        Dim Filename As String = Application.StartupPath & "\" & filebMp
        Dim NewFileName As String = Application.StartupPath & "\gbr\" & Format(Now, "yyyyMMddHHmmss") & ".bmp"

        My.Computer.FileSystem.CopyFile(Filename, NewFileName)
        My.Computer.FileSystem.DeleteFile(Filename)
        If Dir$(NewFileName) <> "" Then
            PictureBox1.BackgroundImage = Bitmap.FromFile(NewFileName)
        End If

        isiListFile()
    End Sub

    Private Sub isiListFile()
        ' make a reference to a directory
        Dim di As New IO.DirectoryInfo(Application.StartupPath & "\gbr")
        Dim diar1 As IO.FileInfo() = di.GetFiles()
        Dim dra As IO.FileInfo
        ListBox1.Items.Clear()
        'list the names of all files in the specified directory
        For Each dra In diar1
            ListBox1.Items.Add(dra)
        Next
    End Sub
End Class
