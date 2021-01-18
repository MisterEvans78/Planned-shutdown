Imports System.Net

Public Class ChangelogDialog
    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ThemeEngine(MainMenu.theme_value)
        ChangelogForm5()
    End Sub
    Sub ChangelogForm5()
        Try
            Dim ChangelogNewVer As New WebClient
            Dim ChangelogFullList As New WebClient
            'Dim ChangelogList As String = ChangelogNewVer.DownloadString("https://dl.dropboxusercontent.com/s/0qdumvoxc8f3kaq/shutdown_app_changelog.txt?dl=1")
            Dim ChangelogList_Full As String = ChangelogFullList.DownloadString("https://dl.dropboxusercontent.com/s/d1qi7kmrhylxs1k/shutdown_app_full_changelog.txt?dl=1")
            'RichTextBox1.Text = ChangelogList
            RichTextBox2.Text = ChangelogList_Full
        Catch ex As Exception
            RichTextBox1.Text = "Changelog for new version : Error"
            RichTextBox2.Text = "Full Changelog : Error"
        End Try
    End Sub
    Sub ThemeEngine(ByVal themecode As String)
        'Mode sombre
        If themecode = "dark" Then
            Me.BackColor = Color.FromArgb(50, 50, 50)

            'Pour chaque bouton
            For Each bouton As Button In Me.Controls.OfType(Of Button)
                bouton.FlatStyle = FlatStyle.Flat
                bouton.BackColor = Color.FromArgb(50, 50, 50)
                bouton.ForeColor = SystemColors.ControlLightLight
            Next

            'Pour chaque zone de texte
            For Each zonetexteriche As RichTextBox In Me.Controls.OfType(Of RichTextBox)
                zonetexteriche.BackColor = Color.FromArgb(50, 50, 50)
                zonetexteriche.ForeColor = SystemColors.ControlLightLight
            Next

            'Mode noir
        ElseIf themecode = "dark_b" Then
            Me.BackColor = SystemColors.ControlText

            'Pour chaque bouton
            For Each bouton As Button In Me.Controls.OfType(Of Button)
                bouton.FlatStyle = FlatStyle.Flat
                bouton.BackColor = SystemColors.ControlText
                bouton.ForeColor = SystemColors.ControlLightLight
            Next

            'Pour chaque zone de texte
            For Each zonetexteriche As RichTextBox In Me.Controls.OfType(Of RichTextBox)
                zonetexteriche.BackColor = SystemColors.ControlText
                zonetexteriche.ForeColor = SystemColors.ControlLightLight
            Next
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class