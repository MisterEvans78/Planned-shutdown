Imports System.IO
Public Class Options

    Sub AutoUpdate()
        Dim updatesavefiledialog As New SaveFileDialog
        updatesavefiledialog.FileName = AppDataFolder & UpdateFile
        Dim updatewriter As New StreamWriter(updatesavefiledialog.FileName)
        If CheckBox2.Checked = True Then
            updatewriter.Write("true")
            updatewriter.Close()
        Else
            updatewriter.Write("false")
            updatewriter.Close()
        End If
    End Sub

    Sub ThemeWriter()
        Dim themesavefiledialog As New SaveFileDialog
        themesavefiledialog.FileName = AppDataFolder & ThemeFile
        Dim themewriter As New StreamWriter(themesavefiledialog.FileName)
        If RadioButton1.Checked Then
            themewriter.Write("light")
            themewriter.Close()
            Application.Restart()
        ElseIf RadioButton2.Checked Then
            If CheckBox1.Checked = True Then
                themewriter.Write("dark_b")
                themewriter.Close()
                Application.Restart()
            Else
                themewriter.Write("dark")
                themewriter.Close()
                Application.Restart()
            End If
        End If
    End Sub

    Private Sub Options_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Theme(Me)

        If RadioButton2.Checked = True Then
            CheckBox1.Visible = True
        End If

        If langue = "1" Then
            ComboBox1.Text = "Français"
            Label2.Text = "Thème :"
            Label4.Text = "Langue :"
            RadioButton1.Text = "Clair"
            RadioButton2.Text = "Sombre"
            CheckBox1.Text = "Thème noir"
            CheckBox2.Text = "Vérifier mises à jours au démarrage"
        ElseIf langue = "2" Then
            ComboBox1.Text = "English"
        End If

        If theme_value = "dark" Then
            RadioButton1.Checked = False
            RadioButton2.Checked = True
        ElseIf theme_value = "dark_b" Then
            RadioButton1.Checked = False
            RadioButton2.Checked = True
            CheckBox1.Checked = True
        Else
            RadioButton1.Checked = True
            RadioButton2.Checked = False
        End If

        If auto_update = True Then
            CheckBox2.Checked = True
        Else
            CheckBox2.Checked = False
        End If

        AcceptButton = Button1
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim langsavefiledialog As New SaveFileDialog
            langsavefiledialog.FileName = AppDataFolder & LanguageFile
            Dim langwriter As New StreamWriter(langsavefiledialog.FileName)
            If ComboBox1.Text = "Français" Then
                langwriter.Write("1")
                langwriter.Close()
                AutoUpdate()
                ThemeWriter()
            ElseIf ComboBox1.Text = "English" Then
                langwriter.Write("2")
                langwriter.Close()
                AutoUpdate()
                ThemeWriter()
            ElseIf ComboBox1.Text = "" Then
                MsgBox("Please choose a language", vbExclamation, "Select language")
                langwriter.Close()
            End If
        Catch ex As Exception
            MsgBox("An error occurred! The program is going to stop!", vbCritical)
            End
        End Try
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked Then
            CheckBox1.Visible = True
        Else
            CheckBox1.Visible = False
            CheckBox1.Checked = False
        End If
    End Sub
End Class