<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EmailFromOutlook
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EmailFromOutlook))
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.ComboBoxTo = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.TextBoxSubject = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.TextBoxMemo = New System.Windows.Forms.TextBox
        Me.Mas500Toolbar = New System.Windows.Forms.ToolStrip
        Me.ButtonExit = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.ButtonSave = New System.Windows.Forms.ToolStripButton
        Me.Button1 = New System.Windows.Forms.Button
        Me.ButtonAttach = New System.Windows.Forms.Button
        Me.ComboBoxAccounts = New System.Windows.Forms.ComboBox
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.Label1 = New System.Windows.Forms.Label
        Me.Mas500Toolbar.SuspendLayout()
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(82, 226)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(288, 20)
        Me.TextBox1.TabIndex = 3
        '
        'ComboBoxTo
        '
        Me.ComboBoxTo.FormattingEnabled = True
        Me.ComboBoxTo.Location = New System.Drawing.Point(139, 55)
        Me.ComboBoxTo.Name = "ComboBoxTo"
        Me.ComboBoxTo.Size = New System.Drawing.Size(257, 21)
        Me.ComboBoxTo.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(110, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(23, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "To:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 229)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Attachment:"
        '
        'TextBoxSubject
        '
        Me.TextBoxSubject.Location = New System.Drawing.Point(139, 82)
        Me.TextBoxSubject.Name = "TextBoxSubject"
        Me.TextBoxSubject.Size = New System.Drawing.Size(257, 20)
        Me.TextBoxSubject.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(87, 85)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Subject:"
        '
        'TextBoxMemo
        '
        Me.TextBoxMemo.Location = New System.Drawing.Point(12, 108)
        Me.TextBoxMemo.Multiline = True
        Me.TextBoxMemo.Name = "TextBoxMemo"
        Me.TextBoxMemo.Size = New System.Drawing.Size(384, 112)
        Me.TextBoxMemo.TabIndex = 10
        '
        'Mas500Toolbar
        '
        Me.Mas500Toolbar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.Mas500Toolbar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ButtonExit, Me.ToolStripSeparator2, Me.ButtonSave})
        Me.Mas500Toolbar.Location = New System.Drawing.Point(0, 0)
        Me.Mas500Toolbar.Name = "Mas500Toolbar"
        Me.Mas500Toolbar.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.Mas500Toolbar.Size = New System.Drawing.Size(409, 25)
        Me.Mas500Toolbar.TabIndex = 111
        Me.Mas500Toolbar.Text = "Mas500Toolbar"
        '
        'ButtonExit
        '
        Me.ButtonExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ButtonExit.Image = CType(resources.GetObject("ButtonExit.Image"), System.Drawing.Image)
        Me.ButtonExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonExit.Name = "ButtonExit"
        Me.ButtonExit.Size = New System.Drawing.Size(23, 22)
        Me.ButtonExit.Text = "Exit"
        Me.ButtonExit.ToolTipText = "Exit"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ButtonSave
        '
        Me.ButtonSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ButtonSave.Image = CType(resources.GetObject("ButtonSave.Image"), System.Drawing.Image)
        Me.ButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonSave.Name = "ButtonSave"
        Me.ButtonSave.Size = New System.Drawing.Size(23, 22)
        Me.ButtonSave.Text = "Save"
        Me.ButtonSave.ToolTipText = "Save"
        Me.ButtonSave.Visible = False
        '
        'Button1
        '
        Me.Button1.Image = Global.MassarelliOutBoundOrders.My.Resources.Resources.Email_Outlook_02
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.Location = New System.Drawing.Point(12, 31)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(69, 41)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Send"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ButtonAttach
        '
        Me.ButtonAttach.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAttach.Location = New System.Drawing.Point(373, 226)
        Me.ButtonAttach.Name = "ButtonAttach"
        Me.ButtonAttach.Size = New System.Drawing.Size(23, 19)
        Me.ButtonAttach.TabIndex = 112
        Me.ButtonAttach.Text = ". . ."
        Me.ButtonAttach.UseVisualStyleBackColor = True
        '
        'ComboBoxAccounts
        '
        Me.ComboBoxAccounts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxAccounts.FormattingEnabled = True
        Me.ComboBoxAccounts.Location = New System.Drawing.Point(139, 28)
        Me.ComboBoxAccounts.Name = "ComboBoxAccounts"
        Me.ComboBoxAccounts.Size = New System.Drawing.Size(257, 21)
        Me.ComboBoxAccounts.TabIndex = 113
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(100, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 13)
        Me.Label1.TabIndex = 114
        Me.Label1.Text = "From:"
        '
        'EmailFromOutlook
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(409, 255)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComboBoxAccounts)
        Me.Controls.Add(Me.ButtonAttach)
        Me.Controls.Add(Me.Mas500Toolbar)
        Me.Controls.Add(Me.TextBoxMemo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TextBoxSubject)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ComboBoxTo)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Button1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "EmailFromOutlook"
        Me.Text = "Email From Outlook"
        Me.Mas500Toolbar.ResumeLayout(False)
        Me.Mas500Toolbar.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents ComboBoxTo As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBoxSubject As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextBoxMemo As System.Windows.Forms.TextBox
    Friend WithEvents Mas500Toolbar As System.Windows.Forms.ToolStrip
    Friend WithEvents ButtonExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ButtonSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents ButtonAttach As System.Windows.Forms.Button
    Friend WithEvents ComboBoxAccounts As System.Windows.Forms.ComboBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
