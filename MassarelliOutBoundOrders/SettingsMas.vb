Imports MassarelliOutBoundOrders
Imports System.Data.SqlClient
Imports System.Collections.Generic
Public Class SettingsMas
    Dim appstng As AppStoredSettings = MassarelliOutBound.appsettings
#Region "  Methods   "

    Private Sub LoadSettings()
        Dim rd As SqlDataReader
        Dim sql As String
        sql = "Select ob_file_path, ob_rep_organization, ob_ftp_upload_location, ob_ftp_host, ob_ftp_port, ob_ftp_username, ob_ftp_password, ob_rep_save_excel_folder, ob_email_dflt_from from OEOBSETTINGS2012_MAS "
        rd = BusObj.ExecuteSQLReader(sql, cn)

        If rd.HasRows Then

            While rd.Read
                With MassarelliOutBound.appsettings
                    If rd("ob_file_path") Is DBNull.Value Then .Path = "" Else .Path = rd("ob_file_path")
                    If rd("ob_rep_organization") Is DBNull.Value Then .DefaultRepGroup = "" Else .DefaultRepGroup = rd("ob_rep_organization")
                    If rd("ob_ftp_upload_location") Is DBNull.Value Then .FTPUploadLocation = "" Else .FTPUploadLocation = rd("ob_ftp_upload_location")
                    If rd("ob_ftp_host") Is DBNull.Value Then .FTPHost = "" Else .FTPHost = rd("ob_ftp_host")
                    If rd("ob_ftp_port") Is DBNull.Value Then .FTPPort = "" Else .FTPPort = rd("ob_ftp_port")
                    If rd("ob_ftp_username") Is DBNull.Value Then .FTPUserName = "" Else .FTPUserName = rd("ob_ftp_username")
                    If rd("ob_ftp_password") Is DBNull.Value Then .FTPPassword = "" Else .FTPPassword = rd("ob_ftp_password")
                    If rd("ob_rep_save_excel_folder") Is DBNull.Value Then .RepSaveExcelFolderPath = "" Else .RepSaveExcelFolderPath = rd("ob_rep_save_excel_folder")
                    If rd("ob_email_dflt_from") Is DBNull.Value Then .FromEmail = "" Else .FromEmail = rd("ob_email_dflt_from")

                End With
            End While

            AppStoredSettingsBindingSource.DataSource = appstng
            'Me.TextBoxPassword.DataBindings("Text").ReadValue()
            Me.TextBoxDefaultRepGroup.DataBindings("Text").ReadValue()
            Me.TextBoxRemoteLocation.DataBindings("Text").ReadValue()
            Me.TextBoxFTPHost.DataBindings("Text").ReadValue()
            Me.TextBoxFTPPort.DataBindings("Text").ReadValue()
            Me.TextBoxUserName.DataBindings("Text").ReadValue()
            Me.TextBoxGridFolderPath.DataBindings("Text").ReadValue()
            Me.TextBoxFromEmail.DataBindings("Text").ReadValue()

            'Me.TextBoxPassword.Refresh()
            Me.TextBoxDefaultRepGroup.Refresh()
            Me.TextBoxRemoteLocation.Refresh()
            Me.TextBoxFTPHost.Refresh()
            Me.TextBoxFTPPort.Refresh()
            Me.TextBoxUserName.Refresh()
            Me.TextBoxGridFolderPath.Refresh()
            Me.TextBoxFromEmail.Refresh()
        End If

        rd.Close()

        IsDirty = False

        Me.ButtonOpenFile.Select()

        With Me.ListBoxRepGroups
            .DataSource = MassarelliOutBound.reps
            .DisplayMember = "RepGroup"
            .ValueMember = "RepGroup"
        End With

    End Sub
    Private Sub GenerateUserPassword()
        Dim des As New TripleDES
        Dim sDelimiter As String
        Dim sValue As String
        Dim i As Integer
        Dim user As String
        Dim pwd() As Byte

        user = Me.TextBoxUserName.Text
        pwd = des.Encrypt(Me.TextBoxPassword.Text)

        Dim ipwd As Int32 = UBound(pwd)

        Dim spwd(pwd.Length - 1) As String

        sDelimiter = ","

        For i = LBound(pwd) To UBound(pwd)
            spwd(i) = CStr(pwd(i))
        Next i

        sValue = Join(spwd, sDelimiter)
        MassarelliOutBound.appsettings.FTPUserName = user
        MassarelliOutBound.appsettings.FTPPassword = sValue
    End Sub
    Private Sub SaveSettings(ByVal sender As System.Object)
        Dim btn As Button = DirectCast(sender, Button)
        Dim ListArray As New List(Of Object)

        Select Case btn.Name
            Case "ButtonSaveRepGroup"
                ListArray.Add("SaveRepGroup")
                ListArray.Add(MassarelliOutBound.appsettings.DefaultRepGroup)
                ListArray.Add(cn)
            Case "ButtonSavePath"
                ListArray.Add("SavePath")
                ListArray.Add(MassarelliOutBound.appsettings.Path)
                ListArray.Add(MassarelliOutBound.appsettings.FTPUploadLocation)
                ListArray.Add(MassarelliOutBound.appsettings.FTPHost)
                ListArray.Add(MassarelliOutBound.appsettings.FTPPort)
                ListArray.Add(cn)
            Case "ButtonSaveUserPassword"
                ListArray.Add("SaveUserPassword")
                ListArray.Add(MassarelliOutBound.appsettings.FTPUserName)
                ListArray.Add(MassarelliOutBound.appsettings.FTPPassword)
                ListArray.Add(cn)
            Case "ButtonSaveGridLayoutFolder"
                ListArray.Add("SaveGridColumnLayoutPath")
                ListArray.Add(MassarelliOutBound.appsettings.RepSaveExcelFolderPath)
                ListArray.Add(cn)
            Case "ButtonSaveFromEmail"
                ListArray.Add("SaveDefaultFromEmail")
                ListArray.Add(MassarelliOutBound.appsettings.FromEmail)
                ListArray.Add(cn)
        End Select
       
        Dim i As Integer
        Dim c As Integer = ListArray.Count - 1
        Dim oArray(c) As Object
        For i = 0 To c
            oArray(i) = ListArray(i)
        Next


        MyBase.Save(MassarelliOutBound.appsettings, oArray)

        IsDirty = False

    End Sub

