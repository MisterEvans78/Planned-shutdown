Imports System.Net
Imports System.IO

Public Class Form1
    Public Version As String = "1.9.2"
    Public theme_value As String
    Public langue As String
    Public dev_mode As Boolean = False
    'Modifier également le numéro de version dans Informations de l'assembly !

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form2.ShowDialog()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            If langue = "1" Then
                btn2fr()
                'Fenetre annuler arrêt + DevMode
            ElseIf langue = "2" Then
                btn2en()
                'Fenetre annuler arrêt + DevMode
            End If
        Catch ex As Exception
            MsgBox("An error occurred! The program is going to stop!", vbCritical)
            End
        End Try
    End Sub

    Sub btn2fr()
        If dev_mode = True Then
            DevModeBtn2()
        Else
            Dim CancelBox As New MsgBoxResult
            CancelBox = MsgBox("Voulez-vous annuler l'arrêt planifié ?", vbYesNo + vbQuestion, "Arrêt planifié")
            If CancelBox = vbYes Then
                Dim btn2 As New Process
                btn2.StartInfo.FileName = "cmd.exe"
                btn2.StartInfo.Arguments = "/c shutdown -a"
                btn2.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                btn2.Start()
            ElseIf CancelBox = vbNo Then

            End If
        End If
    End Sub

    Sub btn2en()
        If dev_mode = True Then
            DevModeBtn2()
        Else
            Dim CancelBox As New MsgBoxResult
            CancelBox = MsgBox("Do you want to cancel the planned shutdown?", vbYesNo + vbQuestion)
            If CancelBox = vbYes Then
                Dim btn2 As New Process
                btn2.StartInfo.FileName = "cmd.exe"
                btn2.StartInfo.Arguments = "/c shutdown -a"
                btn2.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                btn2.Start()
            ElseIf CancelBox = vbNo Then

            End If
        End If
    End Sub

    Sub DevModeBtn2()
        Dim CancelBox As New MsgBoxResult
        CancelBox = MsgBox("Voulez-vous annuler l'arrêt planifié ? (DEVMODE)", vbYesNo + vbQuestion)
        If CancelBox = vbYes Then
            Dim btn2 As New Process
            btn2.StartInfo.FileName = "cmd.exe"
            btn2.StartInfo.Arguments = "/c shutdown -a & pause"
            btn2.Start()
        ElseIf CancelBox = vbNo Then

        End If
    End Sub

    Sub ChkUpdt()
        'Verifie MAJ au démarrage
        Try
            Dim Updt As New WebClient
            Dim LastUpdt As String = Updt.DownloadString("https://dl.dropboxusercontent.com/s/hpdo6tff9oqghym/shutdown_app_last_version.ini?dl=0")
            If Version = LastUpdt Then

            ElseIf LastUpdt = "0" Then

            Else
                LinkLabel1.Text = "Mise à jour disponible"
            End If
        Catch ex As Exception

        End Try

    End Sub

    Sub ChkUpdtButtonFrench()
        'Verifie MAJ manuellement
        Try
            Dim Updt As New WebClient
            Dim LastUpdt As String = Updt.DownloadString("https://dl.dropboxusercontent.com/s/hpdo6tff9oqghym/shutdown_app_last_version.ini?dl=0")
            If Version = LastUpdt Then
                MsgBox("Le logiciel est à jour !", vbInformation, "Mise à jour")
            ElseIf LastUpdt = "0" Then
                MsgBox("Le service n'est actuellement pas disponible !", vbExclamation, "Mise à jour")
            Else
                Me.Show()
                Form3.ShowDialog()
            End If
        Catch ex As Exception
            MsgBox("Impossible de se connecter au serveur", vbCritical, "Mise à jour")
        End Try
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        language()
        Theme()
        'ChkUpdt()
        DevMode()
    End Sub

    Sub language()
        Try
            Dim langopenfile As New OpenFileDialog
            Dim AppDataFolder As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\planned_shutdown\"
            langopenfile.FileName = AppDataFolder & "lang.ini"
            Dim lang As New StreamReader(langopenfile.FileName)
            langue = lang.ReadLine
            If langue = "1" Then
                Me.Text = "Arrêt planifié"
                Label1.Text = "Que voulez-vous faire ?"
                Button1.Text = "Planifier l'arrêt de l'ordinateur"
                Button2.Text = "Annuler l'arrêt de l'ordinateur"
                LinkLabel1.Text = "Vérifier mises à jours"
                Button3.Text = "Options"
                Button4.Text = "À propos"
                lang.Close()
            ElseIf langue = "2" Then
                Me.Text = "Planned shutdown"
                Label1.Text = "What do you want to do?"
                Button1.Text = "Plan the computer shutdown"
                Button2.Text = "Cancel the computer shutdown"
                LinkLabel1.Text = "Check updates"
                Button3.Text = "Options"
                Button4.Text = "About"
                lang.Close()
            ElseIf langue = "0" Then
                lang.Close()
                Form4.Show()
                Me.Close()
            ElseIf langue = "" Then
                lang.Close()
                Form4.Show()
                Me.Close()
            Else
                MsgBox("lang.ini : Incorrect value", vbCritical)
                End
            End If
        Catch ex As Exception
            Dim langsavefile As New SaveFileDialog
            Dim AppDataFolder As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\planned_shutdown\"
            langsavefile.FileName = AppDataFolder & "lang.ini"
            If Not Directory.Exists(AppDataFolder) Then
                Directory.CreateDirectory(AppDataFolder)
            End If
            Dim langsave As New StreamWriter(langsavefile.FileName)
            langsave.Write("0")
            langsave.Close()
            Form4.Show()
            Me.Close()
        End Try
    End Sub

    Sub Theme()
        Try
            Dim themeopenfile As New OpenFileDialog
            Dim AppDataFolder As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\planned_shutdown\"
            themeopenfile.FileName = AppDataFolder & "theme.ini"
            Dim theme As New StreamReader(themeopenfile.FileName)
            theme_value = theme.ReadLine
            theme.Close()
            If theme_value = "light" Or theme_value = "dark" Or theme_value = "dark_b" Then
                'Ne rien faire
            Else
                Dim themesavefiledialog As New SaveFileDialog
                themesavefiledialog.FileName = AppDataFolder & "theme.ini"
                Dim themewriter As New StreamWriter(themesavefiledialog.FileName)
                themewriter.Write("light")
                themewriter.Close()
                theme_value = "light"
            End If
        Catch ex As Exception
            Dim themesavefiledialog As New SaveFileDialog
            Dim AppDataFolder As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\planned_shutdown\"
            themesavefiledialog.FileName = AppDataFolder & "theme.ini"
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
        Else
            'Ne rien faire
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
        If langue = "1" Then
            ChkUpdtButtonFrench()
        ElseIf langue = "2" Then
            ChkUpdtButtonEnglish()
        End If
    End Sub

    Sub ChkUpdtButtonEnglish()
        'Verifie MAJ manuellement
        Try
            Dim Updt As New WebClient
            Dim LastUpdt As String = Updt.DownloadString("https://dl.dropboxusercontent.com/s/hpdo6tff9oqghym/shutdown_app_last_version.ini?dl=0")
            If Version = LastUpdt Then
                MsgBox("The software is updated !", vbInformation, "Update Checker")
            ElseIf LastUpdt = "0" Then
                MsgBox("The service is currently not available!", vbExclamation, "Update Checker")
            Else
                Me.Show()
                Form3.ShowDialog()
            End If
        Catch ex As Exception
            MsgBox("The software cannot connect to the server!", vbCritical, "Update Checker")
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Form4.Show()
        Me.Close()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Form7.ShowDialog()
    End Sub

    Private Sub OpenUpdateWindowToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenUpdateWindowToolStripMenuItem.Click
        Form3.ShowDialog()
    End Sub

    Private Sub VersionNumberToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VersionNumberToolStripMenuItem.Click
        MsgBox(Version)
    End Sub
End Class