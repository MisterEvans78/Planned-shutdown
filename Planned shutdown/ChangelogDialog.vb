Imports System.Net

Public Class ChangelogDialog

    Async Function ChangelogForm() As Task
        Try
            Dim ChangelogFullList As New WebClient
            Dim ChangelogList_Full As String = Await ChangelogFullList.DownloadStringTaskAsync(System.Configuration.ConfigurationManager.AppSettings("fullChangelogURL"))
            RichTextBox2.Text = ChangelogList_Full
        Catch ex As Exception
            RichTextBox2.Text = "Error"
        End Try
    End Function

    Private Sub ChangelogDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Theme(Me)
    End Sub

    Private Async Sub ChangelogDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Await ChangelogForm()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class