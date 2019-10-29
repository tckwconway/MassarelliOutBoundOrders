Imports Microsoft.Office.Core
Imports Microsoft.Office.Interop

Public Class EmailFromOutlook
    Private oApp As Outlook._Application
    Private Sub SendEmail()
        Dim oAcct As Outlook.Account
        
        '' Create a new MailItem.
        For i As Integer = 1 To oApp.Session.Accounts.Count
            If oApp.Session.Accounts.Item(i).DisplayName = Me.ComboBoxAccounts.Text Then
                oAcct = oApp.Session.Accounts.Item(i)
            End If
        Next

        Dim oMsg As Outlook._MailItem
        oMsg = oApp.CreateItem(Outlook.OlItemType.olMailItem)
        oMsg.Subject = "Send Attachment Using OOM in Visual Basic .NET"
        oMsg.Body = "Hello World" & vbCr & vbCr
        oMsg.SendUsingAccount = oAcct

        ' TODO: Replace with a valid e-mail address.
        oMsg.To = "tckwconway@gmail.com"

        ' Add an attachment
        ' TODO: Replace with a valid attachment path.
        Dim sSource As String = "C:\Hello.txt"
        ' TODO: Replace with attachment name
        Dim sDisplayName As String = "Hello.txt"

        Dim sBodyLen As String = oMsg.Body.Length
        Dim oAttachs As Outlook.Attachments = oMsg.Attachments
        Dim oAttach As Outlook.Attachment
        oAttach = oAttachs.Add(sSource, , sBodyLen + 1, sDisplayName)

        ' Send
        oMsg.Send()

        ' Clean up
        oApp = Nothing
        oMsg = Nothing
        oAttach = Nothing
        oAttachs = Nothing
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        SendEmail()
    End Sub

    Private Sub EmailFromOutlook_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Startup()
    End Sub
    Private Sub Startup()

        oApp = New Outlook.Application()
        ComboBoxAccounts.Items.Clear()
        For i As Integer = 1 To oApp.Session.Accounts.Count
            Try
                Me.ComboBoxAccounts.Items.Add(oApp.Session.Accounts.Item(i).SmtpAddress)
            Catch ex As Exception

            End Try

        Next
    End Sub


    Private Sub ButtonExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonExit.Click
        Me.Close()
    End Sub

    
    Private Sub ButtonAttach_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAttach.Click
        Dim ofd As OpenFileDialog = Me.OpenFileDialog1
        ofd.ShowDialog()
        Dim filename = ofd.FileName
    End Sub
End Class