Imports System.Data
Imports System.Data.SqlClient
Imports System.Xml
Imports System.Xml.Schema
Imports System.Data.SqlTypes
Public Class ColumnSettings
    Private rd As SqlDataReader
    Private dgvoutbound As DataGridView

    Private Sub LoadGridColumnDefinitions(ByVal columnpresetname As String)
        Dim lst As ListView = Me.ListViewColumnPreset
        rd = BusObj.ExecuteSQLReader("Select grid_col_layout_name from OEOBGRIDCOL_MAS ", cn)

        Try
            For Each itm As ListViewItem In Me.ListViewColumnPreset.Items
                itm.Remove()
            Next

            While rd.Read
                lst.Items.Add(rd(0))
                If rd(0).ToString = columnpresetname Then
                    lst.Items.Item(lst.Items.Count - 1).Checked = True
                End If
            End While
            rd.Close()
        Catch ex As Exception
            rd.Close()
            MsgBox("Error in LoadGridColumnDefinition", MsgBoxStyle.OkOnly, "LoadGridColumnsError")
        End Try

    End Sub

    Private Sub LoadGridColumns(ByVal columnpresetname As String)
        Dim o As Configuration.SettingsPropertyValue
        Dim r As DataGridViewRow
        Dim c As DataGridViewCell
        Dim colpresetname As String

        Me.DataGridViewColumnSettings.Rows.Clear()
        If columnpresetname = "" Then
            colpresetname = BusObj.ExecuteSQL_Scalar_ReturnString("Select top 1 grid_col_layout_name from OEOBGRIDCOL_MAS", cn)
        Else
            colpresetname = columnpresetname
        End If
        Try
            For Each o In My.Settings.PropertyValues
                If o.Property.PropertyType.Name = "Boolean" Then
                    r = New DataGridViewRow
                    c = New DataGridViewCheckBoxCell
                    c.Value = False
                    r.Cells.Add(c)
                    c = New DataGridViewTextBoxCell
                    c.Value = o.Property.Name.ToString
                    r.Cells.Add(c)
                    Me.DataGridViewColumnSettings.Rows.Add(r)
                End If

            Next
            Me.DataGridViewColumnSettings.Sort(Me.DataGridViewColumnSettings.Columns("ColumnName"), System.ComponentModel.ListSortDirection.Ascending)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        
    End Sub
    Private Sub ColumnSettings_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim columnpresetname As String
        columnpresetname = BusObj.ExecuteSQL_Scalar_ReturnString("Select top 1 grid_col_layout_name from OEOBGRIDCOL_MAS", cn)
        IsEditing = True
        LoadGridColumnDefinitions(columnpresetname)
        LoadGridColumns("")
        dgvoutbound = MassarelliOutBound.OutBoundObjDataGridView
        With cboRepGroup
            .DataSource = MassarelliOutBound.reps
            .DisplayMember = "RepGroup"
            .ValueMember = "RepGroup"
        End With
       
        Dim lst As ListView = Me.ListViewColumnPreset
        ListViewPresetCheckValues(lst, 0, columnpresetname)
        LoadSettings()
        IsEditing = False
    End Sub

    Private Sub DataGridViewColumnSettings_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        Dim dgv As DataGridView = DirectCast(sender, DataGridView)
        If e.ColumnIndex = 0 Then
            Me.ButtonSaveColumnPreset.Enabled = True
        End If
    End Sub

    Private Sub DataGridViewColumnSettings_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs)
        Dim dgv As DataGridView = DirectCast(sender, DataGridView)
        Dim b As Boolean
        Dim r As DataGridViewRow
        If e.ColumnIndex = 0 Then
            dgv.EndEdit()
            b = dgv(0, 0).Value
            If b = True Then
                b = False
            Else
                b = True
            End If
            For Each r In dgv.Rows
                r.Cells("ColumnVisible").Value = b
            Next
        End If
    End Sub

    Private Sub GetSelectedColumnPreset(ByVal GridLayoutName As String)
        Dim rd As SqlDataReader
        Dim col As String = ""
        Dim val As String = ""
        Dim dgv As DataGridView = Me.DataGridViewColumnSettings
        Dim r As DataGridViewRow
        Dim colIndex As Integer
        rd = BusObj.ExecuteSQLReader("Select grid_col_layout_xml from OEOBGRIDCOL_MAS where grid_col_layout_name = '" & GridLayoutName & "'", cn)
        Dim xmlstr As String = ""
        While rd.Read
            xmlstr = rd(0)
        End While
        Try
            Using rdr As XmlTextReader = New XmlTextReader(xmlstr, XmlNodeType.Element, Nothing)
                Dim bValue As Boolean = False
                While rdr.Read()
                    If rdr.IsStartElement Then
                        If rdr.Name = "Name" Then
                            col = rdr.ReadElementContentAsObject.ToString
                            bValue = True
                        End If
                    ElseIf bValue = True Then
                        val = rdr.Value.ToString
                        For Each r In dgv.Rows
                            If r.Cells(1).Value = col Then
                                colIndex = r.Index
                                Exit For
                            End If
                        Next
                        'My.Settings(col) = CBool(val)
                        dgv(0, colIndex).Value = CBool(val)
                        bValue = False
                    End If

                End While
                rdr.Close()
                rd.Close()
            End Using

        Catch ex As Exception
            rd.Close()
        End Try
        
    End Sub


    Private Sub ButtonNewColumnPreset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonNewColumnPreset.Click
        Dim ret As Integer = 0
        Dim columnpresetname As String = Me.TextBoxNewPreset.Text
        Me.ButtonSaveColumnPreset.Enabled = True
        ret = CheckforDuplicateGridColLayoutName(columnpresetname)
        If ret > 0 Then
            MsgBox("The name " & columnpresetname & " already exists.  Please choose a different name", MsgBoxStyle.OkOnly, "Duplicate Column Preset Name")
            Exit Sub
        End If
        Dim lst As ListView = Me.ListViewColumnPreset
        Dim presettype As String = IIf(rbPending.Checked = True, "Pending", "History")
        Dim slsrepgrp As String = IIf(cboRepGroup.Text = "", "", cboRepGroup.Text)
        IsEditing = True
        SaveGridColumnPreset.SaveColumnPreset("New", Me.DataGridViewColumnSettings, columnpresetname, presettype, slsrepgrp)
        LoadGridColumnDefinitions(columnpresetname)
        LoadGridColumns(columnpresetname)
        LoadSettings()
        ListViewPresetCheckValues(lst, 0, columnpresetname)
        IsEditing = False
    End Sub

    Private Sub ListViewColumnPreset_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles ListViewColumnPreset.ItemCheck

        If IsEditing = False Then

            Dim lst As ListView = DirectCast(sender, ListView)
            Dim item As ListViewItem

            For Each item In lst.Items
                If Not item.Index = e.Index Then
                    item.Checked = False
                End If
            Next

            Dim checkedItem As Integer = e.Index
            Dim columnpreset As String = ""

            Try
                For Each item In lst.Items
                    If item.Index = e.Index Then
                        columnpreset = item.Text
                        'item.Checked = True
                    Else
                        item.Checked = False
                    End If

                Next

            Catch ex As Exception

            End Try

            ListViewPresetCheckValues(lst, checkedItem, columnpreset)

        End If

    End Sub
    Private Sub ListViewPresetCheckValues(ByVal lst As ListView, ByVal checkedItem As Integer, ByVal columnpresetname As String)

        Dim item As ListViewItem

        For Each item In lst.Items
            If Not item.Index = checkedItem Then
                item.Checked = False
            End If

        Next

        Me.GetSelectedColumnPreset(columnpresetname)
    End Sub

    Private Sub TextBoxNewPreset_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxNewPreset.TextChanged
        Dim txt As TextBox = DirectCast(sender, TextBox)

        If txt.Text.Length = 0 Then
            Me.ButtonNewColumnPreset.Enabled = False
        Else
            Me.ButtonNewColumnPreset.Enabled = True
            ListViewPresetUncheckAll()

        End If
    End Sub
    Private Sub LoadSettings()
        Try
            Me.ButtonNewColumnPreset.Enabled = False
            Me.TextBoxNewPreset.Text = ""
            Me.ListViewColumnPreset.Items(0).Checked = True
            Me.ButtonSaveColumnPreset.Enabled = False
        Catch ex As Exception

        End Try
        
    End Sub
    Private Function CheckforDuplicateGridColLayoutName(ByVal GridColLayoutName As String) As Integer
        Dim ret As Integer = 0

        ret = BusObj.ExecuteSQL_Scalar("Select count(*) from OEOBGRIDCOL_MAS where grid_col_layout_name = '" & _
                                        GridColLayoutName & "'", cn)

        Return ret
    End Function

    Private Sub ButtonDeleteColumnPreset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDeleteColumnPreset.Click
        Dim lst As ListView = Me.ListViewColumnPreset
        Dim item As ListViewItem
        Dim columnpresetname As String = ""
        Dim retval As Int16

        For Each item In lst.Items
            If item.Checked Then
                columnpresetname = item.Text
            End If
        Next

        retval = MsgBox("This Column Preset will the Deleted: " & columnpresetname & ".  Would you like to proceed?", MsgBoxStyle.YesNo, "Delete Column Preset")

        If retval = MsgBoxResult.Yes Then
            SaveGridColumnPreset.SaveColumnPreset("Delete", Me.DataGridViewColumnSettings, columnpresetname, "", "")
        End If
        LoadGridColumnDefinitions(columnpresetname)
        LoadGridColumns(columnpresetname)
        LoadSettings()
    End Sub

    Private mIsEditing As Boolean
    Public Property IsEditing() As Boolean
        Get
            Return mIsEditing
        End Get
        Set(ByVal value As Boolean)
            mIsEditing = value
        End Set
    End Property

    Private Sub ListViewColumnPreset_ItemSelectionChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.ListViewItemSelectionChangedEventArgs) Handles ListViewColumnPreset.ItemSelectionChanged


        If IsEditing = False Then

            Dim lst As ListView = DirectCast(sender, ListView)
            Dim item As ListViewItem

            For Each item In lst.Items
                If Not item.Index = e.ItemIndex Then
                    item.Checked = False
                End If
            Next

            Dim checkedItem As Integer = e.ItemIndex
            Dim columnpreset As String = ""

            Try
                For Each item In lst.Items
                    If item.Index = e.ItemIndex Then
                        columnpreset = item.Text
                        IsEditing = True
                        item.Checked = True
                        IsEditing = False
                    Else
                        item.Checked = False
                    End If

                Next

            Catch ex As Exception

            End Try

            ListViewPresetCheckValues(lst, checkedItem, columnpreset)

        End If
    End Sub
    Private Sub ListViewPresetUncheckAll()
        Dim lst As ListView = Me.ListViewColumnPreset
        Dim item As ListViewItem
        For Each item In lst.Items

            item.Checked = False

        Next
    End Sub
    Private Sub ButtonExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonExit.Click
        Me.Close()
    End Sub

    Private Sub ButtonSaveColumnPreset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSaveColumnPreset.Click
        Dim columnpresetname As String = ""
        Dim item As ListViewItem
        Dim lst As ListView = Me.ListViewColumnPreset
        Dim slsrepgrp As String = IIf(cboRepGroup.Text = "", "", cboRepGroup.Text)
        Dim presettype As String = IIf(rbPending.Checked = True, "Pending", "History")


        For Each item In lst.Items
            If item.Checked = True Then
                columnpresetname = item.Text
            End If
        Next

        SaveGridColumnPreset.SaveColumnPreset("Pending", Me.DataGridViewColumnSettings, columnpresetname, presettype, slsrepgrp)
        IsEditing = True
        LoadGridColumnDefinitions(columnpresetname)
        LoadGridColumns(columnpresetname)
        GetSelectedColumnPreset(columnpresetname)
        Me.ButtonSaveColumnPreset.Enabled = False
        IsEditing = False
    End Sub

    Private Sub cboRepGroup_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboRepGroup.SelectedIndexChanged
        ButtonSaveColumnPreset.Enabled = True
    End Sub

    Private Sub rbPending_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbPending.CheckedChanged
        ButtonSaveColumnPreset.Enabled = True
    End Sub
End Class