Imports System.IO

Module Procedures

    Sub CheckLanguageFile()
        Try
            Dim langopenfile As New OpenFileDialog
            langopenfile.FileName = AppDataFolder & LanguageFile
            Dim lang As New StreamReader(langopenfile.FileName)
            langue = lang.ReadLine
            lang.Close()
        Catch ex As Exception
            Dim langsavefile As New SaveFileDialog
            langsavefile.FileName = AppDataFolder & LanguageFile
            If Not Directory.Exists(AppDataFolder) Then
                Directory.CreateDirectory(AppDataFolder)
            End If
            Dim langsave As New StreamWriter(langsavefile.FileName)
            langsave.Write("0")
            langsave.Close()
            Options.Show()
            Main.Close()
        End Try
    End Sub

    Sub CheckThemeFile()
        Try
            Dim themeopenfile As New OpenFileDialog
            themeopenfile.FileName = AppDataFolder & ThemeFile
            Dim theme As New StreamReader(themeopenfile.FileName)
            theme_value = theme.ReadLine
            theme.Close()
            If theme_value = "light" Or theme_value = "dark" Or theme_value = "dark_b" Then
                'Ne rien faire
            Else
                Dim themesavefiledialog As New SaveFileDialog
                themesavefiledialog.FileName = AppDataFolder & ThemeFile
                Dim themewriter As New StreamWriter(themesavefiledialog.FileName)
                themewriter.Write("light")
                themewriter.Close()
                theme_value = "light"
            End If
        Catch ex As Exception
            Dim themesavefiledialog As New SaveFileDialog
            themesavefiledialog.FileName = AppDataFolder & ThemeFile
            If Not Directory.Exists(AppDataFolder) Then
                Directory.CreateDirectory(AppDataFolder)
            End If
            Dim themewriter As New StreamWriter(themesavefiledialog.FileName)
            themewriter.Write("light")
            themewriter.Close()
            theme_value = "light"
        End Try
    End Sub

    Sub Theme(ByVal form As Form)
        'Mode sombre
        If theme_value = "dark" Then
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
                'Pour chaque boite de texte dans une group box
                For Each boitetexte As TextBox In groupe.Controls.OfType(Of TextBox)
                    boitetexte.BorderStyle = BorderStyle.FixedSingle
                    boitetexte.BackColor = Color.FromArgb(50, 50, 50)
                    boitetexte.ForeColor = SystemColors.ControlLightLight
                Next
            Next

            'Mode noir
        ElseIf theme_value = "dark_b" Then
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
                'Pour chaque boite de texte dans une group box
                For Each boitetexte As TextBox In groupe.Controls.OfType(Of TextBox)
                    boitetexte.BorderStyle = BorderStyle.FixedSingle
                    boitetexte.BackColor = SystemColors.ControlText
                    boitetexte.ForeColor = SystemColors.ControlLightLight
                Next
            Next
        End If
    End Sub

    Sub AutoUpdate()
        Try
            Dim update_setting As String
            Dim updateopenfile As New OpenFileDialog
            updateopenfile.FileName = AppDataFolder & UpdateFile
            Dim update As New StreamReader(updateopenfile.FileName)
            update_setting = update.ReadLine
            update.Close()
            If update_setting = "true" Then
                auto_update = True
            End If
        Catch ex As Exception
            Dim updatesavefiledialog As New SaveFileDialog
            updatesavefiledialog.FileName = AppDataFolder & UpdateFile
            If Not Directory.Exists(AppDataFolder) Then
                Directory.CreateDirectory(AppDataFolder)
            End If
            Dim updatewriter As New StreamWriter(updatesavefiledialog.FileName)
            updatewriter.Write("false")
            updatewriter.Close()
        End Try
    End Sub

    Sub DevMode()
        Try
            Dim devmodeopenfile As New OpenFileDialog
            Dim devmodevalue As String

            devmodeopenfile.FileName = "DevMode.ini"
            Dim DM As New StreamReader(devmodeopenfile.FileName)
            devmodevalue = DM.ReadLine

            If devmodevalue = "1" Then
                dev_mode = True 'Active le mode developpeur
                Main.ContextMenuStrip = Main.ContextMenuStrip1
            End If

        Catch ex As Exception

        End Try
    End Sub

    Sub ShowAppSettings()
        MsgBox(
            "Version: " & Version & vbNewLine &
            "VersionType: " & VersionType & vbNewLine &
            "AppDataFolder: " & AppDataFolder & vbNewLine &
            "LanguageFile: " & LanguageFile & vbNewLine &
            "ThemeFile: " & ThemeFile & vbNewLine &
            "UpdateFile: " & UpdateFile & vbNewLine &
            "theme_value: " & theme_value & vbNewLine &
            "auto_update: " & auto_update & vbNewLine &
            "language: " & langue & vbNewLine &
            "dev_mode: " & dev_mode
        )
    End Sub
End Module
