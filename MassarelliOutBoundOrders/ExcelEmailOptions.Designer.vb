<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ExcelEmailOptions
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ExcelEmailOptions))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Mas500Toolbar = New System.Windows.Forms.ToolStrip
        Me.ButtonExit = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.ButtonSave = New System.Windows.Forms.ToolStripButton
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.TextBoxMemo = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.TextBoxSubject = New System.Windows.Forms.TextBox
        Me.ButtonSendSelection = New System.Windows.Forms.Button
        Me.pboxSave = New System.Windows.Forms.PictureBox
        Me.pboxSend = New System.Windows.Forms.PictureBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.VLQ_SalesRepGroupListDataGridView = New System.Windows.Forms.DataGridView
        Me.slspsn_no_grp = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.slspsn_name_grp = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.email_addr_grp = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.user_def_fld_1_grp = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FilePathNameGrp = New System.Windows.Forms.DataGridViewLinkColumn
        Me.send_grp = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.save_grp = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.sent = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.BindingSourceRepGroup = New System.Windows.Forms.BindingSource(Me.components)
        Me.VLQ_SalesPersonListDataGridView = New System.Windows.Forms.DataGridView
        Me.slspsn_no_slspsn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.slspsn_name_slspsn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.email_addr_slspsn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.user_def_fld_1_slspsn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FilePathNameRep = New System.Windows.Forms.DataGridViewLinkColumn
        Me.send_slspsn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.save_slspsn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.sent_rep = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.VLQ_SalesPersonListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ButtonCancel = New System.Windows.Forms.Button
        Me.ButtonPrepare = New System.Windows.Forms.Button
        Me.ToolTipEmail = New System.Windows.Forms.ToolTip(Me.components)
        Me.BindingSourceExcelEmailList = New System.Windows.Forms.BindingSource(Me.components)
        Me.BindingSourceReps = New System.Windows.Forms.BindingSource(Me.components)
        Me.TextBoxSendTo = New System.Windows.Forms.TextBox
        Me.CheckBoxSendTo = New System.Windows.Forms.CheckBox
        Me.CheckBoxSendFrom = New System.Windows.Forms.CheckBox
        Me.TextBoxSendFrom = New System.Windows.Forms.TextBox
        Me.ExcelEmailFileListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ExcelEmailFileListBindingSource2 = New System.Windows.Forms.BindingSource(Me.components)
        Me.ExcelEmailFileListBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.MassarelliOutBoundUtilitesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Mas500Toolbar.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.pboxSave, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pboxSend, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VLQ_SalesRepGroupListDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSourceRepGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VLQ_SalesPersonListDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VLQ_SalesPersonListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSourceExcelEmailList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSourceReps, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ExcelEmailFileListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ExcelEmailFileListBindingSource2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ExcelEmailFileListBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MassarelliOutBoundUtilitesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Mas500Toolbar
        '
        Me.Mas500Toolbar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.Mas500Toolbar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ButtonExit, Me.ToolStripSeparator2, Me.ButtonSave})
        Me.Mas500Toolbar.Location = New System.Drawing.Point(0, 0)
        Me.Mas500Toolbar.Name = "Mas500Toolbar"
        Me.Mas500Toolbar.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.Mas500Toolbar.Size = New System.Drawing.Size(932, 25)
        Me.Mas500Toolbar.TabIndex = 140
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
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.TextBoxSendFrom)
        Me.GroupBox2.Controls.Add(Me.CheckBoxSendFrom)
        Me.GroupBox2.Controls.Add(Me.CheckBoxSendTo)
        Me.GroupBox2.Controls.Add(Me.TextBoxSendTo)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.TextBoxMemo)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.TextBoxSubject)
        Me.GroupBox2.Controls.Add(Me.ButtonSendSelection)
        Me.GroupBox2.Controls.Add(Me.pboxSave)
        Me.GroupBox2.Controls.Add(Me.pboxSend)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.VLQ_SalesRepGroupListDataGridView)
        Me.GroupBox2.Controls.Add(Me.VLQ_SalesPersonListDataGridView)
        Me.GroupBox2.Controls.Add(Me.ButtonCancel)
        Me.GroupBox2.Controls.Add(Me.ButtonPrepare)
        Me.GroupBox2.Location = New System.Drawing.Point(9, 33)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(910, 526)
        Me.GroupBox2.TabIndex = 142
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "PREPARE / SEND: Excel Files && Emails"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(146, 51)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(36, 13)
        Me.Label7.TabIndex = 22
        Me.Label7.Text = "Memo"
        '
        'TextBoxMemo
        '
        Me.TextBoxMemo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxMemo.Location = New System.Drawing.Point(188, 48)
        Me.TextBoxMemo.Multiline = True
        Me.TextBoxMemo.Name = "TextBoxMemo"
        Me.TextBoxMemo.Size = New System.Drawing.Size(709, 82)
        Me.TextBoxMemo.TabIndex = 21
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(139, 23)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 13)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "Subject"
        '
        'TextBoxSubject
        '
        Me.TextBoxSubject.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxSubject.Location = New System.Drawing.Point(188, 19)
        Me.TextBoxSubject.Name = "TextBoxSubject"
        Me.TextBoxSubject.Size = New System.Drawing.Size(709, 20)
        Me.TextBoxSubject.TabIndex = 19
        '
        'ButtonSendSelection
        '
        Me.ButtonSendSelection.Enabled = False
        Me.ButtonSendSelection.Image = Global.MassarelliOutBoundOrders.My.Resources.Resources.Email_Outlook_02
        Me.ButtonSendSelection.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonSendSelection.Location = New System.Drawing.Point(15, 47)
        Me.ButtonSendSelection.Name = "ButtonSendSelection"
        Me.ButtonSendSelection.Size = New System.Drawing.Size(89, 24)
        Me.ButtonSendSelection.TabIndex = 6
        Me.ButtonSendSelection.Text = "Send"
        Me.ButtonSendSelection.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonSendSelection.UseVisualStyleBackColor = True
        '
        'pboxSave
        '
        Me.pboxSave.Image = Global.MassarelliOutBoundOrders.My.Resources.Resources.Check_Uncheck_07
        Me.pboxSave.InitialImage = CType(resources.GetObject("pboxSave.InitialImage"), System.Drawing.Image)
        Me.pboxSave.Location = New System.Drawing.Point(55, 174)
        Me.pboxSave.Name = "pboxSave"
        Me.pboxSave.Size = New System.Drawing.Size(40, 20)
        Me.pboxSave.TabIndex = 16
        Me.pboxSave.TabStop = False
        Me.ToolTipEmail.SetToolTip(Me.pboxSave, "Check / Uncheck ALL Save")
        '
        'pboxSend
        '
        Me.pboxSend.Image = Global.MassarelliOutBoundOrders.My.Resources.Resources.Check_Uncheck_06
        Me.pboxSend.Location = New System.Drawing.Point(15, 174)
        Me.pboxSend.Name = "pboxSend"
        Me.pboxSend.Size = New System.Drawing.Size(40, 20)
        Me.pboxSend.TabIndex = 15
        Me.pboxSend.TabStop = False
        Me.ToolTipEmail.SetToolTip(Me.pboxSend, "Check / Uncheck ALL Send")
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 155)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 15)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Rep Group"
        '
        'Label3
        '
        Me.Label3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 252)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 15)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Sales Reps"
        '
        'VLQ_SalesRepGroupListDataGridView
        '
        Me.VLQ_SalesRepGroupListDataGridView.AllowUserToAddRows = False
        Me.VLQ_SalesRepGroupListDataGridView.AllowUserToDeleteRows = False
        Me.VLQ_SalesRepGroupListDataGridView.AllowUserToResizeRows = False
        Me.VLQ_SalesRepGroupListDataGridView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.VLQ_SalesRepGroupListDataGridView.AutoGenerateColumns = False
        Me.VLQ_SalesRepGroupListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.VLQ_SalesRepGroupListDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.slspsn_no_grp, Me.slspsn_name_grp, Me.email_addr_grp, Me.user_def_fld_1_grp, Me.FilePathNameGrp, Me.send_grp, Me.save_grp, Me.sent})
        Me.VLQ_SalesRepGroupListDataGridView.DataSource = Me.BindingSourceRepGroup
        Me.VLQ_SalesRepGroupListDataGridView.Location = New System.Drawing.Point(15, 194)
        Me.VLQ_SalesRepGroupListDataGridView.Name = "VLQ_SalesRepGroupListDataGridView"
        Me.VLQ_SalesRepGroupListDataGridView.RowHeadersVisible = False
        Me.VLQ_SalesRepGroupListDataGridView.Size = New System.Drawing.Size(883, 54)
        Me.VLQ_SalesRepGroupListDataGridView.TabIndex = 8
        '
        'slspsn_no_grp
        '
        Me.slspsn_no_grp.DataPropertyName = "slspsn_no"
        Me.slspsn_no_grp.HeaderText = "Rep Grp #"
        Me.slspsn_no_grp.Name = "slspsn_no_grp"
        Me.slspsn_no_grp.Width = 80
        '
        'slspsn_name_grp
        '
        Me.slspsn_name_grp.DataPropertyName = "slspsn_name"
        Me.slspsn_name_grp.HeaderText = "Rep Group Name"
        Me.slspsn_name_grp.Name = "slspsn_name_grp"
        Me.slspsn_name_grp.Width = 225
        '
        'email_addr_grp
        '
        Me.email_addr_grp.DataPropertyName = "email_addr"
        Me.email_addr_grp.HeaderText = "Email Address"
        Me.email_addr_grp.Name = "email_addr_grp"
        Me.email_addr_grp.Width = 250
        '
        'user_def_fld_1_grp
        '
        Me.user_def_fld_1_grp.DataPropertyName = "user_def_fld_1"
        Me.user_def_fld_1_grp.HeaderText = "Rep Group"
        Me.user_def_fld_1_grp.Name = "user_def_fld_1_grp"
        Me.user_def_fld_1_grp.Visible = False
        '
        'FilePathNameGrp
        '
        Me.FilePathNameGrp.DataPropertyName = "file_path_name"
        Me.FilePathNameGrp.HeaderText = "File Path / Name"
        Me.FilePathNameGrp.Name = "FilePathNameGrp"
        Me.FilePathNameGrp.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.FilePathNameGrp.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.FilePathNameGrp.Width = 175
        '
        'send_grp
        '
        Me.send_grp.DataPropertyName = "send"
        Me.send_grp.HeaderText = "Send"
        Me.send_grp.Name = "send_grp"
        Me.send_grp.Width = 40
        '
        'save_grp
        '
        Me.save_grp.DataPropertyName = "save"
        Me.save_grp.HeaderText = "Save"
        Me.save_grp.Name = "save_grp"
        Me.save_grp.Width = 40
        '
        'sent
        '
        Me.sent.DataPropertyName = "sent"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle1.NullValue = False
        Me.sent.DefaultCellStyle = DataGridViewCellStyle1
        Me.sent.HeaderText = "Sent"
        Me.sent.Name = "sent"
        Me.sent.ReadOnly = True
        Me.sent.Width = 40
        '
        'BindingSourceRepGroup
        '
        Me.BindingSourceRepGroup.DataSource = GetType(MassarelliOutBoundOrders.VLQ_SalesPersonList)
        '
        'VLQ_SalesPersonListDataGridView
        '
        Me.VLQ_SalesPersonListDataGridView.AllowUserToAddRows = False
        Me.VLQ_SalesPersonListDataGridView.AllowUserToDeleteRows = False
        Me.VLQ_SalesPersonListDataGridView.AllowUserToResizeRows = False
        Me.VLQ_SalesPersonListDataGridView.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.VLQ_SalesPersonListDataGridView.AutoGenerateColumns = False
        Me.VLQ_SalesPersonListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.VLQ_SalesPersonListDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.slspsn_no_slspsn, Me.slspsn_name_slspsn, Me.email_addr_slspsn, Me.user_def_fld_1_slspsn, Me.FilePathNameRep, Me.send_slspsn, Me.save_slspsn, Me.sent_rep})
        Me.VLQ_SalesPersonListDataGridView.DataSource = Me.VLQ_SalesPersonListBindingSource
        Me.VLQ_SalesPersonListDataGridView.Location = New System.Drawing.Point(15, 272)
        Me.VLQ_SalesPersonListDataGridView.Name = "VLQ_SalesPersonListDataGridView"
        Me.VLQ_SalesPersonListDataGridView.RowHeadersVisible = False
        Me.VLQ_SalesPersonListDataGridView.Size = New System.Drawing.Size(883, 238)
        Me.VLQ_SalesPersonListDataGridView.TabIndex = 7
        '
        'slspsn_no_slspsn
        '
        Me.slspsn_no_slspsn.DataPropertyName = "slspsn_no"
        Me.slspsn_no_slspsn.HeaderText = "Rep #"
        Me.slspsn_no_slspsn.Name = "slspsn_no_slspsn"
        Me.slspsn_no_slspsn.Width = 80
        '
        'slspsn_name_slspsn
        '
        Me.slspsn_name_slspsn.DataPropertyName = "slspsn_name"
        Me.slspsn_name_slspsn.HeaderText = "Rep Name"
        Me.slspsn_name_slspsn.Name = "slspsn_name_slspsn"
        Me.slspsn_name_slspsn.Width = 225
        '
        'email_addr_slspsn
        '
        Me.email_addr_slspsn.DataPropertyName = "email_addr"
        Me.email_addr_slspsn.HeaderText = "Email Address"
        Me.email_addr_slspsn.Name = "email_addr_slspsn"
        Me.email_addr_slspsn.Width = 250
        '
        'user_def_fld_1_slspsn
        '
        Me.user_def_fld_1_slspsn.DataPropertyName = "user_def_fld_1"
        Me.user_def_fld_1_slspsn.HeaderText = "Rep Group"
        Me.user_def_fld_1_slspsn.Name = "user_def_fld_1_slspsn"
        Me.user_def_fld_1_slspsn.Visible = False
        '
        'FilePathNameRep
        '
        Me.FilePathNameRep.DataPropertyName = "file_path_name"
        Me.FilePathNameRep.HeaderText = "File Path / Name"
        Me.FilePathNameRep.Name = "FilePathNameRep"
        Me.FilePathNameRep.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.FilePathNameRep.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.FilePathNameRep.Width = 175
        '
        'send_slspsn
        '
        Me.send_slspsn.DataPropertyName = "send"
        Me.send_slspsn.HeaderText = "Send"
        Me.send_slspsn.Name = "send_slspsn"
        Me.send_slspsn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.send_slspsn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.send_slspsn.Width = 40
        '
        'save_slspsn
        '
        Me.save_slspsn.DataPropertyName = "save"
        Me.save_slspsn.HeaderText = "Save"
        Me.save_slspsn.Name = "save_slspsn"
        Me.save_slspsn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.save_slspsn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.save_slspsn.Width = 40
        '
        'sent_rep
        '
        Me.sent_rep.DataPropertyName = "sent"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle2.NullValue = False
        Me.sent_rep.DefaultCellStyle = DataGridViewCellStyle2
        Me.sent_rep.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.sent_rep.HeaderText = "Sent"
        Me.sent_rep.Name = "sent_rep"
        Me.sent_rep.ReadOnly = True
        Me.sent_rep.Width = 40
        '
        'VLQ_SalesPersonListBindingSource
        '
        Me.VLQ_SalesPersonListBindingSource.DataSource = GetType(MassarelliOutBoundOrders.VLQ_SalesPersonList)
        '
        'ButtonCancel
        '
        Me.ButtonCancel.Image = Global.MassarelliOutBoundOrders.My.Resources.Resources.cancel
        Me.ButtonCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonCancel.Location = New System.Drawing.Point(15, 75)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(89, 24)
        Me.ButtonCancel.TabIndex = 7
        Me.ButtonCancel.Text = "Cancel"
        Me.ButtonCancel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonCancel.UseVisualStyleBackColor = True
        '
        'ButtonPrepare
        '
        Me.ButtonPrepare.Image = Global.MassarelliOutBoundOrders.My.Resources.Resources.Excel
        Me.ButtonPrepare.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonPrepare.Location = New System.Drawing.Point(15, 19)
        Me.ButtonPrepare.Name = "ButtonPrepare"
        Me.ButtonPrepare.Size = New System.Drawing.Size(89, 24)
        Me.ButtonPrepare.TabIndex = 5
        Me.ButtonPrepare.Text = "Prepare"
        Me.ButtonPrepare.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonPrepare.UseVisualStyleBackColor = True
        '
        'BindingSourceReps
        '
        Me.BindingSourceReps.DataSource = GetType(MassarelliOutBoundOrders.VLQ_SalesPersonList)
        '
        'TextBoxSendTo
        '
        Me.TextBoxSendTo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxSendTo.Location = New System.Drawing.Point(611, 136)
        Me.TextBoxSendTo.Name = "TextBoxSendTo"
        Me.TextBoxSendTo.Size = New System.Drawing.Size(286, 20)
        Me.TextBoxSendTo.TabIndex = 23
        '
        'CheckBoxSendTo
        '
        Me.CheckBoxSendTo.AutoSize = True
        Me.CheckBoxSendTo.Location = New System.Drawing.Point(366, 138)
        Me.CheckBoxSendTo.Name = "CheckBoxSendTo"
        Me.CheckBoxSendTo.Size = New System.Drawing.Size(225, 17)
        Me.CheckBoxSendTo.TabIndex = 24
        Me.CheckBoxSendTo.Text = "Override SEND TO with this email address"
        Me.CheckBoxSendTo.UseVisualStyleBackColor = True
        '
        'CheckBoxSendFrom
        '
        Me.CheckBoxSendFrom.AutoSize = True
        Me.CheckBoxSendFrom.Location = New System.Drawing.Point(366, 161)
        Me.CheckBoxSendFrom.Name = "CheckBoxSendFrom"
        Me.CheckBoxSendFrom.Size = New System.Drawing.Size(241, 17)
        Me.CheckBoxSendFrom.TabIndex = 25
        Me.CheckBoxSendFrom.Text = "Override SEND FROM with this email address"
        Me.CheckBoxSendFrom.UseVisualStyleBackColor = True
        '
        'TextBoxSendFrom
        '
        Me.TextBoxSendFrom.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxSendFrom.Location = New System.Drawing.Point(611, 159)
        Me.TextBoxSendFrom.Name = "TextBoxSendFrom"
        Me.TextBoxSendFrom.Size = New System.Drawing.Size(286, 20)
        Me.TextBoxSendFrom.TabIndex = 26
        '
        'ExcelEmailFileListBindingSource
        '
        Me.ExcelEmailFileListBindingSource.DataSource = GetType(MassarelliOutBoundOrders.ExcelEmailFileList)
        '
        'ExcelEmailFileListBindingSource2
        '
        Me.ExcelEmailFileListBindingSource2.DataSource = GetType(MassarelliOutBoundOrders.ExcelEmailFileList)
        '
        'ExcelEmailFileListBindingSource1
        '
        Me.ExcelEmailFileListBindingSource1.DataSource = GetType(MassarelliOutBoundOrders.ExcelEmailFileList)
        '
        'MassarelliOutBoundUtilitesBindingSource
        '
        Me.MassarelliOutBoundUtilitesBindingSource.DataSource = GetType(MassarelliOutBoundOrders.MassarelliOutBoundUtilites)
        '
        'ExcelEmailOptions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(932, 571)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Mas500Toolbar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ExcelEmailOptions"
        Me.Text = "Sent to Rep - Excel Email Options"
        Me.Mas500Toolbar.ResumeLayout(False)
        Me.Mas500Toolbar.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.pboxSave, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pboxSend, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VLQ_SalesRepGroupListDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSourceRepGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VLQ_SalesPersonListDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VLQ_SalesPersonListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSourceExcelEmailList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSourceReps, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ExcelEmailFileListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ExcelEmailFileListBindingSource2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ExcelEmailFileListBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MassarelliOutBoundUtilitesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Mas500Toolbar As System.Windows.Forms.ToolStrip
    Friend WithEvents ButtonExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ButtonSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents ButtonPrepare As System.Windows.Forms.Button
    Friend WithEvents ButtonCancel As System.Windows.Forms.Button
    Friend WithEvents BindingSourceRepGroup As System.Windows.Forms.BindingSource
    Friend WithEvents VLQ_SalesPersonListDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents VLQ_SalesPersonListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents VLQ_SalesRepGroupListDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents BindingSourceExcelEmailList As System.Windows.Forms.BindingSource
    Friend WithEvents ExcelEmailFileListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents MassarelliOutBoundUtilitesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ExcelEmailFileListBindingSource2 As System.Windows.Forms.BindingSource
    Friend WithEvents ExcelEmailFileListBindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents BindingSourceReps As System.Windows.Forms.BindingSource
    Friend WithEvents SendXL As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents SaveXL As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents pboxSend As System.Windows.Forms.PictureBox
    Friend WithEvents pboxSave As System.Windows.Forms.PictureBox
    Friend WithEvents ToolTipEmail As System.Windows.Forms.ToolTip
    Friend WithEvents ButtonSendSelection As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TextBoxMemo As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TextBoxSubject As System.Windows.Forms.TextBox
    Friend WithEvents slspsn_no_grp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents slspsn_name_grp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents email_addr_grp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents user_def_fld_1_grp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FilePathNameGrp As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents send_grp As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents save_grp As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents sent As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents slspsn_no_slspsn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents slspsn_name_slspsn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents email_addr_slspsn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents user_def_fld_1_slspsn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FilePathNameRep As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents send_slspsn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents save_slspsn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents sent_rep As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents TextBoxSendTo As System.Windows.Forms.TextBox
    Friend WithEvents CheckBoxSendTo As System.Windows.Forms.CheckBox
    Friend WithEvents TextBoxSendFrom As System.Windows.Forms.TextBox
    Friend WithEvents CheckBoxSendFrom As System.Windows.Forms.CheckBox
End Class
