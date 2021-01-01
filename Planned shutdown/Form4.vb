Imports System.IO
Public Class Form4

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim langsavefiledialog As New SaveFileDialog
        Dim AppDataFolder As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\planned_shutdown\"
        langsavefiledialog.FileName = AppDataFolder & "lang.ini"
        Dim langwriter As New StreamWriter(langsavefiledialog.FileName)
        If ComboBox1.Text = "Français" Then
            Try
                langwriter.Write("1")
                langwriter.Close()
                Theme()
            Catch ex As Exception
                MsgBox("An error occurred! The program is going to stop!", vbCritical)
                End
            End Try

        ElseIf ComboBox1.Text = "English" Then
            Try
                langwriter.Write("2")
                langwriter.Close()
                Theme()
            Catch ex As Exception
                MsgBox("An error occurred! The program is going to stop!", vbCritical, "Planned shutdown")
                End
            End Try

        ElseIf ComboBox1.Text = "" Then
            MsgBox("Please choose a language", vbExclamation, "Select language")
            langwriter.Close()
        End If
    End Sub

    Sub Theme()
        Dim themesavefiledialog As New SaveFileDialog
        Dim AppDataFolder As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\planned_shutdown\"
        themesavefiledialog.FileName = AppDataFolder & "theme.ini"
        Dim themewriter As New StreamWriter(themesavefiledialog.FileName)
        If RadioButton1.Checked Then
            Try
                themewriter.Write("light")
                themewriter.Close()
                Application.Restart()
            Catch ex As Exception
                MsgBox("An error occurred! The program is going to stop!", vbCritical, "Planned shutdown")
                End
            End Try
        ElseIf RadioButton2.Checked Then
            Try
                If CheckBox1.Checked = True Then
                    themewriter.Write("dark_b")
                    themewriter.Close()
                    Application.Restart()
                Else
                    themewriter.Write("dark")
                    themewriter.Close()
                    Application.Restart()
                End If

            Catch ex As Exception
                MsgBox("An error occurred! The program is going to stop!", vbCritical, "Planned shutdown")
                End
            End Try
        Else
        End If
    End Sub

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If RadioButton2.Checked = True Then
            CheckBox1.Visible = True
        End If

        ThemeEngine(Form1.theme_value)

        If Form1.langue = "1" Then
            ComboBox1.Text = "Français"
            Label2.Text = "Thème :"
            Label4.Text = "Langue :"
            RadioButton1.Text = "Clair"
            RadioButton2.Text = "Sombre"
            CheckBox1.Text = "Thème noir"
        ElseIf Form1.langue = "2" Then
            ComboBox1.Text = "English"
        Else

        End If

        If Form1.theme_value = "dark" Then
            RadioButton1.Checked = False
            RadioButton2.Checked = True
        ElseIf Form1.theme_value = "dark_b" Then
            RadioButton1.Checked = False
            RadioButton2.Checked = True
            CheckBox1.Checked = True
        Else
            RadioButton1.Checked = True
            RadioButton2.Checked = False
        End If

        AcceptButton = Button1
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked Then
            CheckBox1.Visible = True
        Else
            CheckBox1.Visible = False
            CheckBox1.Checked = False
        End If
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

            'Pour chaque libellé
            For Each texte As Label In Me.Controls.OfType(Of Label)
                texte.ForeColor = SystemColors.ControlLightLight
            Next

            'Pour chaque radio bouton
            For Each radiobouton As RadioButton In Me.Controls.OfType(Of RadioButton)
                radiobouton.ForeColor = SystemColors.ControlLightLight
            Next

            'Pour chaque checkbox
            For Each boitecheck As CheckBox In Me.Controls.OfType(Of CheckBox)
                boitecheck.ForeColor = SystemColors.ControlLightLight
            Next

            'Pour chaque combobox
            For Each combo_box As ComboBox In Me.Controls.OfType(Of ComboBox)
                combo_box.FlatStyle = FlatStyle.Flat
                combo_box.BackColor = Color.FromArgb(50, 50, 50)
                combo_box.ForeColor = SystemColors.ControlLightLight
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

            'Pour chaque libellé
            For Each texte As Label In Me.Controls.OfType(Of Label)
                texte.ForeColor = SystemColors.ControlLightLight
            Next

            'Pour chaque radio bouton
            For Each radiobouton As RadioButton In Me.Controls.OfType(Of RadioButton)
                radiobouton.ForeColor = SystemColors.ControlLightLight
            Next

            'Pour chaque checkbox
            For Each boitecheck As CheckBox In Me.Controls.OfType(Of CheckBox)
                boitecheck.ForeColor = SystemColors.ControlLightLight
            Next

            'Pour chaque combobox
            For Each combo_box As ComboBox In Me.Controls.OfType(Of ComboBox)
                combo_box.FlatStyle = FlatStyle.Flat
                combo_box.BackColor = SystemColors.ControlText
                combo_box.ForeColor = SystemColors.ControlLightLight
            Next

        Else
            'Ne rien faire
        End If
    End Sub
End Class