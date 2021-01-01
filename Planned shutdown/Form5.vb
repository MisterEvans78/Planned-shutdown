Imports System.Net

Public Class Form5
    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ChangelogForm5()
    End Sub
    Sub ChangelogForm5()
        Try
            Dim ChangelogNewVer As New WebClient
            Dim ChangelogFullList As New WebClient
            Dim ChangelogList As String = ChangelogNewVer.DownloadString("https://dl.dropboxusercontent.com/s/0qdumvoxc8f3kaq/shutdown_app_changelog.txt?dl=0")
            Dim ChangelogList_Full As String = ChangelogFullList.DownloadString("https://dl.dropboxusercontent.com/s/d1qi7kmrhylxs1k/shutdown_app_full_changelog.txt?dl=0")
            RichTextBox1.Text = ChangelogList
            RichTextBox2.Text = ChangelogList_Full
        Catch ex As Exception
            RichTextBox1.Text = "Changelog for new version : Error"
            RichTextBox2.Text = "Full Changelog : Error"
        End Try
    End Sub
End Class