Imports System.IO

Public Class About
    Dim easteregg1 As Integer
    Dim easteregg2 As Integer
    Private Sub Form10_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ThemeEngine(MainMenu.theme_value)
        language()

        If Label7.Text <> "42" Then
            Label7.Text = "Version " + MainMenu.Version
        End If

        If MainMenu.theme_value = "dark" Or MainMenu.theme_value = "dark_b" Then
            PictureBox2.Image = My.Resources.github_light
        End If

        easteregg1 = 0
        easteregg2 = 0
    End Sub
    Sub language()
        If MainMenu.langue = "1" Then
            Me.Text = "À propos du logiciel"
            Label2.Text = "Arrêt planifié"
            Label6.Text = "Développé par MisterEvans78"
            Button1.Text = "OK"
        ElseIf MainMenu.langue = "2" Then
            Me.Text = "About"
            Label2.Text = "Planned shutdown"
            Label6.Text = "Developed by MisterEvans78"
            Button1.Text = "OK"
        Else
            MsgBox("lang.ini : Incorrect value", vbCritical)
            End
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Process.Start("https://github.com/MisterEvans78")
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Process.Start("https://twitter.com/MisterEvans78")
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