Imports System.Net

Public Class Download

    Dim WithEvents Download As WebClient

    Private Sub Download_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Download = New WebClient
            Dim DLink As String = Download.DownloadString("https://raw.githubusercontent.com/MisterEvans78/Planned-shutdown/main/txt/shutdown_app_url_download.txt")
            If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                Download.DownloadFileAsync(New Uri(DLink), (SaveFileDialog1.FileName))
            Else
                Me.Close()
            End If
        Catch ex As Exception
            MessageBox.Show("Une erreur s'est produite lors du téléchargement", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End
        End Try
    End Sub

    Private Sub Download_DownloadProgressChanged(sender As Object, e As DownloadProgressChangedEventArgs) Handles Download.DownloadProgressChanged
        ProgressBar1.Value = e.ProgressPercentage
        If ProgressBar1.Value = 100 Then
            System.Threading.Thread.Sleep(500)
            Process.Start(SaveFileDialog1.FileName)
            End
        End If
    End Sub
End Class