#End Region

#Region "   Buttons   "

    Private Sub SettingsMas_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim ret As Integer
        'If IsDirty = True Then
        '    ret = MessageBox.Show("Save changed settings?", "Save Settings", MessageBoxButtons.YesNo)
        '    If ret = MsgBoxResult.Yes Then
        '        SaveSettings(sender)
        '    End If
        'End If
        MassarelliOutBound.ComboBoxRepGroup.Text = MassarelliOutBound.appsettings.DefaultRepGroup
        MassarelliOutBound.Refresh()
        MassarelliOutBound.TextBoxStartDate.Focus()
    End Sub

    Private Sub SettingsMas_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadSettings()
    End Sub

    Private Sub ButtonOpenFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonOpenFile.Click

        Dim ofd As FolderBrowserDialog = Me.FolderBrowserDialog1
        ofd.ShowDialog()
        Dim filepath As String
        Try
            filepath = System.IO.Path.GetDirectoryName(Me.FolderBrowserDialog1.SelectedPath)
            filepath = Me.FolderBrowserDialog1.SelectedPath
            appstng.Path = filepath
            AppStoredSettingsBindingSource.DataSource = appstng
            Me.TextBoxPath.DataBindings("Text").ReadValue()
            Me.TextBoxPath.Refresh()
            IsDirty = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ListBoxRepGroups_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListBoxRepGroups.MouseClick

        Dim lst As ListBox = DirectCast(sender, ListBox)
        appstng.DefaultRepGroup = lst.SelectedValue.ToString
        Me.AppStoredSettingsBindingSource.DataSource = appstng

        Me.TextBoxDefaultRepGroup.DataBindings("Text").ReadValue()
        Me.TextBoxDefaultRepGroup.Refresh()

        If Me.TextBoxDefaultRepGroup.Text <> MassarelliOutBound.appsettings.DefaultRepGroup Then
            IsDirty = True
        End If

    End Sub

    'Private Sub ListBoxRepGroups_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListBoxRepGroups.MouseDoubleClick


    'End Sub

