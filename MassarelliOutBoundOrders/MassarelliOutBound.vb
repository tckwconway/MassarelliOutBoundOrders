Imports System.Data.SqlClient
Imports System.Data
Imports System.Text
Imports System.ComponentModel
Imports excel = Microsoft.Office.Interop.Excel
Imports System.Drawing
Imports System.Configuration
Imports System.Windows.Forms.ContextMenu
Imports System.Drawing.Printing
Imports MassarelliOutBoundOrders.Utilities.FTP
Imports System.Collections
Imports System.Collections.Generic
Imports System.Xml
Imports System.Xml.Schema
Imports System.IO
Imports System.Data.SqlTypes
Imports Microsoft.Office.Core
Imports Microsoft.Office.Interop
Imports System.Runtime.InteropServices.Marshal

Public Class MassarelliOutBound
    Implements IEnumerable


    Friend outboundlist As OutBoundList = New OutBoundList
    Friend outboundhistlist As OutBoundHistList = New OutBoundHistList
    Private outboundhistobj As OutBoundHistObj = New OutBoundHistObj
    Private outboundobj As OutBoundObj = New OutBoundObj
    Private masutil As MassarelliOutBoundUtilites = New MassarelliOutBoundUtilites
    Public reps As List(Of RepGroupObj) = New List(Of RepGroupObj)
    Public rep As RepGroupObj = New RepGroupObj
    Public bo As BusObj = New BusObj
    Private FTPClnt As Utilities.FTP.FTPclient = New Utilities.FTP.FTPclient
    Public appsettings As AppStoredSettings = New AppStoredSettings
    Private ContextMenuDataGridColumns As ContextMenuStrip
    Private ColumnOrderLst As List(Of OutboundColumnOrder)
    Private FindColName As String
    Private ResultList As List(Of OutboundColumnOrder)
    Private canCheck As Boolean
    Private isChecking As Boolean
    Private Cell As DataGridViewCell
    Private txt As String
    Public exporttype As Integer
    Public xlapp As excel.Application = New excel.Application

    Public Enum exporttypeenum
        pending = 0
        history = 1
    End Enum
    Public Enum returntypeRepOrGroup
        Rep = 0
        Group = 1
    End Enum
#Region "   Load Form    "

    Private Sub MassarelliOutBound_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            xlapp.Quit()
            While (ReleaseComObject(xlapp) <> 0)
            End While
        Catch ex As Exception
        Finally
            xlapp = Nothing
            GC.WaitForPendingFinalizers()
            GC.Collect()
            GC.WaitForPendingFinalizers()
            GC.Collect()
        End Try
    End Sub

    Private Sub MassarelliOutBound_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'msgbox("0")
        MacStartup()
        'msgbox("2")
        IsLoading = True
        'msgbox("3")
        GetRepGroups()
        'msgbox("4")
        GetExportPath()
        'msgbox("5")
        GetDefaultSettings() 'look at this one!
        'msgbox("6")
        'Setup the Grid based on default Pending Layout
        appsettings.PendingXMLDefault = ""
        appsettings.HistoryXMLDefault = ""
        'msgbox("7")
        ApplyColumnPreset(DataSource, appsettings.PendingXMLDefault)
        'msgbox("8")
        DataSource = "Pending"

        LoadDataGridColumns()
        'msgbox("9")
        'ContextMenuDataGridColumnsOpen()
        'msgbox("10")
        LoadGridColumnDefinitionsForCombobox()
        'msgbox("11")

        GetSalesRepsFromGroup(appsettings.DefaultRepGroup)
        'msgbox("12")
        Try
            RepListViewCheckItems(True)
        Catch ex As Exception
        End Try
        Me.Refresh()
        IsLoading = False
    End Sub


#End Region

