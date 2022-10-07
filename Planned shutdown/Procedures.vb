Imports System.IO
Imports System.Reflection
Imports System.Resources

Module Procedures

    Sub CheckLanguageFile()
        Try
            Dim language_opendialog As New OpenFileDialog
            language_opendialog.FileName = AppDataFolder & LanguageFile
            Dim language_reader As New StreamReader(language_opendialog.FileName)
            language = language_reader.ReadLine
            language_reader.Close()
        Catch
            Dim language_savedialog As New SaveFileDialog
            language_savedialog.FileName = AppDataFolder & LanguageFile
            If Not Directory.Exists(AppDataFolder) Then
                Directory.CreateDirectory(AppDataFolder)
            End If
            Dim language_writer As New StreamWriter(language_savedialog.FileName)
            language_writer.Write(default_language)
            language_writer.Close()
            language = default_language

            Options.Show()
            Main.Close()
        End Try
    End Sub

    Sub CheckThemeFile()
        Try
            Dim theme_opendialog As New OpenFileDialog
            theme_opendialog.FileName = AppDataFolder & ThemeFile
            Dim theme_reader As New StreamReader(theme_opendialog.FileName)
            theme_value = theme_reader.ReadLine
            theme_reader.Close()
            If theme_value <> "light" And theme_value <> "dark" And theme_value <> "dark_b" And theme_value <> "system" Then
                Dim theme_savedialog As New SaveFileDialog
                theme_savedialog.FileName = AppDataFolder & ThemeFile
                Dim theme_writer As New StreamWriter(theme_savedialog.FileName)
                theme_writer.Write(default_theme)
                theme_writer.Close()
                theme_value = default_theme
            End If
        Catch
            Dim theme_savedialog As New SaveFileDialog
            theme_savedialog.FileName = AppDataFolder & ThemeFile
            If Not Directory.Exists(AppDataFolder) Then
                Directory.CreateDirectory(AppDataFolder)
            End If
            Dim theme_writer As New StreamWriter(theme_savedialog.FileName)
            theme_writer.Write(default_theme)
            theme_writer.Close()
            theme_value = default_theme
        End Try
    End Sub

    Sub AutoUpdate()
        Try
            Dim update_value As String
            Dim update_opendialog As New OpenFileDialog
            update_opendialog.FileName = AppDataFolder & UpdateFile
            Dim update_reader As New StreamReader(update_opendialog.FileName)
            update_value = update_reader.ReadLine
            update_reader.Close()
            If update_value = "true" Then
                auto_update = True
            Else
                auto_update = False
            End If
        Catch
            Dim update_savedialog As New SaveFileDialog
            update_savedialog.FileName = AppDataFolder & UpdateFile
            If Not Directory.Exists(AppDataFolder) Then
                Directory.CreateDirectory(AppDataFolder)
            End If
            Dim update_writer As New StreamWriter(update_savedialog.FileName)
            If default_update = True Then
                update_writer.Write("true")
            Else
                update_writer.Write("false")
            End If
            update_writer.Close()
            auto_update = default_update
        End Try
    End Sub

    Sub DevMode()
        Try
            Dim devmode_value As String
            Dim devmode_opendialog As New OpenFileDialog

            devmode_opendialog.FileName = "DevMode.ini"
            Dim devmode_reader As New StreamReader(devmode_opendialog.FileName)
            devmode_value = devmode_reader.ReadLine

            If devmode_value = "1" Then
                dev_mode = True 'Active le mode developpeur
                Main.ContextMenuStrip = Main.ContextMenuStrip1
            End If
        Catch

        End Try
    End Sub

    Sub LanguageResourceManager()
        LangRS = New ResourceManager("Planned_shutdown.lang_" + language, Assembly.GetExecutingAssembly())
    End Sub

    Sub Theme(ByVal form As Form)
        Dim theme_selected As String

        If theme_value = "system" Then
            If AppsUseLightTheme = "0" Then
                theme_selected = "dark"
            Else
                theme_selected = "light"
            End If
        Else
            theme_selected = theme_value
        End If

        'Mode sombre
        If theme_selected = "dark" Then
            form.BackColor = Color.FromArgb(50, 50, 50)

            'Pour chaque bouton
            For Each bouton As Button In form.Controls.OfType(Of Button)
                bouton.FlatStyle = FlatStyle.Flat
                bouton.BackColor = Color.FromArgb(50, 50, 50)
                bouton.ForeColor = SystemColors.ControlLightLight
            Next

            'Pour chaque libellé
            For Each texte As Label In form.Controls.OfType(Of Label)
                texte.ForeColor = SystemColors.ControlLightLight
            Next

            'Pour chaque lien
            For Each lien As LinkLabel In form.Controls.OfType(Of LinkLabel)
                lien.LinkColor = SystemColors.ControlLightLight
            Next

            'Pour chaque radio bouton
            For Each radiobouton As RadioButton In form.Controls.OfType(Of RadioButton)
                radiobouton.ForeColor = SystemColors.ControlLightLight
            Next

            'Pour chaque checkbox
            For Each boitecheck As CheckBox In form.Controls.OfType(Of CheckBox)
                boitecheck.ForeColor = SystemColors.ControlLightLight
            Next

            'Pour chaque combobox
            For Each combo_box As ComboBox In form.Controls.OfType(Of ComboBox)
                combo_box.FlatStyle = FlatStyle.Flat
                combo_box.BackColor = Color.FromArgb(50, 50, 50)
                combo_box.ForeColor = SystemColors.ControlLightLight
            Next

            'Pour chaque zone de texte
            For Each zonetexteriche As RichTextBox In form.Controls.OfType(Of RichTextBox)
                zonetexteriche.BackColor = Color.FromArgb(50, 50, 50)
                zonetexteriche.ForeColor = SystemColors.ControlLightLight
            Next

            'Pour chaque group box
            For Each groupe As GroupBox In form.Controls.OfType(Of GroupBox)
                groupe.ForeColor = SystemColors.ControlLightLight
                'Pour chaque boite de nombre dans une group box
                For Each boitenombre As NumericUpDown In groupe.Controls.OfType(Of NumericUpDown)
                    boitenombre.BorderStyle = BorderStyle.FixedSingle
                    boitenombre.BackColor = Color.FromArgb(50, 50, 50)
                    boitenombre.ForeColor = SystemColors.ControlLightLight
                Next
            Next

            'Mode noir
        ElseIf theme_selected = "dark_b" Then
            form.BackColor = SystemColors.ControlText

            'Pour chaque bouton
            For Each bouton As Button In form.Controls.OfType(Of Button)
                bouton.FlatStyle = FlatStyle.Flat
                bouton.BackColor = SystemColors.ControlText
                bouton.ForeColor = SystemColors.ControlLightLight
            Next

            'Pour chaque libellé
            For Each texte As Label In form.Controls.OfType(Of Label)
                texte.ForeColor = SystemColors.ControlLightLight
            Next

            'Pour chaque lien
            For Each lien As LinkLabel In form.Controls.OfType(Of LinkLabel)
                lien.LinkColor = SystemColors.ControlLightLight
            Next

            'Pour chaque radio bouton
            For Each radiobouton As RadioButton In form.Controls.OfType(Of RadioButton)
                radiobouton.ForeColor = SystemColors.ControlLightLight
            Next

            'Pour chaque checkbox
            For Each boitecheck As CheckBox In form.Controls.OfType(Of CheckBox)
                boitecheck.ForeColor = SystemColors.ControlLightLight
            Next

            'Pour chaque combobox
            For Each combo_box As ComboBox In form.Controls.OfType(Of ComboBox)
                combo_box.FlatStyle = FlatStyle.Flat
                combo_box.BackColor = SystemColors.ControlText
                combo_box.ForeColor = SystemColors.ControlLightLight
            Next

            'Pour chaque zone de texte
            For Each zonetexteriche As RichTextBox In form.Controls.OfType(Of RichTextBox)
                zonetexteriche.BackColor = SystemColors.ControlText
                zonetexteriche.ForeColor = SystemColors.ControlLightLight
            Next

            'Pour chaque group box
            For Each groupe As GroupBox In form.Controls.OfType(Of GroupBox)
                groupe.ForeColor = SystemColors.ControlLightLight
                'Pour chaque boite de nombre dans une group box
                For Each boitenombre As NumericUpDown In groupe.Controls.OfType(Of NumericUpDown)
                    boitenombre.BorderStyle = BorderStyle.FixedSingle
                    boitenombre.BackColor = SystemColors.ControlText
                    boitenombre.ForeColor = SystemColors.ControlLightLight
                Next
            Next
        End If
    End Sub

    Sub ShowAppSettings()
        MsgBox(
            "Version: " & Version & vbNewLine &
            "VersionType: " & VersionType & vbNewLine &
            "AppDataFolder: " & AppDataFolder & vbNewLine &
            "LanguageFile: " & LanguageFile & vbNewLine &
            "ThemeFile: " & ThemeFile & vbNewLine &
            "UpdateFile: " & UpdateFile & vbNewLine &
            "default_language: " & default_language & vbNewLine &
            "default_theme: " & default_theme & vbNewLine &
            "default_update: " & default_update & vbNewLine &
            "language: " & language & vbNewLine &
            "theme_value: " & theme_value & vbNewLine &
            "auto_update: " & auto_update & vbNewLine &
            "dev_mode: " & dev_mode & vbNewLine &
            "AppsUseLightTheme: " & AppsUseLightTheme
        )
    End Sub

    Sub CheckWin10Theme()
        Dim apps_theme = My.Computer.Registry.GetValue(
            "HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Themes\Personalize", "AppsUseLightTheme", Nothing)
        If apps_theme = "0" Then
            MsgBox("Dark (" & apps_theme & ")")
        Else
            MsgBox("Light (" & apps_theme & ")")
        End If
    End Sub

    Function GetLangText(ByVal name As String) As String
        Try
            Dim text As String = LangRS.GetString(name)

            Return If(text Is Nothing, default_LangRS.GetString(name), text)
        Catch
            MsgBox("lang_" + language + " resource is missing!", MsgBoxStyle.Critical)
            End
        End Try
    End Function
End Module
