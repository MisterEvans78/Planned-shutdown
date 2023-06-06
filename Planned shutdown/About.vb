Public Class About

    Dim easteregg1 As Integer
    Dim easteregg2 As Integer

#Region "Traductions"
    Sub LanguageText()
        TranslateControl(Me, "about")
        TranslateControl(Label2, "title")
        TranslateControl(Label6, "dev_by")
        TranslateControl(Button1, "ok")
    End Sub
#End Region

    Private Sub About_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Theme(Me)
        LanguageText()

        If Label7.Text <> "42" Then
            Label7.Text = GetLangText("version") + " " + My.Application.Info.Version.ToString()
        End If

        If currentTheme = "dark" Or currentTheme = "dark_b" Then
            PictureBox2.Image = My.Resources.github_light
        ElseIf currentTheme = "system" Then
            If AppsUseLightTheme = 0 Then
                PictureBox2.Image = My.Resources.github_light
            End If
        End If

        easteregg1 = 0
        easteregg2 = 0
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Process.Start(System.Configuration.ConfigurationManager.AppSettings("githubURL"))
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        easteregg1 += 1
        If easteregg1 = 5 Then
            Label2.Text = "HELLO WORLD !"
        ElseIf easteregg1 = 50 Then
            Label2.Text = "HELLOOOOOOOOOOOOOOOOOOOOO !!!"
        ElseIf easteregg1 = 100 Then
            Label2.Text = "NEW COLOR UNLOCKED"
            Me.BackColor = Color.DarkRed
        End If
    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click
        easteregg2 += 1
        If easteregg2 = 42 Then
            Label7.Text = "42"
            Label6.Visible = False
            Label7.Font = New Font("Microsoft Sans Serif", 42, FontStyle.Bold)
        End If
    End Sub
End Class