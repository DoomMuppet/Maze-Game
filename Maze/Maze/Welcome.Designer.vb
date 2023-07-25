<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Welcome
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Welcome))
        Me.lbl_Welcome = New System.Windows.Forms.Label()
        Me.pb_Minimise = New System.Windows.Forms.PictureBox()
        Me.pb_Close = New System.Windows.Forms.PictureBox()
        CType(Me.pb_Minimise, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_Close, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbl_Welcome
        '
        Me.lbl_Welcome.AutoSize = True
        Me.lbl_Welcome.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Welcome.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lbl_Welcome.Font = New System.Drawing.Font("Britannic Bold", 48.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Welcome.ForeColor = System.Drawing.Color.White
        Me.lbl_Welcome.Location = New System.Drawing.Point(401, 256)
        Me.lbl_Welcome.Name = "lbl_Welcome"
        Me.lbl_Welcome.Size = New System.Drawing.Size(281, 71)
        Me.lbl_Welcome.TabIndex = 7
        Me.lbl_Welcome.Text = "Welcome"
        Me.lbl_Welcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pb_Minimise
        '
        Me.pb_Minimise.BackColor = System.Drawing.Color.Transparent
        Me.pb_Minimise.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pb_Minimise.Location = New System.Drawing.Point(1054, 2)
        Me.pb_Minimise.Name = "pb_Minimise"
        Me.pb_Minimise.Size = New System.Drawing.Size(21, 27)
        Me.pb_Minimise.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pb_Minimise.TabIndex = 6
        Me.pb_Minimise.TabStop = False
        '
        'pb_Close
        '
        Me.pb_Close.BackColor = System.Drawing.Color.Transparent
        Me.pb_Close.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pb_Close.Location = New System.Drawing.Point(1071, 2)
        Me.pb_Close.Name = "pb_Close"
        Me.pb_Close.Size = New System.Drawing.Size(34, 33)
        Me.pb_Close.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pb_Close.TabIndex = 5
        Me.pb_Close.TabStop = False
        '
        'Welcome
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1107, 581)
        Me.Controls.Add(Me.lbl_Welcome)
        Me.Controls.Add(Me.pb_Minimise)
        Me.Controls.Add(Me.pb_Close)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Welcome"
        Me.Text = "Welcome"
        CType(Me.pb_Minimise, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_Close, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pb_Close As PictureBox
    Friend WithEvents pb_Minimise As PictureBox
    Friend WithEvents lbl_Welcome As Label
End Class
