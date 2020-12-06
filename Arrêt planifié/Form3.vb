Imports System.Net
Imports System.IO

Public Class Form3

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        language()
        ThemeEngine(Form1.theme_value)
        Changelog()
        DevMode()
    End Sub
    Sub language()
        If Form1.langue = "1" Then
            Me.Text = "Mise à jour disponible"
            Label1.Text = "Nouvelle mise à jour disponible !"
            Label2.Text = "Une nouvelle version du logiciel est disponible"
            Label5.Text = "Notes de version"
            Button1.Text = "Télécharger"
            Button2.Text = "Annuler"
        ElseIf Form1.langue = "2" Then
            Me.Text = "Update available"
            Label1.Text = "New update available!"
            Label2.Text = "A new update of the software is available"
            Label5.Text = "Changelog"
            Button1.Text = "Download"
            Button2.Text = "Cancel"
        End If
    End Sub
    Sub ThemeEngine(ByVal themecode As String)
        'Mode sombre
        If themecode = "dark" Then
            Me.BackColor = Color.FromArgb(50, 50, 50)

            'Pour chaque bouton
            For Each bouton As Button In Me.Controls.OfType(Of Button)
                bouton.FlatStyle = FlatStyle.Flat
                bouton.BackColor = Color.FromArgb(50, 50, 50)
                bouton.ForeColor = SystemColors.ControlLightLight
            Next

            'Pour chaque libellé
            For Each texte As Label In Me.Controls.OfType(Of Label)
                texte.ForeColor = SystemColors.ControlLightLight
            Next

            'Pour chaque lien
            For Each lien As LinkLabel In Me.Controls.OfType(Of LinkLabel)
                lien.LinkColor = SystemColors.ControlLightLight
            Next

            'Pour chaque zone de texte
            For Each zonetexteriche As RichTextBox In Me.Controls.OfType(Of RichTextBox)
                zonetexteriche.BackColor = Color.FromArgb(50, 50, 50)
                zonetexteriche.ForeColor = SystemColors.ControlLightLight
            Next

            'Pour chaque checkbox
            For Each boitecheck As CheckBox In Me.Controls.OfType(Of CheckBox)
                boitecheck.ForeColor = SystemColors.ControlLightLight
            Next

            'Mode noir
        ElseIf themecode = "dark_b" Then
            Me.BackColor = SystemColors.ControlText

            'Pour chaque bouton
            For Each bouton As Button In Me.Controls.OfType(Of Button)
                bouton.FlatStyle = FlatStyle.Flat
                bouton.BackColor = SystemColors.ControlText
                bouton.ForeColor = SystemColors.ControlLightLight
            Next

            'Pour chaque libellé
            For Each texte As Label In Me.Controls.OfType(Of Label)
                texte.ForeColor = SystemColors.ControlLightLight
            Next

            'Pour chaque lien
            For Each lien As LinkLabel In Me.Controls.OfType(Of LinkLabel)
                lien.LinkColor = SystemColors.ControlLightLight
            Next

            'Pour chaque zone de texte
            For Each zonetexteriche As RichTextBox In Me.Controls.OfType(Of RichTextBox)
                zonetexteriche.BackColor = SystemColors.ControlText
                zonetexteriche.ForeColor = SystemColors.ControlLightLight
            Next

            'Pour chaque checkbox
            For Each boitecheck As CheckBox In Me.Controls.OfType(Of CheckBox)
                boitecheck.ForeColor = SystemColors.ControlLightLight
            Next

        Else
            'Ne rien faire
        End If
    End Sub
    Sub Changelog()
        Try
            Dim Changelog As New WebClient
            Dim UpdtForm3 As New WebClient
            Dim LastUpdtForm3 As String = UpdtForm3.DownloadString("https://dl.dropboxusercontent.com/s/hpdo6tff9oqghym/shutdown_app_last_version.ini?dl=0")
            Label4.Text = LastUpdtForm3
            If Form1.langue = "1" Then
                Dim UpdateChangelogFR As String = Changelog.DownloadString("https://dl.dropboxusercontent.com/s/i3anwikfs747cqf/shutdown_app_changelog_french.txt?dl=0")
                RichTextBox1.Text = UpdateChangelogFR
            Else
                Dim UpdateChangelog As String = Changelog.DownloadString("https://dl.dropboxusercontent.com/s/bym4lg35ord2thy/shutdown_app_changelog_english.txt?dl=0")
                RichTextBox1.Text = UpdateChangelog
            End If
        Catch ex As Exception
            Me.Close()
        End Try

    End Sub
    Sub DevMode()
        Try
            Dim devmodeopenfile As New OpenFileDialog
            Dim devmodelabel As New Label
            devmodeopenfile.FileName = "DevMode.ini"
            Dim DM As New StreamReader(devmodeopenfile.FileName)
            devmodelabel.Text = DM.ReadLine
            If devmodelabel.Text = "1" Then
                CheckBox1.Visible = True
                LinkLabel1.Visible = True
            Else

            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub DownloadButton()
        'Telechargement via navigateur
        Try
            Dim Download As New WebClient
            Dim DownloadLink As String = Download.DownloadString("https://dl.dropboxusercontent.com/s/nwp685bkejkwhhc/shutdown_app_url_download.ini?dl=0")
            Process.Start(DownloadLink)
            End
        Catch ex As Exception
            MsgBox("Une erreur s'est produite lors de l'ouverture du lien !", vbCritical, "Mise à jour")
        End Try

    End Sub
    Sub Download_Button()
        Form8.ShowDialog()
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
        Form5.Show()
    End Sub
End Class