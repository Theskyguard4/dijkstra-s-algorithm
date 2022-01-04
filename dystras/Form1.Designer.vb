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
        Me.FindPathButt = New System.Windows.Forms.Button()
        Me.AddWallsButt = New System.Windows.Forms.Button()
        Me.DrawEndButt = New System.Windows.Forms.Button()
        Me.AddStartPointButt = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'FindPathButt
        '
        Me.FindPathButt.Location = New System.Drawing.Point(1101, 2)
        Me.FindPathButt.Name = "FindPathButt"
        Me.FindPathButt.Size = New System.Drawing.Size(144, 124)
        Me.FindPathButt.TabIndex = 1
        Me.FindPathButt.Text = "Find Path"
        Me.FindPathButt.UseVisualStyleBackColor = True
        '
        'AddWallsButt
        '
        Me.AddWallsButt.Location = New System.Drawing.Point(1101, 132)
        Me.AddWallsButt.Name = "AddWallsButt"
        Me.AddWallsButt.Size = New System.Drawing.Size(144, 124)
        Me.AddWallsButt.TabIndex = 4
        Me.AddWallsButt.Text = "Draw Walls"
        Me.AddWallsButt.UseVisualStyleBackColor = True
        '
        'DrawEndButt
        '
        Me.DrawEndButt.Location = New System.Drawing.Point(1101, 262)
        Me.DrawEndButt.Name = "DrawEndButt"
        Me.DrawEndButt.Size = New System.Drawing.Size(144, 124)
        Me.DrawEndButt.TabIndex = 5
        Me.DrawEndButt.Text = "Add End Point"
        Me.DrawEndButt.UseVisualStyleBackColor = True
        '
        'AddStartPointButt
        '
        Me.AddStartPointButt.Location = New System.Drawing.Point(1101, 392)
        Me.AddStartPointButt.Name = "AddStartPointButt"
        Me.AddStartPointButt.Size = New System.Drawing.Size(144, 124)
        Me.AddStartPointButt.TabIndex = 6
        Me.AddStartPointButt.Text = "Add Start Point"
        Me.AddStartPointButt.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(678, 661)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 22)
        Me.TextBox1.TabIndex = 7
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1257, 769)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.AddStartPointButt)
        Me.Controls.Add(Me.DrawEndButt)
        Me.Controls.Add(Me.AddWallsButt)
        Me.Controls.Add(Me.FindPathButt)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FindPathButt As System.Windows.Forms.Button
    Friend WithEvents AddWallsButt As System.Windows.Forms.Button
    Friend WithEvents DrawEndButt As System.Windows.Forms.Button
    Friend WithEvents AddStartPointButt As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox

End Class
