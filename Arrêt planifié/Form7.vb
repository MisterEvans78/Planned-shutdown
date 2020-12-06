Public Class Form7
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim cmd As New Process
        cmd.StartInfo.FileName = "cmd.exe"
        cmd.StartInfo.Arguments = "/c " & TextBox1.Text
        If CheckBox1.Checked Then
            cmd.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
            cmd.Start()
            Me.Close()
        Else
            cmd.Start()
            Me.Close()
        End If
    End Sub
End Class