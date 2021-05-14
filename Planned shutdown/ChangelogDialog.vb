Imports System.Net

Public Class ChangelogDialog

    Sub ChangelogForm()
        Try
            Dim ChangelogFullList As New WebClient
            Dim ChangelogList_Full As String = ChangelogFullList.DownloadString("https://dl.dropboxusercontent.com/s/d1qi7kmrhylxs1k/shutdown_app_full_changelog.txt?dl=1")
            RichTextBox2.Text = ChangelogList_Full
        Catch ex As Exception
            RichTextBox2.Text = "Error"
        End Try
    End Sub

    Private Sub ChangelogDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Theme(Me)
        ChangelogForm()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class