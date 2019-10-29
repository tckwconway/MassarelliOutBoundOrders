Imports System.Text
Module AppUtilities
    Sub Main()
        Dim arr = New String() {"abc", "mno", "xyz"}
        arr.RemoveAt(1)
    End Sub

    <System.Runtime.CompilerServices.Extension()> _
        Function RemoveAt(Of T)(ByVal arr As T(), ByVal index As Integer) As T()
        Dim uBound = arr.GetUpperBound(0)
        Dim lBound = arr.GetLowerBound(0)
        Dim arrLen = uBound - lBound

        If index < lBound OrElse index > uBound Then
            Throw New ArgumentOutOfRangeException( _
            String.Format("Index must be from {0} to {1}.", lBound, uBound))

        Else
            'create an array 1 element less than the input array
            Dim outArr(arrLen - 1) As T
            'copy the first part of the input array
            Array.Copy(arr, 0, outArr, 0, index)
            'then copy the second part of the input array
            Array.Copy(arr, index + 1, outArr, index, uBound - index)

            Return outArr
        End If
    End Function
    Public Function EncryptPassword(ByVal pwd As String) As String
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
    Public Function UnEncryptPassword(ByVal pwd As String) As String
        Dim des As New TripleDES
        Dim sArray() As String
        Dim sDelimiter As String = ","
        Dim ipwd As Int32
        Dim sUnEncryptedPwd As String

        sArray = pwd.Split(sDelimiter)
        ipwd = UBound(sArray)

        Dim bpwd(ipwd) As Byte
        For i = LBound(sArray) To UBound(sArray)
            bpwd(i) = CByte(sArray(i))
        Next

        sUnEncryptedPwd = des.Decrypt(bpwd)

        Return sUnEncryptedPwd

    End Function

    Public Function BuildXmlString(ByVal xmlRootName As String, ByVal values As String()) As String
        Dim xmlString As New StringBuilder()

        xmlString.AppendFormat("<{0}>", xmlRootName)
        For i As Integer = 0 To values.Length - 1
            xmlString.AppendFormat("<id>{0}</id>", values(i))
        Next
        xmlString.AppendFormat("</{0}>", xmlRootName)

        Return xmlString.ToString()
    End Function

End Module
