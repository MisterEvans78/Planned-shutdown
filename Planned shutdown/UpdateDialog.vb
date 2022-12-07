Imports System.Net

Public Class UpdateDialog

    Sub LanguageText()
        TranslateControl(Me, "update_available")
        TranslateControl(Label1, "new_update_title")
        TranslateControl(Label2, "new_update_text")
        TranslateControl(Label5, "changelog")
        TranslateControl(Button1, "download")
        TranslateControl(Button2, "cancel")
    End Sub

    Sub Changelog()
        Try
            Dim Changelog As New WebClient
            Dim UpdtForm3 As New WebClient
            Dim LastUpdtForm3 As String = UpdtForm3.DownloadString("https://dl.dropboxusercontent.com/s/hpdo6tff9oqghym/shutdown_app_last_version.ini?dl=1")
            Label4.Text = LastUpdtForm3
            If language = "1" Then
                Dim UpdateChangelogFR As String = Changelog.DownloadString("https://dl.dropboxusercontent.com/s/i3anwikfs747cqf/shutdown_app_changelog_french.txt?dl=1")
                RichTextBox1.Text = UpdateChangelogFR
            Else
                Dim UpdateChangelog As String = Changelog.DownloadString("https://dl.dropboxusercontent.com/s/bym4lg35ord2thy/shutdown_app_changelog_english.txt?dl=1")
                RichTextBox1.Text = UpdateChangelog
            End If
        Catch ex As Exception
            Me.Close()
        End Try

    End Sub

    Sub DownloadButton()
        'Telechargement via navigateur
        Try
            Dim Download As New WebClient
            Dim DownloadLink As String = Download.DownloadString("https://dl.dropboxusercontent.com/s/nwp685bkejkwhhc/shutdown_app_url_download.ini?dl=1")
            Process.Start(DownloadLink)
            End
        Catch ex As Exception
            MsgBox("Une erreur s'est produite lors de l'ouverture du lien !", vbCritical, "Mise à jour")
        End Try

    End Sub

    Private Sub UpdateDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Theme(Me)
        LanguageText()
        Changelog()

        If dev_mode = True Then
            CheckBox1.Visible = True
            LinkLabel1.Visible = True
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If CheckBox1.Checked Then
            DownloadButton()
        Else
            Download.ShowDialog()
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        ChangelogDialog.ShowDialog()
    End Sub
End Class