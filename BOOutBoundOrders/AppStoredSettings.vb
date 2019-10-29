Imports System.ComponentModel
Imports System.Data.DataRowView
Imports System.Data.SqlClient
Imports System.Data
Imports System.Text
Imports System

Public Class AppStoredSettings

#Region "   Properties   "

    Private mPath As String
    Public Property Path() As String
        Get
            Return mPath
        End Get
        Set(ByVal value As String)
            mPath = value
        End Set
    End Property


    Private mDefaultRepGroup As String
    Public Property DefaultRepGroup() As String
        Get
            Return mDefaultRepGroup
        End Get
        Set(ByVal value As String)
            mDefaultRepGroup = value
        End Set
    End Property


    Private mUserName As String
    Public Property UserName() As String
        Get
            Return mUserName
        End Get
        Set(ByVal value As String)
            mUserName = value
        End Set
    End Property

    Private mPassword As String
    Public Property Password() As String
        Get
            Return mPassword
        End Get
        Set(ByVal value As String)
            mPassword = value
        End Set
    End Property


    Private mFTPUploadLocation As String
    Public Property FTPUploadLocation() As String
        Get
            Return mFTPUploadLocation
        End Get
        Set(ByVal value As String)
            mFTPUploadLocation = value
        End Set
    End Property

    Private mFTPHost As String
    Public Property FTPHost() As String
        Get
            Return mFTPHost
        End Get
        Set(ByVal value As String)
            mFTPHost = value
        End Set
    End Property

    Private mFTPPort As String
    Public Property FTPPort() As String
        Get
            Return mFTPPort
        End Get
        Set(ByVal value As String)
            mFTPPort = value
        End Set
    End Property

    Private mFTPUserName As String
    Public Property FTPUserName() As String
        Get
            Return mFTPUserName
        End Get
        Set(ByVal value As String)
            mFTPUserName = value
        End Set
    End Property

    Private mFTPPassword As String
    Public Property FTPPassword() As String
        Get
            Return mFTPPassword
        End Get
        Set(ByVal value As String)
            mFTPPassword = value
        End Set
    End Property


    Private mFTPLocalFileName As String
    Public Property FTPLocalFileName() As String
        Get
            Return mFTPLocalFileName
        End Get
        Set(ByVal value As String)
            mFTPLocalFileName = value
        End Set
    End Property

    Private mFTPUploadFileName As String
    Public Property FTPUploadFileName() As String
        Get
            Return mFTPUploadFileName
        End Get
        Set(ByVal value As String)
            mFTPUploadFileName = value
        End Set
    End Property

    Private mRepSaveExcelFolderPath As String
    Public Property RepSaveExcelFolderPath() As String
        Get
            Return mRepSaveExcelFolderPath
        End Get
        Set(ByVal value As String)
            mRepSaveExcelFolderPath = value
        End Set
    End Property

    Private mDataGridColumnLayoutFilePath As String
    Public Property DataGridColumnLayoutFilePath() As String
        Get
            Return mDataGridColumnLayoutFilePath
        End Get
        Set(ByVal value As String)
            mDataGridColumnLayoutFilePath = value
        End Set
    End Property


    Private mXMLFileName As String
    Public Property XMLFileName() As String
        Get
            Return mXMLFileName
        End Get
        Set(ByVal value As String)
            mXMLFileName = value
        End Set
    End Property


    Private mFromEmail As String
    Public Property FromEmail() As String
        Get
            Return mFromEmail
        End Get
        Set(ByVal value As String)
            mFromEmail = value
        End Set
    End Property


    Private mPendingXMLDefault As String
    Public Property PendingXMLDefault() As String
        Get
            Return mPendingXMLDefault
        End Get
        Set(ByVal value As String)
            value = "<Columns><Column><Name>BillToAddr1</Name><Value>True</Value></Column><Column><Name>BillToAddr2</Name><Value>True</Value></Column><Column><Name>BillToCity</Name><Value>True</Value></Column><Column><Name>BillToName</Name><Value>True</Value></Column><Column><Name>BillToNo</Name><Value>True</Value></Column><Column><Name>BillToState</Name><Value>True</Value></Column><Column><Name>BillToZip</Name><Value>True</Value></Column><Column><Name>Company</Name><Value>True</Value></Column><Column><Name>Discount</Name><Value>True</Value></Column><Column><Name>ExtendedPrice</Name><Value>True</Value></Column><Column><Name>Finish</Name><Value>True</Value></Column><Column><Name>Freight</Name><Value>True</Value></Column><Column><Name>InvoiceAmount</Name><Value>False</Value></Column><Column><Name>InvoiceDate</Name><Value>False</Value></Column><Column><Name>InvoiceNumber</Name><Value>False</Value></Column><Column><Name>ItemDescription</Name><Value>True</Value></Column><Column><Name>ItemNo</Name><Value>True</Value></Column><Column><Name>OrderNumber</Name><Value>True</Value></Column><Column><Name>PONumber</Name><Value>True</Value></Column><Column><Name>Qty</Name><Value>True</Value></Column><Column><Name>SalesAmt</Name><Value>True</Value></Column><Column><Name>SalesAmt_Subtotal</Name><Value>True</Value></Column><Column><Name>SalesPersonName</Name><Value>True</Value></Column><Column><Name>SalesPersonNo</Name><Value>True</Value></Column><Column><Name>ShipDate</Name><Value>True</Value></Column><Column><Name>ShippingInstruction</Name><Value>True</Value></Column><Column><Name>ShipToAddr1</Name><Value>True</Value></Column><Column><Name>ShipToAddr2</Name><Value>True</Value></Column><Column><Name>ShipToCity</Name><Value>True</Value></Column><Column><Name>ShipToName</Name><Value>True</Value></Column><Column><Name>ShipToNo</Name><Value>True</Value></Column><Column><Name>ShipToState</Name><Value>True</Value></Column><Column><Name>ShipToZip</Name><Value>True</Value></Column><Column><Name>ShipViaDesc</Name><Value>True</Value></Column><Column><Name>Terms</Name><Value>True</Value></Column><Column><Name>UnitPrice</Name><Value>True</Value></Column><Column><Name>UOM</Name><Value>True</Value></Column></Columns>"
            mPendingXMLDefault = value
        End Set
    End Property

    Private mHistoryXMLDefault As String
    Public Property HistoryXMLDefault() As String
        Get
            Return mHistoryXMLDefault
        End Get
        Set(ByVal value As String)
            value = "<Columns><Column><Name>BillToAddr1</Name><Value>True</Value></Column><Column><Name>BillToAddr2</Name><Value>True</Value></Column><Column><Name>BillToCity</Name><Value>True</Value></Column><Column><Name>BillToName</Name><Value>True</Value></Column><Column><Name>BillToNo</Name><Value>True</Value></Column><Column><Name>BillToState</Name><Value>True</Value></Column><Column><Name>BillToZip</Name><Value>True</Value></Column><Column><Name>Company</Name><Value>True</Value></Column><Column><Name>Discount</Name><Value>True</Value></Column><Column><Name>ExtendedPrice</Name><Value>True</Value></Column><Column><Name>Finish</Name><Value>True</Value></Column><Column><Name>Freight</Name><Value>True</Value></Column><Column><Name>InvoiceAmount</Name><Value>True</Value></Column><Column><Name>InvoiceDate</Name><Value>True</Value></Column><Column><Name>InvoiceNumber</Name><Value>True</Value></Column><Column><Name>ItemDescription</Name><Value>True</Value></Column><Column><Name>ItemNo</Name><Value>True</Value></Column><Column><Name>OrderNumber</Name><Value>True</Value></Column><Column><Name>PONumber</Name><Value>True</Value></Column><Column><Name>Qty</Name><Value>True</Value></Column><Column><Name>SalesAmt</Name><Value>True</Value></Column><Column><Name>SalesAmt_Subtotal</Name><Value>True</Value></Column><Column><Name>SalesPersonName</Name><Value>True</Value></Column><Column><Name>SalesPersonNo</Name><Value>True</Value></Column><Column><Name>ShipDate</Name><Value>True</Value></Column><Column><Name>ShippingInstruction</Name><Value>True</Value></Column><Column><Name>ShipToAddr1</Name><Value>True</Value></Column><Column><Name>ShipToAddr2</Name><Value>True</Value></Column><Column><Name>ShipToCity</Name><Value>True</Value></Column><Column><Name>ShipToName</Name><Value>True</Value></Column><Column><Name>ShipToNo</Name><Value>True</Value></Column><Column><Name>ShipToState</Name><Value>True</Value></Column><Column><Name>ShipToZip</Name><Value>True</Value></Column><Column><Name>ShipViaDesc</Name><Value>True</Value></Column><Column><Name>Terms</Name><Value>True</Value></Column><Column><Name>UnitPrice</Name><Value>True</Value></Column><Column><Name>UOM</Name><Value>True</Value></Column></Columns>"
            mHistoryXMLDefault = value
        End Set
    End Property





