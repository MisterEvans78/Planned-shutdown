Imports System.IO

Public Class Form10
    Private Sub Form10_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        language()
        ThemeEngine(Form1.theme_value)
        If Label7.Text <> "42" Then
            Label7.Text = "Version " + Form1.Version
        End If

        If Form1.theme_value = "dark" Or Form1.theme_value = "dark_b" Then
            PictureBox2.Image = My.Resources.github_light
        End If

        Label3.Text = 0
        Label4.Text = 0
    End Sub
    Sub language()
        If Form1.langue = "1" Then
            Me.Text = "À propos du logiciel"
            Label2.Text = "Arrêt planifié"
            Label6.Text = "Développé par MisterEvans78"
            Button1.Text = "OK"
        ElseIf Form1.langue = "2" Then
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
        Else
            'Ne rien faire
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
        Label3.Text = Label3.Text + 1
        If Label3.Text = 5 Then
            Label2.Text = "HELLO WORLD !"
        ElseIf Label3.Text = 50 Then
            Label2.Text = "HELLOOOOOOOOOOOOOOOOOOOOO !!!"
        ElseIf Label3.Text = 100 Then
            Label2.Text = "NEW COLOR UNLOCKED"
            Me.BackColor = Color.DarkRed
        Else

        End If
    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click
        Label4.Text = Label4.Text + 1
        If Label4.Text = 42 Then
            Label7.Text = "42"
            Label6.Visible = False
            Label7.Font = New Font("Microsoft Sans Serif", 42, FontStyle.Bold)
        Else

        End If
    End Sub
End Class