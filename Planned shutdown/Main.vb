Imports System.Net

Public Class Main

#Region "Traductions"
    Sub LanguageText()
        TranslateControl(Me, "title")
        TranslateControl(Label1, "main_question")
        TranslateControl(Button1, "shutdown_btn")
        TranslateControl(Button2, "cancel_shutdown_btn")
        TranslateControl(LinkLabel1, "chkupdt_btn")
        TranslateControl(Button3, "options")
        TranslateControl(Button4, "about")
    End Sub
#End Region

    Async Function ChkUpdt() As Task
        'Verifie MAJ au démarrage
        Try
            If Await NewUpdateAvailable() Then
                TranslateControl(LinkLabel1, "update_available")
            End If
        Catch

        End Try
    End Function

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            AppStart()

            If VersionType = "dev" Then
                Me.ContextMenuStrip = ContextMenuStrip1
            End If

            Theme(Me)
            LanguageText()
        Catch ex As Exception
            MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End
        End Try
    End Sub

    Private Async Sub Main_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If autoUpdate = True Then
            Await ChkUpdt()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ShutdownTime.ShowDialog()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim CancelBox As DialogResult = MessageBox.Show(GetLangText("shutdown_question"), GetLangText("title"), MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If CancelBox = DialogResult.Yes Then
                ShutdownProcess.CancelShutdown()
            End If
        Catch ex As Exception
            MessageBox.Show("An error occurred! The program is going to stop!", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End
        End Try
    End Sub

    Private Async Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        'Verifie MAJ manuellement
        TranslateControl(LinkLabel1, "please_wait")
        If Await NewUpdateAvailable() Then
            UpdateDialog.ShowDialog()
        Else
            MessageBox.Show(GetLangText("updated"), GetLangText("update"), MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        TranslateControl(LinkLabel1, "chkupdt_btn") 'Pour reafficher le texte "Verifier les mises à jours"
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