#End Region

#Region "   Methods   "

    Public Function LoadSettings(ByVal cn As SqlConnection) As SqlDataReader

        Dim rd As SqlDataReader
        Dim sql As String
        sql = "Select ob_file_path, ob_rep_organization, ob_rep_save_excel_folder, ob_email_dflt_from, ob_ftp_upload_location,ob_ftp_host ,ob_ftp_port ,ob_ftp_username ,ob_ftp_password from OEOBSETTINGS2012_MAS "
        rd = BusObj.ExecuteSQLReader(sql, cn)

        Return rd

    End Function
    Public Shared Function CheckForEmptyTable(ByVal cn As SqlConnection) As Integer
        Dim sql As String
        Dim ret As Integer
        sql = "Select 1 from OEOBSETTINGS2012_MAS "
        ret = BusObj.ExecuteSQL_Scalar(sql, cn)
        Return ret
    End Function
    Public Shared Sub SaveRepGroup(ByVal RepGroup As String, ByVal cn As SqlConnection)
        Dim sql As String
        Dim ret As Integer = CheckForEmptyTable(cn)

        If ret = 1 Then
            sql = "Update OEOBSETTINGS2012_MAS Set ob_rep_organization = '" & RepGroup & "'"
            BusObj.ExecuteNonSQL(sql, cn)
        Else
            sql = "Insert Into OEOBSETTINGS2012_MAS (ob_rep_organization) Values('" & RepGroup & "')"
            BusObj.ExecuteNonSQL(sql, cn)
        End If

    End Sub

    Public Shared Sub SavePath(ByVal Path As String, ByVal FTPLocation As String, ByVal FTPHost As String, ByVal FTPPort As String, ByVal cn As SqlConnection)
        Dim sql As String
        Dim ret As Integer = CheckForEmptyTable(cn)

        If ret = 1 Then
            sql = "Update OEOBSETTINGS2012_MAS Set " & _
                    "ob_file_path = '" & Path & "', " & _
                    "ob_ftp_upload_location = '" & FTPLocation & "', " & _
                    "ob_ftp_host = '" & FTPHost & "', " & _
                    "ob_ftp_port = '" & FTPPort & "'"
            BusObj.ExecuteNonSQL(sql, cn)
        Else
            sql = "Insert Into OEOBSETTINGS2012_MAS (ob_file_path, ob_ftp_upload_location, ob_ftp_host, ob_ftp_port) " & _
                  "Values('" & Path & "', '" & FTPLocation & "', '" & FTPHost & "', '" & FTPPort & "')"
            BusObj.ExecuteNonSQL(sql, cn)
        End If

    End Sub

    Public Shared Sub SaveUserPassword(ByVal UserName As String, ByVal Password As String, ByVal cn As SqlConnection)
        Dim sql As String
        Dim ret As Integer = CheckForEmptyTable(cn)

        If ret = 1 Then
            sql = "Update OEOBSETTINGS2012_MAS Set ob_ftp_username = '" & UserName & "', ob_ftp_password = '" & Password & "'"
            BusObj.ExecuteNonSQL(sql, cn)
        Else
            sql = "Insert Into OEOBSETTINGS2012_MAS (ob_ftp_username, ob_ftp_password) Values('" & UserName & "', '" & Password & "')"
            BusObj.ExecuteNonSQL(sql, cn)
        End If

    End Sub

    Public Shared Sub SaveGridColumnLayoutPath(ByVal GridColumnLayoutFolderPath As String, ByVal cn As SqlConnection)
        Dim sql As String
        Dim ret As Integer = CheckForEmptyTable(cn)

        If ret = 1 Then
            sql = "Update OEOBSETTINGS2012_MAS Set ob_rep_save_excel_folder = '" & GridColumnLayoutFolderPath & "'"
            BusObj.ExecuteNonSQL(sql, cn)
        Else
            sql = "Insert Into OEOBSETTINGS2012_MAS (ob_rep_save_excel_folder) Values('" & GridColumnLayoutFolderPath & "')"
            BusObj.ExecuteNonSQL(sql, cn)
        End If

    End Sub
    Public Shared Sub SaveDefaultFromEmail(ByVal FromEmailAddress As String, ByVal cn As SqlConnection)
        Dim sql As String
        Dim ret As Integer = CheckForEmptyTable(cn)

        If ret = 1 Then
            sql = "Update OEOBSETTINGS2012_MAS Set ob_rep_save_excel_folder = '" & FromEmailAddress & "'"
            BusObj.ExecuteNonSQL(sql, cn)
        Else
            sql = "Insert Into OEOBSETTINGS2012_MAS (ob_rep_save_excel_folder) Values('" & FromEmailAddress & "')"
            BusObj.ExecuteNonSQL(sql, cn)
        End If

    End Sub
#End Region


End Class
