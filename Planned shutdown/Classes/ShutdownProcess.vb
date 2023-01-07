Public Class ShutdownProcess
    Public Enum ShutdownAction
        Shutdown
        Restart
        ShutdownWithFastBoot 'A partir de Windows 8
    End Enum

    Public Property Action As ShutdownAction
    Public Property Time As Integer

    Public Sub New(shutdownAction As ShutdownAction, shutdownTime As Integer)
        Action = shutdownAction
        Time = shutdownTime
    End Sub

    ''' <summary>
    ''' Exécuter la planification de l'arrêt selon les propriétés de l'objet ShutdownProcess.
    ''' </summary>
    Public Sub Run()
        Dim ParamString As String
        Select Case Action
            Case ShutdownAction.Restart
                ParamString = "-r"
            Case ShutdownAction.ShutdownWithFastBoot
                ParamString = "-s -hybrid"
            Case Else
                ParamString = "-s"
        End Select

        CmdProcess("shutdown " & ParamString & " -t " & Time)
    End Sub

    ''' <summary>
    ''' Demander l'annulation de l'arrêt planifié.
    ''' </summary>
    Public Shared Sub CancelShutdown()
        CmdProcess("shutdown -a")
    End Sub

    ''' <summary>
    ''' Exécuter une commande via cmd.exe.
    ''' </summary>
    ''' <param name="commandString">La commande a exécuter.</param>
    Private Shared Sub CmdProcess(commandString As String)
        Dim MyProcess As New Process
        With MyProcess
            .StartInfo.FileName = "cmd.exe"
            .StartInfo.Arguments = $"/c {commandString}"
            .StartInfo.WindowStyle = ProcessWindowStyle.Hidden
            .Start()
        End With
    End Sub
End Class