#Region "  Controls   "

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        ClearGrid()
    End Sub

    'Private Sub btnExcelExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcelExport.Click

    '    ExportToExcel(exporttype)

    'End Sub

    Private Sub btnGetData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetData.Click
        Me.Validate()
        Me.Cursor = Cursors.WaitCursor
        If GetPropertyValues() = False Then Exit Sub

    End Sub

    Private Sub PictureBoxCalendar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBoxCalendarStart.Click, PictureBoxEndDate.Click
        Dim cal As PictureBox = DirectCast(sender, PictureBox)

        Dim p As Point
        Dim x As Integer = 0
        Dim y As Integer = 0
        Dim w As Integer = 0

        If Me.PanelCalendar.Visible = False Then
            Me.PanelCalendar.Visible = True
            Me.PanelCalendar.BringToFront()
            p = cal.FindForm.PointToClient(cal.Parent.PointToScreen(cal.Location))
            w = cal.Width
            With Me.PanelCalendar
                .Left = p.X + w
                .Top = p.Y
            End With
        Else
            Me.PanelCalendar.Visible = False
        End If

        If cal.Name = Me.PictureBoxCalendarStart.Name Then
            Me.StartDateSelected = True
        Else
            Me.StartDateSelected = False
        End If
    End Sub

    Private Sub PictureBoxExitCalendar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBoxExitCalendar.Click
        PanelCalendar.Hide()
    End Sub

    Private Sub ButtonGetData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGetData.Click
        If Me.TextBoxStartDate.Text = "" OrElse Me.TextBoxEndDate.Text = "" Then
            MsgBox("Start and/or End Dates appear to be empty", MsgBoxStyle.OkOnly, "Date Range Not Entered")
            Exit Sub
        End If

        Dim chk As Boolean = False
        For Each itm As ListViewItem In Me.ListViewSalesRepList.Items
            If itm.Checked = True Then
                chk = True
                Exit For
            End If
        Next
        If chk = False Then
            MsgBox("You much ckeck at least one Sales Rep from the Rep List", MsgBoxStyle.OkOnly, "Sales Reps Not Selected")
            Exit Sub
        End If

        Me.Validate()
        Me.Cursor = Cursors.WaitCursor
        Dim cbo As ComboBox = Me.ComboBoxColumnPresets
        GetPropertyValues()
        If GetPropertyValues() = False Then Exit Sub
        ClearGrid()
        Me.OutBoundObjDataGridView.DataSource = Nothing
        Me.OutBoundObjBindingSource.DataSource = outboundlist
        Me.OutBoundObjDataGridView.DataSource = Me.OutBoundObjBindingSource
        Me.OutBoundObjDataGridView.Refresh()
        Dim rps As String = GetRepsXMLParam()
        GetOutbound(rps)

        'Get the Column Preset to use
        appsettings.XMLFileName = cbo.SelectedItem
        'Load the Column Preset Selected by the User.  Retrieve the XML values, then set My.Settings based on the XML preset
        ApplyColumnPreset(appsettings.XMLFileName)
        'Using My.Settings, hide or show the columns.  
        LoadDataGridColumns()
        'LoadContextMenuItems()
        Me.Cursor = Cursors.Default
        Me.ExelExportToolStripButton.Enabled = True
        Me.ButtonGetData.Font = New Font("Microsoft Sans Serif", 8, FontStyle.Regular)
        Me.PictureBoxRefresh.Visible = False
    End Sub

    Private Sub ButtonClearAllCriteria_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClearAllCriteria.Click
        Me.TextBoxCustomerNo.Text = ""
        Me.TextBoxOrderNo.Text = ""
        If Me.TextBoxInvoice.Enabled = True Then Me.TextBoxInvoice.Text = ""
        Me.outboundhistlist.Clear()
        Me.outboundlist.Clear()
    End Sub

    Private Sub btnSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSettings.Click
        SettingsMas.Show()
    End Sub

    Private Sub ComboBoxRepGroup_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxRepGroup.DropDownClosed
        Dim cbo As ComboBox = DirectCast(sender, ComboBox)
        Dim sSQL As String
        Dim slsrepgrp As String
        txt = cbo.GetItemText(cbo.SelectedItem)
        GetSalesRepsFromGroup(txt)
        
        Me.ExelExportToolStripButton.Enabled = False

        Me.ButtonGetData.Font = New Font("Microsoft Sans Serif", 8, FontStyle.Bold)
        Me.PictureBoxRefresh.Visible = True

        If txt = "" Then
            Me.CheckBoxRepGroup.Checked = False
        Else
            Me.CheckBoxRepGroup.Checked = True
        End If
        RepListViewCheckItems(Me.CheckBoxRepGroup.Checked)
        Dim presettype As String = IIf(RadioButtonPending.Checked = True, "Pending", "History")
        Me.DataSource = presettype
        If ComboBoxRepGroup.SelectedValue Is Nothing Then slsrepgrp = "" Else slsrepgrp = ComboBoxRepGroup.SelectedValue.ToString
        sSQL = "Select count(*) from OEOBGRIDCOL_MAS where slsrep_grp = '" & slsrepgrp & "' "
        Dim repgroupexists As Integer = BusObj.ExecuteSQL_Scalar("Select count(*) from OEOBGRIDCOL_MAS where slsrep_grp = '" & slsrepgrp & "' ", cn)
        If repgroupexists > 0 Then
            sSQL = "Select top 1 IsNull(grid_col_layout_name, '') from OEOBGRIDCOL_MAS where slsrep_grp = '" & slsrepgrp & "' and preset_type = '" & presettype & "' "
        Else
            sSQL = "Select top 1 IsNull(grid_col_layout_name, '') from OEOBGRIDCOL_MAS where slsrep_grp = '' and preset_type = '" & presettype & "' "
        End If

        Dim xmlfilename As String = BusObj.ExecuteSQL_Scalar(sSQL, cn).ToString

        ComboBoxColumnPresets.Text = xmlfilename
        ApplyColumnSettings(xmlfilename)

    End Sub

    Private Sub ListViewSalesRepList_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles ListViewSalesRepList.ItemCheck
        'If IsEditing = False Then
        '    Dim lst As ListView = DirectCast(sender, ListView)

        '    Dim item As ListViewItem

        '    For Each item In lst.Items
        '        If Not item.Index = e.Index Then
        '            item.Checked = False
        '        End If

        '    Next
        'End If

    End Sub
    Private Function GetRepsXMLParam() As String
        Try
            Dim itm As ListViewItem
            Dim sRps() As String
            Dim i As Integer = -1
            For Each itm In Me.ListViewSalesRepList.Items
                If itm.Checked = True Then
                    i = i + 1
                    ReDim Preserve sRps(i)
                    sRps(i) = itm.SubItems(1).Text.Trim
                End If
            Next

            Dim xmlParam As String = AppUtilities.BuildXmlString("Reps", sRps)
            'xmlParam = "'" & xmlParam & "'"
            Return xmlParam

        Catch ex As Exception

        End Try

        Return Nothing
    End Function


    'Private Sub RadioButtonPending_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonPending.CheckedChanged, RadioButtonHistory.CheckedChanged
    '    MsgBox("1")
    '    Dim rb As RadioButton = DirectCast(sender, RadioButton)

    '    If rb.Name = Me.RadioButtonHistory.Name Then
    '        Select Case rb.Checked
    '            Case True
    '                Me.DataSource = "History"
    '                exporttype = exporttypeenum.history
    '            Case False
    '                Me.DataSource = "Pending"
    '                exporttype = exporttypeenum.pending
    '        End Select
    '        Me.TextBoxInvoice.Enabled = True
    '        Me.TextBoxInvoice.Text = ""

    '        Dim itm As Object
    '        For Each itm In ComboBoxColumnPresets.Items
    '            If itm.ToString.Substring(0, 7) = "Pending" Then
    '                Me.ComboBoxColumnPresets.SelectedItem = itm.ToString
    '            End If
    '        Next
    '    ElseIf rb.Name = Me.RadioButtonPending.Name Then
    '        Select Case rb.Checked
    '            Case True
    '                Me.DataSource = "Pending"
    '                exporttype = exporttypeenum.pending
    '            Case False
    '                Me.DataSource = "History"
    '                exporttype = exporttypeenum.history
    '        End Select
    '        Me.TextBoxInvoice.Enabled = False
    '        Me.TextBoxInvoice.Text = "(history only)"
    '    End If

    '    If Me.DataSource = "Pending" Then
    '        Dim itm As Object
    '        For Each itm In ComboBoxColumnPresets.Items
    '            If itm.ToString.Substring(0, 7) = "Pending" Then
    '                Me.ComboBoxColumnPresets.SelectedItem = itm.ToString
    '            End If
    '        Next
    '    Else
    '        Dim itm As Object
    '        For Each itm In ComboBoxColumnPresets.Items
    '            If itm.ToString.Substring(0, 7) = "History" Then
    '                Me.ComboBoxColumnPresets.SelectedItem = itm.ToString
    '            End If
    '        Next
    '    End If

    'End Sub

    Private Sub ComboBoxRepGroup_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ComboBoxRepGroup.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim cbo As ComboBox = DirectCast(sender, ComboBox)

            txt = cbo.GetItemText(cbo.SelectedItem)

            If txt > "" Then
                GetSalesRepsFromGroup(txt)
            End If
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        GetRepGroupList()
    End Sub
    Public Shared Function DataGridViewToDataTable(ByVal dtg As DataGridView, _
    Optional ByVal DataTableName As String = "myDataTable") As DataTable
        Try
            Dim dt As New DataTable(DataTableName)
            Dim row As DataRow
            Dim r As Integer = 0
            Dim TotalDatagridviewColumns As Integer = dtg.ColumnCount - 1
            'Add Datacolumn
            For Each c As DataGridViewColumn In dtg.Columns
                If c.Visible = True Then
                    Dim idColumn As DataColumn = New DataColumn()
                    idColumn.ColumnName = c.Name
                    dt.Columns.Add(idColumn)
                End If
            Next
            'Now Iterate thru Datagrid and create the data row

            For Each dr As DataGridViewRow In dtg.Rows
                'Iterate thru datagrid
                row = dt.NewRow 'Create new row
                'Iterate thru Column 1 up to the total number of columns
                For i As Integer = 0 To TotalDatagridviewColumns
                    If dtg.Columns(i).Visible = True Then
                        row.Item(r) = dr.Cells(i).Value.ToString
                        r = r + 1
                    End If
                Next
                'Now add the row to Datarow Collection
                dt.Rows.Add(row)
                r = 0
            Next
            'Now return the data table
            Return dt
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Private Sub ExportDataTableToExcel(ByVal dt As DataTable)

        Dim MaxRow As String = dt.Rows.Count
        Dim MaxCol As String = (Convert.ToChar(dt.Columns.Count \ 26 + 64).ToString() + Convert.ToChar(dt.Columns.Count Mod 26 + 64).ToString()).Replace("@", "").Trim

        Dim MaxCell As String = MaxCol & MaxRow
        Dim i As Integer ' = dt.Rows.Count
        Dim j As Integer ' = dt.Columns.Count

        ' Dim xlapp As excel.Application = New excel.Application
        xlapp.Visible = False
        Dim xlwrk As excel.Workbook = xlapp.Workbooks.Add(excel.XlWBATemplate.xlWBATWorksheet)
        Dim xlsht As excel.Worksheet = CType(xlwrk.Worksheets(1), excel.Worksheet)
        Dim xlrng As excel.Range
        'xlapp = 
        'xlapp.Visible = False
        ''xlwrk = excel.Workbook
        'Dim xlwbook As excel.Workbook = xlapp.Workbooks.Add(excel.XlWBATemplate.xlWBATWorksheet)
        'xlapp.Workbooks.Add(xlwrk)
        'xlsht = New excel.Worksheet
        'xlwrk.Worksheets.Add(xlsht)


        For i = 0 To dt.Columns.Count - 1
            xlsht.Cells(1, i + 1) = dt.Columns(i).ColumnName
        Next

        xlsht.Range("A1", MaxCol & "1").Font.Bold = True


        Dim values(dt.Rows.Count, dt.Columns.Count) As String

        For i = 0 To dt.Rows.Count - 1
            For j = 0 To dt.Columns.Count - 1
                values(i, j) = dt(i)(j).ToString
            Next
        Next


        xlsht.Range("A2", MaxCell).Value2 = values
        xlapp.Visible = True
        xlapp.UserControl = True

    End Sub

    Private Sub ButtonMaintaincolumnpresets_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonMaintaincolumnpresets.Click
        ColumnSettings.Show()
    End Sub

    Private Sub ComboBoxColumnPresets_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxColumnPresets.DropDownClosed
        Dim cbo As ComboBox = DirectCast(sender, ComboBox)

        'Get the Column Preset to use
        ApplyColumnSettings(cbo.SelectedItem)
        
    End Sub
    Private Sub ApplyColumnSettings(XMLFile As String)
        'Get the Column Preset to use
        appsettings.XMLFileName = XMLFile
        'Load the Column Preset Selected by the User.  Retrieve the XML values, then set My.Settings based on the XML preset
        ApplyColumnPreset(appsettings.XMLFileName)
        'Using My.Settings, hide or show the columns.  
        LoadDataGridColumns()
    End Sub
    Private Sub MonthCalendarDate_DateSelected(ByVal sender As Object, ByVal e As System.Windows.Forms.DateRangeEventArgs) Handles MonthCalendarDate.DateSelected
        Dim cal As MonthCalendar = DirectCast(sender, MonthCalendar)
        If Me.StartDateSelected = True Then
            Me.TextBoxStartDate.Text = Me.MonthCalendarDate.SelectionRange.Start.ToString("MM/dd/yyyy")
        Else
            Me.TextBoxEndDate.Text = Me.MonthCalendarDate.SelectionRange.Start.ToString("MM/dd/yyyy")
        End If
        Me.PanelCalendar.Visible = False
    End Sub

    Private Sub TextBoxStartDate_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBoxStartDate.KeyDown
        Dim txt As TextBox = DirectCast(sender, TextBox)

        If e.KeyCode = Keys.Enter Then
            SetTextBoxDate(txt)
        End If
    End Sub

    Private Sub TextBoxStartDate_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxStartDate.Leave, TextBoxEndDate.Leave
        Dim txt As TextBox = DirectCast(sender, TextBox)
        If txt.Text = "" Then
            Exit Sub
        Else
            SetTextBoxDate(txt)
        End If
    End Sub

#End Region

