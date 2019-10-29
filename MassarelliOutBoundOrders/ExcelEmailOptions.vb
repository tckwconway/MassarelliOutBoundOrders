Imports Microsoft.Office.Core
Imports Microsoft.Office.Interop
Imports System.Runtime.InteropServices.Marshal
Imports System.Text
Public Class ExcelEmailOptions
    Const RepGroup As String = "RepGroup" '??
    Const Reps As String = "Reps" '??

    Private LQ_SalesPersonList As LQ_SalesPersonListDataContext
    Private obpendlist As OutBoundList = MassarelliOutBound.outboundlist
    Private obhistlist As OutBoundHistList = MassarelliOutBound.outboundhistlist
    Private dgv As DataGridView = MassarelliOutBound.OutBoundObjDataGridView
    Private sls As List(Of VLQ_SalesPersonList)
    Private grp As String '??
    Private slsgrp As List(Of VLQ_SalesPersonList)
    Private slsgrplst As List(Of VLQ_SalesRepGroupList)
    Private xlemaillst As New List(Of ExcelEmailFileList) '??
    Private chk As Boolean
    Private appsettings As AppStoredSettings = MassarelliOutBound.appsettings
    Private ExcelFileNames As New List(Of String)
    'Private xlapp As Excel.Application = New Excel.Application
    Private xlapp As Excel.Application = MassarelliOutBound.xlapp
    Dim xlwbook As Excel.Workbook
    Dim xlwsheet As Excel.Worksheet

    Private Sub ExcelEmailOptions_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            While (ReleaseComObject(xlwsheet)) <> 0
            End While
        Catch ex As Exception
        Finally
            xlwsheet = Nothing
        End Try
        
        Try
            While (ReleaseComObject(xlwbook)) <> 0
            End While
        Catch ex As Exception
        Finally
            xlwbook = Nothing
        End Try
        
    End Sub

    Private Sub ExcelEmailOptions_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        DeleteExcelSpreadsheet()
    End Sub

    Private Sub ExcelEmailOptions_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'EMAIL - Load the settings (obviously)
        LoadSettings()

    End Sub
    Private Sub LoadSettings()
        'EMAIL...
        'Load the Sales Reps/email addresses, bind to the SalesRep Grid
        'No IF required as the user cannot open ExcelEmailOptions form without checking at least one Rep on the Massarelli Outbound Orders Form first.
        sls = GetRepList(MassarelliOutBound.exporttype)
        Me.BindingSourceReps.DataSource = sls
        Me.VLQ_SalesPersonListDataGridView.DataSource = Me.BindingSourceReps

        'Load the Rep Group/and Group Email Address, bind to the SalesRep Group Grid
        'Use if on this one as the Group may NOT have been checked
        If MassarelliOutBound.CheckBoxRepGroup.Checked = True Then
            grp = MassarelliOutBound.ComboBoxRepGroup.Text
            slsgrp = GetRepGroup(grp)
            Me.BindingSourceRepGroup.DataSource = slsgrp
            Me.VLQ_SalesRepGroupListDataGridView.DataSource = Me.BindingSourceRepGroup
        End If

        'The Display Index Keeps changing even though set in the Designer, this forces it to the correct order
        SetGridDisplayIndex(Me.VLQ_SalesRepGroupListDataGridView)
        SetGridDisplayIndex(Me.VLQ_SalesPersonListDataGridView)

        
        'Fill Subject and Memo Email fields with a defaul.  User can edit.
        Me.TextBoxSubject.Text = "Massarelli - Excel File Attached"
        Me.TextBoxMemo.Text = "See attached spreadsheet."

    End Sub
    Private Sub SetGridDisplayIndex(ByVal dgv As DataGridView)
        'EMAIL - This is required to keep the Column order (which keeps changing for some unknow reason) in 
        'its correct order
        Dim col As DataGridViewColumn

        For Each col In dgv.Columns
            If col.Name.Substring(0, 4).ToString = "send" Then
                col.DisplayIndex = 0
            ElseIf col.Name.Substring(0, 4).ToString = "save" Then
                col.DisplayIndex = 1
            ElseIf col.Name.Substring(0, 4).ToString = "sent" Then
                col.DisplayIndex = 2
            ElseIf col.Name.Substring(0, 8).ToString = "FilePath" Then
                col.DisplayIndex = dgv.ColumnCount - 1
            End If
        Next

    End Sub
    Private Function GetRepList(ByVal exporttype As Integer) As List(Of VLQ_SalesPersonList)

        'EMAIL - 
        'Gets the rep list that populates the SalesRep Datagrid
        'Return Variable for SalesReps is sls
        Dim RepLst As List(Of String)
        Dim reps() As String
        Dim repstr As New StringBuilder
        Dim i As Integer

        RepLst = MassarelliOutBound.GetRepListForEmail(exporttype)

        ReDim reps(RepLst.Count - 1)

        For i = 0 To RepLst.Count - 1
            repstr.Append(ControlChars.Quote)
            repstr.Append(RepLst(i))
            repstr.Append(ControlChars.Quote)
            If i < RepLst.Count - 1 Then
                repstr.Append(",")
            End If
        Next

        sls = MassarelliOutBound.GetRepList(RepLst)

        Return sls

    End Function
    Private Function GetRepGroup() As List(Of VLQ_SalesRepGroupList)

        slsgrplst = MassarelliOutBound.GetRepGroupList

        Return slsgrplst

    End Function
    Private Function GetRepGroup(ByVal RepGrp As String) As List(Of VLQ_SalesPersonList)
        'EMAIL - 
        'Get the Rep Group for the Grid.  
        'FIRST - If the Rep group is left empty on Main Form, but was also checked, then return ALL Rep Groups
        'to variable slsgrp
        'ELSE - A Rep group has been selected AND checked on the main form, return just the one Rep Group
        'to varialbe slsgrp
        If RepGrp = "" Then
            slsgrp = MassarelliOutBound.GetRepList()
        Else
            slsgrp = MassarelliOutBound.GetRepList(RepGrp, MassarelliOutBound.returntypeRepOrGroup.Group)
        End If

        Return slsgrp

    End Function

    Private Sub ButtonPrepare_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPrepare.Click
        'EMAIL - 
        '1: Empty any existing data if the Prepare has been run previously, FilePathName, Sent Checkbox for Reps and RepGroups
        '2: Loop through the RepGroup Grid First, if send is checked, create excel file and put filepathname in the grid
        '   Use new export techinque
        '   a: Create a DataTable dt that will hold the data in the same layout of Massarelli Outbound Datagridview
        '   b: Create the Spreadsheet based on the DataTable.  Very Very Quick!
        Dim dgvRepGrp As DataGridView = Me.VLQ_SalesRepGroupListDataGridView
        Dim dgvRep As DataGridView = Me.VLQ_SalesPersonListDataGridView
        Dim repno As String
        Dim repgrp As String
        Dim send As Boolean
        Dim dt As New DataTable
        Dim row As DataGridViewRow
        Dim o As VLQ_SalesPersonList
        Dim filepath As String

        Cursor = Cursors.WaitCursor

        'Empty the 'Sent' check box and FilePathName for RepGroup Grid. 
        If Not (slsgrp Is Nothing) Then
            For Each o In slsgrp
                o.sent = False
                o.file_path_name = ""
                dgvRepGrp.DataSource = Nothing
                dgvRepGrp.DataSource = slsgrp
                dgvRepGrp.Refresh()
            Next
        End If

        'Empty the 'Sent' check box and FilePathName for SalesRep Grid. 
        If Not (sls Is Nothing) Then
            For Each o In sls
                o.sent = False
                o.file_path_name = ""
                dgvRep.DataSource = Nothing
                dgvRep.DataSource = sls
                dgvRep.Refresh()
            Next
        End If

        'Create the EXCEL file for the RepGroup Grid Items that were checked to Send
        If dgvRepGrp.RowCount > 0 Then

            For Each o In slsgrp
                repno = o.slspsn_no
                repgrp = o.user_def_fld_1.Trim
                send = o.send

                If send = True Then

                    'Export takes place here...
                    dt = ExcelExport.DataGridViewToDataTable(dgv, RepGroup, repgrp, "", repgrp)
                    filepath = ExcelExport.ExportDataTableToExcel(xlapp, dt, "RepGroup", repgrp, "", repgrp)

                    o.file_path_name = filepath

                    dgvRepGrp.DataSource = Nothing
                    dgvRepGrp.DataSource = slsgrp
                    dgvRepGrp.Refresh()
                Else
                    slsgrp(0).file_path_name = ""
                    dgvRepGrp.DataSource = Nothing
                    dgvRepGrp.DataSource = slsgrp
                    dgvRepGrp.Refresh()
                End If
            Next

        End If

        If dgvRep.RowCount > 0 Then
            For Each o In sls
                repno = o.slspsn_no
                For Each row In dgvRep.Rows
                    If dgvRep("slspsn_no_slspsn", row.Index).Value = o.slspsn_no Then
                        If dgvRep("send_slspsn", row.Index).Value = True Then

                            dt = DataGridViewToDataTable(dgv, Reps, grp, o.slspsn_name, repno)
                            filepath = ExportDataTableToExcel(xlapp, dt, "Reps", grp, o.slspsn_name.Trim, repno)
                            o.file_path_name = filepath
                            dgvRep.DataSource = Nothing
                            dgvRep.DataSource = sls
                            dgvRep.Refresh()
                        Else
                            o.file_path_name = ""
                            dgvRep.DataSource = Nothing
                            dgvRep.DataSource = sls
                            dgvRep.Refresh()
                        End If
                    End If
                Next
            Next
        End If

        ButtonSendSelection.Enabled = True
        Cursor = Cursors.Default
    End Sub

    Private Sub VLQ_SalesRepGroupListDataGridView_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles VLQ_SalesRepGroupListDataGridView.CellContentClick

        'EMAIL - Open the Excel Spreadsheet from the RepGroup Datagrid
        Dim dgv As DataGridView = DirectCast(sender, DataGridView)
        Dim col As Integer = dgv.Columns("FilePathNameGrp").Index
        If e.ColumnIndex = col Then
            Try
                Process.Start(dgv(e.ColumnIndex, e.RowIndex).Value)
            Catch ex As Exception

            End Try
        End If

    End Sub

    Private Sub VLQ_SalesPersonListDataGridView_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles VLQ_SalesPersonListDataGridView.CellContentClick
        'EMAIL - Open the Excel Spreadsheet from the SalesRep Datagrid
        Dim dgv As DataGridView = DirectCast(sender, DataGridView)
        Dim col As Integer = dgv.Columns("FilePathNameRep").Index
        If e.ColumnIndex = col Then
            Try
                Process.Start(dgv(e.ColumnIndex, e.RowIndex).Value)
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub VLQ_SalesRepGroupListDataGridView_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) _
                                                                         Handles VLQ_SalesRepGroupListDataGridView.ColumnHeaderMouseClick, _
                                                                                 VLQ_SalesPersonListDataGridView.ColumnHeaderMouseClick
        'EMAIL - Toggles Check on Send or Save Header on RepGroup and SalesRep Grids
        Dim dgv As DataGridView = DirectCast(sender, DataGridView)
        Dim sendsave As String = ""
        Dim colidx As Integer = e.ColumnIndex

        If dgv.Columns(e.ColumnIndex).Name.Substring(0, 4) = "save" Then
            sendsave = "save"
        ElseIf dgv.Columns(e.ColumnIndex).Name.Substring(0, 4) = "send" Then
            sendsave = "send"
        End If
        CheckSendSaveDataGridView(dgv, sendsave, colidx)

    End Sub

    
    Private Sub pboxSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pboxSend.Click, pboxSave.Click
        'EMAIL - This Event Handles both PictureBox buttons, Send and Save
        'Toggle, check or uncheck the Send option
        Dim pbox As PictureBox = DirectCast(sender, PictureBox)
        Dim sendsave As String = ""
        Dim colidx As Integer
        Dim col As DataGridViewColumn
        Dim dgvgrp As New DataGridView
        Dim dgvrep As New DataGridView

        dgvgrp = Me.VLQ_SalesRepGroupListDataGridView
        dgvrep = Me.VLQ_SalesPersonListDataGridView
        If pbox.Name.Replace("pbox", "") = "Send" Then
            sendsave = "send"
        ElseIf pbox.Name.Replace("pbox", "") = "Save" Then
            sendsave = "save"
        End If

        If dgvgrp.RowCount > 0 Then
            For Each col In dgvgrp.Columns
                If col.Name.Substring(0, 4) = sendsave Then
                    colidx = col.Index
                    CheckSendSaveDataGridView(dgvgrp, sendsave, colidx)
                    Exit For
                End If
            Next
        End If

        If dgvrep.RowCount > 0 Then
            For Each col In dgvrep.Columns
                If col.Name.Substring(0, 4) = sendsave Then
                    colidx = col.Index
                    CheckSendSaveDataGridView(dgvrep, sendsave, colidx)
                    Exit For
                End If
            Next
        End If
    End Sub

    Private Sub CheckSendSaveDataGridView(ByVal dgv As DataGridView, ByVal SendSave As String, ByVal colidx As Integer)

        'EMAIL - This does the Toggle for the Grid of RepGroups or SalesReps

        Dim col As DataGridViewColumn
        Dim row As DataGridViewRow
        If SendSave = "save" OrElse SendSave = "send" Then

            For Each col In dgv.Columns

                If col.Index = colidx Then

                    If dgv.Name = "VLQ_SalesRepGroupListDataGridView" Then
                        dgv = VLQ_SalesRepGroupListDataGridView
                    Else
                        dgv = VLQ_SalesPersonListDataGridView
                    End If

                    dgv.EndEdit()

                    If dgv(col.Index, 0).Value = True Then
                        chk = False
                    Else
                        chk = True
                    End If


                    For Each row In dgv.Rows
                        dgv(colidx, row.Index).Value = chk
                    Next
                End If

            Next

        End If

    End Sub

   
    Private Sub ButtonSendSelection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSendSelection.Click
        'EMAIL - Sends the Email to the Selected RepGroups and SalesReps on the two grids
        Cursor = Cursors.WaitCursor
        SendEmail()
        Cursor = Cursors.Default

        Dim o As VLQ_SalesPersonList
        For Each o In slsgrp
            If o.file_path_name = "" Then
                ButtonSendSelection.Enabled = False
            Else
                Exit Sub
            End If
        Next

        For Each o In sls
            If o.file_path_name = "" Then
                ButtonSendSelection.Enabled = False
            Else
                ButtonSendSelection.Enabled = True
                Exit Sub
            End If
        Next


    End Sub

    Private Sub SendEmail()
        ' Create an Outlook application.
        Dim oApp As Outlook._Application
        Dim oAcct As Outlook.Account
        Dim oAttachs As Outlook.Attachments
        Dim oAttach As Outlook.Attachment
        Dim dgvgrp As DataGridView = Me.VLQ_SalesRepGroupListDataGridView
        Dim dgvrep As DataGridView = Me.VLQ_SalesPersonListDataGridView

        'TODO - Need to Change the FROM Email Address to the one Peter Set Up in the System
        oApp = New Outlook.Application()
        '        Me.txtUsername.Text = oApp.Session.Accounts.Item(1).UserName

        If Me.CheckBoxSendFrom.Checked = True Then
            For Each oAcct In oApp.Session.Accounts
                If oAcct.SmtpAddress = Me.TextBoxSendFrom.Text Then
                    Exit For
                End If
            Next
        Else
            For Each oAcct In oApp.Session.Accounts
                If oAcct.SmtpAddress = appsettings.FromEmail Then
                    Exit For
                End If
            Next
        End If
        
        'oAcct = oApp.Session.Accounts.Item(1).UserName

        'With oAcct
        '    .UserName = "tckwconway@live.com"
        'End With

        ' Create a new MailItem.
        Dim oMsg As Outlook._MailItem
        oMsg = oApp.CreateItem(Outlook.OlItemType.olMailItem)
        oMsg.Subject = Me.TextBoxSubject.Text
        oMsg.Body = Me.TextBoxMemo.Text
        'oMsg.SendUsingAccount

        ' TODO: Replace with a valid e-mail address.
        Dim send_email_list As New List(Of VLQ_SalesPersonList)
        Dim o As VLQ_SalesPersonList
        For Each o In slsgrp
            If o.send = True Then
                send_email_list.Add(o)
            End If

        Next
        For Each o In sls
            If o.send = True Then
                send_email_list.Add(o)
            End If
        Next

        For Each o In send_email_list
            oMsg = oApp.CreateItem(Outlook.OlItemType.olMailItem)
            oMsg.Subject = Me.TextBoxSubject.Text
            oMsg.Body = Me.TextBoxMemo.Text

            If Me.CheckBoxSendTo.Checked Then
                oMsg.To = "tckwconway@gmail.com"
            Else
                oMsg.To = o.email_addr
            End If

            ' Add an attachment
            Dim sSource As String = o.file_path_name
            Dim sDisplayName As String = "Excel File Attached"

            Dim sBodyLen As String = oMsg.Body.Length
            oAttachs = oMsg.Attachments
            oAttachs.Add(sSource, , sBodyLen + 1, sDisplayName)

            ' Send
            Try
                oMsg.Send()
                o.sent = True

                'Delete File if Save Not checked.  
                If o.save = False Then
                    If System.IO.File.Exists(o.file_path_name) = True Then
                        System.IO.File.Delete(o.file_path_name)
                        o.file_path_name = ""
                    End If
                End If

            Catch ex As Exception
                MessageBox.Show("Email Failed.  Reason: " & ex.Message, "Email Send Failure", MessageBoxButtons.OK)
            End Try

            dgvrep.DataSource = Nothing
            dgvrep.DataSource = sls
            dgvrep.Refresh()
            dgvgrp.DataSource = Nothing
            dgvgrp.DataSource = slsgrp
            dgvgrp.Refresh()

        Next
        ' Clean up
        oMsg = Nothing
        oAttach = Nothing
        oAttachs = Nothing
        oApp = Nothing

    End Sub
    Private Sub DeleteExcelSpreadsheet()
        If Not (slsgrp Is Nothing) Then
            If slsgrp.Count > 0 Then
                For Each o In slsgrp
                    If o.save = False AndAlso o.file_path_name > "" Then
                        If System.IO.File.Exists(o.file_path_name) = True Then
                            System.IO.File.Delete(o.file_path_name)
                            o.file_path_name = ""
                        End If
                    End If
                Next
            End If
        End If
        If Not (sls Is Nothing) Then
            If sls.Count > 0 Then
                For Each o In sls
                    If o.save = False AndAlso o.file_path_name > "" Then
                        If System.IO.File.Exists(o.file_path_name) = True Then
                            System.IO.File.Delete(o.file_path_name)
                            o.file_path_name = ""
                        End If
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub ButtonExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonExit.Click
        'EMAIL - Toolbar Button EXIT
        Me.Close()
    End Sub

    Private Sub ButtonCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCancel.Click
        'EMAIL - Button CANCEL 
        Me.Close()
    End Sub
End Class