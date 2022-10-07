Imports System.Globalization
Imports System.Net
Imports System.Reflection
Imports System.Resources
Imports System.Threading
Imports System.Windows

Public Class Main

    Sub ChkUpdt()
        'Verifie MAJ au démarrage
        Try
            Dim Updt As New WebClient
            Dim LastUpdt As String = Updt.DownloadString("https://dl.dropboxusercontent.com/s/hpdo6tff9oqghym/shutdown_app_last_version.ini?dl=1")
            If Version <> LastUpdt And LastUpdt <> "0" Then
                LinkLabel1.Text = GetLangText("update_available")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Sub LanguageText()
        Me.Text = GetLangText("title")
        Label1.Text = GetLangText("main_question")
        Button1.Text = GetLangText("shutdown_btn")
        Button2.Text = GetLangText("cancel_shutdown_btn")
        LinkLabel1.Text = GetLangText("chkupdt_btn")
        Button3.Text = GetLangText("options")
        Button4.Text = GetLangText("about")
    End Sub

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AutoUpdate()
        CheckThemeFile()
        CheckLanguageFile()
        LanguageResourceManager()
        DevMode()

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
            Dim CancelBox As New MsgBoxResult
            CancelBox = MsgBox(GetLangText("shutdown_question"), vbYesNo + vbQuestion)
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

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        'Verifie MAJ manuellement
        If VersionType = "stable" Then
            LinkLabel1.Text = GetLangText("please_wait")
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
            LinkLabel1.Text = GetLangText("chkupdt_btn") 'Pour reafficher le texte "Verifier les mises à jours"
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