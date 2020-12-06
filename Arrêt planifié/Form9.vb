Imports System.Net

Public Class Form9
    Dim WithEvents Download As WebClient
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Download = New WebClient
            Download.DownloadFileAsync(New Uri(TextBox1.Text), (SaveFileDialog1.FileName))
        Catch ex As Exception
            MsgBox("Error", vbCritical)
            End
        End Try

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Button1.Enabled = True
        End If
    End Sub

    Private Sub Download_DownloadProgressChanged(sender As Object, e As DownloadProgressChangedEventArgs) Handles Download.DownloadProgressChanged
        ProgressBar1.Value = e.ProgressPercentage
        Try
            If ProgressBar1.Value = 100 Then
                MsgBox("Téléchargement terminé")
            End If
        Catch ex As Exception
            MsgBox("Error", vbCritical)
        End Try
    End Sub
End Class