<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainMenu
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainMenu))
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DevModeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.OpenUpdateWindowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VersionNumberToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.ChangelogFormToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 25)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(266, 29)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "shutdown_button"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(12, 60)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(266, 29)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "cancel_button"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "question"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.Location = New System.Drawing.Point(170, 101)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(108, 13)
        Me.LinkLabel1.TabIndex = 4
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "chkupdate_button"
        Me.LinkLabel1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DevModeToolStripMenuItem, Me.ToolStripSeparator1, Me.OpenUpdateWindowToolStripMenuItem, Me.VersionNumberToolStripMenuItem, Me.ChangelogFormToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(190, 120)
        '
        'DevModeToolStripMenuItem
        '
        Me.DevModeToolStripMenuItem.Enabled = False
        Me.DevModeToolStripMenuItem.Name = "DevModeToolStripMenuItem"
        Me.DevModeToolStripMenuItem.Size = New System.Drawing.Size(189, 22)
        Me.DevModeToolStripMenuItem.Text = "DevMode"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(186, 6)
        '
        'OpenUpdateWindowToolStripMenuItem
        '
        Me.OpenUpdateWindowToolStripMenuItem.Name = "OpenUpdateWindowToolStripMenuItem"
        Me.OpenUpdateWindowToolStripMenuItem.Size = New System.Drawing.Size(189, 22)
        Me.OpenUpdateWindowToolStripMenuItem.Text = "Open update form"
        '
        'VersionNumberToolStripMenuItem
        '
        Me.VersionNumberToolStripMenuItem.Name = "VersionNumberToolStripMenuItem"
        Me.VersionNumberToolStripMenuItem.Size = New System.Drawing.Size(189, 22)
        Me.VersionNumberToolStripMenuItem.Text = "Show version number"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(12, 96)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 6
        Me.Button3.Text = "options_btn"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(93, 96)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 23)
        Me.Button4.TabIndex = 8
        Me.Button4.Text = "aboutpage_btn"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'ChangelogFormToolStripMenuItem
        '
        Me.ChangelogFormToolStripMenuItem.Name = "ChangelogFormToolStripMenuItem"
        Me.ChangelogFormToolStripMenuItem.Size = New System.Drawing.Size(189, 22)
        Me.ChangelogFormToolStripMenuItem.Text = "Changelog form"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(290, 128)
        Me.Controls.Add(Me.Button4)
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
        Me.Text = "Planned shutdown"
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
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents ChangelogFormToolStripMenuItem As ToolStripMenuItem
End Class