#Region "   Methods   "
    Public Sub New()
        'MsgBox("TEST")
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        'MsgBox("TEST1")

        ' Add any initialization after the InitializeComponent() call.
        ContextMenuDataGridColumns = New ContextMenuStrip
        AddHandler ContextMenuDataGridColumns.Opening, AddressOf ContextMenuDataGridColumns_Opening
        AddHandler ContextMenuDataGridColumns.ItemClicked, AddressOf ContextMenuDataGridColumns_ItemClicked
        'MsgBox("TEST3")

    End Sub

    'Private Function ExportToExcel(ByVal exporttype As Integer) As FTPFileList

    '    If Me.ComboBoxColumnPresets.Text = "" Then
    '        MessageBox.Show("A Column Preset has not been selected.  Choose a column preset from the dropdown box and try again.", "Column Preset", MessageBoxButtons.OK)
    '        Return Nothing

    '    End If

    '    Dim dgv As DataGridView = Me.OutBoundObjDataGridView
    '    If exporttype = 0 Then

    '    End If
    '    Dim dt As DataTable = ExcelExport.DataGridViewToDataTable(dgv, exporttype, "", "", "")

    '    ExcelExport.ExportToExcel(exporttype, Me.OutBoundObjDataGridView)
    '    'Return 
    'End Function

    Private Sub GetRepGroups()
        Dim rd As SqlDataReader
        Dim ssql As String = "Select Distinct RepGroup from VLQ_SalesRepGroupList2012 order by RepGroup"
        rd = outboundobj.GetRepGroups(ssql, cn)

        'Add a blank entry to the ComboBox for selecting 'None' for the Rep Group, but only to the ComboBox on Startup.  
        If IsLoading = True Then
            rep = New RepGroupObj
            reps.Add(rep)
        End If

        'Read the RepGroup Values into the Combo Box.  
        While rd.Read
            rep = New RepGroupObj
            rep.RepGroup = (rd(0).ToString.Trim)
            reps.Add(rep)
        End While

        rd.Close()

        'Assign the data source for the RepGroup to the ComboBox
        Me.ComboBoxRepGroup.DataSource = reps
        Me.ComboBoxRepGroup.DisplayMember = "RepGroup"
        Me.ComboBoxRepGroup.ValueMember = "RepGroup"

        rd.Close()
        rd = Nothing
    End Sub
    Private Sub GetSalesRepsFromGroup(ByVal RepGroup As String)

        'TODO - Put This One Back
        Dim srplst As New List(Of VLQ_SalesPersonList)
        srplst = GetRepList(RepGroup, returntypeRepOrGroup.Rep)
        Dim lv As ListView = Me.ListViewSalesRepList
        Dim lvi As New ListViewItem
        lv.Items.Clear()
        For Each itm As VLQ_SalesPersonList In srplst
            lv.BeginUpdate()
            lvi = New ListViewItem
            lvi.Text = itm.slspsn_name.Trim
            lvi.SubItems.Add(itm.slspsn_no.Trim)
            lv.Items.Add(lvi)
            lv.EndUpdate()
            lv.Refresh()
        Next
    End Sub
    Private Sub GetDefaultSettings()
        Dim rd As SqlDataReader
        rd = appsettings.LoadSettings(cn)
        If rd.HasRows Then

            While rd.Read
                If rd("ob_file_path") Is DBNull.Value Then appsettings.Path = "" Else appsettings.Path = rd("ob_file_path")
                If rd("ob_rep_organization") Is DBNull.Value Then appsettings.DefaultRepGroup = "" Else appsettings.DefaultRepGroup = rd("ob_rep_organization")
                If rd("ob_rep_save_excel_folder") Is DBNull.Value Then appsettings.RepSaveExcelFolderPath = "" Else appsettings.RepSaveExcelFolderPath = rd("ob_rep_save_excel_folder")
                If rd("ob_email_dflt_from") Is DBNull.Value Then appsettings.RepSaveExcelFolderPath = "" Else appsettings.FromEmail = rd("ob_email_dflt_from")
                If rd("ob_ftp_upload_location") Is DBNull.Value Then appsettings.FTPUploadLocation = "" Else appsettings.FTPUploadLocation = rd("ob_ftp_upload_location")
                If rd("ob_ftp_host") Is DBNull.Value Then appsettings.FTPHost = "" Else appsettings.FTPHost = rd("ob_ftp_host")
                If rd("ob_ftp_port") Is DBNull.Value Then appsettings.FTPPort = "" Else appsettings.FTPPort = rd("ob_ftp_port")
                If rd("ob_ftp_username") Is DBNull.Value Then appsettings.FTPUserName = "" Else appsettings.FTPUserName = rd("ob_ftp_username")
                If rd("ob_ftp_password") Is DBNull.Value Then appsettings.FTPPassword = "" Else appsettings.FTPPassword = rd("ob_ftp_password")
            End While

        End If

        rd.Close()

        Me.ComboBoxRepGroup.Text = appsettings.DefaultRepGroup


    End Sub

    Private Sub GetExportPath()
        Dim sql As String

        sql = "Select ob_file_path from OEOBSETTINGS2012_MAS "
        appsettings.Path = BusObj.ExecuteSQL_Scalar_ReturnString(sql, cn)

    End Sub

    Private Sub ClearGrid()
        Try
            Me.outboundlist.Clear()
            Me.outboundhistlist.Clear()
        Catch ex As Exception
            'MsgBox("Error at the ClearGrid subrouting for outboundlist and outboundhistlist.  Error is .
        End Try

    End Sub

    Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator

    End Function

    Private Function GetPropertyValues() As Boolean
        GetPropertyValues = True

        If StartDT > 0 And EndDT = 0 Then
            MsgBox("Start Date and End Date must have a value")
            GetPropertyValues = False
            Exit Function
        Else
            GetPropertyValues = True
        End If
        Me.OrderNo = ""
        Me.CustomerNo = ""
        Me.InvoiceNo = 0
        Me.RepGroup = ""
        Me.StartDT = 0
        Me.EndDT = 0
        Me.SearchType = ""
        Me.SalesRepNo = ""
        Try
            Me.StartDT = GetDateInteger(CDate(Me.TextBoxStartDate.Text))
            Me.EndDT = GetDateInteger(CDate(Me.TextBoxEndDate.Text))
            If Me.TextBoxOrderNo.Text > "" Then Me.OrderNo = PackZeros(TextBoxOrderNo.Text, 8)
            If Me.TextBoxCustomerNo.Text > "" Then Me.CustomerNo = PackZeros(TextBoxCustomerNo.Text, 12)
            If Me.TextBoxInvoice.Enabled = True Then
                If IsNumeric(Me.TextBoxInvoice.Text) Then
                    Me.InvoiceNo = Convert.ToInt32(Me.TextBoxInvoice.Text)
                Else
                    Me.InvoiceNo = 0
                End If
            End If

            Me.RepGroup = Me.ComboBoxRepGroup.Text

            Dim itm As ListViewItem
            For Each itm In Me.ListViewSalesRepList.Items
                If itm.Checked = True Then
                    Me.SalesRepNo = itm.SubItems(1).Text
                End If
            Next


            If Me.StartDT > 0 Then Me.SearchType = "DATE"
            If Me.OrderNo > "" Then Me.SearchType = Me.SearchType & "ORDNO"
            If Me.CustomerNo > "" Then Me.SearchType = Me.SearchType & "CUST"
            If Me.InvoiceNo > 0 Then Me.SearchType = Me.SearchType & "INVC"

        Catch ex As Exception

        End Try

    End Function

    Private Function GetDateInteger(ByVal dtpDate As Date) As Integer
        Dim yr As String
        Dim mo As String
        Dim dy As String

        yr = dtpDate.Year.ToString
        mo = dtpDate.Month.ToString("0#")
        dy = dtpDate.Day.ToString("0#")

        Return Convert.ToInt32(yr & mo & dy)

    End Function

    Private Function PackZeros(ByVal txtvalue As String, ByVal numbertopack As Integer) As String
        txtvalue = "00000000000000000000" & txtvalue
        txtvalue = txtvalue.Substring(txtvalue.Length - numbertopack)

        Return txtvalue
    End Function

    Private Sub SetTextBoxDate(ByVal txt As TextBox)
        Dim dttxt As String = ""
        Me.PanelCalendar.Visible = False
        If IsDate(txt.Text) = True Then Exit Sub
        If IsDate(txt.Text) = False Then
            Try
                dttxt = txt.Text.Substring(4, 2) & "/" & txt.Text.Substring(6, 2) & "/" & txt.Text.Substring(0, 4)
            Catch ex As Exception
                MsgBox("Date entered, " & txt.Text & " does not appear to be a date.", MsgBoxStyle.OkOnly, "Invalid Date Entry")
            End Try

        End If
        If IsDate(dttxt) <> True Then
            MsgBox("Date entered, " & txt.Text & " does not appear to be a date.", MsgBoxStyle.OkOnly, "Invalid Date Entry")
        Else
            txt.Text = dttxt
        End If
    End Sub

    Private Sub Reset_MassarelliOutboundBindingSource()
        MassarelliOutBoundUtilitesBindingSource.DataSource = masutil
        Me.SearchPropertyNameTextBox.DataBindings("Text").ReadValue()
        Me.SearchPropertyValueTextBox.DataBindings("Text").ReadValue()
        Me.SearchPropertyNameTextBox.Refresh()
        Me.SearchPropertyValueTextBox.Refresh()

    End Sub

    Private Sub GetOutbound(ByVal SelectedReps As String)
        Dim rd As SqlDataReader


        If DataSource = "Pending" Then
            rd = outboundobj.GetOutboundData(StartDT, EndDT, OrderNo, InvoiceNo, CustomerNo, RepGroup, SearchType, DataSource, SelectedReps, cn)
            Try
                If rd.HasRows = False Then
                    MsgBox("No outbound orders found. ", MsgBoxStyle.OkOnly, "Outbound Orders Not Found")
                    If rd IsNot Nothing Then rd.Close()
                    rd = Nothing
                    Exit Sub
                End If
            Catch ex As Exception
                MsgBox("No outbound orders found. ", MsgBoxStyle.OkOnly, "Outbound Orders Not Found")
                If rd IsNot Nothing Then rd.Close()
                rd = Nothing
                Exit Sub
            End Try
            Try
                outboundlist = outboundobj.PopulateOutBoundObj(rd)

                If outboundlist Is Nothing Then
                    MsgBox("Error in Outbound Pending List.", MsgBoxStyle.OkOnly, "Error in Outbound Pending List")
                    rd.Close()
                    Exit Sub
                End If
            Catch ex As Exception
                MsgBox("Error in Outbound Pending List.", MsgBoxStyle.OkOnly, "Error in Outbound Pending List")
                MsgBox(ex.Message)
                rd.Close()
                Exit Sub
            End Try


            If outboundlist.Count = 0 Or outboundlist Is Nothing Then
                MsgBox("No outbound orders found. ", MsgBoxStyle.OkOnly, "Outbound Orders Not Found")
                If rd IsNot Nothing Then rd.Close()
                rd = Nothing
                Exit Sub
            Else
                Me.OutBoundObjDataGridView.Columns.Clear()
                Dim info() As System.Reflection.PropertyInfo = outboundhistobj.GetType().GetProperties
                Dim p As System.Reflection.PropertyInfo
                Dim c As DataGridViewColumn
                Dim j As Integer = -1
                Dim i As Integer = 1
                ColumnOrderLst = Me.GetColumnOrderList(DataSource)
                OutBoundObjDataGridView.Columns.Clear()
                For Each p In info
                    If p.CanRead Then
                        FindColName = p.Name
                        j = CInt(FindAllColumns())
                        If j >= 0 Then
                            c = FormatDataGridView(p.Name, p.PropertyType.ToString, p.Name, p.Name, j)
                            Me.OutBoundObjDataGridView.Columns.Add(c)
                            i = i + 1
                        End If
                    End If
                Next
                'FormatDataGridColOrder(DataSource)
                Me.OutBoundObjBindingSource.DataSource = outboundlist
                Me.OutBoundObjDataGridView.DataSource = Me.OutBoundObjBindingSource
            End If
        Else

            rd = outboundobj.GetOutboundData(StartDT, EndDT, OrderNo, InvoiceNo, CustomerNo, RepGroup, SearchType, DataSource, SelectedReps, cn)
            'If rd Is Nothing Then
            '    MsgBox("No Outbound Orders found for the criteria", MsgBoxStyle.OkOnly, "Outbound Orders")
            '    rd.Close()
            '    Exit Sub
            'End If
            If (rd Is Nothing) OrElse (rd.HasRows = False) Then
                MsgBox("No Outbound Orders found for the criteria", MsgBoxStyle.OkOnly, "Outbound Orders")
                If rd IsNot Nothing Then rd.Close()
                Exit Sub
            End If
            outboundhistlist = outboundhistobj.PopulateOutBoundHistObj(rd)

            If outboundhistlist Is Nothing Then
                MsgBox("Error in Outbound History List.", MsgBoxStyle.OkOnly, "Error in Outbound History List")
                Exit Sub
            End If

            If outboundhistlist.Count = 0 Or outboundhistlist Is Nothing Then
                MsgBox("No outbound orders found. ", MsgBoxStyle.OkOnly, "Outbound Orders Not Found")
                If rd IsNot Nothing Then rd.Close()
                rd = Nothing
                Exit Sub
            Else
                Me.OutBoundObjDataGridView.Columns.Clear()
                Dim info() As System.Reflection.PropertyInfo = outboundhistobj.GetType().GetProperties
                Dim p As System.Reflection.PropertyInfo
                Dim c As DataGridViewColumn
                Dim j As Integer
                Dim i As Integer = 1
                ColumnOrderLst = Me.GetColumnOrderList(DataSource)
                'FormatDataGridColOrder(DataSource)
                OutBoundObjDataGridView.Columns.Clear()
                For Each p In info
                    If p.CanRead Then
                        FindColName = p.Name
                        j = CInt(FindAllColumns())
                        c = FormatDataGridView(p.Name, p.PropertyType.ToString, p.Name, p.Name, j)
                        Me.OutBoundObjDataGridView.Columns.Add(c)
                        i = i + 1
                    End If
                Next

                Me.OutBoundObjBindingSource.DataSource = outboundhistlist
                Me.OutBoundObjDataGridView.DataSource = Me.OutBoundObjBindingSource
            End If
        End If
        Try
            If rd IsNot Nothing Then rd.Close()
            rd = Nothing
            Exit Sub
        Catch ex As Exception

        End Try

        rd = Nothing

        SetColumnDisplayIndex()

        'LoadContextMenuItems()

    End Sub

    Friend Function GetRepList(ByVal repslst As List(Of String)) As List(Of VLQ_SalesPersonList)
        Dim dc As New LQ_SalesPersonListDataContext(cn)

        Dim srplst = _
    (From r In dc.VLQ_SalesPersonLists _
     Where repslst.Contains(r.slspsn_name.Trim) _
     Order By r.slspsn_name _
     Select r).ToList

        Return srplst

    End Function

    Friend Function GetRepGroupList() As List(Of VLQ_SalesRepGroupList)
        Dim dc As New LQ_SalesRepGroupListDataContext(cn)

        Dim sgrplst = _
    (From r In dc.VLQ_SalesRepGroupLists _
     Order By r.user_def_fld_1 _
     Select r).ToList

        Return sgrplst

    End Function

    Friend Function GetRepList() As List(Of VLQ_SalesPersonList)
        Dim dc As New LQ_SalesPersonListDataContext(cn)
        Dim srplst = _
    (From r In dc.VLQ_SalesPersonLists _
     Where r.user_def_fld_1 = r.slspsn_name _
     And Not r.user_def_fld_1 = "house" _
     Order By r.slspsn_name _
     Select r).ToList

        Return srplst

    End Function
    Friend Function GetRepList(ByVal RepGroup As String, ByVal ReturnTypeRepOrGroup As Integer) As List(Of VLQ_SalesPersonList)
        Dim dc As New LQ_SalesPersonListDataContext(cn)

        If ReturnTypeRepOrGroup = 0 Then 'Rep List Return Type

            If RepGroup > "" Then 'Return Replist from a single RepGroup
                Dim srplst = _
                (From r In dc.VLQ_SalesPersonLists _
                 Where r.user_def_fld_1.StartsWith(RepGroup) _
                 Order By r.slspsn_name _
                 Select r).ToList
                Return srplst
            Else 'Return ALL Reps to the Replist, no RepGroup
                Dim srplst = _
                (From r In dc.VLQ_SalesPersonLists _
                 Order By r.slspsn_name _
                 Select r).ToList
                Return srplst
            End If



        Else 'RepGroup List Return Type
            Dim srplst = _
            (From r In dc.VLQ_SalesPersonLists _
             Where r.user_def_fld_1.StartsWith(RepGroup) _
             And r.user_def_fld_1 = r.slspsn_name _
             Order By r.slspsn_name _
             Select r).ToList

            Return srplst

        End If

    End Function

    Friend Function GetRepList(ByVal RepGroup As String, ByVal RepName As String) As List(Of VLQ_SalesPersonList)
        Dim dc As New LQ_SalesPersonListDataContext(cn)
        Dim srplst = _
    (From r In dc.VLQ_SalesPersonLists _
     Where r.user_def_fld_1.StartsWith(RepGroup) And r.slspsn_name.StartsWith(RepName) _
     Order By r.slspsn_name _
     Select r).ToList

        Return srplst

    End Function

    Public Function GetRepListForEmail(ByVal exporttype As Integer) As List(Of String)
        Dim replst As New List(Of String)
        Dim rep As String = ""
        Dim otbdlst As OutBoundList = outboundlist
        Dim otbdobj As OutBoundObj
        Dim otbdhstlst As OutBoundHistList = outboundhistlist
        Dim otbdhstobj As OutBoundHistObj
        'Dim r As Integer
        If exporttype = exporttypeenum.pending Then
            For Each otbdobj In otbdlst
                rep = otbdobj.SalesPersonName
                If replst.Contains(rep) = False Then
                    replst.Add(rep)
                End If
            Next
        ElseIf exporttype = exporttypeenum.history Then
            For Each otbdhstobj In otbdhstlst
                rep = otbdhstobj.SalesPersonName
                If replst.Contains(rep) = False Then
                    replst.Add(rep)
                End If
            Next
        End If

        Return replst

    End Function

