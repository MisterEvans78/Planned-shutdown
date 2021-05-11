Imports System.Net
Imports System.IO

Public Class UpdateDialog

    Private Sub UpdateDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Theme(Me)
        language()
        Changelog()

        If dev_mode = True Then
            CheckBox1.Visible = True
            LinkLabel1.Visible = True
        End If
    End Sub
    Sub language()
        If langue = "1" Then
            Me.Text = "Mise à jour disponible"
            Label1.Text = "Nouvelle mise à jour disponible !"
            Label2.Text = "Une nouvelle version du logiciel est disponible"
            Label5.Text = "Notes de version"
            Button1.Text = "Télécharger"
            Button2.Text = "Annuler"
        ElseIf langue = "2" Then
            Me.Text = "Update available"
            Label1.Text = "New update available!"
            Label2.Text = "A new update of the software is available"
            Label5.Text = "Changelog"
            Button1.Text = "Download"
            Button2.Text = "Cancel"
        End If
    End Sub

    Sub Changelog()
        Try
            Dim Changelog As New WebClient
            Dim UpdtForm3 As New WebClient
            Dim LastUpdtForm3 As String = UpdtForm3.DownloadString("https://dl.dropboxusercontent.com/s/hpdo6tff9oqghym/shutdown_app_last_version.ini?dl=1")
            Label4.Text = LastUpdtForm3
            If langue = "1" Then
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

    Sub Download_Button()
        Download.ShowDialog()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If CheckBox1.Checked Then
            DownloadButton()
        Else
            Download_Button()
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        ChangelogDialog.ShowDialog()
    End Sub
End Class