Public Class ShutdownTime

    Sub LanguageText()
        TranslateControl(Me, "title")
        TranslateControl(GroupBox1, "input_time")
        TranslateControl(Button1, "ok")
        TranslateControl(Button2, "cancel")
        TranslateControl(GroupBox2, "choose_action")
        TranslateControl(RadioButton1, "shutdown")
        TranslateControl(RadioButton2, "reboot")
    End Sub

    Sub ShutdownCommand()
        Dim ShutdownProcess As New Process
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

        With ShutdownProcess
            .StartInfo.FileName = "cmd.exe"
            .StartInfo.Arguments = "/c shutdown " & Action & " -t " & Valeur
            .StartInfo.WindowStyle = ProcessWindowStyle.Hidden
            .Start()
        End With

        Me.Close()
    End Sub

    Private Sub ShutdownTime_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Theme(Me)
        LanguageText()
        AcceptButton = Button1
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If NumericUpDown1.Value = Nothing And NumericUpDown2.Value = Nothing And NumericUpDown3.Value = Nothing Then
            MsgBox(GetLangText("enter_time"), vbExclamation, GetLangText("title"))
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