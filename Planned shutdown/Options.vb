Imports System.IO

Public Class Options

    Sub ThemeWriter()
        Dim theme_savedialog As New SaveFileDialog
        theme_savedialog.FileName = AppDataFolder & ThemeFile
        Dim theme_writer As New StreamWriter(theme_savedialog.FileName)
        If RadioButton1.Checked Then
            theme_writer.Write("system")
        ElseIf RadioButton2.Checked Then
            theme_writer.Write("light")
        ElseIf RadioButton3.Checked Then
            If CheckBox1.Checked = True Then
                theme_writer.Write("dark_b")
            Else
                theme_writer.Write("dark")
            End If
        End If
        theme_writer.Close()
    End Sub

    Sub UpdateWriter()
        Dim update_savedialog As New SaveFileDialog
        update_savedialog.FileName = AppDataFolder & UpdateFile
        Dim update_writer As New StreamWriter(update_savedialog.FileName)
        If CheckBox2.Checked = True Then
            update_writer.Write("true")
        Else
            update_writer.Write("false")
        End If
        update_writer.Close()
    End Sub

    Private Sub Options_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Theme(Me)

        If RadioButton3.Checked = True Then
            CheckBox1.Visible = True
        End If

        'Check language value
        If language = "1" Then
            ComboBox1.Text = "Français"
            Label2.Text = "Thème :"
            Label4.Text = "Langue :"
            RadioButton1.Text = "Système"
            RadioButton2.Text = "Clair"
            RadioButton3.Text = "Sombre"
            CheckBox1.Text = "Thème noir"
            CheckBox2.Text = "Vérifier mises à jours au démarrage"
        ElseIf language = "2" Then
            ComboBox1.Text = "English"
        End If

        'Check theme value
        If theme_value = "dark" Then
            RadioButton1.Checked = False
            RadioButton2.Checked = False
            RadioButton3.Checked = True
        ElseIf theme_value = "dark_b" Then
            RadioButton1.Checked = False
            RadioButton2.Checked = False
            RadioButton3.Checked = True
            CheckBox1.Checked = True
        ElseIf theme_value = "system" Then
            RadioButton1.Checked = True
            RadioButton2.Checked = False
            RadioButton3.Checked = False
        Else
            RadioButton1.Checked = False
            RadioButton2.Checked = True
            RadioButton3.Checked = False
        End If

        'Check update value
        If auto_update = True Then
            CheckBox2.Checked = True
        Else
            CheckBox2.Checked = False
        End If

        AcceptButton = Button1
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim language_savedialog As New SaveFileDialog
            language_savedialog.FileName = AppDataFolder & LanguageFile
            Dim language_writer As New StreamWriter(language_savedialog.FileName)
            If ComboBox1.Text = "Français" Then
                language_writer.Write("1")
            ElseIf ComboBox1.Text = "English" Then
                language_writer.Write("2")
            ElseIf ComboBox1.Text = "" Then
                MsgBox("Please choose a language", vbExclamation, "Select language")
            End If
            language_writer.Close()

            ThemeWriter()
            UpdateWriter()

            Application.Restart()
        Catch ex As Exception
            MsgBox("An error occurred! The program is going to stop!", vbCritical)
            End
        End Try
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        If RadioButton3.Checked Then
            CheckBox1.Visible = True
        Else
            CheckBox1.Visible = False
            CheckBox1.Checked = False
        End If
    End Sub
End Class