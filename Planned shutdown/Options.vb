Imports System.IO
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class Options

    Sub WriteConfig()
        Dim config As JObject

        config = New JObject(
            New JProperty("language", GetLanguageIdByName(ComboBox1.SelectedItem)),
            New JProperty("theme", GetSelectedTheme()),
            New JProperty("update", CheckBox2.Checked)
        )

        File.WriteAllText(AppDataFolder & "config.json", JsonConvert.SerializeObject(config, Formatting.Indented))
    End Sub

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
        Theme(Me)

        If RadioButton3.Checked = True Then
            CheckBox1.Visible = True
        End If

        ' Ajout des langues dans la ComboBox
        With ComboBox1.Items
            .Clear()
            GetLanguages().ForEach(Function(l) .Add(l))
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

        Dim langName As String = GetLanguageName(currentLanguage)

        'Check language value
        If ComboBox1.Items.Contains(langName) Then
            ComboBox1.SelectedIndex = ComboBox1.Items.IndexOf(langName)
        End If

        'Check theme value
        Select Case currentTheme
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
        If autoUpdate = True Then
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