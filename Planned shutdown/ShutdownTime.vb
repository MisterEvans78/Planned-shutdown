Imports System.IO

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
            GroupBox1.Text = "Entrez un temps"
            Button1.Text = "OK"
            Button2.Text = "Annuler"
            RadioButton1.Text = "seconde(s)"
            RadioButton2.Text = "minute(s)"
            RadioButton3.Text = "heure(s)"
            Label2.Text = "Veuillez n'entrer que des chiffres !"
            GroupBox2.Text = "Choisir une action"
            RadioButton4.Text = "Arrêter"
            RadioButton5.Text = "Redémarrer"
        ElseIf Main.langue = "2" Then
            Me.Text = "Planned shutdown"
            GroupBox1.Text = "Input time"
            Button1.Text = "OK"
            Button2.Text = "Cancel"
            RadioButton1.Text = "second(s)"
            RadioButton2.Text = "minute(s)"
            RadioButton3.Text = "hour(s)"
            Label2.Text = "Please enter numbers only!"
            GroupBox2.Text = "Choose action"
            RadioButton4.Text = "Shutdown"
            RadioButton5.Text = "Reboot"
        Else
            MsgBox("lang.ini : Incorrect value", vbCritical)
            End
        End If
    End Sub

    Sub btn1cmd()
        Dim btn1 As New Process
        Dim Valeur As String = TextBox1.Text
        Dim Action As String = "-s"

        'Unité de temps
        If RadioButton1.Checked = True Then
            Valeur = TextBox1.Text
        ElseIf RadioButton2.Checked = True Then
            Valeur = TextBox1.Text * 60
        ElseIf RadioButton3.Checked = True Then
            Valeur = TextBox1.Text * 3600
        End If

        'Redémarrer ou arrêter
        If RadioButton5.Checked Then
            Action = "-r"
        End If

        btn1.StartInfo.FileName = "cmd.exe"
        btn1.StartInfo.Arguments = "/c shutdown " & Action & " -t " & Valeur
        btn1.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
        btn1.Start()
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ThemeEngine(Main.theme_value)
        Label2.Visible = False
        AcceptButton = Button1
        language()
        RadioButton1.Checked = True
        RadioButton2.Checked = False
        RadioButton3.Checked = False
        RadioButton4.Checked = True
        RadioButton5.Checked = False
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

            'Pour chaque group box
            For Each groupe As GroupBox In Me.Controls.OfType(Of GroupBox)
                groupe.ForeColor = SystemColors.ControlLightLight

                'Pour chaque boite de texte dans une group box
                For Each boitetexte As TextBox In groupe.Controls.OfType(Of TextBox)
                    boitetexte.BorderStyle = BorderStyle.FixedSingle
                    boitetexte.BackColor = Color.FromArgb(50, 50, 50)
                    boitetexte.ForeColor = SystemColors.ControlLightLight
                Next
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

            'Pour chaque group box
            For Each groupe As GroupBox In Me.Controls.OfType(Of GroupBox)
                groupe.ForeColor = SystemColors.ControlLightLight

                'Pour chaque boite de texte dans une group box
                For Each boitetexte As TextBox In groupe.Controls.OfType(Of TextBox)
                    boitetexte.BorderStyle = BorderStyle.FixedSingle
                    boitetexte.BackColor = SystemColors.ControlText
                    boitetexte.ForeColor = SystemColors.ControlLightLight
                Next
            Next
        End If
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