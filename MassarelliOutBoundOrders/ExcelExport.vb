Imports Microsoft.Office.Core
Imports Microsoft.Office.Interop
Imports System.Runtime.InteropServices.Marshal
Imports System.Text

Module ExcelExport
    Private appsettings As AppStoredSettings = MassarelliOutBound.appsettings
    Private ExcelFileNames As New List(Of String)
    Private xlwbook As Excel.Workbook
    Private xlwsheet As Excel.Worksheet

    Public Function DataGridViewToDataTable(ByVal dgv As DataGridView, ByVal RecipientExportType As String, ByVal salesrepgroup As String, ByVal salesrepname As String, ByVal salesrepno As String, _
    Optional ByVal DataTableName As String = "myDataTable") As DataTable

        Dim cols As List(Of DataGridViewColumn) = (From column As DataGridViewColumn In dgv.Columns.Cast(Of DataGridViewColumn)() _
                             Order By column.DisplayIndex Select column).ToList


        'Dim dgvindex As New DGVDisplayIndex
        'Dim colList As New List(Of DGVDisplayIndex)

        'For Each c As DataGridViewColumn In dgv.Columns
        '    dgvindex = New DGVDisplayIndex
        '    dgvindex.DGVIndex = c.Index
        '    dgvindex.DGVDisplayIndex = c.DisplayIndex
        '    dgvindex.ColVisible = c.Visible
        '    dgvindex.ColName = c.Name
        '    colList.Add(dgvindex)
        'Next


        'For Each c As Object In colList

        'Next
        'EXCEL EXPORT - Create Data Table for Excel File Creation
        Try
            Dim dt As New DataTable(DataTableName)
            Dim row As DataRow
            Dim r As Integer = 0
            Dim TotalDatagridviewColumns As Integer = dgv.ColumnCount - 1
            'Add Datacolumn

            'For i As Integer = 0 To colList.Count - 1
            '    If colList(i).ColVisible = True Then
            '        Dim idColumn As DataColumn = New DataColumn()
            '        idColumn.ColumnName = colList(i).ColName
            '        dt.Columns.Add(idColumn)
            '    End If
            'Next



            For Each c As DataGridViewColumn In cols
                If c.Visible = True Then
                    Dim idColumn As DataColumn = New DataColumn()
                    idColumn.ColumnName = c.Name
                    dt.Columns.Add(idColumn)
                End If
            Next
            'Now Iterate thru Datagrid and create the data row
            Select Case RecipientExportType

                Case "RepGroup"
                    For Each dr As DataGridViewRow In dgv.Rows
                        If dr.Cells("SalesRepGroup").Value.ToString.Trim = salesrepgroup Then
                            'Iterate thru datagrid
                            row = dt.NewRow 'Create new row
                            'Iterate thru Column 1 up to the total number of columns
                            For i As Integer = 0 To TotalDatagridviewColumns
                                If dgv.Columns(i).Visible = True Then
                                    row.Item(r) = dr.Cells(i).Value.ToString
                                    r = r + 1
                                End If
                            Next
                            'Now add the row to Datarow Collection
                            dt.Rows.Add(row)
                            r = 0
                        End If
                    Next
                    'Now return the data table
                    Return dt

                Case "Reps"

                    For Each dr As DataGridViewRow In dgv.Rows
                        'Iterate thru datagrid
                        If dr.Cells("SalesPersonNo").Value.ToString.Trim = salesrepno Then
                            row = dt.NewRow 'Create new row
                            'Iterate thru Column 1 up to the total number of columns
                            For i As Integer = 0 To TotalDatagridviewColumns
                                If dgv.Columns(i).Visible = True Then
                                    row.Item(r) = dr.Cells(i).Value.ToString
                                    r = r + 1
                                End If
                            Next
                            'Now add the row to Datarow Collection
                            dt.Rows.Add(row)
                            r = 0
                        End If
                    Next
                    'Now return the data table
                    Return dt

                Case "FTP", "open", "history", "Excel"
                    For Each dr As DataGridViewRow In dgv.Rows
                        'Iterate thru datagrid
                        row = dt.NewRow 'Create new row
                        'Iterate thru Column 1 up to the total number of columns
                        'For i As Integer = 0 To cols.Count - 1
                        For Each col As DataGridViewColumn In cols
                            If col.Visible = True Then
                                row.Item(col.Name) = dr.Cells(col.Name).Value.ToString.Trim
                                r += 1
                            End If
                        Next
                        'Next
                        'For i As Integer = 0 To TotalDatagridviewColumns
                        '    If dgv.Columns(i).Visible = True Then
                        '        row.Item(r) = dr.Cells(i).Value.ToString
                        '        r = r + 1
                        '    End If
                        'Next
                        'Now add the row to Datarow Collection
                        dt.Rows.Add(row)
                        r = 0
                    Next
                    'Now return the data table
                    Return dt

            End Select

        Catch ex As Exception
            Return Nothing
        End Try

    End Function

    Public Function ExportDataTableToExcel(ByVal xlapp As Excel.Application, ByVal dt As DataTable, ByVal RecipientExportType As String, Optional ByVal RepGroup As String = "", _
                                        Optional ByVal RepName As String = "", _
                                        Optional ByVal RepNo As String = "") As Object


        'EXCEL EXPORT - Creates Excel File for Email Export 

        Dim MaxRow As String = dt.Rows.Count
        Dim MaxCol As String = (Convert.ToChar(dt.Columns.Count \ 26 + 64).ToString() + Convert.ToChar(dt.Columns.Count Mod 26 + 64).ToString()).Replace("@", "").Trim
        Dim MaxCell As String = MaxCol & MaxRow
        Dim i As Integer
        Dim j As Integer

        Dim filename As String
        Dim filepath_name As String = ""
        Dim SaveDate As String


        xlapp.Visible = False
        xlwbook = xlapp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet)
        xlwsheet = CType(xlwbook.Worksheets(1), Excel.Worksheet)

        For i = 0 To dt.Columns.Count - 1
            xlwsheet.Cells(1, i + 1) = dt.Columns(i).ColumnName
            'Select Case dt.Columns(i).ColumnName

            '    Case "InvoiceNumber", "OrderNumber", "BillToNo", "ShipToNo"
            '        Dim range As Excel.Range = xlwsheet.Range(xlwsheet.Cells(1, i + 1), xlwsheet.Cells(1, i + 1)).EntireColumn
            '        range.Select()
            '        range.NumberFormat = "0"
            '        'Case "InvoiceDate", "", ""

            '        'Case "BillToZip", "ShipToZip"

            'End Select
            'Dim range As Excel.Range = xlwsheet.Range(xlwsheet.Cells(1, i + 1), xlwsheet.Cells(1, i + 1)).EntireColumn
            'Dim range2 As Excel.Range
            'range = xlwsheet.Range(xlwsheet.Cells(1, i + 1), xlwsheet.Cells(20000, i + 1))
            'range2 = xlwsheet.Range(xlwsheet.Cells(1, i + 1), xlwsheet.Cells(1, i + 1)).EntireColumn
            'xlwsheet.Columns("G:G").
            'wb.Worksheets("Sheet1").Columns("B:B").NumberFormat = "m/d/yyyy;@"
        Next

        xlwsheet.Range("A1", MaxCol & "1").Font.Bold = True

        If dt.Rows.Count > 0 Then
            Dim values(dt.Rows.Count, dt.Columns.Count) As String

            For i = 0 To dt.Rows.Count - 1
                For j = 0 To dt.Columns.Count - 1
                    Select Case dt.Columns(j).ColumnName
                        Case "InvoiceNumber", "OrderNumber", "BillToNo", "ShipToNo"
                            'Need to strip off the zeros for Total Marketing
                            If IsNumeric(dt(i)(j)) = True Then
                                values(i, j) = Convert.ToInt32(dt(i)(j)).ToString()
                            Else
                                values(i, j) = ""
                            End If
                            'values(i, j) = IIf(IsNumeric(dt(i)(j)) = True, Convert.ToInt32(dt(i)(j)).ToString, "")

                        Case "SalesAmt_SubTotal", "Freight", "SalesAmt", "InvoiceAmount", "UnitPrice", "ExtendedPrice"
                            If IsNumeric(dt(i)(j)) = True Then
                                values(i, j) = Convert.ToDecimal(dt(i)(j)).ToString("N2")
                            Else
                                values(i, j) = ""
                            End If
                        Case "ShipDate", "InvoiceDate"
                            If IsDate(dt(i)(j)) = True Then
                                values(i, j) = Convert.ToDateTime(dt(i)(j)).ToString("MM/dd/yyyy")
                            Else
                                values(i, j) = ""
                            End If
                        Case "Discount"
                            If IsNumeric(dt(i)(j)) = True Then
                                values(i, j) = String.Format("{0:0.00}", (dt(i)(j))).ToString & "%"
                            Else
                                values(i, j) = ""
                            End If
                        Case Else
                            values(i, j) = dt(i)(j).ToString
                    End Select

                Next
            Next
            xlwsheet.Range("A2", MaxCell).Value2 = values
        End If

        If RecipientExportType > "" Then
            Try
                xlapp.Visible = False

                Select Case RecipientExportType

                    Case "RepGroup"

                        With xlwbook
                            SaveDate = Now.ToString("yyyyMMdd_hhmmss")
                            filename = RepGroup & "_" & SaveDate & "_" & RecipientExportType & ".xls"
                            filepath_name = appsettings.RepSaveExcelFolderPath & "\" & filename
                            .SaveAs(filepath_name, Excel.XlFileFormat.xlExcel8)
                            'ExcelFileNames.Add(filepath_name)
                            .Close()
                        End With
                        Return filepath_name

                    Case "Reps"

                        With xlwbook
                            SaveDate = Now.ToString("yyyyMMdd_hhmmss")
                            filename = RepName & "_" & SaveDate & "_" & ".xls"
                            filepath_name = appsettings.RepSaveExcelFolderPath & "\" & filename
                            .SaveAs(filepath_name, Excel.XlFileFormat.xlExcel8)
                            'ExcelFileNames.Add(filepath_name)
                            .Close()
                        End With
                        Return filepath_name

                    Case "FTP", "open", "history"

                        With xlwbook
                            SaveDate = Now.ToString("yyyyMMdd_hhmmss")
                            filename = "ma_in_" & SaveDate & RecipientExportType & ".xls"
                            appsettings.FTPLocalFileName = appsettings.Path & "\" & filename
                            appsettings.FTPUploadFileName = SaveDate & RecipientExportType & ".xls"
                            filepath_name = appsettings.Path & "\" & filename
                            .SaveAs(filepath_name, Excel.XlFileFormat.xlExcel8)
                            'ExcelFileNames.Add(filepath_name)
                            .Close()
                        End With
                    Case "Excel"
                        xlapp.Visible = True

                End Select
                xlwsheet = Nothing
                While (ReleaseComObject(xlwbook)) <> 0
                End While
                xlwbook = Nothing

            Catch ex As Exception
                MsgBox(ex.Message)
                Return Nothing
            Finally


                GC.WaitForPendingFinalizers()
                GC.Collect()
                GC.WaitForPendingFinalizers()
                GC.Collect()
            End Try

            Return filepath_name
        Else

            'xlapp.Visible = True
            Return Nothing

        End If


    End Function

    Private Class DGVDisplayIndex
        Private mDGVIndex As Integer
        Public Property DGVIndex() As String
            Get
                Return mDGVIndex
            End Get
            Set(ByVal value As String)
                mDGVIndex = value
            End Set
        End Property
        Private mDGVDisplayIndex As Integer
        Public Property DGVDisplayIndex() As Integer
            Get
                Return mDGVDisplayIndex
            End Get
            Set(ByVal value As Integer)
                mDGVDisplayIndex = value
            End Set
        End Property
        Private mColVisible As Boolean
        Public Property ColVisible() As Boolean
            Get
                Return mColVisible
            End Get
            Set(ByVal value As Boolean)
                mColVisible = value
            End Set
        End Property
        Private mColName As String
        Public Property ColName() As String
            Get
                Return mColName
            End Get
            Set(ByVal value As String)
                mColName = value
            End Set
        End Property


    End Class
End Module
