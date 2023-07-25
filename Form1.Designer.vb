<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btn_Generate = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_Check = New System.Windows.Forms.Button()
        Me.tb_right = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btn_Generate
        '
        Me.btn_Generate.Location = New System.Drawing.Point(38, 21)
        Me.btn_Generate.Name = "btn_Generate"
        Me.btn_Generate.Size = New System.Drawing.Size(82, 42)
        Me.btn_Generate.TabIndex = 0
        Me.btn_Generate.Text = "Generate Number"
        Me.btn_Generate.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(14, 82)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(27, 20)
        Me.TextBox1.TabIndex = 1
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(47, 82)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(27, 20)
        Me.TextBox2.TabIndex = 2
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(80, 82)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(29, 20)
        Me.TextBox3.TabIndex = 3
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(115, 82)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(28, 20)
        Me.TextBox4.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 66)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(135, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Put in your 4 Numbers here"
        '
        'btn_Check
        '
        Me.btn_Check.Location = New System.Drawing.Point(170, 21)
        Me.btn_Check.Name = "btn_Check"
        Me.btn_Check.Size = New System.Drawing.Size(86, 42)
        Me.btn_Check.TabIndex = 6
        Me.btn_Check.Text = "Check Numbers"
        Me.btn_Check.UseVisualStyleBackColor = True
        '
        'tb_right
        '
        Me.tb_right.Location = New System.Drawing.Point(184, 82)
        Me.tb_right.Name = "tb_right"
        Me.tb_right.Size = New System.Drawing.Size(56, 20)
        Me.tb_right.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(167, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(105, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Number you got right"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 116)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tb_right)
        Me.Controls.Add(Me.btn_Check)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.btn_Generate)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btn_Generate As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btn_Check As Button
    Friend WithEvents tb_right As TextBox
    Friend WithEvents Label2 As Label
End Class
