Imports System.IO
Imports System.Net
Imports System.Reflection
Imports System.Resources
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Module Procedures

    ''' <summary>
    ''' Obtenir les réglages. Ouvre le formulaire des options si aucun réglage trouvé (cas lors du premier démarrage de l'application).
    ''' </summary>
    Sub GetConfig()
        Dim config As JObject
        Dim openOptions As Boolean = False

        Try
            Dim json As String = File.ReadAllText(AppDataFolder & "config.json")
            config = JsonConvert.DeserializeObject(json)
        Catch
            openOptions = True

            If Not Directory.Exists(AppDataFolder) Then
                Directory.CreateDirectory(AppDataFolder)
            End If

            config = New JObject(
                New JProperty("language", default_language),
                New JProperty("theme", default_theme),
                New JProperty("update", default_update)
            )

            File.WriteAllText(AppDataFolder & "config.json", JsonConvert.SerializeObject(config, Formatting.Indented))
        End Try

        With config
            language = .GetValue("language")
            theme_value = .GetValue("theme")
            auto_update = .GetValue("update")
        End With

        If openOptions Then
            Options.Show()
            Main.Close()
        End If
    End Sub

    Sub LanguageResourceManager()
        LangRS = New ResourceManager("Planned_shutdown.lang_" & language, Assembly.GetExecutingAssembly())
    End Sub

    ''' <summary>
    ''' Procédures à exécuter au démarrage de l'application.
    ''' </summary>
    Sub AppStart()
        GetConfig()
        LanguageResourceManager()
    End Sub

    ''' <summary>
    ''' Appliquer le thème au formulaire.
    ''' </summary>
    ''' <param name="form">Le formulaire sur lequel on souhaite appliquer le thème.</param>
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
        MessageBox.Show(
            "Version: " & Version.ToString() & vbNewLine &
            "VersionType: " & VersionType & vbNewLine &
            "AppDataFolder: " & AppDataFolder & vbNewLine &
            "default_language: " & default_language & vbNewLine &
            "default_theme: " & default_theme & vbNewLine &
            "default_update: " & default_update & vbNewLine &
            "language: " & language & vbNewLine &
            "theme_value: " & theme_value & vbNewLine &
            "auto_update: " & auto_update & vbNewLine &
            "AppsUseLightTheme: " & AppsUseLightTheme
        )
    End Sub

    Sub CheckWin10Theme()
        Dim apps_theme = My.Computer.Registry.GetValue(
            "HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Themes\Personalize", "AppsUseLightTheme", Nothing)
        If apps_theme = "0" Then
            MessageBox.Show("Dark (" & apps_theme & ")")
        Else
            MessageBox.Show("Light (" & apps_theme & ")")
        End If
    End Sub

    ''' <summary>
    ''' Traduire le texte d'un contrôle.
    ''' </summary>
    ''' <param name="control">Contrôle à traduire.</param>
    ''' <param name="name">Nom du texte de traduction, si vide utilise la valeur de control.Text comme nom.</param>
    Sub TranslateControl(control As Control, Optional name As String = Nothing)
        If name Is Nothing Then
            name = control.Text
        End If

        control.Text = GetLangText(name)
    End Sub

    Function GetLangText(ByVal name As String) As String
        Try
            Dim text As String = LangRS.GetString(name)

            Return If(text Is Nothing, default_LangRS.GetString(name), text)
        Catch
            MessageBox.Show("lang_" & language & " resource is missing!", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End
        End Try
    End Function

    ''' <summary>
    ''' Vérifie si une mise à jour est disponible.
    ''' </summary>
    ''' <returns></returns>
    Function NewUpdateAvailable() As Boolean
        Try
            Dim Updt As New WebClient
            Dim LastUpdt As String = Updt.DownloadString("https://raw.githubusercontent.com/MisterEvans78/Planned-shutdown/main/txt/shutdown_app_last_version.txt")

            If LastUpdt <> "0" Then
                Dim LastVersion As New Version(LastUpdt)

                If LastVersion > Version And LastUpdt.ToString() <> "0" Then
                    Return True
                End If
            End If

            Return False
        Catch
            Return False
        End Try
    End Function
End Module
