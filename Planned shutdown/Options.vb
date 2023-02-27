Imports System.IO
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class Options

    Sub WriteConfig()
        Dim config As JObject

        config = New JObject(
            New JProperty("language", GetSelectedLanguage()),
            New JProperty("theme", GetSelectedTheme),
            New JProperty("update", CheckBox2.Checked)
        )

        File.WriteAllText(AppDataFolder & "config.json", JsonConvert.SerializeObject(config, Formatting.Indented))
    End Sub

    Function GetSelectedLanguage() As String
        Select Case ComboBox1.SelectedItem
            Case GetLangText("lang_french")
                Return "fr"
            Case GetLangText("lang_portuguese")
                Return "pt"
            Case Else
                Return "en"
        End Select
    End Function

    Function GetSelectedTheme() As String
        If RadioButton2.Checked Then
            Return "light"
        ElseIf RadioButton3.Checked Then
            If CheckBox1.Checked = True Then
                Return "dark_b"
            Else
                Return "dark"
            End If
        Else
            Return "system"
        End If
    End Function

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
            If ComboBox1.Text <> "" Then
                ' Enregistrement des réglages
                WriteConfig()

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