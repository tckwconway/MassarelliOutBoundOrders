Imports System.Collections.Generic
Imports System.Collections
Imports System.ComponentModel

Public Class SalesRepList
    Public SalesRepNo As String
    Public SalesRepName As String
    Public SalesRepEmail As String
    Public SalesRepGroup As Decimal

    Public Sub New( _
       ByVal mSalesRepNo As String, _
       ByVal mSalesRepName As String, _
       ByVal mSalesRepEmail As String, _
       ByVal mSalesRepGroup As Decimal)
        SalesRepNo = mSalesRepNo
        SalesRepName = mSalesRepName
        SalesRepEmail = mSalesRepEmail
        SalesRepGroup = mSalesRepGroup
    End Sub
End Class



