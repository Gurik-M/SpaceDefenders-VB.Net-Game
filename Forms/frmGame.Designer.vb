<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmGame
    Inherits System.Windows.Forms.Form

    'Const w As Integer = MarioGame.MAP_SIZE_X * MarioGame.TILE_SIZE
    'Const h As Integer = MarioGame.MAP_SIZE_Y * MarioGame.TILE_SIZE + DEBUG_SIZE

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
        Me.tmrRepaint = New System.Windows.Forms.Timer(Me.components)
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.pbcCanvas = New FinalGameProject.PictureBoxConsumer()
        CType(Me.pbcCanvas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tmrRepaint
        '
        Me.tmrRepaint.Enabled = True
        Me.tmrRepaint.Interval = 30
        '
        'lblInfo
        '
        Me.lblInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInfo.Location = New System.Drawing.Point(12, 27)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(256, 143)
        Me.lblInfo.TabIndex = 1
        Me.lblInfo.Text = "This form will get automatically sized at startup, based on the Game's Map Size.." &
    "." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Also, don't put other stuff in the interface here..."
        Me.lblInfo.Visible = False
        '
        'pbcCanvas
        '
        Me.pbcCanvas.BackColor = System.Drawing.Color.White
        Me.pbcCanvas.Location = New System.Drawing.Point(0, 0)
        Me.pbcCanvas.Name = "pbcCanvas"
        Me.pbcCanvas.Size = New System.Drawing.Size(10, 10)
        Me.pbcCanvas.TabIndex = 0
        Me.pbcCanvas.TabStop = False
        '
        'frmGame
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(280, 179)
        Me.Controls.Add(Me.lblInfo)
        Me.Controls.Add(Me.pbcCanvas)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmGame"
        Me.Text = "Final Game"
        CType(Me.pbcCanvas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pbcCanvas As PictureBoxConsumer
    Friend WithEvents tmrRepaint As Timer
    Friend WithEvents lblInfo As Label
End Class
