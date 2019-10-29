Imports Microsoft.Office.Core
Imports Microsoft.Office.Interop
Imports System.Runtime.InteropServices.Marshal
Imports System.Text
Imports MassarelliOutBoundOrders.Utilities.FTP
Public Class FTPOptions
    Private ftpobj As New FTPFileList("", "", "", "", "", "", "")
    Private ftplst As New List(Of FTPFileList)
    Private appstg As AppStoredSettings = MassarelliOutBound.appsettings
    Private dgv As DataGridView = MassarelliOutBound.OutBoundObjDataGridView
    Private exporttype As String = MassarelliOutBound.exporttype
    Private xlapp As Excel.Application = MassarelliOutBound.xlapp

    Private Sub FTPOptions_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadSettings()
    End Sub
    Private Sub LoadSettings()
        ExportToExcel()
        Try
            ftplst.Clear()
        Catch ex As Exception

        End Try
        ftplst.Add(ftpobj)

        With ftplst(0)
            .ftphost = appstg.FTPHost
            .ftpport = appstg.FTPPort
            .ftppwd = appstg.FTPPassword
            .ftpuser = appstg.FTPUserName
            .ftplocalfilename = appstg.FTPLocalFileName
            .ftpuploadfilename = appstg.FTPUploadFileName
            .ftpuploadloc = appstg.FTPUploadLocation
        End With

        Me.FTPFileListBindingSource.DataSource = ftplst

        Me.FtphostTextBox.DataBindings("Text").ReadValue()
        Me.FtpportTextBox.DataBindings("Text").ReadValue()
        Me.FtppwdTextBox.DataBindings("Text").ReadValue()
        Me.FtpuserTextBox.DataBindings("Text").ReadValue()
        Me.FtplocalfilenameLinkLabel.DataBindings("Text").ReadValue()
        Me.FtpuploadfilenameTextBox.DataBindings("Text").ReadValue()
        Me.FtpuploadlocTextBox.DataBindings("Text").ReadValue()
    End Sub
    Private Function ExportToExcel() As String
        Dim filename As String = ""
        Dim dt As DataTable
        If exporttype = "0" Then
            exporttype = "open"
        Else
            exporttype = "history"
        End If

        dt = ExcelExport.DataGridViewToDataTable(dgv, exporttype, "", "", "")

        filename = ExcelExport.ExportDataTableToExcel(xlapp, dt, exporttype, "", "", "")
        Return filename
    End Function

    Private Sub FtplocalfilenameLinkLabel_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles FtplocalfilenameLinkLabel.Paint
        'TODO PAINT CONTROL
        'Dim CadetBluePen As New Pen(Color.CadetBlue, 2)
        'Dim rect As Rectangle = e.ClipRectangle
        'e.Graphics.DrawRectangle(CadetBluePen, rect)
    End Sub

    Private Sub FtplocalfilenameLinkLabel_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles FtplocalfilenameLinkLabel.LinkClicked
        Dim ftplnk As LinkLabel = DirectCast(sender, LinkLabel)
        Process.Start(ftplnk.Text)
    End Sub

    Private Sub GroupBox2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub ButtonOpenFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonOpenFile.Click

        Dim ofd As OpenFileDialog = Me.OpenFileDialogFTP
        With ofd
            .Filter = "Excel File 2003 (*.xls)|*.xls|Excel File 2007 (*.xlsx)|*.xlsx|All Files (*.*|*.*"
            .InitialDirectory = appstg.Path
            .FileName = ""
        End With
        ofd.ShowDialog()
        Dim filepath As String
        Try
            filepath = ofd.FileName
            appstg.FTPLocalFileName = filepath
            ftplst(0).ftplocalfilename = appstg.FTPLocalFileName

            'Change FTPUploadFileName to Match
            Dim ftpfile As String = filepath.Substring(filepath.IndexOf("ma_in_") + 6)
            appstg.FTPUploadFileName = ftpfile
            ftplst(0).ftpuploadfilename = appstg.FTPUploadFileName
            Me.FtplocalfilenameLinkLabel.DataBindings("Text").ReadValue()
            Me.FtpuploadfilenameTextBox.DataBindings("Text").ReadValue()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ButtonCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCancel.Click
        Me.Close()
    End Sub

    Private Sub ButtonExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonExit.Click
        Me.Close()
    End Sub

    Private Sub ButtonSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSend.Click
        FTPSend()
    End Sub

    Private Sub FTPSend()

        Dim ftphost As String = ""
        Dim ftpport As String = ""
        Dim ftpuser As String = ""
        Dim ftppwd As String = ""
        Dim ftpuploadloc As String = ""
        Dim ftplocalfilename As String = ""
        Dim ftpuploadfilename As String = ""
        Dim ftplocalfileexists As Boolean

        ftplocalfileexists = System.IO.File.Exists(ftplst(0).ftplocalfilename)
        If ftplocalfileexists = False Then
            MsgBox("The Excel File cound not be found.  Check the Filename and location.", MsgBoxStyle.OkOnly, "File Not Found")
            Exit Sub
        End If
        
        With ftplst(0)

            ftphost = .ftphost
            ftpport = .ftpport
            ftpuser = .ftpuser
            ftppwd = .ftppwd
            ftpuploadloc = .ftpuploadloc
            ftplocalfilename = .ftplocalfilename
            ftpuploadfilename = ftpuploadloc & "/" & .ftpuploadfilename
            ftppwd = AppUtilities.UnEncryptPassword(ftppwd)

        End With

        Dim ftpcl As New FTPclient(ftphost & ":" & ftpport, ftpuser, ftppwd)
        Try

            ftpcl.Upload(ftplocalfilename, ftpuploadfilename)
            MessageBox.Show("FTP File " & appstg.FTPLocalFileName & " successfully uploaded.", "FTP Send", MessageBoxButtons.OK)

        Catch ex As Exception

            MessageBox.Show("FTP Send: Error Occurred.  Error Message: " & ex.Message, "FTP Error", MessageBoxButtons.OK)

        End Try

    End Sub

End Class