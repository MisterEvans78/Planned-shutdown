Module AppSettings

    'Modifier également le numéro de version dans Informations de l'assembly !
    Public ReadOnly Version As String = "1.11.0"

    Public ReadOnly VersionType As String = "beta"

    Public ReadOnly AppDataFolder As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\planned_shutdown\"

    Public ReadOnly LanguageFile As String = "lang.ini"

    Public ReadOnly ThemeFile As String = "theme.ini"

    Public ReadOnly UpdateFile As String = "update.ini"

    Public theme_value As String

    Public auto_update As Boolean = False

    Public langue As String

    Public dev_mode As Boolean = False

End Module
