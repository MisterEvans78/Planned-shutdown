Module AppSettings

    'Modifier également le numéro de version dans Informations de l'assembly !
    Public ReadOnly Version As New Version("1.12.0")

#If DEBUG Then
    Public ReadOnly VersionType As String = "dev"
#Else
    Public ReadOnly VersionType As String = "stable"
#End If

    Public ReadOnly AppDataFolder As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\Planned shutdown\"

    Public ReadOnly default_language As String = "en"

    Public ReadOnly default_theme As String = "system"

    Public ReadOnly default_update As Boolean = False

    Public ReadOnly AppsUseLightTheme = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Themes\Personalize", "AppsUseLightTheme", Nothing)

    Public currentLanguage As String

    Public currentTheme As String

    Public autoUpdate As Boolean

End Module
