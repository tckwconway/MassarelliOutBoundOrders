<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FTPOptions
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
        Me.components = New System.ComponentModel.Container()
        Dim FtppwdLabel As System.Windows.Forms.Label
        Dim FtphostLabel As System.Windows.Forms.Label
        Dim FtpportLabel As System.Windows.Forms.Label
        Dim FtpuserLabel As System.Windows.Forms.Label
        Dim FtplocalfilenameLabel As System.Windows.Forms.Label
        Dim FtpuploadfilenameLabel As System.Windows.Forms.Label
        Dim FtpuploadlocLabel As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FTPOptions))
        Me.Mas500Toolbar = New System.Windows.Forms.ToolStrip()
        Me.ButtonExit = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ButtonSave = New System.Windows.Forms.ToolStripButton()
        Me.FtppwdTextBox = New System.Windows.Forms.TextBox()
        Me.FTPFileListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.FtpuserTextBox = New System.Windows.Forms.TextBox()
        Me.FtpportTextBox = New System.Windows.Forms.TextBox()
        Me.FtphostTextBox = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.ButtonOpenFile = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.FtpuploadlocTextBox = New System.Windows.Forms.TextBox()
        Me.FtpuploadfilenameTextBox = New System.Windows.Forms.TextBox()
        Me.FtplocalfilenameLinkLabel = New System.Windows.Forms.LinkLabel()
        Me.ButtonSend = New System.Windows.Forms.Button()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.OpenFileDialogFTP = New System.Windows.Forms.OpenFileDialog()
        FtppwdLabel = New System.Windows.Forms.Label()
        FtphostLabel = New System.Windows.Forms.Label()
        FtpportLabel = New System.Windows.Forms.Label()
        FtpuserLabel = New System.Windows.Forms.Label()
        FtplocalfilenameLabel = New System.Windows.Forms.Label()
        FtpuploadfilenameLabel = New System.Windows.Forms.Label()
        FtpuploadlocLabel = New System.Windows.Forms.Label()
        Me.Mas500Toolbar.SuspendLayout()
        CType(Me.FTPFileListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'FtppwdLabel
        '
        FtppwdLabel.AutoSize = True
        FtppwdLabel.Location = New System.Drawing.Point(20, 59)
        FtppwdLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        FtppwdLabel.Name = "FtppwdLabel"
        FtppwdLabel.Size = New System.Drawing.Size(103, 17)
        FtppwdLabel.TabIndex = 145
        FtppwdLabel.Text = "FTP Password:"
        '
        'FtphostLabel
        '
        FtphostLabel.AutoSize = True
        FtphostLabel.Location = New System.Drawing.Point(52, 91)
        FtphostLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        FtphostLabel.Name = "FtphostLabel"
        FtphostLabel.Size = New System.Drawing.Size(71, 17)
        FtphostLabel.TabIndex = 145
        FtphostLabel.Text = "FTP Host:"
        '
        'FtpportLabel
        '
        FtpportLabel.AutoSize = True
        FtpportLabel.Location = New System.Drawing.Point(56, 123)
        FtpportLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        FtpportLabel.Name = "FtpportLabel"
        FtpportLabel.Size = New System.Drawing.Size(68, 17)
        FtpportLabel.TabIndex = 147
        FtpportLabel.Text = "FTP Port:"
        '
        'FtpuserLabel
        '
        FtpuserLabel.AutoSize = True
        FtpuserLabel.Location = New System.Drawing.Point(11, 27)
        FtpuserLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        FtpuserLabel.Name = "FtpuserLabel"
        FtpuserLabel.Size = New System.Drawing.Size(113, 17)
        FtpuserLabel.TabIndex = 150
        FtpuserLabel.Text = "FTP User Name:"
        '
        'FtplocalfilenameLabel
        '
        FtplocalfilenameLabel.AutoSize = True
        FtplocalfilenameLabel.Location = New System.Drawing.Point(8, 23)
        FtplocalfilenameLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        FtplocalfilenameLabel.Name = "FtplocalfilenameLabel"
        FtplocalfilenameLabel.Size = New System.Drawing.Size(185, 17)
        FtplocalfilenameLabel.TabIndex = 144
        FtplocalfilenameLabel.Text = "Local Filename - this XL file:"
        '
        'FtpuploadfilenameLabel
        '
        FtpuploadfilenameLabel.AutoSize = True
        FtpuploadfilenameLabel.Location = New System.Drawing.Point(8, 87)
        FtpuploadfilenameLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        FtpuploadfilenameLabel.Name = "FtpuploadfilenameLabel"
        FtpuploadfilenameLabel.Size = New System.Drawing.Size(183, 17)
        FtpuploadfilenameLabel.TabIndex = 148
        FtpuploadfilenameLabel.Text = "FTP File Name - this XL file:"
        '
        'FtpuploadlocLabel
        '
        FtpuploadlocLabel.AutoSize = True
        FtpuploadlocLabel.Location = New System.Drawing.Point(8, 119)
        FtpuploadlocLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        FtpuploadlocLabel.Name = "FtpuploadlocLabel"
        FtpuploadlocLabel.Size = New System.Drawing.Size(177, 17)
        FtpuploadlocLabel.TabIndex = 150
        FtpuploadlocLabel.Text = "FTP Server Upload Folder:"
        '
        'Mas500Toolbar
        '
        Me.Mas500Toolbar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.Mas500Toolbar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ButtonExit, Me.ToolStripSeparator2, Me.ButtonSave})
        Me.Mas500Toolbar.Location = New System.Drawing.Point(0, 0)
        Me.Mas500Toolbar.Name = "Mas500Toolbar"
        Me.Mas500Toolbar.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.Mas500Toolbar.Size = New System.Drawing.Size(809, 25)
        Me.Mas500Toolbar.TabIndex = 141
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
        'FtppwdTextBox
        '
        Me.FtppwdTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FTPFileListBindingSource, "ftppwd", True))
        Me.FtppwdTextBox.Location = New System.Drawing.Point(133, 55)
        Me.FtppwdTextBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.FtppwdTextBox.Name = "FtppwdTextBox"
        Me.FtppwdTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.FtppwdTextBox.ReadOnly = True
        Me.FtppwdTextBox.Size = New System.Drawing.Size(159, 22)
        Me.FtppwdTextBox.TabIndex = 146
        '
        'FTPFileListBindingSource
        '
        Me.FTPFileListBindingSource.DataSource = GetType(MassarelliOutBoundOrders.FTPFileList)
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(FtpuserLabel)
        Me.GroupBox1.Controls.Add(Me.FtpuserTextBox)
        Me.GroupBox1.Controls.Add(FtpportLabel)
        Me.GroupBox1.Controls.Add(Me.FtpportTextBox)
        Me.GroupBox1.Controls.Add(FtphostLabel)
        Me.GroupBox1.Controls.Add(FtppwdLabel)
        Me.GroupBox1.Controls.Add(Me.FtphostTextBox)
        Me.GroupBox1.Controls.Add(Me.FtppwdTextBox)
        Me.GroupBox1.Location = New System.Drawing.Point(488, 42)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(308, 161)
        Me.GroupBox1.TabIndex = 150
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "FTP "
        '
        'FtpuserTextBox
        '
        Me.FtpuserTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FTPFileListBindingSource, "ftpuser", True))
        Me.FtpuserTextBox.Location = New System.Drawing.Point(133, 23)
        Me.FtpuserTextBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.FtpuserTextBox.Name = "FtpuserTextBox"
        Me.FtpuserTextBox.ReadOnly = True
        Me.FtpuserTextBox.Size = New System.Drawing.Size(159, 22)
        Me.FtpuserTextBox.TabIndex = 151
        '
        'FtpportTextBox
        '
        Me.FtpportTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FTPFileListBindingSource, "ftpport", True))
        Me.FtpportTextBox.Location = New System.Drawing.Point(133, 119)
        Me.FtpportTextBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.FtpportTextBox.Name = "FtpportTextBox"
        Me.FtpportTextBox.ReadOnly = True
        Me.FtpportTextBox.Size = New System.Drawing.Size(159, 22)
        Me.FtpportTextBox.TabIndex = 148
        '
        'FtphostTextBox
        '
        Me.FtphostTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FTPFileListBindingSource, "ftphost", True))
        Me.FtphostTextBox.Location = New System.Drawing.Point(133, 87)
        Me.FtphostTextBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.FtphostTextBox.Name = "FtphostTextBox"
        Me.FtphostTextBox.ReadOnly = True
        Me.FtphostTextBox.Size = New System.Drawing.Size(159, 22)
        Me.FtphostTextBox.TabIndex = 146
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ButtonOpenFile)
        Me.GroupBox2.Controls.Add(Me.GroupBox3)
        Me.GroupBox2.Controls.Add(FtpuploadlocLabel)
        Me.GroupBox2.Controls.Add(Me.FtpuploadlocTextBox)
        Me.GroupBox2.Controls.Add(FtpuploadfilenameLabel)
        Me.GroupBox2.Controls.Add(Me.FtpuploadfilenameTextBox)
        Me.GroupBox2.Controls.Add(Me.FtplocalfilenameLinkLabel)
        Me.GroupBox2.Controls.Add(FtplocalfilenameLabel)
        Me.GroupBox2.Location = New System.Drawing.Point(15, 42)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox2.Size = New System.Drawing.Size(460, 160)
        Me.GroupBox2.TabIndex = 151
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "File Information"
        '
        'ButtonOpenFile
        '
        Me.ButtonOpenFile.Location = New System.Drawing.Point(419, 44)
        Me.ButtonOpenFile.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ButtonOpenFile.Name = "ButtonOpenFile"
        Me.ButtonOpenFile.Size = New System.Drawing.Size(32, 27)
        Me.ButtonOpenFile.TabIndex = 153
        Me.ButtonOpenFile.Text = "..."
        Me.ButtonOpenFile.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Location = New System.Drawing.Point(12, 76)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox3.Size = New System.Drawing.Size(440, 2)
        Me.GroupBox3.TabIndex = 152
        Me.GroupBox3.TabStop = False
        '
        'FtpuploadlocTextBox
        '
        Me.FtpuploadlocTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FTPFileListBindingSource, "ftpuploadloc", True))
        Me.FtpuploadlocTextBox.Location = New System.Drawing.Point(195, 116)
        Me.FtpuploadlocTextBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.FtpuploadlocTextBox.Name = "FtpuploadlocTextBox"
        Me.FtpuploadlocTextBox.ReadOnly = True
        Me.FtpuploadlocTextBox.Size = New System.Drawing.Size(256, 22)
        Me.FtpuploadlocTextBox.TabIndex = 151
        '
        'FtpuploadfilenameTextBox
        '
        Me.FtpuploadfilenameTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FTPFileListBindingSource, "ftpuploadfilename", True))
        Me.FtpuploadfilenameTextBox.Location = New System.Drawing.Point(195, 84)
        Me.FtpuploadfilenameTextBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.FtpuploadfilenameTextBox.Name = "FtpuploadfilenameTextBox"
        Me.FtpuploadfilenameTextBox.ReadOnly = True
        Me.FtpuploadfilenameTextBox.Size = New System.Drawing.Size(256, 22)
        Me.FtpuploadfilenameTextBox.TabIndex = 149
        '
        'FtplocalfilenameLinkLabel
        '
        Me.FtplocalfilenameLinkLabel.BackColor = System.Drawing.SystemColors.Window
        Me.FtplocalfilenameLinkLabel.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FTPFileListBindingSource, "ftplocalfilename", True))
        Me.FtplocalfilenameLinkLabel.Location = New System.Drawing.Point(8, 47)
        Me.FtplocalfilenameLinkLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.FtplocalfilenameLinkLabel.Name = "FtplocalfilenameLinkLabel"
        Me.FtplocalfilenameLinkLabel.Size = New System.Drawing.Size(409, 23)
        Me.FtplocalfilenameLinkLabel.TabIndex = 145
        Me.FtplocalfilenameLinkLabel.TabStop = True
        Me.FtplocalfilenameLinkLabel.Text = "LinkLabel1"
        Me.FtplocalfilenameLinkLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ButtonSend
        '
        Me.ButtonSend.Image = Global.MassarelliOutBoundOrders.My.Resources.Resources.FTPExcel
        Me.ButtonSend.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonSend.Location = New System.Drawing.Point(591, 215)
        Me.ButtonSend.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ButtonSend.Name = "ButtonSend"
        Me.ButtonSend.Size = New System.Drawing.Size(109, 33)
        Me.ButtonSend.TabIndex = 152
        Me.ButtonSend.Text = "Send FTP"
        Me.ButtonSend.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonSend.UseVisualStyleBackColor = True
        '
        'ButtonCancel
        '
        Me.ButtonCancel.Image = Global.MassarelliOutBoundOrders.My.Resources.Resources.Cancel_Clear_1616
        Me.ButtonCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonCancel.Location = New System.Drawing.Point(708, 215)
        Me.ButtonCancel.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(88, 33)
        Me.ButtonCancel.TabIndex = 153
        Me.ButtonCancel.Text = "Cancel"
        Me.ButtonCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonCancel.UseVisualStyleBackColor = True
        '
        'OpenFileDialogFTP
        '
        Me.OpenFileDialogFTP.FileName = "OpenFileDialog1"
        '
        'FTPOptions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(809, 263)
        Me.Controls.Add(Me.ButtonCancel)
        Me.Controls.Add(Me.ButtonSend)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Mas500Toolbar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "FTPOptions"
        Me.Text = "FTP Send XL"
        Me.Mas500Toolbar.ResumeLayout(False)
        Me.Mas500Toolbar.PerformLayout()
        CType(Me.FTPFileListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Mas500Toolbar As System.Windows.Forms.ToolStrip
    Friend WithEvents ButtonExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ButtonSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents FTPFileListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents FtppwdTextBox As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents FtpuserTextBox As System.Windows.Forms.TextBox
    Friend WithEvents FtpportTextBox As System.Windows.Forms.TextBox
    Friend WithEvents FtphostTextBox As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents FtpuploadfilenameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents FtplocalfilenameLinkLabel As System.Windows.Forms.LinkLabel
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents FtpuploadlocTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ButtonSend As System.Windows.Forms.Button
    Friend WithEvents ButtonCancel As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialogFTP As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ButtonOpenFile As System.Windows.Forms.Button
End Class
