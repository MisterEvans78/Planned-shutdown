Imports System.Net

Public Class UpdateDialog

#Region "Traductions"
    Sub LanguageText()
        TranslateControl(Me, "update_available")
        TranslateControl(Label1, "new_update_title")
        TranslateControl(Label2, "new_update_text")
        TranslateControl(Label5, "changelog")
        TranslateControl(Button1, "download")
        TranslateControl(Button2, "cancel")
    End Sub
#End Region

    Async Function LoadChangelog() As Task
        Try
            Dim Changelog As New WebClient
            Dim UpdtForm3 As New WebClient
            Dim LastUpdtForm3 As String = Await UpdtForm3.DownloadStringTaskAsync("https://raw.githubusercontent.com/MisterEvans78/Planned-shutdown/main/txt/shutdown_app_last_version.txt")
            Label4.Text = LastUpdtForm3
            If language = "1" Then
                Dim UpdateChangelogFR As String = Await Changelog.DownloadStringTaskAsync("https://raw.githubusercontent.com/MisterEvans78/Planned-shutdown/main/txt/shutdown_app_changelog_french.txt")
                RichTextBox1.Text = UpdateChangelogFR
            Else
                Dim UpdateChangelog As String = Await Changelog.DownloadStringTaskAsync("https://raw.githubusercontent.com/MisterEvans78/Planned-shutdown/main/txt/shutdown_app_changelog_english.txt")
                RichTextBox1.Text = UpdateChangelog
            End If
        Catch ex As Exception
            Me.Close()
        End Try

    End Function

    Async Function DownloadButton() As Task
        'Telechargement via navigateur
        Try
            Dim Download As New WebClient
            Dim DownloadLink As String = Await Download.DownloadStringTaskAsync("https://raw.githubusercontent.com/MisterEvans78/Planned-shutdown/main/txt/shutdown_app_url_download.txt")
            Process.Start(DownloadLink)
            End
        Catch ex As Exception
            MessageBox.Show("Une erreur s'est produite lors de l'ouverture du lien !", "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Function

    Private Sub UpdateDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Theme(Me)
        LanguageText()

        If VersionType = "dev" Then
            CheckBox1.Visible = True
            LinkLabel1.Visible = True
        End If
    End Sub

    Private Async Sub UpdateDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Await LoadChangelog()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Async Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If CheckBox1.Checked Then
            Await DownloadButton()
        Else
            Download.ShowDialog()
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        ChangelogDialog.ShowDialog()
    End Sub
End Class