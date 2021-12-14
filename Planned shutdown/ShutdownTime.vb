Public Class ShutdownTime

    Sub CheckLanguage()
        If language = "1" Then
            Me.Text = "Arrêt planifié"
            GroupBox1.Text = "Saisir un délai"
            Button1.Text = "OK"
            Button2.Text = "Annuler"
            GroupBox2.Text = "Choisir une action"
            RadioButton1.Text = "Arrêter"
            RadioButton2.Text = "Redémarrer"
        End If
    End Sub

    Sub ShutdownCommand()
        Dim btn1 As New Process
        Dim Valeur As Integer = (NumericUpDown1.Value * 3600) + (NumericUpDown2.Value * 60) + (NumericUpDown3.Value)
        Dim Action As String = "-s"

        'Redémarrer ou arrêter
        If RadioButton2.Checked Then
            Action = "-r"
        End If

        'Redémarrage rapide (windows 8 et 10)
        If CheckBox1.Checked Then
            Action += " -hybrid"
        End If

        btn1.StartInfo.FileName = "cmd.exe"
        btn1.StartInfo.Arguments = "/c shutdown " & Action & " -t " & Valeur
        btn1.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
        btn1.Start()
        Me.Close()
    End Sub

    Private Sub ShutdownTime_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Theme(Me)
        CheckLanguage()
        AcceptButton = Button1
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If NumericUpDown1.Value = Nothing And NumericUpDown2.Value = Nothing And NumericUpDown3.Value = Nothing Then
            If language = 1 Then
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

    Private Sub RadioButton1_Click(sender As Object, e As EventArgs) Handles RadioButton1.Click
        RadioButton1.Checked = True
    End Sub

    Private Sub RadioButton2_Click(sender As Object, e As EventArgs) Handles RadioButton2.Click
        RadioButton2.Checked = True
    End Sub

    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged
        If NumericUpDown1.Value = 100 Then
            NumericUpDown1.Value = 0
        ElseIf NumericUpDown1.Value = -1 Then
            NumericUpDown1.Value = 99
        End If
    End Sub

    Private Sub NumericUpDown2_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown2.ValueChanged
        If NumericUpDown2.Value = 60 Then
            NumericUpDown2.Value = 0
        ElseIf NumericUpDown2.Value = -1 Then
            NumericUpDown2.Value = 59
        End If
    End Sub

    Private Sub NumericUpDown3_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown3.ValueChanged
        If NumericUpDown3.Value = 60 Then
            NumericUpDown3.Value = 0
        ElseIf NumericUpDown3.Value = -1 Then
            NumericUpDown3.Value = 59
        End If
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked Then
            CheckBox1.Visible = True
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked Then
            CheckBox1.Visible = False
            CheckBox1.Checked = False
        End If
    End Sub
End Class