#End Region

#Region "   Properties   "

    Private mStartDT As Integer
    Public Property StartDT() As Integer
        Get
            Return mStartDT
        End Get
        Set(ByVal value As Integer)
            mStartDT = value
        End Set
    End Property

    Private mEndDT As Integer
    Public Property EndDT() As Integer
        Get
            Return mEndDT
        End Get
        Set(ByVal value As Integer)
            mEndDT = value
        End Set
    End Property


    Private mOrderNo As String
    Public Property OrderNo() As String
        Get
            Return mOrderNo
        End Get
        Set(ByVal value As String)
            mOrderNo = value
        End Set
    End Property

    Private mCustomerNo As String
    Public Property CustomerNo() As String
        Get
            Return mCustomerNo
        End Get
        Set(ByVal value As String)
            mCustomerNo = value
        End Set
    End Property


    Private mRepGroup As String
    Public Property RepGroup() As String
        Get
            Return mRepGroup
        End Get
        Set(ByVal value As String)
            mRepGroup = value
        End Set
    End Property


    Private mSearchType As String
    Public Property SearchType() As String
        Get
            Return mSearchType
        End Get
        Set(ByVal value As String)
            mSearchType = value
        End Set
    End Property

    Private mDataSource As String
    Public Property DataSource() As String
        Get
            Return mDataSource
        End Get
        Set(ByVal value As String)
            mDataSource = value
        End Set
    End Property

    Private mInvoiceNo As Integer
    Public Property InvoiceNo() As Integer
        Get
            Return mInvoiceNo
        End Get
        Set(ByVal value As Integer)
            mInvoiceNo = value
        End Set
    End Property

    Private mStartDateSelected As Boolean
    Public Property StartDateSelected() As Boolean
        Get
            Return mStartDateSelected
        End Get
        Set(ByVal value As Boolean)
            mStartDateSelected = value
        End Set
    End Property

    Private mSalesRepNo As String
    Public Property SalesRepNo() As String
        Get
            Return mSalesRepNo
        End Get
        Set(ByVal value As String)
            mSalesRepNo = value
        End Set
    End Property

    Private mIsLoading As Boolean
    Public Property IsLoading() As Boolean
        Get
            Return mIsLoading
        End Get
        Set(ByVal value As Boolean)
            mIsLoading = value
        End Set
    End Property


    Private mIsEditing As Boolean
    Public Property IsEditing() As Boolean
        Get
            Return mIsEditing
        End Get
        Set(ByVal value As Boolean)
            mIsEditing = value
        End Set
    End Property

#End Region

