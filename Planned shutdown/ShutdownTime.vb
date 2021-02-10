﻿Imports System.IO

Public Class ShutdownTime

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Then
            If Main.langue = 1 Then
                MsgBox("Veuillez entrer un temps !", vbExclamation, "Arrêt planifié")
            Else
                MsgBox("Please enter a time!", vbExclamation, "Planned shutdown")
            End If
        Else
            btn1cmd()
        End If
    End Sub

    Sub language()
        If Main.langue = "1" Then
            Me.Text = "Arrêt planifié"
            Label1.Text = "Veuillez entrer un temps :"
            Button1.Text = "OK"
            Button2.Text = "Annuler"
            RadioButton1.Text = "seconde(s)"
            RadioButton2.Text = "minute(s)"
            RadioButton3.Text = "heure(s)"
            Label2.Text = "Veuillez n'entrer que des chiffres !"
        ElseIf Main.langue = "2" Then
            Me.Text = "Planned shutdown"
            Label1.Text = "Please enter a time :"
            Button1.Text = "OK"
            Button2.Text = "Cancel"
            RadioButton1.Text = "second(s)"
            RadioButton2.Text = "minute(s)"
            RadioButton3.Text = "hour(s)"
            Label2.Text = "Please enter numbers only!"
        Else
            MsgBox("lang.ini : Incorrect value", vbCritical)
            End
        End If
    End Sub

    Sub btn1cmd()
        Dim btn1 As New Process
        Dim Valeur As String = TextBox1.Text
        If RadioButton1.Checked = True Then
            Valeur = TextBox1.Text
        ElseIf RadioButton2.Checked = True Then
            Valeur = TextBox1.Text * 60
        ElseIf RadioButton3.Checked = True Then
            Valeur = TextBox1.Text * 3600
        End If
        btn1.StartInfo.FileName = "cmd.exe"
        btn1.StartInfo.Arguments = "/c shutdown -s -t " & Valeur
        btn1.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
        btn1.Start()
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ThemeEngine(Main.theme_value)
        TextBox1.Text = ""
        Label2.Visible = False
        AcceptButton = Button1
        language()
        RadioButton1.Checked = True
        RadioButton2.Checked = False
        RadioButton3.Checked = False
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

            'Pour chaque boite de texte
            For Each boitetexte As TextBox In Me.Controls.OfType(Of TextBox)
                boitetexte.BorderStyle = BorderStyle.FixedSingle
                boitetexte.BackColor = Color.FromArgb(50, 50, 50)
                boitetexte.ForeColor = SystemColors.ControlLightLight
            Next

            'Pour chaque radio bouton
            For Each radiobouton As RadioButton In Me.Controls.OfType(Of RadioButton)
                radiobouton.ForeColor = SystemColors.ControlLightLight
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

            'Pour chaque boite de texte
            For Each boitetexte As TextBox In Me.Controls.OfType(Of TextBox)
                boitetexte.BorderStyle = BorderStyle.FixedSingle
                boitetexte.BackColor = SystemColors.ControlText
                boitetexte.ForeColor = SystemColors.ControlLightLight
            Next

            For Each radiobouton As RadioButton In Me.Controls.OfType(Of RadioButton)
                radiobouton.ForeColor = SystemColors.ControlLightLight
            Next
        End If

        Label2.ForeColor = Color.Red
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
            Label2.Show()
        Else
            Label2.Hide()
        End If
    End Sub
End Class