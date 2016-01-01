<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmmain
    Inherits System.Windows.Forms.Form


    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub


    Private components As System.ComponentModel.IContainer




    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.TimerFadeStart = New System.Windows.Forms.Timer(Me.components)
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.Timer1Second = New System.Windows.Forms.Timer(Me.components)
        Me.Timer250ml = New System.Windows.Forms.Timer(Me.components)
        Me.Timer20ml = New System.Windows.Forms.Timer(Me.components)
        Me.TimerStatus = New System.Windows.Forms.Timer(Me.components)
        Me.TimerPlayList = New System.Windows.Forms.Timer(Me.components)
        Me.Vol = New System.Windows.Forms.PictureBox()
        Me.TimerFadeOut = New System.Windows.Forms.Timer(Me.components)
        Me.Player = New AxSlingPlayerAXLib.AxSlingPlayer()
        CType(Me.Vol, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Player, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TimerFadeStart
        '
        Me.TimerFadeStart.Interval = 10
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.BackColor = System.Drawing.Color.Transparent
        Me.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStatus.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.ForeColor = System.Drawing.Color.White
        Me.lblStatus.Location = New System.Drawing.Point(16, 16)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Padding = New System.Windows.Forms.Padding(20)
        Me.lblStatus.Size = New System.Drawing.Size(42, 74)
        Me.lblStatus.TabIndex = 1
        Me.lblStatus.Visible = False
        '
        'Timer1Second
        '
        Me.Timer1Second.Enabled = True
        Me.Timer1Second.Interval = 1000
        '
        'Timer250ml
        '
        Me.Timer250ml.Enabled = True
        Me.Timer250ml.Interval = 250
        '
        'Timer20ml
        '
        Me.Timer20ml.Interval = 20
        '
        'TimerStatus
        '
        Me.TimerStatus.Interval = 290
        '
        'TimerPlayList
        '
        Me.TimerPlayList.Interval = 250
        '
        'Vol
        '
        Me.Vol.Location = New System.Drawing.Point(440, 214)
        Me.Vol.Name = "Vol"
        Me.Vol.Size = New System.Drawing.Size(150, 50)
        Me.Vol.TabIndex = 2
        Me.Vol.TabStop = False
        Me.Vol.Visible = False
        '
        'TimerFadeOut
        '
        Me.TimerFadeOut.Interval = 25
        '
        'Player
        '
        Me.Player.CausesValidation = False
        Me.Player.Enabled = True
        Me.Player.Location = New System.Drawing.Point(194, 66)
        Me.Player.Name = "Player"
        Me.Player.Size = New System.Drawing.Size(605, 340)
        Me.Player.TabIndex = 3
        Me.Player.Visible = False
        '
        'frmmain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(590, 264)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.Vol)
        Me.Controls.Add(Me.Player)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmmain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Form1"
        CType(Me.Vol, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Player, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TimerFadeStart As System.Windows.Forms.Timer
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents Timer1Second As System.Windows.Forms.Timer
    Friend WithEvents Timer250ml As System.Windows.Forms.Timer
    Friend WithEvents Timer20ml As System.Windows.Forms.Timer
    Friend WithEvents TimerStatus As System.Windows.Forms.Timer
    Friend WithEvents TimerPlayList As System.Windows.Forms.Timer
    Friend WithEvents Vol As System.Windows.Forms.PictureBox
    Friend WithEvents TimerFadeOut As System.Windows.Forms.Timer
    Friend WithEvents Player As AxSlingPlayerAXLib.AxSlingPlayer


End Class
