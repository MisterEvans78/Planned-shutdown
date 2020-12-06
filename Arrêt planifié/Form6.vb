Public Class Form6
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If ListBox1.SelectedItem = "Form1" Then
                Form1.Show()
            ElseIf ListBox1.SelectedItem = "Form2" Then
                Form2.Show()
            ElseIf ListBox1.SelectedItem = "Form3" Then
                Form3.Show()
            ElseIf ListBox1.SelectedItem = "Form4" Then
                Form4.Show()
            ElseIf ListBox1.SelectedItem = "Form5" Then
                Form5.Show()
            ElseIf ListBox1.SelectedItem = "Form6" Then
                Me.Show()
            ElseIf ListBox1.SelectedItem = "Form7" Then
                Form7.Show()
            ElseIf ListBox1.SelectedItem = "Form8" Then
                Form8.Show()
            ElseIf ListBox1.SelectedItem = "Form9" Then
                Form9.Show()
            ElseIf ListBox1.SelectedItem = "Form10" Then
                Form10.Show()
            End If
        Catch ex As Exception
            MsgBox("Impossible d'ouvrir la fenêtre", vbCritical)
        End Try
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        If ListBox1.SelectedItem = "Form1" Then
            Label1.Text = "Fenêtre principale"
        ElseIf ListBox1.SelectedItem = "Form2" Then
            Label1.Text = "Fenêtre pour choisir le temps"
        ElseIf ListBox1.SelectedItem = "Form3" Then
            Label1.Text = "Fenêtre Mise à jour"
        ElseIf ListBox1.SelectedItem = "Form4" Then
            Label1.Text = ""
        ElseIf ListBox1.SelectedItem = "Form5" Then
            Label1.Text = ""
        ElseIf ListBox1.SelectedItem = "Form6" Then
            Label1.Text = "La fenêtre actuel"
        ElseIf ListBox1.SelectedItem = "Form7" Then
            Label1.Text = "Interpréteur de commandes"
        ElseIf ListBox1.SelectedItem = "Form8" Then
            Label1.Text = ""
        ElseIf ListBox1.SelectedItem = "Form9" Then
            Label1.Text = "Test de téléchargement"
        ElseIf ListBox1.SelectedItem = "Form10" Then
            Label1.Text = "A propos"
        End If
    End Sub

    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class