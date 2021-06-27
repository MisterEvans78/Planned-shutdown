Module AppSettings

    'Modifier également le numéro de version dans Informations de l'assembly !
    Public ReadOnly Version As String = "1.11.0"

    Public ReadOnly VersionType As String = "beta"

    Public ReadOnly AppDataFolder As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\planned_shutdown\"

    Public ReadOnly LanguageFile As String = "lang.ini"

    Public ReadOnly ThemeFile As String = "theme.ini"

    Public ReadOnly UpdateFile As String = "update.ini"

    Public ReadOnly default_language As String = "0"

    Public ReadOnly default_theme As String = "light"

    Public ReadOnly default_update As Boolean = False

    Public language As String

    Public theme_value As String

    Public auto_update As Boolean

    Public dev_mode As Boolean = False

    Public AppsUseLightTheme = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Themes\Personalize", "AppsUseLightTheme", Nothing)

End Module
