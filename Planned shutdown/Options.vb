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
        'Premier lancement de l'application
        If LangRS Is Nothing Then
            LangRS = default_LangRS
        End If

        Theme(Me)

        If RadioButton3.Checked = True Then
            CheckBox1.Visible = True
        End If

        ' Ajout des langues dans la ComboBox
        With ComboBox1.Items
            .Clear()
            .Add(GetLangText("lang_english"))
            .Add(GetLangText("lang_french"))
            .Add(GetLangText("lang_portuguese"))
        End With

#Region "Traductions"
        TranslateControl(Label2, "theme_text")
        TranslateControl(Label4, "language_text")
        TranslateControl(RadioButton1, "theme_system")
        TranslateControl(RadioButton2, "theme_light")
        TranslateControl(RadioButton3, "theme_dark")
        TranslateControl(CheckBox1, "theme_superdark")
        TranslateControl(CheckBox2, "update_chkbox")
        TranslateControl(Button1, "ok")
#End Region

        'Check language value
        Select Case language
            Case "fr"
                ComboBox1.Text = GetLangText("lang_french")
            Case "pt"
                ComboBox1.Text = GetLangText("lang_portuguese")
            Case Else
                ComboBox1.Text = GetLangText("lang_english")
        End Select

        'Check theme value
        Select Case theme_value
            Case "dark"
                RadioButton1.Checked = False
                RadioButton2.Checked = False
                RadioButton3.Checked = True
            Case "dark_b"
                RadioButton1.Checked = False
                RadioButton2.Checked = False
                RadioButton3.Checked = True
                CheckBox1.Checked = True
            Case "system"
                RadioButton1.Checked = True
                RadioButton2.Checked = False
                RadioButton3.Checked = False
            Case Else
                RadioButton1.Checked = False
                RadioButton2.Checked = True
                RadioButton3.Checked = False
        End Select

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

            If ComboBox1.Text <> "" Then
                Dim language_writer As New StreamWriter(language_savedialog.FileName)

                ' Enregistrement de la langue choisie
                Select Case ComboBox1.SelectedItem
                    Case GetLangText("lang_french")
                        language_writer.Write("fr")
                    Case GetLangText("lang_portuguese")
                        language_writer.Write("pt")
                    Case Else
                        language_writer.Write("en")
                End Select

                language_writer.Close()

                ThemeWriter()
                UpdateWriter()
                Application.Restart()
            Else
                MessageBox.Show("Please choose a language", "Select language", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Catch ex As Exception
            MessageBox.Show("An error occurred! The program is going to stop!", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
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