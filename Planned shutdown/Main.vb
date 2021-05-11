Imports System.Net
Imports System.IO

Public Class Main

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckThemeFile()
        Theme(Me)
        AutoUpdate()
        language()

        If VersionType = "stable" Then
            If auto_update = True Then
                ChkUpdt()
            End If
        End If

        DevMode()
    End Sub

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

    Private Sub ChangelogFormToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChangelogFormToolStripMenuItem.Click
        ChangelogDialog.ShowDialog()
    End Sub

    Private Sub ShowAppInfosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShowAppInfosToolStripMenuItem.Click
        ShowAppSettings()
    End Sub
End Class