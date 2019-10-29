Public Class FTPFileList

    Private mftphost As String
    Public Property ftphost() As String
        Get
            Return mftphost
        End Get
        Set(ByVal value As String)
            mftphost = value
        End Set
    End Property


    Private mftpport As String
    Public Property ftpport() As String
        Get
            Return mftpport
        End Get
        Set(ByVal value As String)
            mftpport = value
        End Set
    End Property

    Private mftpuser As String
    Public Property ftpuser() As String
        Get
            Return mftpuser
        End Get
        Set(ByVal value As String)
            mftpuser = value
        End Set
    End Property

    Private mftppwd As String
    Public Property ftppwd() As String
        Get
            Return mftppwd
        End Get
        Set(ByVal value As String)
            mftppwd = value
        End Set
    End Property

    Private mftpuploadloc As String
    Public Property ftpuploadloc() As String
        Get
            Return mftpuploadloc
        End Get
        Set(ByVal value As String)
            mftpuploadloc = value
        End Set
    End Property

    Private mftplocalfilename As String
    Public Property ftplocalfilename() As String
        Get
            Return mftplocalfilename
        End Get
        Set(ByVal value As String)
            mftplocalfilename = value
        End Set
    End Property

    Private mftpuploadfilename As String
    Public Property ftpuploadfilename() As String
        Get
            Return mftpuploadfilename
        End Get
        Set(ByVal value As String)
            mftpuploadfilename = value
        End Set
    End Property

    Public Sub New(ByVal mftphost As String, ByVal mftpport As String, ByVal mftpuser As String, ByVal mftppwd As String, ByVal mftpuploadloc As String, ByVal mftplocalfilename As String, ByVal mftpuploadfilename As String)
        ftphost = mftphost
        ftpport = mftpport
        ftpuser = mftpuser
        ftppwd = mftppwd
        ftpuploadloc = mftpuploadloc
        ftplocalfilename = mftplocalfilename
        ftpuploadfilename = mftpuploadfilename
    End Sub

End Class
