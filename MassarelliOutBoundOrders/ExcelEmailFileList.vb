Public Class ExcelEmailFileList

    Private mRecipient As String
    Public Property Recipient() As String
        Get
            Return mRecipient
        End Get
        Set(ByVal value As String)
            mRecipient = value
        End Set
    End Property

    Private mEmailAddress As String
    Public Property EmailAddress() As String
        Get
            Return mEmailAddress
        End Get
        Set(ByVal value As String)
            mEmailAddress = value
        End Set
    End Property

    Private mFilePath_Name As String
    Public Property FilePath_Name() As String
        Get
            Return mFilePath_Name
        End Get
        Set(ByVal value As String)
            mFilePath_Name = value
        End Set
    End Property

    Private mSendXL As Boolean
    Public Property SendXL() As Boolean
        Get
            Return mSendXL
        End Get
        Set(ByVal value As Boolean)
            mSendXL = value
        End Set
    End Property

    Private mSendSuccessful As Boolean
    Public Property SendSuccessful() As Boolean
        Get
            Return mSendSuccessful
        End Get
        Set(ByVal value As Boolean)
            mSendSuccessful = value
        End Set
    End Property

    Private mRepNo As String
    Public Property RepNo() As String
        Get
            Return mRepNo
        End Get
        Set(ByVal value As String)
            mRepNo = value
        End Set
    End Property

    Public Sub New(ByVal mRecipient As String, ByVal mEmailAddress As String, ByVal mFilePath_Name As String, ByVal mSendXL As Boolean, ByVal mSendSuccessful As Boolean, ByVal mRepNo As String)
        Recipient = mRecipient
        EmailAddress = mEmailAddress
        FilePath_Name = mFilePath_Name
        SendXL = mSendXL
        SendSuccessful = mSendSuccessful
        RepNo = mRepNo
    End Sub

End Class