#End Region

#Region "   Properties   "

    Private mIsDirty As Boolean
    Public Property IsDirty() As Boolean
        Get
            Return mIsDirty
        End Get
        Set(ByVal value As Boolean)
            mIsDirty = value
        End Set
    End Property

#End Region

   

 
  
    Private Sub Mas500Toolbar_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles Mas500Toolbar.ItemClicked

        Select Case e.ClickedItem.Name

            'Case "ButtonSave"

            '    Me.SaveSettings(sender)
            '    MsgBox("Settings Saved", MsgBoxStyle.OkOnly, "Save")

            Case "ButtonExit"

                Me.Close()

        End Select
    End Sub

    Private Sub ButtonReloadDefaults_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LoadSettings()
    End Sub

    Private Sub ListBoxRepGroups_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBoxRepGroups.SelectedIndexChanged

    End Sub

    Private Sub ButtonSavePath_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.SaveSettings(sender)
    End Sub

    Private Sub SaveButton(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSaveRepGroup.Click, ButtonSavePath.Click, ButtonSaveGridLayoutFolder.Click, ButtonSaveFromEmail.Click

        'If TextBoxPassword.Text = TextBoxConfirmPassword.Text Then
        '    Me.TextBoxPwdEncrypted.Text = EncryptPassword(TextBoxPassword.Text)
        '    Me.TextBoxPwdEncrypted.DataBindings("Text").WriteValue()

        Try
            SaveSettings(sender)
            MsgBox("Settings Saved", MsgBoxStyle.OkOnly, "Save")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        'Else
        'MsgBox("Passwords do not match.  User and password were not saved.", MsgBoxStyle.OkOnly, "Unmatching Password")
        'End If


    End Sub
    Private Function EncryptPassword(ByVal pwd As String) As String
        Dim des As New TripleDES
        Dim pwdEncrypted As String
        Dim bpwd() As Byte = des.Encrypt(pwd)
        Dim ipwd As Int32 = UBound(bpwd)
        Dim spwd(bpwd.Length - 1) As String
        Dim sDelimiter = ","

        For i = LBound(bpwd) To UBound(bpwd)
            spwd(i) = CStr(bpwd(i))
        Next i

        pwdEncrypted = Join(spwd, sDelimiter)

        Return pwdEncrypted

    End Function

    Private Sub ButtonOpenGridFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonOpenGridFile.Click

        Dim ofd As FolderBrowserDialog = Me.FolderBrowserDialog1
        ofd.Description = "Select a folder where the Rep Group and Rep Excel files will be saved."
        ofd.ShowDialog()
        Dim filepath As String
        Try
            filepath = System.IO.Path.GetDirectoryName(Me.FolderBrowserDialog1.SelectedPath)
            filepath = Me.FolderBrowserDialog1.SelectedPath
            appstng.RepSaveExcelFolderPath = filepath
            AppStoredSettingsBindingSource.DataSource = appstng
            Me.TextBoxGridFolderPath.DataBindings("Text").ReadValue()
            Me.TextBoxGridFolderPath.Refresh()
            IsDirty = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub ButtonSaveUserPassword_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSaveUserPassword.Click
        If TextBoxPassword.Text = TextBoxConfirmPassword.Text Then
            Me.TextBoxPwdEncrypted.Text = EncryptPassword(TextBoxPassword.Text)
            Me.TextBoxPwdEncrypted.DataBindings("Text").WriteValue()

            Try
                SaveSettings(sender)
                MsgBox("Settings Saved", MsgBoxStyle.OkOnly, "Save")
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            MsgBox("Passwords do not match.  User and password were not saved.", MsgBoxStyle.OkOnly, "Unmatching Password")
        End If
    End Sub

    
End Class