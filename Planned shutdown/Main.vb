Imports System.Net
Imports System.IO

Public Class Main
    'Modifier également le numéro de version dans Informations de l'assembly !
    Public Version As String = "1.10.0"
    Public VersionType As String = "beta"
    Public theme_value As String
    Public auto_update As Boolean = False
    Public langue As String
    Public dev_mode As Boolean = False
    Public AppDataFolder As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\planned_shutdown\"
    Public LanguageFile As String = "lang.ini"
    Public ThemeFile As String = "theme.ini"
    Public UpdateFile As String = "update.ini"

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ShutdownTime.ShowDialog()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim CancelBox As New MsgBoxResult
            If langue = "1" Then
                CancelBox = MsgBox("Voulez-vous annuler l'arrêt planifié ?", vbYesNo + vbQuestion, "Arrêt planifié")
            Else
                CancelBox = MsgBox("Do you want to cancel the planned shutdown?", vbYesNo + vbQuestion)
            End If
            If CancelBox = vbYes Then
                Dim btn2 As New Process
                btn2.StartInfo.FileName = "cmd.exe"
                btn2.StartInfo.Arguments = "/c shutdown -a"
                btn2.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                btn2.Start()
            End If
        Catch ex As Exception
            MsgBox("An error occurred! The program is going to stop!", vbCritical)
            End
        End Try
    End Sub

    Sub ChkUpdt()
        'Verifie MAJ au démarrage
        Try
            Dim Updt As New WebClient
            Dim LastUpdt As String = Updt.DownloadString("https://dl.dropboxusercontent.com/s/hpdo6tff9oqghym/shutdown_app_last_version.ini?dl=1")
            If Version = LastUpdt Then

            ElseIf LastUpdt = "0" Then

            Else
                If langue = "1" Then
                    LinkLabel1.Text = "Mise à jour disponible"
                Else
                    LinkLabel1.Text = "Update available"
                End If

            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Theme()
        AutoUpdate()
        language()

        If VersionType = "stable" Then
            If auto_update = True Then
                ChkUpdt()
            End If
        End If

        DevMode()
    End Sub
    Sub AutoUpdate()
        Try
            Dim update_setting As String
            Dim updateopenfile As New OpenFileDialog
            updateopenfile.FileName = AppDataFolder & UpdateFile
            Dim update As New StreamReader(updateopenfile.FileName)
            update_setting = update.ReadLine
            update.Close()
            If update_setting = "true" Then
                auto_update = True
            End If
        Catch ex As Exception
            Dim updatesavefiledialog As New SaveFileDialog
            updatesavefiledialog.FileName = AppDataFolder & UpdateFile
            If Not Directory.Exists(AppDataFolder) Then
                Directory.CreateDirectory(AppDataFolder)
            End If
            Dim updatewriter As New StreamWriter(updatesavefiledialog.FileName)
            updatewriter.Write("false")
            updatewriter.Close()
        End Try
    End Sub

    Sub language()
        Try
            Dim langopenfile As New OpenFileDialog
            langopenfile.FileName = AppDataFolder & LanguageFile
            Dim lang As New StreamReader(langopenfile.FileName)
            langue = lang.ReadLine
            lang.Close()
            If langue = "1" Then
                Me.Text = "Arrêt planifié"
                Label1.Text = "Que voulez-vous faire ?"
                Button1.Text = "Planifier l'arrêt de l'ordinateur"
                Button2.Text = "Annuler l'arrêt de l'ordinateur"
                LinkLabel1.Text = "Vérifier mises à jours"
                Button3.Text = "Options"
                Button4.Text = "À propos"

            ElseIf langue = "2" Then
                Me.Text = "Planned shutdown"
                Label1.Text = "What do you want to do?"
                Button1.Text = "Plan the computer shutdown"
                Button2.Text = "Cancel the computer shutdown"
                LinkLabel1.Text = "Check updates"
                Button3.Text = "Options"
                Button4.Text = "About"
            ElseIf langue = "0" Then
                Options.Show()
                Me.Close()
            ElseIf langue = "" Then
                Options.Show()
                Me.Close()
            Else
                MsgBox("lang.ini : Incorrect value", vbCritical)
                End
            End If
        Catch ex As Exception
            Dim langsavefile As New SaveFileDialog
            langsavefile.FileName = AppDataFolder & LanguageFile
            If Not Directory.Exists(AppDataFolder) Then
                Directory.CreateDirectory(AppDataFolder)
            End If
            Dim langsave As New StreamWriter(langsavefile.FileName)
            langsave.Write("0")
            langsave.Close()
            Options.Show()
            Me.Close()
        End Try
    End Sub

    Sub Theme()
        Try
            Dim themeopenfile As New OpenFileDialog
            themeopenfile.FileName = AppDataFolder & ThemeFile
            Dim theme As New StreamReader(themeopenfile.FileName)
            theme_value = theme.ReadLine
            theme.Close()
            If theme_value = "light" Or theme_value = "dark" Or theme_value = "dark_b" Then
                'Ne rien faire
            Else
                Dim themesavefiledialog As New SaveFileDialog
                themesavefiledialog.FileName = AppDataFolder & ThemeFile
                Dim themewriter As New StreamWriter(themesavefiledialog.FileName)
                themewriter.Write("light")
                themewriter.Close()
                theme_value = "light"
            End If
        Catch ex As Exception
            Dim themesavefiledialog As New SaveFileDialog
            themesavefiledialog.FileName = AppDataFolder & ThemeFile
            If Not Directory.Exists(AppDataFolder) Then
                Directory.CreateDirectory(AppDataFolder)
            End If
            Dim themewriter As New StreamWriter(themesavefiledialog.FileName)
            themewriter.Write("light")
            themewriter.Close()
            theme_value = "light"
        End Try

        ThemeEngine(theme_value)

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
        End If
    End Sub

    Sub DevMode()
        Try
            Dim devmodeopenfile As New OpenFileDialog
            Dim devmodevalue As String

            devmodeopenfile.FileName = "DevMode.ini"
            Dim DM As New StreamReader(devmodeopenfile.FileName)
            devmodevalue = DM.ReadLine

            If devmodevalue = "1" Then
                dev_mode = True 'Active le mode developpeur
                Me.ContextMenuStrip = ContextMenuStrip1
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        'Verifie MAJ manuellement
        If VersionType = "stable" Then
            If langue = "1" Then
                LinkLabel1.Text = "Veuillez patienter..."
                Try
                    Dim Updt As New WebClient
                    Dim LastUpdt As String = Updt.DownloadString("https://dl.dropboxusercontent.com/s/hpdo6tff9oqghym/shutdown_app_last_version.ini?dl=1")
                    If Version = LastUpdt Then
                        MsgBox("Le logiciel est à jour !", vbInformation, "Mise à jour")
                    ElseIf LastUpdt = "0" Then
                        MsgBox("Le service n'est actuellement pas disponible !", vbExclamation, "Mise à jour")
                    Else
                        Me.Show()
                        UpdateDialog.ShowDialog()
                    End If
                Catch ex As Exception
                    MsgBox("Impossible de se connecter au serveur", vbCritical, "Mise à jour")
                End Try
            Else
                LinkLabel1.Text = "Please wait..."
                Try
                    Dim Updt As New WebClient
                    Dim LastUpdt As String = Updt.DownloadString("https://dl.dropboxusercontent.com/s/hpdo6tff9oqghym/shutdown_app_last_version.ini?dl=1")
                    If Version = LastUpdt Then
                        MsgBox("The software is updated !", vbInformation, "Update Checker")
                    ElseIf LastUpdt = "0" Then
                        MsgBox("The service is currently not available!", vbExclamation, "Update Checker")
                    Else
                        Me.Show()
                        UpdateDialog.ShowDialog()
                    End If
                Catch ex As Exception
                    MsgBox("The software cannot connect to the server!", vbCritical, "Update Checker")
                End Try
            End If
            language() 'Pour reafficher le texte "Verifier les mises à jours"
        Else
            MsgBox("Only available in stable version.", vbExclamation)
        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Options.Show()
        Me.Close()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        About.ShowDialog()
    End Sub

    Private Sub OpenUpdateWindowToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenUpdateWindowToolStripMenuItem.Click
        UpdateDialog.ShowDialog()
    End Sub

    Private Sub VersionNumberToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VersionNumberToolStripMenuItem.Click
        MsgBox(Version)
    End Sub

    Private Sub ChangelogFormToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChangelogFormToolStripMenuItem.Click
        ChangelogDialog.ShowDialog()
    End Sub
End Class