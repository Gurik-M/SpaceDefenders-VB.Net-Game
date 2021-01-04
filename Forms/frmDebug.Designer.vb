<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmDebug
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.chkMouseConsole = New System.Windows.Forms.CheckBox()
        Me.chkFps = New System.Windows.Forms.CheckBox()
        Me.btnNewGame = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblScore = New System.Windows.Forms.Label()
        Me.tmrGame = New System.Windows.Forms.Timer(Me.components)
        Me.btnGameOver = New System.Windows.Forms.Button()
        Me.btnRestartLevel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'chkMouseConsole
        '
        Me.chkMouseConsole.AutoSize = True
        Me.chkMouseConsole.Location = New System.Drawing.Point(12, 12)
        Me.chkMouseConsole.Name = "chkMouseConsole"
        Me.chkMouseConsole.Size = New System.Drawing.Size(182, 17)
        Me.chkMouseConsole.TabIndex = 4
        Me.chkMouseConsole.Text = "Keyboard+Mouse to Output View"
        Me.chkMouseConsole.UseVisualStyleBackColor = True
        '
        'chkFps
        '
        Me.chkFps.AutoSize = True
        Me.chkFps.Checked = True
        Me.chkFps.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkFps.Location = New System.Drawing.Point(12, 35)
        Me.chkFps.Name = "chkFps"
        Me.chkFps.Size = New System.Drawing.Size(95, 17)
        Me.chkFps.TabIndex = 4
        Me.chkFps.Text = "Display Debug"
        Me.chkFps.UseVisualStyleBackColor = True
        '
        'btnNewGame
        '
        Me.btnNewGame.Location = New System.Drawing.Point(12, 67)
        Me.btnNewGame.Name = "btnNewGame"
        Me.btnNewGame.Size = New System.Drawing.Size(182, 25)
        Me.btnNewGame.TabIndex = 5
        Me.btnNewGame.Text = "New Game"
        Me.btnNewGame.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(60, 164)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Score"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblScore
        '
        Me.lblScore.AutoSize = True
        Me.lblScore.Location = New System.Drawing.Point(108, 164)
        Me.lblScore.Name = "lblScore"
        Me.lblScore.Size = New System.Drawing.Size(10, 13)
        Me.lblScore.TabIndex = 9
        Me.lblScore.Text = "-"
        '
        'tmrGame
        '
        Me.tmrGame.Enabled = True
        Me.tmrGame.Interval = 1000
        '
        'btnGameOver
        '
        Me.btnGameOver.Location = New System.Drawing.Point(12, 129)
        Me.btnGameOver.Name = "btnGameOver"
        Me.btnGameOver.Size = New System.Drawing.Size(182, 25)
        Me.btnGameOver.TabIndex = 10
        Me.btnGameOver.Text = "Game Over"
        Me.btnGameOver.UseVisualStyleBackColor = True
        '
        'btnRestartLevel
        '
        Me.btnRestartLevel.Location = New System.Drawing.Point(12, 98)
        Me.btnRestartLevel.Name = "btnRestartLevel"
        Me.btnRestartLevel.Size = New System.Drawing.Size(182, 25)
        Me.btnRestartLevel.TabIndex = 5
        Me.btnRestartLevel.Text = "Restart Level"
        Me.btnRestartLevel.UseVisualStyleBackColor = True
        '
        'frmDebug
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(232, 259)
        Me.Controls.Add(Me.btnGameOver)
        Me.Controls.Add(Me.lblScore)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnRestartLevel)
        Me.Controls.Add(Me.btnNewGame)
        Me.Controls.Add(Me.chkMouseConsole)
        Me.Controls.Add(Me.chkFps)
        Me.Name = "frmDebug"
        Me.Text = "Debug Options"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents chkMouseConsole As CheckBox
    Friend WithEvents chkFps As CheckBox
    Friend WithEvents btnNewGame As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents lblScore As Label
    Friend WithEvents tmrGame As Timer
    Friend WithEvents btnGameOver As Button
    Friend WithEvents btnRestartLevel As Button
End Class
