Imports System.ComponentModel
Imports System.Net

Public Class Download

    Dim WithEvents DownloadClient As WebClient

    Private Async Sub Download_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                DownloadClient = New WebClient
                Dim DLink As String = Await DownloadClient.DownloadStringTaskAsync(System.Configuration.ConfigurationManager.AppSettings("lastVersionDownloadURL"))
                Await DownloadClient.DownloadFileTaskAsync(New Uri(DLink), SaveFileDialog1.FileName)
            Else
                Me.Close()
            End If
        Catch ex As Exception
            MessageBox.Show("Une erreur s'est produite lors du téléchargement", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End
        End Try
    End Sub

    Private Sub DownloadClient_DownloadProgressChanged(sender As Object, e As DownloadProgressChangedEventArgs) Handles DownloadClient.DownloadProgressChanged
        ProgressBar1.Value = e.ProgressPercentage
    End Sub

    Private Sub DownloadClient_DownloadFileCompleted(sender As Object, e As AsyncCompletedEventArgs) Handles DownloadClient.DownloadFileCompleted
        Process.Start(SaveFileDialog1.FileName)
        End
    End Sub
End Class