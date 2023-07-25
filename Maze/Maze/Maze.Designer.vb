<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Maze
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Maze))
        Me.pb_Player = New System.Windows.Forms.PictureBox()
        Me.pb_Collision = New System.Windows.Forms.PictureBox()
        Me.tmr_CollisionB = New System.Windows.Forms.Timer(Me.components)
        Me.Pb_Exit = New System.Windows.Forms.PictureBox()
        Me.tmr_Timer = New System.Windows.Forms.Timer(Me.components)
        Me.lbl_Timer = New System.Windows.Forms.Label()
        Me.pb_Close = New System.Windows.Forms.PictureBox()
        Me.pb_Minimise = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Pb_Exit2 = New System.Windows.Forms.PictureBox()
        Me.pb_Player2 = New System.Windows.Forms.PictureBox()
        Me.pb_Collision2 = New System.Windows.Forms.PictureBox()
        Me.tmr_CollisionR = New System.Windows.Forms.Timer(Me.components)
        CType(Me.pb_Player, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_Collision, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Pb_Exit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_Close, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_Minimise, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Pb_Exit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_Player2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_Collision2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pb_Player
        '
        Me.pb_Player.BackColor = System.Drawing.Color.Blue
        Me.pb_Player.InitialImage = CType(resources.GetObject("pb_Player.InitialImage"), System.Drawing.Image)
        Me.pb_Player.Location = New System.Drawing.Point(651, 338)
        Me.pb_Player.Name = "pb_Player"
        Me.pb_Player.Size = New System.Drawing.Size(32, 32)
        Me.pb_Player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pb_Player.TabIndex = 0
        Me.pb_Player.TabStop = False
        '
        'pb_Collision
        '
        Me.pb_Collision.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.pb_Collision.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pb_Collision.InitialImage = CType(resources.GetObject("pb_Collision.InitialImage"), System.Drawing.Image)
        Me.pb_Collision.Location = New System.Drawing.Point(651, 300)
        Me.pb_Collision.Name = "pb_Collision"
        Me.pb_Collision.Size = New System.Drawing.Size(32, 32)
        Me.pb_Collision.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pb_Collision.TabIndex = 1
        Me.pb_Collision.TabStop = False
        Me.pb_Collision.Visible = False
        '
        'tmr_CollisionB
        '
        Me.tmr_CollisionB.Enabled = True
        Me.tmr_CollisionB.Interval = 15
        '
        'Pb_Exit
        '
        Me.Pb_Exit.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Pb_Exit.Location = New System.Drawing.Point(604, 90)
        Me.Pb_Exit.Name = "Pb_Exit"
        Me.Pb_Exit.Size = New System.Drawing.Size(32, 32)
        Me.Pb_Exit.TabIndex = 2
        Me.Pb_Exit.TabStop = False
        '
        'tmr_Timer
        '
        Me.tmr_Timer.Enabled = True
        '
        'lbl_Timer
        '
        Me.lbl_Timer.AutoSize = True
        Me.lbl_Timer.BackColor = System.Drawing.Color.Gray
        Me.lbl_Timer.Font = New System.Drawing.Font("Modern No. 20", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Timer.ForeColor = System.Drawing.Color.White
        Me.lbl_Timer.Location = New System.Drawing.Point(12, 9)
        Me.lbl_Timer.Name = "lbl_Timer"
        Me.lbl_Timer.Size = New System.Drawing.Size(43, 17)
        Me.lbl_Timer.TabIndex = 3
        Me.lbl_Timer.Text = "Time"
        '
        'pb_Close
        '
        Me.pb_Close.BackColor = System.Drawing.Color.Gray
        Me.pb_Close.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pb_Close.Location = New System.Drawing.Point(799, -1)
        Me.pb_Close.Name = "pb_Close"
        Me.pb_Close.Size = New System.Drawing.Size(34, 33)
        Me.pb_Close.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pb_Close.TabIndex = 4
        Me.pb_Close.TabStop = False
        '
        'pb_Minimise
        '
        Me.pb_Minimise.BackColor = System.Drawing.Color.Gray
        Me.pb_Minimise.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pb_Minimise.Location = New System.Drawing.Point(778, -1)
        Me.pb_Minimise.Name = "pb_Minimise"
        Me.pb_Minimise.Size = New System.Drawing.Size(21, 27)
        Me.pb_Minimise.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pb_Minimise.TabIndex = 5
        Me.pb_Minimise.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Gray
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(841, 32)
        Me.Panel1.TabIndex = 6
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Gray
        Me.Panel2.Location = New System.Drawing.Point(0, 416)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(854, 64)
        Me.Panel2.TabIndex = 7
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Gray
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(32, 965)
        Me.Panel3.TabIndex = 8
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Gray
        Me.Panel4.Location = New System.Drawing.Point(800, 12)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(32, 983)
        Me.Panel4.TabIndex = 9
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Gray
        Me.Panel5.Location = New System.Drawing.Point(0, 864)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(820, 32)
        Me.Panel5.TabIndex = 7
        '
        'Pb_Exit2
        '
        Me.Pb_Exit2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Pb_Exit2.Location = New System.Drawing.Point(604, 523)
        Me.Pb_Exit2.Name = "Pb_Exit2"
        Me.Pb_Exit2.Size = New System.Drawing.Size(32, 32)
        Me.Pb_Exit2.TabIndex = 10
        Me.Pb_Exit2.TabStop = False
        '
        'pb_Player2
        '
        Me.pb_Player2.BackColor = System.Drawing.Color.Red
        Me.pb_Player2.InitialImage = CType(resources.GetObject("pb_Player2.InitialImage"), System.Drawing.Image)
        Me.pb_Player2.Location = New System.Drawing.Point(651, 622)
        Me.pb_Player2.Name = "pb_Player2"
        Me.pb_Player2.Size = New System.Drawing.Size(32, 32)
        Me.pb_Player2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pb_Player2.TabIndex = 11
        Me.pb_Player2.TabStop = False
        '
        'pb_Collision2
        '
        Me.pb_Collision2.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.pb_Collision2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pb_Collision2.InitialImage = CType(resources.GetObject("pb_Collision2.InitialImage"), System.Drawing.Image)
        Me.pb_Collision2.Location = New System.Drawing.Point(651, 584)
        Me.pb_Collision2.Name = "pb_Collision2"
        Me.pb_Collision2.Size = New System.Drawing.Size(32, 32)
        Me.pb_Collision2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pb_Collision2.TabIndex = 12
        Me.pb_Collision2.TabStop = False
        Me.pb_Collision2.Visible = False
        '
        'tmr_CollisionR
        '
        Me.tmr_CollisionR.Interval = 15
        '
        'Maze
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(832, 896)
        Me.ControlBox = False
        Me.Controls.Add(Me.pb_Collision2)
        Me.Controls.Add(Me.pb_Player2)
        Me.Controls.Add(Me.Pb_Exit2)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.pb_Player)
        Me.Controls.Add(Me.pb_Minimise)
        Me.Controls.Add(Me.pb_Close)
        Me.Controls.Add(Me.lbl_Timer)
        Me.Controls.Add(Me.Pb_Exit)
        Me.Controls.Add(Me.pb_Collision)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(832, 896)
        Me.MinimumSize = New System.Drawing.Size(832, 448)
        Me.Name = "Maze"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Maze"
        CType(Me.pb_Player, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_Collision, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Pb_Exit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_Close, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_Minimise, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Pb_Exit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_Player2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_Collision2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pb_Player As PictureBox
    Friend WithEvents pb_Collision As PictureBox
    Friend WithEvents tmr_CollisionB As Timer
    Friend WithEvents Pb_Exit As PictureBox
    Friend WithEvents tmr_Timer As Timer
    Friend WithEvents lbl_Timer As Label
    Friend WithEvents pb_Close As PictureBox
    Friend WithEvents pb_Minimise As PictureBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Pb_Exit2 As PictureBox
    Friend WithEvents pb_Player2 As PictureBox
    Friend WithEvents pb_Collision2 As PictureBox
    Friend WithEvents tmr_CollisionR As Timer
End Class