#Region "   Format Datagridview   "

    'Sets the column visible based on My.Settings value for each field.  
    'Adds columns to the Check Box enabled Context Menu accessed from right Clicking the DataGridView column Header
    Private Sub LoadDataGridColumns()


        Dim col As DataGridViewColumn
        Dim itms As System.Windows.Forms.ToolStripItemCollection = Me.ContextMenuDataGridColumns.Items
        Dim itm As New ToolStripMenuItem
        Dim idx As Integer = 0
        Dim nextidx As Integer = 0

        For Each col In Me.OutBoundObjDataGridView.Columns
            'Add column names to context menu, then set the visibility of each column based on values in My.Settings
            With Me.ContextMenuDataGridColumns
                .Items.Add(col.Name.ToString)
                'Set the visibility of each column based on My.Settings value for each field.  
                Try
                    col.Visible = CBool(My.Settings(col.Name).ToString)
                Catch ex As Exception

                End Try

            End With
        Next

        'Create the Display Index Sort List(of ColumnDisplayIndexSort).  This puts the FieldName and Display index together - BUT Based on Visibility, only using Visible columns to be used to arrange the columns according to the Display Index rather than Index.
        Dim colList As New List(Of ColumnDisplayIndexSort)
        For Each col In Me.OutBoundObjDataGridView.Columns
            If col.Visible = True Then
                colList.Add(New ColumnDisplayIndexSort(col.Name, col.DisplayIndex))
            End If

        Next

        'Sort the columns in the colList - This sort does NOT remove hidden
        colList.Sort(AddressOf ColumnDisplayIndexSort.SortColumns)
        'Show what it looks like....
        For Each o As ColumnDisplayIndexSort In colList
            Debug.Print(o.DisplayIndex.ToString & " - " & o.ColName)
        Next
        'Set the Display index to a the actual numeric value
        Dim id As Integer = 0
        For Each o As ColumnDisplayIndexSort In colList
            colList(id).DisplayIndex = id
            id = id + 1
            Debug.Print(o.DisplayIndex.ToString & " - " & o.ColName)
        Next


    End Sub

    'Formats the column data type, string, decimal, date...etc
    Private Function FormatDataGridView(ByVal PropName As String, ByVal PropType As String, ByVal Name As String, ByVal HeaderText As String, ByVal DisplayIndex As Integer) As DataGridViewTextBoxColumn

        Dim coltxt As New DataGridViewTextBoxColumn

        coltxt.DataPropertyName = PropName

        If PropType = "System.Decimal" Then
            coltxt.DefaultCellStyle.Format = "N2"
        ElseIf PropType = "System.DateTime" Then
            coltxt.DefaultCellStyle.Format = "MM/dd/yyyy"
        ElseIf PropType = "System.Integer" Then
            coltxt.DefaultCellStyle.Format = "N"
        End If

        coltxt.DisplayIndex = DisplayIndex
        coltxt.Name = Name
        coltxt.HeaderText = HeaderText
        coltxt.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

        Return coltxt

    End Function

    'Removes all columns from DataGridView, then adds them back in the DisplayIndex order.  
    Private Function ApplyColumnOrder() As List(Of OutboundColumnOrder)

        Me.OutBoundObjDataGridView.Columns.Clear()
        Dim info() As System.Reflection.PropertyInfo = outboundhistobj.GetType().GetProperties
        Dim p As System.Reflection.PropertyInfo
        Dim c As DataGridViewColumn
        Dim j As Integer = -1
        Dim i As Integer = 1
        'ColumnOrderLst list(of T) is the pre-defined fixed order with FieldName  and DisplayIndex together
        ColumnOrderLst = Me.GetColumnOrderList(DataSource)
        'OutBoundObjDataGridView.Columns.Clear()
        For Each p In info
            If p.CanRead Then
                FindColName = p.Name
                j = CInt(FindAllColumns())
                If j >= 0 Then
                    c = FormatDataGridView(p.Name, p.PropertyType.ToString, p.Name, p.Name, j)
                    Me.OutBoundObjDataGridView.Columns.Add(c)
                    i = i + 1
                End If
            End If
        Next
        'FormatDataGridColOrder(DataSource)
        Return ColumnOrderLst

    End Function
    'FindAllColumns is Called by ApplyColumnOrder
    Private Function FindAllColumns() As String
        Try
            Dim sublist As New List(Of OutboundColumnOrder)
            sublist = ColumnOrderLst.FindAll(AddressOf findColumn)
            For Each r As OutboundColumnOrder In sublist

                Return r.Idx

            Next
            Return "-1"
        Catch ex As Exception
            Return Nothing
        End Try

    End Function

    Function findColumn(ByVal c As OutboundColumnOrder) _
      As Boolean
        If (c.Col = FindColName) Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub SetColumnDisplayIndex()
        Dim col As DataGridViewColumn
        Dim j As Integer
        For Each col In OutBoundObjDataGridView.Columns

            FindColName = col.DataPropertyName
            j = CInt(FindAllColumns())
            col.DisplayIndex = j
        Next

    End Sub

    Private Sub ApplyColumnPreset(ByVal columnpresetname As String, Optional ByVal columnpresetXML As String = "")
        Dim col As String = ""
        Dim val As String = ""
        Dim xmlstr As String = ""
        Dim rd As SqlDataReader

        If columnpresetXML = "" Then
            rd = BusObj.ExecuteSQLReader("Select grid_col_layout_xml from OEOBGRIDCOL_MAS where grid_col_layout_name = '" & columnpresetname & "'", cn)
            While rd.Read
                xmlstr = rd(0)
            End While
            rd.Close()
        Else
            xmlstr = columnpresetXML
        End If
        Using rdr As XmlTextReader = New XmlTextReader(xmlstr, XmlNodeType.Element, Nothing)
            Dim bValue As Boolean = False
            While rdr.Read()
                If rdr.IsStartElement Then
                    If rdr.Name = "Name" Then
                        col = rdr.ReadElementContentAsObject.ToString
                        'If col.Contains("Description") Then
                        '    MsgBox("STOP")
                        'End If
                        bValue = True
                    End If
                ElseIf bValue = True Then
                    val = rdr.Value.ToString
                    My.Settings(col) = CBool(val)
                    bValue = False
                End If

            End While
            rdr.Close()
        End Using



    End Sub

    Private Function GetColumnOrderList(ByVal outboundType As String) As List(Of OutboundColumnOrder)
        Dim colord As New List(Of OutboundColumnOrder)

        If outboundType = "Pending" Then
            colord.Add(New OutboundColumnOrder("Company", "0"))
            colord.Add(New OutboundColumnOrder("SalesAmt_SubTotal", "1"))
            colord.Add(New OutboundColumnOrder("Freight", "2"))
            colord.Add(New OutboundColumnOrder("SalesAmt", "3"))
            colord.Add(New OutboundColumnOrder("ShipViaDesc", "4"))
            colord.Add(New OutboundColumnOrder("ShipDate", "5"))
            colord.Add(New OutboundColumnOrder("Terms", "6"))
            colord.Add(New OutboundColumnOrder("OrderNumber", "7"))
            colord.Add(New OutboundColumnOrder("PONumber", "8"))
            colord.Add(New OutboundColumnOrder("BillToNo", "9"))
            colord.Add(New OutboundColumnOrder("BillToName", "10"))
            colord.Add(New OutboundColumnOrder("BillToAddr1", "11"))
            colord.Add(New OutboundColumnOrder("BillToAddr2", "12"))
            colord.Add(New OutboundColumnOrder("BillToCity", "13"))
            colord.Add(New OutboundColumnOrder("BillToState", "14"))
            colord.Add(New OutboundColumnOrder("BillToZip", "15"))
            colord.Add(New OutboundColumnOrder("ShipToNo", "16"))
            colord.Add(New OutboundColumnOrder("ShipToName", "17"))
            colord.Add(New OutboundColumnOrder("ShipToAddr1", "18"))
            colord.Add(New OutboundColumnOrder("ShipToAddr2", "19"))
            colord.Add(New OutboundColumnOrder("ShipToCity", "20"))
            colord.Add(New OutboundColumnOrder("ShipToState", "21"))
            colord.Add(New OutboundColumnOrder("ShipToZip", "22"))
            colord.Add(New OutboundColumnOrder("Qty", "23"))
            colord.Add(New OutboundColumnOrder("ItemNo", "24"))
            colord.Add(New OutboundColumnOrder("ItemDescription", "25"))
            colord.Add(New OutboundColumnOrder("UOM", "26"))
            colord.Add(New OutboundColumnOrder("Finish", "27"))
            colord.Add(New OutboundColumnOrder("UnitPrice", "28"))
            colord.Add(New OutboundColumnOrder("ExtendedPrice", "29"))
            colord.Add(New OutboundColumnOrder("Discount", "30"))
            colord.Add(New OutboundColumnOrder("ShippingInstruction", "31"))
            colord.Add(New OutboundColumnOrder("SalesPersonNo", "32"))
            colord.Add(New OutboundColumnOrder("SalesPersonName", "33"))
            colord.Add(New OutboundColumnOrder("SalesRepGroup", "34"))

        ElseIf outboundType = "History" Then
            colord.Add(New OutboundColumnOrder("Company", "0"))
            colord.Add(New OutboundColumnOrder("SalesAmt_SubTotal", "1"))
            colord.Add(New OutboundColumnOrder("Freight", "2"))
            colord.Add(New OutboundColumnOrder("SalesAmt", "3"))
            colord.Add(New OutboundColumnOrder("ShipViaDesc", "4"))
            colord.Add(New OutboundColumnOrder("ShipDate", "5"))
            colord.Add(New OutboundColumnOrder("Terms", "6"))
            colord.Add(New OutboundColumnOrder("OrderNumber", "7"))
            colord.Add(New OutboundColumnOrder("PONumber", "8"))
            colord.Add(New OutboundColumnOrder("InvoiceNumber", "9"))
            colord.Add(New OutboundColumnOrder("InvoiceDate", "10"))
            colord.Add(New OutboundColumnOrder("InvoiceAmount", "11"))
            colord.Add(New OutboundColumnOrder("BillToNo", "12"))
            colord.Add(New OutboundColumnOrder("BillToName", "13"))
            colord.Add(New OutboundColumnOrder("BillToAddr1", "14"))
            colord.Add(New OutboundColumnOrder("BillToAddr2", "15"))
            colord.Add(New OutboundColumnOrder("BillToCity", "16"))
            colord.Add(New OutboundColumnOrder("BillToState", "17"))
            colord.Add(New OutboundColumnOrder("BillToZip", "18"))
            colord.Add(New OutboundColumnOrder("ShipToNo", "19"))
            colord.Add(New OutboundColumnOrder("ShipToName", "20"))
            colord.Add(New OutboundColumnOrder("ShipToAddr1", "21"))
            colord.Add(New OutboundColumnOrder("ShipToAddr2", "22"))
            colord.Add(New OutboundColumnOrder("ShipToCity", "23"))
            colord.Add(New OutboundColumnOrder("ShipToState", "24"))
            colord.Add(New OutboundColumnOrder("ShipToZip", "25"))
            colord.Add(New OutboundColumnOrder("Qty", "26"))
            colord.Add(New OutboundColumnOrder("ItemNo", "27"))
            colord.Add(New OutboundColumnOrder("ItemDescription", "28"))
            colord.Add(New OutboundColumnOrder("UOM", "29"))
            colord.Add(New OutboundColumnOrder("Finish", "30"))
            colord.Add(New OutboundColumnOrder("UnitPrice", "31"))
            colord.Add(New OutboundColumnOrder("ExtendedPrice", "32"))
            colord.Add(New OutboundColumnOrder("Discount", "33"))
            colord.Add(New OutboundColumnOrder("ShippingInstruction", "34"))
            colord.Add(New OutboundColumnOrder("SalesPersonNo", "35"))
            colord.Add(New OutboundColumnOrder("SalesPersonName", "36"))
            colord.Add(New OutboundColumnOrder("SalesRepGroup", "37"))

        End If

        Return colord




    End Function


    Private Sub SaveColumnLayoutXML(ByVal FilePathAndName As String)
        Dim doc As New XmlDocument

        Dim settings As XmlWriterSettings = New XmlWriterSettings()
        settings.Indent = True
        'Dim filename As StrongTypingEx
        Try
            Using writer As XmlWriter = XmlWriter.Create(FilePathAndName, settings)
                writer.WriteStartDocument()
                writer.WriteStartElement("Columns")

                Dim col As DataGridViewColumn

                For Each col In OutBoundObjDataGridView.Columns
                    writer.WriteStartElement("Column")
                    writer.WriteElementString("Name", col.DataPropertyName)
                    writer.WriteElementString("Value", My.Settings(col.DataPropertyName.ToString).ToString)
                    writer.WriteEndElement()
                Next

                writer.WriteEndElement()
                writer.WriteEndDocument()
                writer.Close()
            End Using

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        '    Try
        '        Dim col As DataGridViewColumn
        '        Dim dec As XmlDeclaration = doc.CreateXmlDeclaration("1.0", "utf-8", Nothing)
        '        doc.AppendChild(dec)
        '        Dim docroot As XmlElement = doc.CreateElement("Columns")
        '        doc.AppendChild(docroot)
        '        Dim coln As XmlNode
        '        Dim colv As XmlNode

        '        For Each col In OutBoundObjDataGridView.Columns
        '            Dim colnv As XmlNode = doc.CreateElement("Column")
        '            coln = colnv.AppendChild(doc.CreateElement("Name"))
        '            coln.InnerText = col.DataPropertyName.ToString
        '            colv = colnv.AppendChild(doc.CreateElement("Value"))
        '            colv.InnerText = My.Settings(col.DataPropertyName.ToString).ToString
        '            docroot.AppendChild(colnv)
        '        Next
        '        'doc.Save("C:\TextMy.XML")
        '    Catch ex As Exception
        '        MsgBox(ex.Message)
        '    End Try

        '    Dim sw As New StringWriter
        '    Dim xw As New XmlTextWriter(sw)
        '    doc.WriteTo(xw)
        '    Dim transactionXML As StringReader = New StringReader(sw.ToString)
        '    Dim xmlReader As New XmlTextReader(transactionXML)
        '    Dim sqlXml As New SqlXml(xmlReader)

        '    'StringWriter sw = new StringWriter(); 
        '    'XmlTextWriter xw = new XmlTextWriter(sw); 
        '    'doc.WriteTo(xw)
        '    'StringReader transactionXml = new StringReader(sw.ToString()); 
        '    'XmlTextReader xmlReader = new XmlTextReader(transactionXml); 
        '    'SqlXml sqlXml = new SqlXml(xmlReader); 

        '    BusObj.SaveGridColumnView(sqlXml, "Test", cn)




        'End Sub
        'Private Sub SaveColumnLayoutXML()
        '    Dim xmlout As FileStream
        '    Dim settings As XmlWriterSettings = New XmlWriterSettings()
        '    settings.Indent = True
        '    Try
        '        Using writer As XmlWriter = XmlWriter.Create(xmlout, settings)
        '            writer.WriteStartDocument()
        '            writer.WriteStartElement("Columns")

        '            Dim col As DataGridViewColumn

        '            For Each col In OutBoundObjDataGridView.Columns
        '                writer.WriteStartElement("Column")
        '                writer.WriteElementString("Name", col.DataPropertyName)
        '                writer.WriteElementString("Value", My.Settings(col.DataPropertyName.ToString).ToString)
        '                writer.WriteEndElement()
        '            Next

        '            writer.WriteEndElement()
        '            writer.WriteEndDocument()
        '            writer.Close()
        '        End Using

        '    Catch ex As Exception
        '        MsgBox(ex.Message)
        '    End Try


    End Sub
