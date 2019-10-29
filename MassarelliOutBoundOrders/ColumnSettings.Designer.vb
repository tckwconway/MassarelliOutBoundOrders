<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ColumnSettings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ColumnSettings))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ButtonNewColumnPreset = New System.Windows.Forms.Button()
        Me.TextBoxNewPreset = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.ButtonDeleteColumnPreset = New System.Windows.Forms.Button()
        Me.ButtonSaveColumnPreset = New System.Windows.Forms.Button()
        Me.ListViewColumnPreset = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Mas500Toolbar = New System.Windows.Forms.ToolStrip()
        Me.ButtonExit = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ButtonSave = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.rbHistory = New System.Windows.Forms.RadioButton()
        Me.rbPending = New System.Windows.Forms.RadioButton()
        Me.cboRepGroup = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.DataGridViewColumnSettings = New System.Windows.Forms.DataGridView()
        Me.ColumnVisible = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ColumnName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MySettingsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Mas500Toolbar.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.DataGridViewColumnSettings, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MySettingsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.ButtonNewColumnPreset)
        Me.GroupBox1.Controls.Add(Me.TextBoxNewPreset)
        Me.GroupBox1.Location = New System.Drawing.Point(17, 34)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(295, 109)
        Me.GroupBox1.TabIndex = 136
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "New Preset"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 33)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(231, 17)
        Me.Label1.TabIndex = 136
        Me.Label1.Text = "Enter a unique name and press OK"
        '
        'ButtonNewColumnPreset
        '
        Me.ButtonNewColumnPreset.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ButtonNewColumnPreset.Location = New System.Drawing.Point(235, 65)
        Me.ButtonNewColumnPreset.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ButtonNewColumnPreset.Name = "ButtonNewColumnPreset"
        Me.ButtonNewColumnPreset.Size = New System.Drawing.Size(52, 25)
        Me.ButtonNewColumnPreset.TabIndex = 135
        Me.ButtonNewColumnPreset.Text = "OK"
        Me.ButtonNewColumnPreset.UseVisualStyleBackColor = True
        '
        'TextBoxNewPreset
        '
        Me.TextBoxNewPreset.Location = New System.Drawing.Point(8, 65)
        Me.TextBoxNewPreset.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TextBoxNewPreset.Name = "TextBoxNewPreset"
        Me.TextBoxNewPreset.Size = New System.Drawing.Size(217, 22)
        Me.TextBoxNewPreset.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.ButtonDeleteColumnPreset)
        Me.GroupBox2.Controls.Add(Me.ButtonSaveColumnPreset)
        Me.GroupBox2.Controls.Add(Me.ListViewColumnPreset)
        Me.GroupBox2.Location = New System.Drawing.Point(17, 152)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox2.Size = New System.Drawing.Size(295, 497)
        Me.GroupBox2.TabIndex = 138
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Existing Presets -  Modify or Delete"
        '
        'ButtonDeleteColumnPreset
        '
        Me.ButtonDeleteColumnPreset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonDeleteColumnPreset.Location = New System.Drawing.Point(157, 460)
        Me.ButtonDeleteColumnPreset.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ButtonDeleteColumnPreset.Name = "ButtonDeleteColumnPreset"
        Me.ButtonDeleteColumnPreset.Size = New System.Drawing.Size(129, 30)
        Me.ButtonDeleteColumnPreset.TabIndex = 137
        Me.ButtonDeleteColumnPreset.Text = "Delete Preset"
        Me.ButtonDeleteColumnPreset.UseVisualStyleBackColor = True
        '
        'ButtonSaveColumnPreset
        '
        Me.ButtonSaveColumnPreset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonSaveColumnPreset.Location = New System.Drawing.Point(8, 460)
        Me.ButtonSaveColumnPreset.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ButtonSaveColumnPreset.Name = "ButtonSaveColumnPreset"
        Me.ButtonSaveColumnPreset.Size = New System.Drawing.Size(129, 30)
        Me.ButtonSaveColumnPreset.TabIndex = 136
        Me.ButtonSaveColumnPreset.Text = "Save Preset"
        Me.ButtonSaveColumnPreset.UseVisualStyleBackColor = True
        '
        'ListViewColumnPreset
        '
        Me.ListViewColumnPreset.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ListViewColumnPreset.CheckBoxes = True
        Me.ListViewColumnPreset.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1})
        Me.ListViewColumnPreset.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.ListViewColumnPreset.Location = New System.Drawing.Point(8, 23)
        Me.ListViewColumnPreset.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ListViewColumnPreset.Name = "ListViewColumnPreset"
        Me.ListViewColumnPreset.Size = New System.Drawing.Size(277, 431)
        Me.ListViewColumnPreset.TabIndex = 132
        Me.ListViewColumnPreset.UseCompatibleStateImageBehavior = False
        Me.ListViewColumnPreset.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Width = 200
        '
        'Mas500Toolbar
        '
        Me.Mas500Toolbar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.Mas500Toolbar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ButtonExit, Me.ToolStripSeparator2, Me.ButtonSave})
        Me.Mas500Toolbar.Location = New System.Drawing.Point(0, 0)
        Me.Mas500Toolbar.Name = "Mas500Toolbar"
        Me.Mas500Toolbar.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.Mas500Toolbar.Size = New System.Drawing.Size(663, 25)
        Me.Mas500Toolbar.TabIndex = 139
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
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.cboRepGroup)
        Me.GroupBox3.Controls.Add(Me.rbHistory)
        Me.GroupBox3.Controls.Add(Me.rbPending)
        Me.GroupBox3.Location = New System.Drawing.Point(327, 34)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(322, 109)
        Me.GroupBox3.TabIndex = 142
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Settings"
        '
        'rbHistory
        '
        Me.rbHistory.AutoSize = True
        Me.rbHistory.Location = New System.Drawing.Point(103, 29)
        Me.rbHistory.Margin = New System.Windows.Forms.Padding(4)
        Me.rbHistory.Name = "rbHistory"
        Me.rbHistory.Size = New System.Drawing.Size(73, 21)
        Me.rbHistory.TabIndex = 143
        Me.rbHistory.Text = "History"
        Me.rbHistory.UseVisualStyleBackColor = True
        '
        'rbPending
        '
        Me.rbPending.AutoSize = True
        Me.rbPending.Checked = True
        Me.rbPending.Location = New System.Drawing.Point(14, 29)
        Me.rbPending.Margin = New System.Windows.Forms.Padding(4)
        Me.rbPending.Name = "rbPending"
        Me.rbPending.Size = New System.Drawing.Size(81, 21)
        Me.rbPending.TabIndex = 142
        Me.rbPending.TabStop = True
        Me.rbPending.Text = "Pending"
        Me.rbPending.UseVisualStyleBackColor = True
        '
        'cboRepGroup
        '
        Me.cboRepGroup.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboRepGroup.FormattingEnabled = True
        Me.cboRepGroup.Location = New System.Drawing.Point(14, 77)
        Me.cboRepGroup.Name = "cboRepGroup"
        Me.cboRepGroup.Size = New System.Drawing.Size(300, 24)
        Me.cboRepGroup.TabIndex = 146
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(11, 56)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(247, 17)
        Me.Label2.TabIndex = 147
        Me.Label2.Text = "Associate with a Rep Group (optional)"
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.DataGridViewColumnSettings)
        Me.GroupBox4.Location = New System.Drawing.Point(327, 152)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(322, 497)
        Me.GroupBox4.TabIndex = 143
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Column Selection"
        '
        'DataGridViewColumnSettings
        '
        Me.DataGridViewColumnSettings.AllowUserToAddRows = False
        Me.DataGridViewColumnSettings.AllowUserToResizeRows = False
        Me.DataGridViewColumnSettings.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridViewColumnSettings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewColumnSettings.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColumnVisible, Me.ColumnName})
        Me.DataGridViewColumnSettings.Location = New System.Drawing.Point(14, 22)
        Me.DataGridViewColumnSettings.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridViewColumnSettings.Name = "DataGridViewColumnSettings"
        Me.DataGridViewColumnSettings.RowHeadersVisible = False
        Me.DataGridViewColumnSettings.Size = New System.Drawing.Size(303, 468)
        Me.DataGridViewColumnSettings.TabIndex = 1
        '
        'ColumnVisible
        '
        Me.ColumnVisible.HeaderText = "x"
        Me.ColumnVisible.Name = "ColumnVisible"
        Me.ColumnVisible.Width = 25
        '
        'ColumnName
        '
        Me.ColumnName.HeaderText = "Column Name"
        Me.ColumnName.Name = "ColumnName"
        Me.ColumnName.Width = 175
        '
        'MySettingsBindingSource
        '
        Me.MySettingsBindingSource.DataSource = GetType(System.Configuration.ApplicationSettingsBase)
        '
        'ColumnSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(663, 664)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Mas500Toolbar)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "ColumnSettings"
        Me.Text = "Column Presets"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.Mas500Toolbar.ResumeLayout(False)
        Me.Mas500Toolbar.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.DataGridViewColumnSettings, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MySettingsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MySettingsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ButtonNewColumnPreset As System.Windows.Forms.Button
    Friend WithEvents TextBoxNewPreset As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents ButtonDeleteColumnPreset As System.Windows.Forms.Button
    Friend WithEvents ButtonSaveColumnPreset As System.Windows.Forms.Button
    Friend WithEvents ListViewColumnPreset As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Mas500Toolbar As System.Windows.Forms.ToolStrip
    Friend WithEvents ButtonExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ButtonSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rbHistory As System.Windows.Forms.RadioButton
    Friend WithEvents rbPending As System.Windows.Forms.RadioButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboRepGroup As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents DataGridViewColumnSettings As System.Windows.Forms.DataGridView
    Friend WithEvents ColumnVisible As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ColumnName As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
