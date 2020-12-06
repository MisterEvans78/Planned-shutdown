<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DevModeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.OpenUpdateWindowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VersionNumberToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ThèmeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AfficherLaValeurDuThèmeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ThèmeClairToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ThèmeSombreToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ThèmeSombre2ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LangueToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AfficherLaValeurDeLaLangueToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.RienToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FrançaisToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EnglishToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WindowsFormsSelectionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CommandPrompyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TestTéléchargementToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.ReloadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 25)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(266, 29)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(12, 60)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(266, 29)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Label1"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.Location = New System.Drawing.Point(170, 101)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(108, 13)
        Me.LinkLabel1.TabIndex = 4
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "LinkLabel1"
        Me.LinkLabel1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DevModeToolStripMenuItem, Me.ToolStripSeparator1, Me.OpenUpdateWindowToolStripMenuItem, Me.VersionNumberToolStripMenuItem, Me.ThèmeToolStripMenuItem, Me.LangueToolStripMenuItem, Me.WindowsFormsSelectionToolStripMenuItem, Me.CommandPrompyToolStripMenuItem, Me.TestTéléchargementToolStripMenuItem, Me.ReloadToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(222, 230)
        '
        'DevModeToolStripMenuItem
        '
        Me.DevModeToolStripMenuItem.Enabled = False
        Me.DevModeToolStripMenuItem.Name = "DevModeToolStripMenuItem"
        Me.DevModeToolStripMenuItem.Size = New System.Drawing.Size(221, 22)
        Me.DevModeToolStripMenuItem.Text = "DevMode"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(218, 6)
        '
        'OpenUpdateWindowToolStripMenuItem
        '
        Me.OpenUpdateWindowToolStripMenuItem.Name = "OpenUpdateWindowToolStripMenuItem"
        Me.OpenUpdateWindowToolStripMenuItem.Size = New System.Drawing.Size(221, 22)
        Me.OpenUpdateWindowToolStripMenuItem.Text = "Ouvrir fenêtre MAJ"
        '
        'VersionNumberToolStripMenuItem
        '
        Me.VersionNumberToolStripMenuItem.Name = "VersionNumberToolStripMenuItem"
        Me.VersionNumberToolStripMenuItem.Size = New System.Drawing.Size(221, 22)
        Me.VersionNumberToolStripMenuItem.Text = "Afficher numéro version"
        '
        'ThèmeToolStripMenuItem
        '
        Me.ThèmeToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AfficherLaValeurDuThèmeToolStripMenuItem, Me.ToolStripSeparator2, Me.ThèmeClairToolStripMenuItem, Me.ThèmeSombreToolStripMenuItem1, Me.ThèmeSombre2ToolStripMenuItem})
        Me.ThèmeToolStripMenuItem.Name = "ThèmeToolStripMenuItem"
        Me.ThèmeToolStripMenuItem.Size = New System.Drawing.Size(221, 22)
        Me.ThèmeToolStripMenuItem.Text = "Thème"
        '
        'AfficherLaValeurDuThèmeToolStripMenuItem
        '
        Me.AfficherLaValeurDuThèmeToolStripMenuItem.Name = "AfficherLaValeurDuThèmeToolStripMenuItem"
        Me.AfficherLaValeurDuThèmeToolStripMenuItem.Size = New System.Drawing.Size(217, 22)
        Me.AfficherLaValeurDuThèmeToolStripMenuItem.Text = "Afficher la valeur du thème"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(214, 6)
        '
        'ThèmeClairToolStripMenuItem
        '
        Me.ThèmeClairToolStripMenuItem.Name = "ThèmeClairToolStripMenuItem"
        Me.ThèmeClairToolStripMenuItem.Size = New System.Drawing.Size(217, 22)
        Me.ThèmeClairToolStripMenuItem.Text = "Thème clair (light)"
        '
        'ThèmeSombreToolStripMenuItem1
        '
        Me.ThèmeSombreToolStripMenuItem1.Name = "ThèmeSombreToolStripMenuItem1"
        Me.ThèmeSombreToolStripMenuItem1.Size = New System.Drawing.Size(217, 22)
        Me.ThèmeSombreToolStripMenuItem1.Text = "Thème sombre (dark)"
        '
        'ThèmeSombre2ToolStripMenuItem
        '
        Me.ThèmeSombre2ToolStripMenuItem.Name = "ThèmeSombre2ToolStripMenuItem"
        Me.ThèmeSombre2ToolStripMenuItem.Size = New System.Drawing.Size(217, 22)
        Me.ThèmeSombre2ToolStripMenuItem.Text = "Thème sombre 2 (dark_b)"
        '
        'LangueToolStripMenuItem
        '
        Me.LangueToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AfficherLaValeurDeLaLangueToolStripMenuItem, Me.ToolStripSeparator3, Me.RienToolStripMenuItem, Me.FrançaisToolStripMenuItem, Me.EnglishToolStripMenuItem})
        Me.LangueToolStripMenuItem.Name = "LangueToolStripMenuItem"
        Me.LangueToolStripMenuItem.Size = New System.Drawing.Size(221, 22)
        Me.LangueToolStripMenuItem.Text = "Langue"
        '
        'AfficherLaValeurDeLaLangueToolStripMenuItem
        '
        Me.AfficherLaValeurDeLaLangueToolStripMenuItem.Name = "AfficherLaValeurDeLaLangueToolStripMenuItem"
        Me.AfficherLaValeurDeLaLangueToolStripMenuItem.Size = New System.Drawing.Size(230, 22)
        Me.AfficherLaValeurDeLaLangueToolStripMenuItem.Text = "Afficher la valeur de la langue"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(227, 6)
        '
        'RienToolStripMenuItem
        '
        Me.RienToolStripMenuItem.Name = "RienToolStripMenuItem"
        Me.RienToolStripMenuItem.Size = New System.Drawing.Size(230, 22)
        Me.RienToolStripMenuItem.Text = "Rien (0)"
        '
        'FrançaisToolStripMenuItem
        '
        Me.FrançaisToolStripMenuItem.Name = "FrançaisToolStripMenuItem"
        Me.FrançaisToolStripMenuItem.Size = New System.Drawing.Size(230, 22)
        Me.FrançaisToolStripMenuItem.Text = "Français (1)"
        '
        'EnglishToolStripMenuItem
        '
        Me.EnglishToolStripMenuItem.Name = "EnglishToolStripMenuItem"
        Me.EnglishToolStripMenuItem.Size = New System.Drawing.Size(230, 22)
        Me.EnglishToolStripMenuItem.Text = "English (2)"
        '
        'WindowsFormsSelectionToolStripMenuItem
        '
        Me.WindowsFormsSelectionToolStripMenuItem.Name = "WindowsFormsSelectionToolStripMenuItem"
        Me.WindowsFormsSelectionToolStripMenuItem.Size = New System.Drawing.Size(221, 22)
        Me.WindowsFormsSelectionToolStripMenuItem.Text = "Sélecteur de fenêtres"
        '
        'CommandPrompyToolStripMenuItem
        '
        Me.CommandPrompyToolStripMenuItem.Name = "CommandPrompyToolStripMenuItem"
        Me.CommandPrompyToolStripMenuItem.Size = New System.Drawing.Size(221, 22)
        Me.CommandPrompyToolStripMenuItem.Text = "Interpréteur de commandes"
        '
        'TestTéléchargementToolStripMenuItem
        '
        Me.TestTéléchargementToolStripMenuItem.Name = "TestTéléchargementToolStripMenuItem"
        Me.TestTéléchargementToolStripMenuItem.Size = New System.Drawing.Size(221, 22)
        Me.TestTéléchargementToolStripMenuItem.Text = "Test téléchargement"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(12, 96)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 6
        Me.Button3.Text = "Button3"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(216, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(13, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "0"
        Me.Label4.Visible = False
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(93, 96)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 23)
        Me.Button4.TabIndex = 8
        Me.Button4.Text = "Button4"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'ReloadToolStripMenuItem
        '
        Me.ReloadToolStripMenuItem.Name = "ReloadToolStripMenuItem"
        Me.ReloadToolStripMenuItem.Size = New System.Drawing.Size(221, 22)
        Me.ReloadToolStripMenuItem.Text = "Reload"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(290, 128)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Arrêt planifié"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents DevModeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents OpenUpdateWindowToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents VersionNumberToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents WindowsFormsSelectionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CommandPrompyToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TestTéléchargementToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Button3 As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Button4 As Button
    Friend WithEvents ThèmeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AfficherLaValeurDuThèmeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ThèmeClairToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ThèmeSombreToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ThèmeSombre2ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LangueToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RienToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FrançaisToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EnglishToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AfficherLaValeurDeLaLangueToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents ReloadToolStripMenuItem As ToolStripMenuItem
End Class
