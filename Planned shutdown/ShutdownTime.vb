Imports System.IO

Public Class ShutdownTime

    Sub language()
        If langue = "1" Then
            Me.Text = "Arrêt planifié"
            GroupBox1.Text = "Saisir un délai"
            Button1.Text = "OK"
            Button2.Text = "Annuler"
            RadioButton1.Text = "seconde(s)"
            RadioButton2.Text = "minute(s)"
            RadioButton3.Text = "heure(s)"
            Label2.Text = "Veuillez n'entrer que des chiffres !"
            GroupBox2.Text = "Choisir une action"
            RadioButton4.Text = "Arrêter"
            RadioButton5.Text = "Redémarrer"
        End If
    End Sub

    Sub ShutdownCommand()
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

    Private Sub ShutdownTime_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Theme(Me)
        Label2.Visible = False
        AcceptButton = Button1
        language()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Then
            If langue = 1 Then
                MsgBox("Veuillez entrer un temps !", vbExclamation, "Arrêt planifié")
            Else
                MsgBox("Please enter a time!", vbExclamation, "Planned shutdown")
            End If
        Else
            ShutdownCommand()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
            Label2.Show()
        Else
            Label2.Hide()
        End If
    End Sub

    Private Sub RadioButton4_Click(sender As Object, e As EventArgs) Handles RadioButton4.Click
        RadioButton4.Checked = True
    End Sub

    Private Sub RadioButton5_Click(sender As Object, e As EventArgs) Handles RadioButton5.Click
        RadioButton5.Checked = True
    End Sub

    Private Sub RadioButton1_Click(sender As Object, e As EventArgs) Handles RadioButton1.Click
        RadioButton1.Checked = True
    End Sub

    Private Sub RadioButton2_Click(sender As Object, e As EventArgs) Handles RadioButton2.Click
        RadioButton2.Checked = True
    End Sub

    Private Sub RadioButton3_Click(sender As Object, e As EventArgs) Handles RadioButton3.Click
        RadioButton3.Checked = True
    End Sub
End Class