<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SettingsMas
    Inherits BaseForm 'System.Windows.Forms.Form

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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SettingsMas))
        Me.Mas500Toolbar = New System.Windows.Forms.ToolStrip
        Me.ButtonExit = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.ButtonSave = New System.Windows.Forms.ToolStripButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.ButtonSavePath = New System.Windows.Forms.Button
        Me.TextBoxFTPPort = New System.Windows.Forms.TextBox
        Me.AppStoredSettingsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.TextBoxFTPHost = New System.Windows.Forms.TextBox
        Me.TextBoxRemoteLocation = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.ButtonOpenFile = New System.Windows.Forms.Button
        Me.TextBoxPath = New System.Windows.Forms.TextBox
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.ButtonSaveRepGroup = New System.Windows.Forms.Button
        Me.ListBoxRepGroups = New System.Windows.Forms.ListBox
        Me.TextBoxDefaultRepGroup = New System.Windows.Forms.TextBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.TextBoxConfirmPassword = New System.Windows.Forms.TextBox
        Me.ButtonSaveUserPassword = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.TextBoxPassword = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.TextBoxUserName = New System.Windows.Forms.TextBox
        Me.TextBoxPwdEncrypted = New System.Windows.Forms.TextBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.ButtonSaveGridLayoutFolder = New System.Windows.Forms.Button
        Me.Label8 = New System.Windows.Forms.Label
        Me.ButtonOpenGridFile = New System.Windows.Forms.Button
        Me.TextBoxGridFolderPath = New System.Windows.Forms.TextBox
        Me.AppStoredSettingsBindingSource2 = New System.Windows.Forms.BindingSource(Me.components)
        Me.AppStoredSettingsBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.ButtonSaveFromEmail = New System.Windows.Forms.Button
        Me.TextBoxFromEmail = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Mas500Toolbar.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.AppStoredSettingsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.AppStoredSettingsBindingSource2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AppStoredSettingsBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'Mas500Toolbar
        '
        Me.Mas500Toolbar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.Mas500Toolbar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ButtonExit, Me.ToolStripSeparator2, Me.ButtonSave})
        Me.Mas500Toolbar.Location = New System.Drawing.Point(0, 0)
        Me.Mas500Toolbar.Name = "Mas500Toolbar"
        Me.Mas500Toolbar.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.Mas500Toolbar.Size = New System.Drawing.Size(396, 25)
        Me.Mas500Toolbar.TabIndex = 110
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
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.ButtonSavePath)
        Me.GroupBox1.Controls.Add(Me.TextBoxFTPPort)
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.TextBoxFTPHost)
        Me.GroupBox1.Controls.Add(Me.TextBoxRemoteLocation)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.ButtonOpenFile)
        Me.GroupBox1.Controls.Add(Me.TextBoxPath)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 168)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(371, 177)
        Me.GroupBox1.TabIndex = 111
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "FTP Settings"
        '
        'ButtonSavePath
        '
        Me.ButtonSavePath.Location = New System.Drawing.Point(236, 143)
        Me.ButtonSavePath.Name = "ButtonSavePath"
        Me.ButtonSavePath.Size = New System.Drawing.Size(125, 23)
        Me.ButtonSavePath.TabIndex = 135
        Me.ButtonSavePath.Text = "Save FTP Settings"
        Me.ButtonSavePath.UseVisualStyleBackColor = True
        '
        'TextBoxFTPPort
        '
        Me.TextBoxFTPPort.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.AppStoredSettingsBindingSource, "FTPPort", True))
        Me.TextBoxFTPPort.Location = New System.Drawing.Point(236, 117)
        Me.TextBoxFTPPort.Name = "TextBoxFTPPort"
        Me.TextBoxFTPPort.Size = New System.Drawing.Size(126, 20)
        Me.TextBoxFTPPort.TabIndex = 133
        '
        'AppStoredSettingsBindingSource
        '
        Me.AppStoredSettingsBindingSource.DataSource = GetType(BOOutBoundOrders.AppStoredSettings)
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(223, 117)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(10, 20)
        Me.TextBox1.TabIndex = 132
        Me.TextBox1.Text = ":"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(235, 101)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(89, 13)
        Me.Label4.TabIndex = 131
        Me.Label4.Text = "FTP Port Number"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 102)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 13)
        Me.Label3.TabIndex = 130
        Me.Label3.Text = "FTP Host URL"
        '
        'TextBoxFTPHost
        '
        Me.TextBoxFTPHost.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.AppStoredSettingsBindingSource, "FTPHost", True))
        Me.TextBoxFTPHost.Location = New System.Drawing.Point(15, 117)
        Me.TextBoxFTPHost.Name = "TextBoxFTPHost"
        Me.TextBoxFTPHost.Size = New System.Drawing.Size(206, 20)
        Me.TextBoxFTPHost.TabIndex = 129
        '
        'TextBoxRemoteLocation
        '
        Me.TextBoxRemoteLocation.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.AppStoredSettingsBindingSource, "FTPUploadLocation", True))
        Me.TextBoxRemoteLocation.Location = New System.Drawing.Point(14, 76)
        Me.TextBoxRemoteLocation.Name = "TextBoxRemoteLocation"
        Me.TextBoxRemoteLocation.Size = New System.Drawing.Size(348, 20)
        Me.TextBoxRemoteLocation.TabIndex = 128
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 127
        Me.Label2.Text = "FTP Inbox"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(184, 13)
        Me.Label1.TabIndex = 126
        Me.Label1.Text = "Folder for storing sent FTP Excel  files"
        '
        'ButtonOpenFile
        '
        Me.ButtonOpenFile.Location = New System.Drawing.Point(336, 33)
        Me.ButtonOpenFile.Name = "ButtonOpenFile"
        Me.ButtonOpenFile.Size = New System.Drawing.Size(25, 22)
        Me.ButtonOpenFile.TabIndex = 124
        Me.ButtonOpenFile.Text = "..."
        Me.ButtonOpenFile.UseVisualStyleBackColor = True
        '
        'TextBoxPath
        '
        Me.TextBoxPath.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.AppStoredSettingsBindingSource, "Path", True))
        Me.TextBoxPath.Location = New System.Drawing.Point(14, 34)
        Me.TextBoxPath.Name = "TextBoxPath"
        Me.TextBoxPath.Size = New System.Drawing.Size(322, 20)
        Me.TextBoxPath.TabIndex = 2
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ButtonSaveRepGroup)
        Me.GroupBox2.Controls.Add(Me.ListBoxRepGroups)
        Me.GroupBox2.Controls.Add(Me.TextBoxDefaultRepGroup)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 28)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(371, 134)
        Me.GroupBox2.TabIndex = 126
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Default Rep Group On Startup"
        '
        'ButtonSaveRepGroup
        '
        Me.ButtonSaveRepGroup.Location = New System.Drawing.Point(236, 107)
        Me.ButtonSaveRepGroup.Name = "ButtonSaveRepGroup"
        Me.ButtonSaveRepGroup.Size = New System.Drawing.Size(125, 23)
        Me.ButtonSaveRepGroup.TabIndex = 147
        Me.ButtonSaveRepGroup.Text = "Save Default Rep Group"
        Me.ButtonSaveRepGroup.UseVisualStyleBackColor = True
        '
        'ListBoxRepGroups
        '
        Me.ListBoxRepGroups.FormattingEnabled = True
        Me.ListBoxRepGroups.Location = New System.Drawing.Point(13, 45)
        Me.ListBoxRepGroups.Name = "ListBoxRepGroups"
        Me.ListBoxRepGroups.Size = New System.Drawing.Size(348, 56)
        Me.ListBoxRepGroups.TabIndex = 126
        '
        'TextBoxDefaultRepGroup
        '
        Me.TextBoxDefaultRepGroup.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.AppStoredSettingsBindingSource, "DefaultRepGroup", True))
        Me.TextBoxDefaultRepGroup.Location = New System.Drawing.Point(14, 19)
        Me.TextBoxDefaultRepGroup.Name = "TextBoxDefaultRepGroup"
        Me.TextBoxDefaultRepGroup.Size = New System.Drawing.Size(347, 20)
        Me.TextBoxDefaultRepGroup.TabIndex = 2
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.TextBoxConfirmPassword)
        Me.GroupBox3.Controls.Add(Me.ButtonSaveUserPassword)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.TextBoxPassword)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.TextBoxUserName)
        Me.GroupBox3.Controls.Add(Me.TextBoxPwdEncrypted)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 351)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(371, 130)
        Me.GroupBox3.TabIndex = 129
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "FTP User Name and Password"
        '
        'TextBoxConfirmPassword
        '
        Me.TextBoxConfirmPassword.Location = New System.Drawing.Point(120, 73)
        Me.TextBoxConfirmPassword.Name = "TextBoxConfirmPassword"
        Me.TextBoxConfirmPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBoxConfirmPassword.Size = New System.Drawing.Size(241, 20)
        Me.TextBoxConfirmPassword.TabIndex = 144
        '
        'ButtonSaveUserPassword
        '
        Me.ButtonSaveUserPassword.Location = New System.Drawing.Point(189, 99)
        Me.ButtonSaveUserPassword.Name = "ButtonSaveUserPassword"
        Me.ButtonSaveUserPassword.Size = New System.Drawing.Size(172, 23)
        Me.ButtonSaveUserPassword.TabIndex = 146
        Me.ButtonSaveUserPassword.Text = "Save FTP User/Password"
        Me.ButtonSaveUserPassword.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(11, 76)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(95, 13)
        Me.Label7.TabIndex = 145
        Me.Label7.Text = "(confirm password)"
        '
        'TextBoxPassword
        '
        Me.TextBoxPassword.Location = New System.Drawing.Point(120, 47)
        Me.TextBoxPassword.Name = "TextBoxPassword"
        Me.TextBoxPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBoxPassword.Size = New System.Drawing.Size(241, 20)
        Me.TextBoxPassword.TabIndex = 143
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(10, 50)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(76, 13)
        Me.Label6.TabIndex = 142
        Me.Label6.Text = "FTP Password"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(11, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 13)
        Me.Label5.TabIndex = 141
        Me.Label5.Text = "FTP User Name"
        '
        'TextBoxUserName
        '
        Me.TextBoxUserName.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.AppStoredSettingsBindingSource, "FTPUserName", True))
        Me.TextBoxUserName.Location = New System.Drawing.Point(120, 21)
        Me.TextBoxUserName.Name = "TextBoxUserName"
        Me.TextBoxUserName.Size = New System.Drawing.Size(241, 20)
        Me.TextBoxUserName.TabIndex = 140
        '
        'TextBoxPwdEncrypted
        '
        Me.TextBoxPwdEncrypted.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.AppStoredSettingsBindingSource, "FTPPassword", True))
        Me.TextBoxPwdEncrypted.Location = New System.Drawing.Point(137, 73)
        Me.TextBoxPwdEncrypted.Name = "TextBoxPwdEncrypted"
        Me.TextBoxPwdEncrypted.Size = New System.Drawing.Size(46, 20)
        Me.TextBoxPwdEncrypted.TabIndex = 147
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.ButtonSaveGridLayoutFolder)
        Me.GroupBox4.Controls.Add(Me.Label8)
        Me.GroupBox4.Controls.Add(Me.ButtonOpenGridFile)
        Me.GroupBox4.Controls.Add(Me.TextBoxGridFolderPath)
        Me.GroupBox4.Location = New System.Drawing.Point(15, 564)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(371, 90)
        Me.GroupBox4.TabIndex = 130
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Rep Group && Rep Excel - Sent Files Folder"
        '
        'ButtonSaveGridLayoutFolder
        '
        Me.ButtonSaveGridLayoutFolder.Location = New System.Drawing.Point(189, 61)
        Me.ButtonSaveGridLayoutFolder.Name = "ButtonSaveGridLayoutFolder"
        Me.ButtonSaveGridLayoutFolder.Size = New System.Drawing.Size(172, 23)
        Me.ButtonSaveGridLayoutFolder.TabIndex = 135
        Me.ButtonSaveGridLayoutFolder.Text = "Save Rep Excel File Folder"
        Me.ButtonSaveGridLayoutFolder.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(11, 18)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(195, 13)
        Me.Label8.TabIndex = 129
        Me.Label8.Text = "Folder for storing emailed rep Excel  files"
        '
        'ButtonOpenGridFile
        '
        Me.ButtonOpenGridFile.Location = New System.Drawing.Point(334, 34)
        Me.ButtonOpenGridFile.Name = "ButtonOpenGridFile"
        Me.ButtonOpenGridFile.Size = New System.Drawing.Size(25, 22)
        Me.ButtonOpenGridFile.TabIndex = 128
        Me.ButtonOpenGridFile.Text = "..."
        Me.ButtonOpenGridFile.UseVisualStyleBackColor = True
        '
        'TextBoxGridFolderPath
        '
        Me.TextBoxGridFolderPath.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.AppStoredSettingsBindingSource, "RepSaveExcelFolderPath", True))
        Me.TextBoxGridFolderPath.Location = New System.Drawing.Point(12, 35)
        Me.TextBoxGridFolderPath.Name = "TextBoxGridFolderPath"
        Me.TextBoxGridFolderPath.Size = New System.Drawing.Size(322, 20)
        Me.TextBoxGridFolderPath.TabIndex = 127
        '
        'AppStoredSettingsBindingSource2
        '
        Me.AppStoredSettingsBindingSource2.DataSource = GetType(BOOutBoundOrders.AppStoredSettings)
        '
        'AppStoredSettingsBindingSource1
        '
        Me.AppStoredSettingsBindingSource1.DataSource = GetType(BOOutBoundOrders.AppStoredSettings)
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.ButtonSaveFromEmail)
        Me.GroupBox5.Controls.Add(Me.TextBoxFromEmail)
        Me.GroupBox5.Location = New System.Drawing.Point(15, 487)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(368, 71)
        Me.GroupBox5.TabIndex = 131
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Default FROM Email Account"
        '
        'ButtonSaveFromEmail
        '
        Me.ButtonSaveFromEmail.Location = New System.Drawing.Point(185, 42)
        Me.ButtonSaveFromEmail.Name = "ButtonSaveFromEmail"
        Me.ButtonSaveFromEmail.Size = New System.Drawing.Size(172, 23)
        Me.ButtonSaveFromEmail.TabIndex = 136
        Me.ButtonSaveFromEmail.Text = "Save Default FROM Email"
        Me.ButtonSaveFromEmail.UseVisualStyleBackColor = True
        '
        'TextBoxFromEmail
        '
        Me.TextBoxFromEmail.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.AppStoredSettingsBindingSource, "FromEmail", True))
        Me.TextBoxFromEmail.Location = New System.Drawing.Point(12, 19)
        Me.TextBoxFromEmail.Name = "TextBoxFromEmail"
        Me.TextBoxFromEmail.Size = New System.Drawing.Size(345, 20)
        Me.TextBoxFromEmail.TabIndex = 0
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(15, 143)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(180, 13)
        Me.Label9.TabIndex = 136
        Me.Label9.Text = "NOTE: FTP Inbox, URL and Port No"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(15, 158)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(179, 13)
        Me.Label10.TabIndex = 137
        Me.Label10.Text = "values must be provided by recipient"
        '
        'SettingsMas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(396, 678)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Mas500Toolbar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "SettingsMas"
        Me.Text = "Settings"
        Me.Mas500Toolbar.ResumeLayout(False)
        Me.Mas500Toolbar.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.AppStoredSettingsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.AppStoredSettingsBindingSource2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AppStoredSettingsBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Mas500Toolbar As System.Windows.Forms.ToolStrip
    Friend WithEvents ButtonExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ButtonSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ButtonOpenFile As System.Windows.Forms.Button
    Friend WithEvents TextBoxPath As System.Windows.Forms.TextBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TextBoxDefaultRepGroup As System.Windows.Forms.TextBox
    Friend WithEvents ListBoxRepGroups As System.Windows.Forms.ListBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBoxRemoteLocation As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBoxFTPHost As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxFTPPort As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents ButtonSaveUserPassword As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TextBoxConfirmPassword As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TextBoxUserName As System.Windows.Forms.TextBox
    Friend WithEvents ButtonSavePath As System.Windows.Forms.Button
    Friend WithEvents ButtonSaveRepGroup As System.Windows.Forms.Button
    Friend WithEvents AppStoredSettingsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents AppStoredSettingsBindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents TextBoxPwdEncrypted As System.Windows.Forms.TextBox
    Friend WithEvents AppStoredSettingsBindingSource2 As System.Windows.Forms.BindingSource
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ButtonOpenGridFile As System.Windows.Forms.Button
    Friend WithEvents TextBoxGridFolderPath As System.Windows.Forms.TextBox
    Friend WithEvents ButtonSaveGridLayoutFolder As System.Windows.Forms.Button
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents TextBoxFromEmail As System.Windows.Forms.TextBox
    Friend WithEvents ButtonSaveFromEmail As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
End Class
