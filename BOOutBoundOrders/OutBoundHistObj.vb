Imports System.ComponentModel
Imports System.Data.DataRowView
Imports System.Data.SqlClient
Imports System.Data
Imports System.Text
Imports System
Public Class OutBoundHistObj
    Inherits OutBoundObj

    Implements INotifyPropertyChanged
    Implements IEditableObject

#Region "   Methods   "

    Public Shared Function NewOutboundHistObj(ByVal Company As String, ByVal SalesAmt_SubTotal As Decimal, ByVal Freight As Decimal, ByVal SalesAmt As Decimal, _
                                      ByVal ShipViaDesc As String, ByVal ShipDate As Date, ByVal Terms As String, ByVal OrderNumber As String, _
                                      ByVal PONumber As String, ByVal InvoiceNumber As Integer, ByVal InvoiceDate As Date, ByVal InvoiceAmount As Decimal, _
                                      ByVal BillToNo As String, ByVal BillToName As String, ByVal BillToAddr1 As String, _
                                      ByVal BillToAddr2 As String, ByVal BillToCity As String, ByVal BillToState As String, ByVal BillToZip As String, _
                                      ByVal ShipToNo As String, ByVal ShipToName As String, ByVal ShipToAddr1 As String, ByVal ShipToAddr2 As String, _
                                      ByVal ShipToCity As String, ByVal ShipToState As String, ByVal ShipToZip As String, ByVal Qty As Integer, _
                                      ByVal ItemNo As String, ByVal ItemDescription As String, ByVal UOM As String, ByVal Finish As String, _
                                      ByVal UnitPrice As Decimal, ByVal ExtendedPrice As Decimal, ByVal Discount As Decimal, _
                                      ByVal ShippingInstruction As String, ByVal SalesPersonNo As String, ByVal SalesPersonName As String, _
                                      ByVal SalesRepGroup As String) As OutBoundObj


        Dim ob As New OutBoundHistObj
        ob.Company = Company
        ob.SalesAmt_SubTotal = SalesAmt_SubTotal
        ob.Freight = Freight
        ob.SalesAmt = SalesAmt
        ob.ShipViaDesc = ShipViaDesc
        ob.ShipDate = ShipDate
        ob.Terms = Terms
        ob.OrderNumber = OrderNumber
        ob.PONumber = PONumber
        ob.InvoiceNumber = InvoiceNumber
        ob.InvoiceDate = InvoiceDate
        ob.InvoiceAmount = InvoiceAmount
        ob.BillToNo = BillToNo
        ob.BillToName = BillToName
        ob.BillToAddr1 = BillToAddr1
        ob.BillToAddr2 = BillToAddr2
        ob.BillToCity = BillToCity
        ob.BillToState = BillToState
        ob.BillToZip = BillToZip
        ob.ShipToNo = ShipToNo
        ob.ShipToName = ShipToName
        ob.ShipToAddr1 = ShipToAddr1
        ob.ShipToAddr2 = ShipToAddr2
        ob.ShipToCity = ShipToCity
        ob.ShipToState = ShipToState
        ob.ShipToZip = ShipToZip
        ob.Qty = Qty
        ob.ItemNo = ItemNo
        ob.ItemDescription = ItemDescription
        ob.UOM = UOM
        ob.Finish = Finish
        ob.UnitPrice = UnitPrice
        ob.ExtendedPrice = ExtendedPrice
        ob.Discount = Discount
        ob.ShippingInstruction = ShippingInstruction
        ob.SalesPersonNo = SalesPersonNo
        ob.SalesPersonName = SalesPersonName
        ob.SalesRepGroup = SalesRepGroup

        Return ob

    End Function

    Public Shared Function GetOutboundHistObj(ByVal Company As String, ByVal SalesAmt_SubTotal As Decimal, ByVal Freight As Decimal, ByVal SalesAmt As Decimal, _
                                      ByVal ShipViaDesc As String, ByVal ShipDate As Date, ByVal Terms As String, ByVal OrderNumber As String, _
                                      ByVal PONumber As String, ByVal InvoiceNumber As Integer, ByVal InvoiceDate As Date, ByVal InvoiceAmount As Decimal, _
                                      ByVal BillToNo As String, ByVal BillToName As String, ByVal BillToAddr1 As String, _
                                      ByVal BillToAddr2 As String, ByVal BillToCity As String, ByVal BillToState As String, ByVal BillToZip As String, _
                                      ByVal ShipToNo As String, ByVal ShipToName As String, ByVal ShipToAddr1 As String, ByVal ShipToAddr2 As String, _
                                      ByVal ShipToCity As String, ByVal ShipToState As String, ByVal ShipToZip As String, ByVal Qty As Integer, _
                                      ByVal ItemNo As String, ByVal ItemDescription As String, ByVal UOM As String, ByVal Finish As String, _
                                      ByVal UnitPrice As Decimal, ByVal ExtendedPrice As Decimal, ByVal Discount As Decimal, _
                                      ByVal ShippingInstruction As String, ByVal SalesPersonNo As String, ByVal SalesPersonName As String, _
                                      ByVal SalesRepGroup As String) As OutBoundObj


        Dim ob As New OutBoundHistObj
        ob.Company = Company
        ob.SalesAmt_SubTotal = SalesAmt_SubTotal
        ob.Freight = Freight
        ob.SalesAmt = SalesAmt
        ob.ShipViaDesc = ShipViaDesc
        ob.ShipDate = ShipDate
        ob.Terms = Terms
        ob.OrderNumber = OrderNumber
        ob.PONumber = PONumber
        ob.InvoiceNumber = InvoiceNumber
        ob.InvoiceDate = InvoiceDate
        ob.InvoiceAmount = InvoiceAmount
        ob.BillToNo = BillToNo
        ob.BillToName = BillToName
        ob.BillToAddr1 = BillToAddr1
        ob.BillToAddr2 = BillToAddr2
        ob.BillToCity = BillToCity
        ob.BillToState = BillToState
        ob.BillToZip = BillToZip
        ob.ShipToNo = ShipToNo
        ob.ShipToName = ShipToName
        ob.ShipToAddr1 = ShipToAddr1
        ob.ShipToAddr2 = ShipToAddr2
        ob.ShipToCity = ShipToCity
        ob.ShipToState = ShipToState
        ob.ShipToZip = ShipToZip
        ob.Qty = Qty
        ob.ItemNo = ItemNo
        ob.ItemDescription = ItemDescription
        ob.UOM = UOM
        ob.Finish = Finish
        ob.UnitPrice = UnitPrice
        ob.ExtendedPrice = ExtendedPrice
        ob.Discount = Discount
        ob.ShippingInstruction = ShippingInstruction
        ob.SalesPersonNo = SalesPersonNo
        ob.SalesPersonName = SalesPersonName
        ob.SalesRepGroup = SalesRepGroup

        Return ob

    End Function

    Public Shared Function PopulateOutBoundHistObj(ByVal rd As SqlDataReader) As OutBoundHistList
        Dim i As Integer = 1
        Dim oolist(37) As Object
        Dim oblist As New OutBoundHistList
        Try
            While rd.Read
                If rd(0).Equals(DBNull.Value) Then oolist(0) = "" Else oolist(0) = CStr(rd(0))
                If rd(1).Equals(DBNull.Value) Then oolist(1) = 0 Else oolist(1) = CDec(rd(1))
                If rd(2).Equals(DBNull.Value) Then oolist(2) = 0 Else oolist(2) = CDec(rd(2))
                If rd(3).Equals(DBNull.Value) Then oolist(3) = 0 Else oolist(3) = CDec(rd(3))
                If rd(4).Equals(DBNull.Value) Then oolist(4) = "" Else oolist(4) = CStr(rd(4))
                If rd(5).Equals(DBNull.Value) Then oolist(5) = CDate("01/01/1900") Else oolist(5) = CDate(rd(5))
                If rd(6).Equals(DBNull.Value) Then oolist(6) = "" Else oolist(6) = CStr(rd(6))
                If rd(7).Equals(DBNull.Value) Then oolist(7) = "" Else oolist(7) = CStr(rd(7))
                If rd(8).Equals(DBNull.Value) Then oolist(8) = "" Else oolist(8) = CStr(rd(8))
                If rd(9).Equals(DBNull.Value) Then oolist(9) = 0 Else oolist(9) = CInt(rd(9))
                If rd(10).Equals(DBNull.Value) Then oolist(10) = CDate("01/01/1900") Else oolist(10) = CDate(rd(10))
                If rd(11).Equals(DBNull.Value) Then oolist(11) = 0 Else oolist(11) = CDec(rd(11))
                If rd(12).Equals(DBNull.Value) Then oolist(12) = "" Else oolist(12) = CStr(rd(12))
                If rd(13).Equals(DBNull.Value) Then oolist(13) = "" Else oolist(13) = CStr(rd(13))
                If rd(14).Equals(DBNull.Value) Then oolist(14) = "" Else oolist(14) = CStr(rd(14))
                If rd(15).Equals(DBNull.Value) Then oolist(15) = "" Else oolist(15) = CStr(rd(15))
                If rd(16).Equals(DBNull.Value) Then oolist(16) = "" Else oolist(16) = CStr(rd(16))
                If rd(17).Equals(DBNull.Value) Then oolist(17) = "" Else oolist(17) = CStr(rd(17))
                If rd(18).Equals(DBNull.Value) Then oolist(18) = "" Else oolist(18) = CStr(rd(18))
                If rd(19).Equals(DBNull.Value) Then oolist(19) = "" Else oolist(19) = CStr(rd(19))
                If rd(20).Equals(DBNull.Value) Then oolist(20) = "" Else oolist(20) = CStr(rd(20))
                If rd(21).Equals(DBNull.Value) Then oolist(21) = "" Else oolist(21) = CStr(rd(21))
                If rd(22).Equals(DBNull.Value) Then oolist(22) = "" Else oolist(22) = CStr(rd(22))
                If rd(23).Equals(DBNull.Value) Then oolist(23) = "" Else oolist(23) = CStr(rd(23))
                If rd(24).Equals(DBNull.Value) Then oolist(24) = "" Else oolist(24) = CStr(rd(24))
                If rd(25).Equals(DBNull.Value) Then oolist(25) = "" Else oolist(25) = CStr(rd(25))
                If rd(26).Equals(DBNull.Value) Then oolist(26) = 0 Else oolist(26) = CInt(rd(26))
                If rd(27).Equals(DBNull.Value) Then oolist(27) = "" Else oolist(27) = CStr(rd(27))
                If rd(28).Equals(DBNull.Value) Then oolist(28) = "" Else oolist(28) = CStr(rd(28))
                If rd(29).Equals(DBNull.Value) Then oolist(29) = "" Else oolist(29) = CStr(rd(29))
                If rd(30).Equals(DBNull.Value) Then oolist(30) = "" Else oolist(30) = CStr(rd(30))
                If rd(31).Equals(DBNull.Value) Then oolist(31) = 0 Else oolist(31) = CDec(rd(31))
                If rd(32).Equals(DBNull.Value) Then oolist(32) = 0 Else oolist(32) = CDec(rd(32))
                If rd(33).Equals(DBNull.Value) Then oolist(33) = 0 Else oolist(33) = CDec(rd(33))
                If rd(34).Equals(DBNull.Value) Then oolist(34) = "" Else oolist(34) = CStr(rd(34))
                If rd(35).Equals(DBNull.Value) Then oolist(35) = "" Else oolist(35) = CStr(rd(35))
                If rd(36).Equals(DBNull.Value) Then oolist(36) = "" Else oolist(36) = CStr(rd(36))
                If rd(37).Equals(DBNull.Value) Then oolist(37) = "" Else oolist(37) = CStr(rd(37))

                oblist.Add(OutBoundHistObj.GetOutboundHistObj(CStr(oolist(0)), CDec(oolist(1)), CDec(oolist(2)), CDec(oolist(3)), _
                                                      CStr(oolist(4)), CDate(oolist(5)), CStr(oolist(6)), CStr(oolist(7)), _
                                                      CStr(oolist(8)), CInt(oolist(9)), CDate(oolist(10)), CDec(oolist(11)), _
                                                      CStr(oolist(12)), CStr(oolist(13)), CStr(oolist(14)), CStr(oolist(15)), _
                                                      CStr(oolist(16)), CStr(oolist(17)), CStr(oolist(18)), CStr(oolist(19)), _
                                                      CStr(oolist(20)), CStr(oolist(21)), CStr(oolist(22)), CStr(oolist(23)), _
                                                      CStr(oolist(24)), CStr(oolist(25)), CInt(oolist(26)), CStr(oolist(27)), _
                                                      CStr(oolist(28)), CStr(oolist(29)), CStr(oolist(30)), CDec(oolist(31)), _
                                                      CDec(oolist(32)), CDec(oolist(33)), CStr(oolist(34)), CStr(oolist(35)), _
                                                      CStr(oolist(36)), CStr(oolist(37))))

            End While
            rd.Close()
            Return oblist
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

#End Region

    Private mInvoiceNumber As String
    Public Property InvoiceNumber() As String
        Get
            Return mInvoiceNumber
        End Get
        Set(ByVal value As String)
            mInvoiceNumber = value
        End Set
    End Property

    Private mInvoiceDate As Date
    Public Property InvoiceDate() As Date
        Get
            Return mInvoiceDate
        End Get
        Set(ByVal value As Date)
            mInvoiceDate = value
        End Set
    End Property

    Private mInvoiceAmount As Decimal
    Public Property InvoiceAmount() As Decimal
        Get
            Return mInvoiceAmount
        End Get
        Set(ByVal value As Decimal)
            mInvoiceAmount = value
        End Set
    End Property

    Private mParent As OutBoundHistList
    'Public Event PropertyChanged(ByVal sender As Object, ByVal e As System.ComponentModel.PropertyChangedEventArgs) Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
    Friend Overloads Sub SetParent(ByVal parent As OutBoundHistList)
        mParent = parent
    End Sub

  
End Class
