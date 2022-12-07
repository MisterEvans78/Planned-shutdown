Imports System.Net

Public Class Main

    Sub ChkUpdt()
        'Verifie MAJ au démarrage
        Try
            Dim Updt As New WebClient
            Dim LastUpdt As String = Updt.DownloadString("https://dl.dropboxusercontent.com/s/hpdo6tff9oqghym/shutdown_app_last_version.ini?dl=1")
            If Version <> LastUpdt And LastUpdt <> "0" Then
                TranslateControl(LinkLabel1, "update_available")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Sub LanguageText()
        TranslateControl(Me, "title")
        TranslateControl(Label1, "main_question")
        TranslateControl(Button1, "shutdown_btn")
        TranslateControl(Button2, "cancel_shutdown_btn")
        TranslateControl(LinkLabel1, "chkupdt_btn")
        TranslateControl(Button3, "options")
        TranslateControl(Button4, "about")
    End Sub

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AppStart()

        If dev_mode Then
            Me.ContextMenuStrip = ContextMenuStrip1
        End If

        Theme(Me)
        LanguageText()

        If VersionType = "stable" Then
            If auto_update = True Then
                ChkUpdt()
            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ShutdownTime.ShowDialog()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim CancelBox As MsgBoxResult = MsgBox(GetLangText("shutdown_question"), vbYesNo + vbQuestion)
            If CancelBox = vbYes Then
                Dim CancelShutdown As New Process
                With CancelShutdown
                    .StartInfo.FileName = "cmd.exe"
                    .StartInfo.Arguments = "/c shutdown -a"
                    .StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                    .Start()
                End With
            End If
        Catch ex As Exception
            MsgBox("An error occurred! The program is going to stop!", vbCritical)
            End
        End Try
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        'Verifie MAJ manuellement
        If VersionType = "stable" Then
            TranslateControl(LinkLabel1, "please_wait")
            Try
                Dim Updt As New WebClient
                Dim LastUpdt As String = Updt.DownloadString("https://dl.dropboxusercontent.com/s/hpdo6tff9oqghym/shutdown_app_last_version.ini?dl=1")
                If Version = LastUpdt Then
                    MsgBox(GetLangText("updated"), vbInformation, "Update Checker")
                ElseIf LastUpdt = "0" Then
                    MsgBox(GetLangText("service_not_available"), vbExclamation, "Update Checker")
                Else
                    Me.Show()
                    UpdateDialog.ShowDialog()
                End If
            Catch ex As Exception
                MsgBox(GetLangText("cannot_connect"), vbCritical, "Update Checker")
            End Try
            TranslateControl(LinkLabel1, "chkupdt_btn") 'Pour reafficher le texte "Verifier les mises à jours"
        Else
            MsgBox("Only available in stable version.", vbExclamation)
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Options.ShowDialog()
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

    Private Sub CheckWin10ThemeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CheckWin10ThemeToolStripMenuItem.Click
        CheckWin10Theme()
    End Sub
End Class