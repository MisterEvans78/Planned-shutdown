Imports System.Configuration

Module Configuration

#If DEBUG Then
    Public ReadOnly VersionType As String = "dev"
#Else
    Public ReadOnly VersionType As String = "stable"
#End If
    Public ReadOnly AppDataFolder As String = $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\{ConfigurationManager.AppSettings("folderName")}\"
    Public ReadOnly AppsUseLightTheme = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Themes\Personalize", "AppsUseLightTheme", Nothing)
    Public ReadOnly default_language = ConfigurationManager.AppSettings("defaultLanguage")
    Public ReadOnly default_theme = ConfigurationManager.AppSettings("defaultTheme")
    Public ReadOnly default_update = ConfigurationManager.AppSettings("defaultUpdate")

    Public currentLanguage As String
    Public currentTheme As String
    Public autoUpdate As Boolean

End Module
