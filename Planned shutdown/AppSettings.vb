Imports System.Reflection
Imports System.Resources

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

    Public ReadOnly default_LangRS As ResourceManager = New ResourceManager("Planned_shutdown.lang_" + default_language, Assembly.GetExecutingAssembly())

    Public ReadOnly AppsUseLightTheme = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Themes\Personalize", "AppsUseLightTheme", Nothing)

    Public language As String

    Public theme_value As String

    Public auto_update As Boolean

    Public LangRS As ResourceManager

End Module
