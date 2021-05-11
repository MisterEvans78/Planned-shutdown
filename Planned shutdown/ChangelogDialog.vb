Imports System.Net

Public Class ChangelogDialog

    Private Sub ChangelogDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Theme(Me)
        ChangelogForm()
    End Sub

    Sub ChangelogForm()
        Try
            Dim ChangelogNewVer As New WebClient
            Dim ChangelogFullList As New WebClient
            'Dim ChangelogList As String = ChangelogNewVer.DownloadString("https://dl.dropboxusercontent.com/s/0qdumvoxc8f3kaq/shutdown_app_changelog.txt?dl=1")
            Dim ChangelogList_Full As String = ChangelogFullList.DownloadString("https://dl.dropboxusercontent.com/s/d1qi7kmrhylxs1k/shutdown_app_full_changelog.txt?dl=1")
            'RichTextBox1.Text = ChangelogList
            RichTextBox2.Text = ChangelogList_Full
        Catch ex As Exception
            RichTextBox1.Text = "Changelog for new version : Error"
            RichTextBox2.Text = "Full Changelog : Error"
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class