#End Region

#Region "   Context Menu   "

    Private Sub OutBoundObjDataGridView_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles OutBoundObjDataGridView.CellFormatting
        Dim dgv As DataGridView = DirectCast(sender, DataGridView)
        Dim col As DataGridViewColumn
        Dim d As Double
        col = dgv.Columns(e.ColumnIndex)
        Try
            Select Case col.Name
                Case "SalesAmt_SubTotal", "Freight", "SalesAmt", "UnitPrice", "ExtendedPrice", "InvoiceAmt"
                    d = Double.Parse(e.Value.ToString)
                    e.Value = d.ToString("N2")
                Case "Qty"
                    d = Double.Parse(e.Value.ToString)
                    e.Value = d.ToString("N0")
                Case "Discount"
                    d = Double.Parse(e.Value.ToString)
                    e.Value = d.ToString("P1")
            End Select

        Catch ex As Exception

        End Try

    End Sub

    Private Sub OutBoundObjDataGridView_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles OutBoundObjDataGridView.ColumnHeaderMouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then

            Me.ContextMenuDataGridColumns.Show(sender, New Point(e.X, e.Y))
            'Me.ContextMenuDataGridColumns.Show(sender, New Point(e.X, e.Y))
            'Me.ContextMenuDataGridColumns.Visible = True
        End If
    End Sub

    Private Sub LoadContextMenuItems()
        ContextMenuDataGridColumns.Hide()
        With ContextMenuDataGridColumns
            .AutoClose = False
            .ShowCheckMargin = True
            .ShowImageMargin = False
        End With
        Dim col As DataGridViewColumn
        ContextMenuDataGridColumns.Items.Clear()

        Dim closeitm As New ToolStripMenuItem(" Apply Setting && Close")
        closeitm.ForeColor = Color.Blue
        closeitm.Font = New Font(closeitm.Font.Name, closeitm.Font.Size, FontStyle.Bold)
        Me.ContextMenuDataGridColumns.Items.Add(closeitm)

        'Dim opengridpreset As New ToolStripMenuItem("Open Grid Preset")
        'closemnustrip.ForeColor = Color.Blue
        'closemnustrip.Font = New Font(closemnustrip.Font.Name, closemnustrip.Font.Size, FontStyle.Bold)
        'Me.ContextMenuDataGridColumns.Items.Add(closemnustrip)

        'Dim savegridcoldefas As New ToolStripMenuItem("2) Save Column Preset")
        'savegridcoldefas.ForeColor = Color.Blue
        'savegridcoldefas.Font = New Font(savegridcoldefas.Font.Name, savegridcoldefas.Font.Size, FontStyle.Bold)
        'Me.ContextMenuDataGridColumns.Items.Add(savegridcoldefas)

        Dim closemnustrip As New ToolStripMenuItem(" Close Menu")
        closemnustrip.ForeColor = Color.Blue
        closemnustrip.Font = New Font(closemnustrip.Font.Name, closemnustrip.Font.Size, FontStyle.Bold)
        Me.ContextMenuDataGridColumns.Items.Add(closemnustrip)


        'Dim opengridpreset As New ToolStripMenuItem("Open Column Preset")
        'opengridpreset.ForeColor = Color.Blue
        'opengridpreset.Font = New Font(opengridpreset.Font.Name, opengridpreset.Font.Size, FontStyle.Bold)
        'Me.ContextMenuDataGridColumns.Items.Add(opengridpreset)

        'Dim presetmenuitems() As ToolStripItem = { _
        '    New ToolStripMenuItem("TOTAL MARKETING - Pending", Nothing, AddressOf MenuItemTotalPending_Clicked), _
        '    New ToolStripMenuItem("TOTAL MARKETING - History", Nothing, AddressOf MenuItemTotalHistory_Clicked) _
        '}

        'Dim presetmenuitem As ToolStripItem
        'presetmenuitem = New ToolStripMenuItem("TEST Item", Nothing, AddressOf MenuItemTotalHistory_Clicked)
        'DirectCast(opengridpreset, ToolStripMenuItem).DropDownItems.AddRange(presetmenuitems)
        'DirectCast(opengridpreset, ToolStripMenuItem).DropDownItems.Add(presetmenuitem)

        For Each col In Me.OutBoundObjDataGridView.Columns
            With Me.ContextMenuDataGridColumns
                Dim chkitm As New ToolStripMenuItem(col.Name)
                If col.HeaderText > "" Then chkitm.Text = col.HeaderText
                chkitm.Name = col.Name
                Try
                    chkitm.Checked = My.Settings(col.Name)
                    .Items.Add(chkitm)
                Catch ex As Exception

                End Try
                Debug.Print(col.Name)
            End With
        Next

        Dim col1 As ToolStripItemCollection = ContextMenuDataGridColumns.Items
        ToolStripItemCollection(col1)
        ContextMenuDataGridColumns.Show()

    End Sub
    Private Sub ToolStripItemCollection(ByVal coll As ToolStripItemCollection)
        Dim oAList As New System.Collections.ArrayList(coll)
        oAList.Sort(New ToolStripItemComparer())
        coll.Clear()

        For Each oItem As ToolStripItem In oAList
            coll.Add(oItem)
        Next
    End Sub
    Private Class ToolStripItemComparer
        Implements System.Collections.IComparer

        Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements System.Collections.IComparer.Compare
            Dim oItem1 As ToolStripItem = DirectCast(x, ToolStripItem)
            Dim oItem2 As ToolStripItem = DirectCast(y, ToolStripItem)
            Return String.Compare(oItem1.Text, oItem2.Text, True)
        End Function
    End Class


    Private Sub ContextMenuDataGridColumns_ItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles ContextMenuStripColumns.ItemClicked
        Dim mnu As ContextMenuStrip = DirectCast(sender, ContextMenuStrip)
        Dim chk As ToolStripMenuItem

        chk = e.ClickedItem

        Select Case chk.Text

            Case " Apply Setting && Close"
                mnu.Close()
                LoadDataGrid()
                Exit Sub

            Case " Close Menu"
                mnu.Close()

                'Exit Sub
                'Case "2) Save Column Preset"

                '    Dim savedlg As New SaveFileDialog
                '    With savedlg
                '        .Title = "Enter the Grid Column Definition"
                '        .Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*"
                '        .AddExtension = True
                '        .InitialDirectory = appsettings.DataGridColumnLayoutFolderPath
                '    End With

                '    If savedlg.ShowDialog = Windows.Forms.DialogResult.OK Then
                '        appsettings.DataGridColumnLayoutFilePath = savedlg.FileName
                '        SaveColumnLayoutXML(appsettings.DataGridColumnLayoutFilePath)
                '        LoadGridColumnDefinitions(appsettings.DataGridColumnLayoutFolderPath)
                '    Else
                '        LoadGridColumnDefinitions(appsettings.DataGridColumnLayoutFolderPath)
                '    End If
                '    'mnu.Hide()

            Case Else
                Dim i As Integer = mnu.Items.Count
                Dim c As Integer = 0
                For Each ch In mnu.Items
                    If ch.Checked = False Then
                        c = c + 1
                    End If
                Next

                If chk.Checked = False Then
                    chk.Checked = True
                Else
                    If i - c = 1 Then
                        chk.Checked = True
                    Else
                        chk.Checked = False
                    End If
                End If
                Try
                    My.Settings(e.ClickedItem.Name) = chk.Checked

                Catch ex As Exception

                End Try
        End Select





    End Sub

    Private Sub LoadDataGrid()
        Dim col As DataGridViewColumn
        Dim itms As System.Windows.Forms.ToolStripItemCollection = Me.ContextMenuStripColumns.Items
        Dim itm As New ToolStripMenuItem
        For Each col In Me.OutBoundObjDataGridView.Columns
            With Me.ContextMenuStripColumns
                .Items.Add(col.Name.ToString)
                Try
                    col.Visible = CBool(My.Settings(col.Name).ToString)
                Catch ex As Exception

                End Try

            End With
        Next

    End Sub

    Private Sub ContextMenuDataGridColumns_Opening(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) ' Handles ContextMenuDataGridColumns.Opening
        LoadContextMenuItems()
    End Sub



    'Loads ColumnPresets for the ComboBox
    Private Sub LoadGridColumnDefinitionsForCombobox()
        Dim rd As SqlDataReader
        rd = BusObj.ExecuteSQLReader("Select grid_col_layout_name from OEOBGRIDCOL_MAS ", cn)

        Try

            While rd.Read

                Me.ComboBoxColumnPresets.Items.Add(rd(0))

            End While
            rd.Close()

            Dim itm As Object
            For Each itm In ComboBoxColumnPresets.Items
                If itm.ToString.Substring(0, 7) = "Pending" Then
                    Me.ComboBoxColumnPresets.SelectedItem = itm.ToString
                End If
            Next
        Catch ex As Exception
            rd.Close()
            MsgBox("Error in LoadGridColumnDefinition", MsgBoxStyle.OkOnly, "LoadGridColumnsError")
        End Try

    End Sub


    'Private Sub ButtoSaveFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim opnfiledialog As New OpenFileDialog

    '    With opnfiledialog

    '        .InitialDirectory = appsettings.DataGridColumnLayoutFolderPath.ToString
    '        .Filter = "xml files (*.xml)|*.xml|All files(*.*)|*.*"
    '        .FilterIndex = 1
    '        .RestoreDirectory = True
    '    End With

    '    If opnfiledialog.ShowDialog = Windows.Forms.DialogResult.OK Then
    '        appsettings.DataGridColumnLayoutFilePath = opnfiledialog.FileName
    '    Else

    '    End If

    '    LoadGridColumnDefinitions(appsettings.DataGridColumnLayoutFolderPath)

    'End Sub

#Region "     ** SubMenu   "

    Private Function AddSubMenuItems() As ToolStripItem
        Dim tsi As ToolStripItem


        Return tsi
    End Function

    Private Sub MenuItemTotalPending_Clicked(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MsgBox("Pending Clicked")
    End Sub

    Private Sub MenuItemTotalHistory_Clicked(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MsgBox("History Clicked")
    End Sub

#End Region

#End Region

#Region "   Quick Filter    "
    Private Sub ButtonApplyFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonApplyFilter.Click
        If Me.RadioButtonPending.Checked = True Then
            outboundlist.Filter = Me.SearchPropertyNameTextBox.Text & Me.TextBox1.Text & Me.SearchPropertyValueTextBox.Text
        Else
            outboundhistlist.Filter = Me.SearchPropertyNameTextBox.Text & Me.TextBox1.Text & Me.SearchPropertyValueTextBox.Text
        End If


    End Sub

    Private Sub ButtonRemoveFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRemoveFilter.Click
        If Me.RadioButtonPending.Checked = True Then
            outboundlist.RemoveFilter()
        Else
            outboundhistlist.RemoveFilter()
        End If
        With masutil
            .SearchPropertyName = ""
            .SearchPropertyValue = ""
        End With
        Reset_MassarelliOutboundBindingSource()
    End Sub

    Private Sub OutBoundObjDataGridView_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles OutBoundObjDataGridView.CellMouseClick
        Dim dgv As DataGridView = DirectCast(sender, DataGridView)
        Dim obobj As New OutBoundObj


        If e.Button = Windows.Forms.MouseButtons.Left Then
            Try
                obobj = outboundlist(masutil.DataGridViewRow)
            Catch ex As Exception

            End Try

            masutil.DataGridViewCol = e.ColumnIndex
            masutil.DataGridViewRow = e.RowIndex
            Try
                masutil.SearchPropertyValue = dgv(masutil.DataGridViewCol, masutil.DataGridViewRow).Value
                masutil.SearchPropertyName = dgv.Columns(e.ColumnIndex).Name
            Catch ex As Exception

            End Try
            Reset_MassarelliOutboundBindingSource()

            'Dim propinfo As System.Reflection.PropertyInfo
            'For Each propinfo In obobj.GetType().GetProperties()
            '    If propinfo.CanRead Then
            '        If i = masutil.DataGridViewCol Then
            '            masutil.SearchPropertyName = propinfo.Name
            '            i = 0
            'MassarelliOutBoundUtilitesBindingSource.DataSource = masutil
            'Me.SearchPropertyNameTextBox.DataBindings("Text").ReadValue()
            'Me.SearchPropertyValueTextBox.DataBindings("Text").ReadValue()
            '            Me.SearchPropertyNameTextBox.Refresh()
            '            Me.SearchPropertyValueTextBox.Refresh()
            '            Me.Refresh()
            '            Exit For
            '        End If
            '        i = i + 1
            '    End If
            'Next


        End If

    End Sub

#End Region

#Region "   FTP   "
    'Private Sub ToolStripButtonFTP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonFTP.Click
    '    FTPSend()
    'End Sub

    Private Sub FTPSend(ByVal xlftp As FTPFileList)
        Dim rd As SqlDataReader
        Dim ftphost As String = ""
        Dim ftpport As String = ""
        Dim ftpuser As String = ""
        Dim ftppwd As String = ""
        Dim ftpuploadloc As String = ""
        Dim ftplocalfilename As String = ""
        Dim ftpuploadfilename As String = ""
        Dim ftplocalfileexists As Boolean
        Dim opnFiledialog As New OpenFileDialog
        rd = GetFTPSettingsAndUser()

        ftplocalfileexists = System.IO.File.Exists(appsettings.FTPLocalFileName)

        If ftplocalfileexists = False Then
            With opnFiledialog
                .InitialDirectory = appsettings.Path '.Path is the local FTP File location setting
                .Filter = "xls files (*.xls)|*.xls|xlsx files (*.xlsx)|*.xlsx|All files(*.*)|*.*"
                .FilterIndex = 1
                .RestoreDirectory = True
            End With

            If opnFiledialog.ShowDialog = Windows.Forms.DialogResult.OK Then
                appsettings.FTPLocalFileName = opnFiledialog.FileName
            Else
                MsgBox("A local Excel file to FTP upload has not been selected.  Try sending FTP again and select a file at the File Dialog", MsgBoxStyle.OkOnly, "Local File to Send Not Selected")
                rd.Close()
                Exit Sub
            End If

        End If

        If rd.HasRows Then
            While rd.Read
                ftphost = rd("ob_ftp_host")
                ftpport = rd("ob_ftp_port")
                ftpuser = rd("ob_ftp_username")
                ftppwd = rd("ob_ftp_password")
                ftpuploadloc = rd("ob_ftp_upload_location")
                ftplocalfilename = appsettings.FTPLocalFileName
                ftpuploadfilename = ftpuploadloc + "/" + appsettings.FTPUploadFileName
            End While
        End If
        rd.Close()
        ftppwd = AppUtilities.UnEncryptPassword(ftppwd)

        Dim ftpcl As New FTPclient(ftphost & ":" & ftpport, ftpuser, ftppwd)
        Try

            ftpcl.Upload(ftplocalfilename, ftpuploadfilename)
            MessageBox.Show("FTP File " & appsettings.FTPLocalFileName & " successfully uploaded.", "FTP Send", MessageBoxButtons.OK)

        Catch ex As Exception

            MessageBox.Show("FTP Send: Error Occurred.  Error Message: " & ex.Message, "FTP Error", MessageBoxButtons.OK)

        End Try

    End Sub

    Private Function GetFTPSettingsAndUser() As SqlDataReader
        Dim rd As SqlDataReader
        Dim sSQL As String

        sSQL = "Select * from OEOBSETTINGS2012_MAS"
        rd = BusObj.ExecuteSQLReader(sSQL, cn)

        Return rd

    End Function

    'Private Sub ButtonExcelAndSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonExcelAndSave.Click

    '    If Me.RadioButtonPending.Checked = True Then
    '        exporttype = exporttypeenum.pending
    '    Else
    '        exporttype = exporttypeenum.history
    '    End If
    '    ExportToExcel(exporttype)
    'End Sub

#End Region



    Private Sub ExcelExportOnlyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcelExportOnlyToolStripMenuItem.Click
        Dim RecipientExportType As String = "Excel"
        Dim dt As DataTable
        Dim dgv As DataGridView = Me.OutBoundObjDataGridView
        Dim xlapp As excel.Application = New excel.Application
        dt = ExcelExport.DataGridViewToDataTable(dgv, RecipientExportType, "", "", "")
        ExcelExport.ExportDataTableToExcel(xlapp, dt, RecipientExportType)
    End Sub

    Private Sub FTPToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FTPToolStripMenuItem.Click
        If Me.RadioButtonPending.Checked = True Then
            exporttype = exporttypeenum.pending
        Else
            exporttype = exporttypeenum.history
        End If
        FTPOptions.Show()
        'ExportToExcel(exporttype)
    End Sub
    Private Sub RepsRepGroupToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RepsRepGroupToolStripMenuItem.Click
        ExcelEmailOptions.Show()
    End Sub

    'Private Sub ExelExportToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExelExportToolStripButton.Click
    '    Dim reps As List(Of String) = GetRepListForEmail()
    'End Sub

    Private Sub PanelRepGroup_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PanelRepGroup.Paint
        'Dim pen As New Pen(color.FromKnownColor(KnownColor.CadetBlue)
        'TODO PAINT CONTROL
        'e.Graphics.DrawRectangle(Pens.CadetBlue, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width, e.ClipRectangle.Height - 1)
    End Sub

    Private Sub ComboBoxRepGroup_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxRepGroup.SelectedIndexChanged

    End Sub

    Private Sub pboxReps_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pboxReps.Click
        RepListViewCheckItems()
    End Sub
    Private Sub RepListViewCheckItems()
        Dim lst As ListView = Me.ListViewSalesRepList
        Dim chk As Boolean = lst.Items(0).Checked
        Dim itm As ListViewItem
        IsEditing = True
        If chk = False Then
            chk = True
        Else
            chk = False
        End If

        For Each itm In lst.Items
            itm.Checked = chk
        Next
        IsEditing = False
    End Sub
    Private Sub RepListViewCheckItems(ByVal chk As Boolean)
        Dim lst As ListView = Me.ListViewSalesRepList

        Dim itm As ListViewItem
        IsEditing = True
        'If chk = False Then
        '    chk = True
        'Else
        '    chk = False
        'End If

        For Each itm In lst.Items
            itm.Checked = chk
        Next
        IsEditing = False
    End Sub
    'Private Sub CheckBoxRepGroup_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxRepGroup.CheckedChanged
    '    'Dim chk As CheckBox = DirectCast(Me.CheckBoxRepGroup, CheckBox)

    '    'RepListViewCheckItems(chk.Checked)

    'End Sub

    

    Private Sub FTPSend()
        Dim rd As SqlDataReader
        Dim ftphost As String = ""
        Dim ftpport As String = ""
        Dim ftpuser As String = ""
        Dim ftppwd As String = ""
        Dim ftpuploadloc As String = ""
        Dim ftplocalfilename As String = ""
        Dim ftpuploadfilename As String = ""
        Dim ftplocalfileexists As Boolean
        Dim opnFiledialog As New OpenFileDialog
        rd = GetFTPSettingsAndUser()

        ftplocalfileexists = System.IO.File.Exists(appsettings.FTPLocalFileName)

        If ftplocalfileexists = False Then
            With opnFiledialog
                .InitialDirectory = appsettings.Path '.Path is the local FTP File location setting
                .Filter = "xls files (*.xls)|*.xls|xlsx files (*.xlsx)|*.xlsx|All files(*.*)|*.*"
                .FilterIndex = 1
                .RestoreDirectory = True
            End With

            If opnFiledialog.ShowDialog = Windows.Forms.DialogResult.OK Then
                appsettings.FTPLocalFileName = opnFiledialog.FileName
            Else
                MsgBox("A local Excel file to FTP upload has not been selected.  Try sending FTP again and select a file at the File Dialog", MsgBoxStyle.OkOnly, "Local File to Send Not Selected")
                rd.Close()
                Exit Sub
            End If

        End If

        If rd.HasRows Then
            While rd.Read
                ftphost = rd("ob_ftp_host")
                ftpport = rd("ob_ftp_port")
                ftpuser = rd("ob_ftp_username")
                ftppwd = rd("ob_ftp_password")
                ftpuploadloc = rd("ob_ftp_upload_location")
                ftplocalfilename = appsettings.FTPLocalFileName
                ftpuploadfilename = ftpuploadloc + "/" + appsettings.FTPUploadFileName
            End While
        End If
        rd.Close()
        ftppwd = AppUtilities.UnEncryptPassword(ftppwd)

        Dim ftpcl As New FTPclient(ftphost & ":" & ftpport, ftpuser, ftppwd)
        Try

            ftpcl.Upload(ftplocalfilename, ftpuploadfilename)
            MessageBox.Show("FTP File " & appsettings.FTPLocalFileName & " successfully uploaded.", "FTP Send", MessageBoxButtons.OK)

        Catch ex As Exception

            MessageBox.Show("FTP Send: Error Occurred.  Error Message: " & ex.Message, "FTP Error", MessageBoxButtons.OK)

        End Try

    End Sub
    Private Function GetXMLFileName(SlsRepGroup As String, PresetType As String) As String
        Dim sSQL As String = ""
        Dim slsrepgrp As String = ""

        If ComboBoxRepGroup.SelectedValue Is Nothing Then slsrepgrp = "" Else slsrepgrp = ComboBoxRepGroup.SelectedValue.ToString
        sSQL = "Select count(*) from OEOBGRIDCOL_MAS where slsrep_grp = '" & slsrepgrp & "' "
        Dim repgroupexists As Integer = BusObj.ExecuteSQL_Scalar("Select count(*) from OEOBGRIDCOL_MAS where slsrep_grp = '" & slsrepgrp & "' ", cn)
        If repgroupexists > 0 Then
            sSQL = "Select top 1 IsNull(grid_col_layout_name, '') from OEOBGRIDCOL_MAS where slsrep_grp = '" & slsrepgrp & "' and preset_type = '" & PresetType & "' "
        Else
            sSQL = "Select top 1 IsNull(grid_col_layout_name, '') from OEOBGRIDCOL_MAS where slsrep_grp = '' and preset_type = '" & PresetType & "' "
        End If


        'sSQL = "Select IsNull(grid_col_layout_name, '') from OEOBGRIDCOL_MAS where slsrep_grp = '" & SlsRepGroup & "' and preset_type = '" & PresetType & "'"
        Dim xmlfilename As String = BusObj.ExecuteSQL_Scalar(sSQL, cn).ToString

        'ComboBoxColumnPresets.Text = xmlfilename
        'ApplyColumnSettings(xmlfilename)
        Return xmlfilename
    End Function
    Private Sub RadioButtonHistory_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonHistory.Click, RadioButtonPending.Click

        Dim rb As RadioButton = DirectCast(sender, RadioButton)
        Dim xmlFileName As String = ""
        Dim slsrepgrp As String
        If ComboBoxRepGroup.SelectedValue Is Nothing Then slsrepgrp = "" Else slsrepgrp = ComboBoxRepGroup.SelectedValue.ToString
        If rb.Name = Me.RadioButtonHistory.Name Then

            Me.DataSource = "History"
            xmlFileName = GetXMLFileName(slsrepgrp, Me.DataSource)

            Me.TextBoxInvoice.Enabled = True
            Me.TextBoxInvoice.Text = ""

        ElseIf rb.Name = Me.RadioButtonPending.Name Then

            Me.DataSource = "Pending"
            xmlFileName = GetXMLFileName(slsrepgrp, Me.DataSource)

        End If


        ComboBoxColumnPresets.Text = xmlFileName
        ApplyColumnSettings(xmlFileName)

    End Sub

    Private Sub CheckBoxRepGroup_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxRepGroup.Click
        Dim chk As CheckBox = DirectCast(Me.CheckBoxRepGroup, CheckBox)

        RepListViewCheckItems(chk.Checked)
    End Sub

    Private Sub ComboBoxColumnPresets_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBoxColumnPresets.SelectedIndexChanged

    End Sub
End Class
