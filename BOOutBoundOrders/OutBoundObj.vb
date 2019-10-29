Imports System.ComponentModel
Imports System.Data.DataRowView
Imports System.Data.SqlClient
Imports System.Data
Imports System.Text
Imports System
Public Class OutBoundObj
    Implements INotifyPropertyChanged
    Implements IEditableObject

#Region "   Methods"
    Public Shared Function NewOutboundObj(ByVal Company As String, ByVal SalesAmt_SubTotal As Decimal, ByVal Freight As Decimal, ByVal SalesAmt As Decimal, _
                                          ByVal ShipViaDesc As String, ByVal ShipDate As Date, ByVal Terms As String, ByVal OrderNumber As String, _
                                          ByVal PONumber As String, ByVal BillToNo As String, ByVal BillToName As String, ByVal BillToAddr1 As String, _
                                          ByVal BillToAddr2 As String, ByVal BillToCity As String, ByVal BillToState As String, ByVal BillToZip As String, _
                                          ByVal ShipToNo As String, ByVal ShipToName As String, ByVal ShipToAddr1 As String, ByVal ShipToAddr2 As String, _
                                          ByVal ShipToCity As String, ByVal ShipToState As String, ByVal ShipToZip As String, ByVal Qty As Integer, _
                                          ByVal ItemNo As String, ByVal ItemDescription As String, ByVal UOM As String, ByVal Finish As String, _
                                          ByVal UnitPrice As Decimal, ByVal ExtendedPrice As Decimal, ByVal Discount As Decimal, _
                                          ByVal ShippingInstruction As String, ByVal SalesPersonNo As String, ByVal SalesPersonName As String, _
                                          ByVal SalesRepGroup As String) As OutBoundObj


        Dim ob As New OutBoundObj
        ob.Company = Company
        ob.SalesAmt_SubTotal = SalesAmt_SubTotal
        ob.Freight = Freight
        ob.SalesAmt = SalesAmt
        ob.ShipViaDesc = ShipViaDesc
        ob.ShipDate = ShipDate
        ob.Terms = Terms
        ob.OrderNumber = OrderNumber
        ob.PONumber = PONumber
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

    Public Shared Function GetOutboundObj(ByVal Company As String, ByVal SalesAmt_SubTotal As Decimal, ByVal Freight As Decimal, ByVal SalesAmt As Decimal, _
                                          ByVal ShipViaDesc As String, ByVal ShipDate As Date, ByVal Terms As String, ByVal OrderNumber As String, _
                                          ByVal PONumber As String, ByVal BillToNo As String, ByVal BillToName As String, ByVal BillToAddr1 As String, _
                                          ByVal BillToAddr2 As String, ByVal BillToCity As String, ByVal BillToState As String, ByVal BillToZip As String, _
                                          ByVal ShipToNo As String, ByVal ShipToName As String, ByVal ShipToAddr1 As String, ByVal ShipToAddr2 As String, _
                                          ByVal ShipToCity As String, ByVal ShipToState As String, ByVal ShipToZip As String, ByVal Qty As Integer, _
                                          ByVal ItemNo As String, ByVal ItemDescription As String, ByVal UOM As String, ByVal Finish As String, _
                                          ByVal UnitPrice As Decimal, ByVal ExtendedPrice As Decimal, ByVal Discount As Decimal, _
                                          ByVal ShippingInstruction As String, ByVal SalesPersonNo As String, ByVal SalesPersonName As String, _
                                          ByVal SalesRepGroup As String) As OutBoundObj

        Dim ob As New OutBoundObj
        ob.Company = Company
        ob.SalesAmt_SubTotal = SalesAmt_SubTotal
        ob.Freight = Freight
        ob.SalesAmt = SalesAmt
        ob.ShipViaDesc = ShipViaDesc
        ob.ShipDate = ShipDate
        ob.Terms = Terms
        ob.OrderNumber = OrderNumber
        ob.PONumber = PONumber
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

    Public Shared Function PopulateOutBoundObj(ByVal rd As SqlDataReader) As OutBoundList
        Dim i As Integer = 1
        Dim oolist(34) As Object
        Dim oblist As New OutBoundList
        Try
            While rd.Read
                If rd(0).Equals(DBNull.Value) Then oolist(0) = "" Else oolist(0) = CStr(rd(0))
                If rd(1).Equals(DBNull.Value) Then oolist(1) = 0 Else oolist(1) = CDec(rd(1))
                If rd(2).Equals(DBNull.Value) Then oolist(2) = 0 Else oolist(2) = CDec(rd(2))
                If rd(3).Equals(DBNull.Value) Then oolist(3) = 0 Else oolist(3) = CDec(rd(3))
                If rd(4).Equals(DBNull.Value) Then oolist(4) = "" Else oolist(4) = CStr(rd(4)).Trim
                If rd(5).Equals(DBNull.Value) OrElse rd(5).ToString = "" Then oolist(5) = CDate("01/01/1900") Else oolist(5) = CDate(rd(5)).Date
                If rd(6).Equals(DBNull.Value) Then oolist(6) = "" Else oolist(6) = CStr(rd(6)).Trim
                If rd(7).Equals(DBNull.Value) Then oolist(7) = "" Else oolist(7) = CStr(rd(7)).Trim
                If rd(8).Equals(DBNull.Value) Then oolist(8) = "" Else oolist(8) = CStr(rd(8)).Trim
                If rd(9).Equals(DBNull.Value) Then oolist(9) = "" Else oolist(9) = CStr(rd(9)).Trim
                If rd(10).Equals(DBNull.Value) Then oolist(10) = "" Else oolist(10) = CStr(rd(10)).Trim
                If rd(11).Equals(DBNull.Value) Then oolist(11) = "" Else oolist(11) = CStr(rd(11)).Trim
                If rd(12).Equals(DBNull.Value) Then oolist(12) = "" Else oolist(12) = CStr(rd(12)).Trim
                If rd(13).Equals(DBNull.Value) Then oolist(13) = "" Else oolist(13) = CStr(rd(13)).Trim
                If rd(14).Equals(DBNull.Value) Then oolist(14) = "" Else oolist(14) = CStr(rd(14)).Trim
                If rd(15).Equals(DBNull.Value) Then oolist(15) = "" Else oolist(15) = CStr(rd(15)).Trim
                If rd(16).Equals(DBNull.Value) Then oolist(16) = "" Else oolist(16) = CStr(rd(16)).Trim
                If rd(17).Equals(DBNull.Value) Then oolist(17) = "" Else oolist(17) = CStr(rd(17)).Trim
                If rd(18).Equals(DBNull.Value) Then oolist(18) = "" Else oolist(18) = CStr(rd(18)).Trim
                If rd(19).Equals(DBNull.Value) Then oolist(19) = "" Else oolist(19) = CStr(rd(19)).Trim
                If rd(20).Equals(DBNull.Value) Then oolist(20) = "" Else oolist(20) = CStr(rd(20)).Trim
                If rd(21).Equals(DBNull.Value) Then oolist(21) = "" Else oolist(21) = CStr(rd(21)).Trim
                If rd(22).Equals(DBNull.Value) Then oolist(22) = "" Else oolist(22) = CStr(rd(22)).Trim
                If rd(23).Equals(DBNull.Value) Then oolist(23) = 0 Else oolist(23) = CInt(rd(23))
                If rd(24).Equals(DBNull.Value) Then oolist(24) = "" Else oolist(24) = CStr(rd(24)).Trim
                If rd(25).Equals(DBNull.Value) Then oolist(25) = "" Else oolist(25) = CStr(rd(25)).Trim
                If rd(26).Equals(DBNull.Value) Then oolist(26) = "" Else oolist(26) = CStr(rd(26)).Trim
                If rd(27).Equals(DBNull.Value) Then oolist(27) = "" Else oolist(27) = CStr(rd(27)).Trim
                If rd(28).Equals(DBNull.Value) Then oolist(28) = 0 Else oolist(28) = CDec(rd(28))
                If rd(29).Equals(DBNull.Value) Then oolist(29) = 0 Else oolist(29) = CDec(rd(29))
                If rd(30).Equals(DBNull.Value) Then oolist(30) = 0 Else oolist(30) = CDec(rd(30))
                If rd(31).Equals(DBNull.Value) Then oolist(31) = "" Else oolist(31) = CStr(rd(31))
                If rd(32).Equals(DBNull.Value) Then oolist(32) = "" Else oolist(32) = CStr(rd(32)).Trim
                If rd(33).Equals(DBNull.Value) Then oolist(33) = "" Else oolist(33) = CStr(rd(33)).Trim
                If rd(34).Equals(DBNull.Value) Then oolist(34) = "" Else oolist(34) = CStr(rd(34)).Trim


                oblist.Add(OutBoundObj.GetOutboundObj(CStr(oolist(0)), CDec(oolist(1)), CDec(oolist(2)), CDec(oolist(3)), _
                                                      CStr(oolist(4)), CDate(oolist(5)), CStr(oolist(6)), _
                                                      CStr(oolist(7)), CStr(oolist(8)), CStr(oolist(9)), _
                                                      CStr(oolist(10)), CStr(oolist(11)), CStr(oolist(12)), _
                                                      CStr(oolist(13)), CStr(oolist(14)), CStr(oolist(15)), _
                                                      CStr(oolist(16)), CStr(oolist(17)), CStr(oolist(18)), _
                                                      CStr(oolist(19)), CStr(oolist(20)), CStr(oolist(21)), _
                                                      CStr(oolist(22)), CInt(oolist(23)), CStr(oolist(24)), _
                                                      CStr(oolist(25)), CStr(oolist(26)), CStr(oolist(27)), _
                                                      CDec(oolist(28)), CDec(oolist(29)), CDec(oolist(30)), _
                                                      CStr(oolist(31)), CStr(oolist(32)), CStr(oolist(33)), _
                                                      CStr(oolist(34))))

                i += 1
            End While
            rd.Close()
            Return oblist
        Catch ex As Exception
            MsgBox(i.ToString & " - " & ex.Message)
            Return Nothing
        End Try
    End Function

    Public Shared Function GetOutboundData(ByVal StartDate As Integer, ByVal EndDate As Integer, _
                                           ByVal OrderNo As String, ByVal InvoiceNo As Integer, ByVal CustomerNo As String, _
                                           ByVal RepGroup As String, ByVal SearchType As String, _
                                           ByVal DataSource As String, ByVal SalesRepNo As String, ByVal cn As SqlConnection) As SqlDataReader

        Dim rd As SqlDataReader
        If DataSource = "Pending" Then
            rd = DAC.ExecuteSP_Reader(My.Resources.SP_spoeGetOutboundOrders_MAS, cn, _
                                  DAC.Parameter(My.Resources.Param_iStartDate, StartDate, ParameterDirection.Input), _
                                  DAC.Parameter(My.Resources.Param_iEndDate, EndDate, ParameterDirection.Input), _
                                  DAC.Parameter(My.Resources.Param_iOrderNo, OrderNo, ParameterDirection.Input), _
                                  DAC.Parameter(My.Resources.Param_iCustomerNo, CustomerNo, ParameterDirection.Input), _
                                  DAC.Parameter(My.Resources.Param_iRepGroup, RepGroup, ParameterDirection.Input), _
                                  DAC.Parameter(My.Resources.Param_iSearchType, SearchType, ParameterDirection.Input), _
                                  DAC.Parameter(My.Resources.Param_iSalesRepNo, SalesRepNo, ParameterDirection.Input))
        ElseIf DataSource = "History" Then
            rd = DAC.ExecuteSP_Reader(My.Resources.SP_spoeGetOutboundOrdersHistory_MAS, cn, _
                                  DAC.Parameter(My.Resources.Param_iStartDate, StartDate, ParameterDirection.Input), _
                                  DAC.Parameter(My.Resources.Param_iEndDate, EndDate, ParameterDirection.Input), _
                                  DAC.Parameter(My.Resources.Param_iOrderNo, OrderNo, ParameterDirection.Input), _
                                  DAC.Parameter(My.Resources.Param_iInvoiceNo, InvoiceNo, ParameterDirection.Input), _
                                  DAC.Parameter(My.Resources.Param_iCustomerNo, CustomerNo, ParameterDirection.Input), _
                                  DAC.Parameter(My.Resources.Param_iRepGroup, RepGroup, ParameterDirection.Input), _
                                  DAC.Parameter(My.Resources.Param_iSearchType, SearchType, ParameterDirection.Input), _
                                  DAC.Parameter(My.Resources.Param_iSalesRepNo, SalesRepNo, ParameterDirection.Input))
        End If


        Return rd

    End Function

    Public Shared Function GetRepGroups(ByVal ssql As String, ByVal cn As SqlConnection) As SqlDataReader
        Dim rd As SqlDataReader

        rd = DAC.ExecuteSQL_Reader(ssql, cn)
        Return rd

    End Function


#End Region



#Region "   Properties   "

    Private mCompany As String
    Public Property Company() As String
        Get
            Return mCompany
        End Get
        Set(ByVal value As String)
            mCompany = value
        End Set
    End Property

    Private mSalesAmt_SubTotal As Decimal
    Public Property SalesAmt_SubTotal() As Decimal
        Get
            Return mSalesAmt_SubTotal
        End Get
        Set(ByVal value As Decimal)
            mSalesAmt_SubTotal = value
        End Set
    End Property

    Private mFreight As Decimal
    Public Property Freight() As Decimal
        Get
            Return mFreight
        End Get
        Set(ByVal value As Decimal)
            mFreight = value
        End Set
    End Property


    Private mSalesAmt As Decimal
    Public Property SalesAmt() As Decimal
        Get
            Return mSalesAmt
        End Get
        Set(ByVal value As Decimal)
            mSalesAmt = value
        End Set
    End Property

    Private mShipViaDesc As String
    Public Property ShipViaDesc() As String
        Get
            Return mShipViaDesc
        End Get
        Set(ByVal value As String)
            mShipViaDesc = value
        End Set
    End Property

    Private mShipDate As Date
    Public Property ShipDate() As Date
        Get
            Return mShipDate
        End Get
        Set(ByVal value As Date)
            mShipDate = value
        End Set
    End Property

    Private mTerms As String
    Public Property Terms() As String
        Get
            Return mTerms
        End Get
        Set(ByVal value As String)
            mTerms = value
        End Set
    End Property

    Private mOrderNumber As String
    Public Property OrderNumber() As String
        Get
            Return mOrderNumber
        End Get
        Set(ByVal value As String)
            mOrderNumber = value
        End Set
    End Property

    Private mPONumber As String
    Public Property PONumber() As String
        Get
            Return mPONumber
        End Get
        Set(ByVal value As String)
            mPONumber = value
        End Set
    End Property

    Private mBillToNo As String
    Public Property BillToNo() As String
        Get
            Return mBillToNo
        End Get
        Set(ByVal value As String)
            mBillToNo = value
        End Set
    End Property

    Private mBillToName As String
    Public Property BillToName() As String
        Get
            Return mBillToName
        End Get
        Set(ByVal value As String)
            mBillToName = value
        End Set
    End Property

    Private mBillToAddr1 As String
    Public Property BillToAddr1() As String
        Get
            Return mBillToAddr1
        End Get
        Set(ByVal value As String)
            mBillToAddr1 = value
        End Set
    End Property

    Private mBillToAddr2 As String
    Public Property BillToAddr2() As String
        Get
            Return mBillToAddr2
        End Get
        Set(ByVal value As String)
            mBillToAddr2 = value
        End Set
    End Property

    Private mBillToCity As String
    Public Property BillToCity() As String
        Get
            Return mBillToCity
        End Get
        Set(ByVal value As String)
            mBillToCity = value
        End Set
    End Property

    Private mBillToState As String
    Public Property BillToState() As String
        Get
            Return mBillToState
        End Get
        Set(ByVal value As String)
            mBillToState = value
        End Set
    End Property

    Private mBillToZip As String
    Public Property BillToZip() As String
        Get
            Return mBillToZip
        End Get
        Set(ByVal value As String)
            mBillToZip = value
        End Set
    End Property

    Private mShipToNo As String
    Public Property ShipToNo() As String
        Get
            Return mShipToNo
        End Get
        Set(ByVal value As String)
            mShipToNo = value
        End Set
    End Property

    Private mShipToName As String
    Public Property ShipToName() As String
        Get
            Return mShipToName
        End Get
        Set(ByVal value As String)
            mShipToName = value
        End Set
    End Property

    Private mShipToAddr1 As String
    Public Property ShipToAddr1() As String
        Get
            Return mShipToAddr1
        End Get
        Set(ByVal value As String)
            mShipToAddr1 = value
        End Set
    End Property

    Private mShipToAddr2 As String
    Public Property ShipToAddr2() As String
        Get
            Return mShipToAddr2
        End Get
        Set(ByVal value As String)
            mShipToAddr2 = value
        End Set
    End Property

    Private mShipToCity As String
    Public Property ShipToCity() As String
        Get
            Return mShipToCity
        End Get
        Set(ByVal value As String)
            mShipToCity = value
        End Set
    End Property

    Private mShipToState As String
    Public Property ShipToState() As String
        Get
            Return mShipToState
        End Get
        Set(ByVal value As String)
            mShipToState = value
        End Set
    End Property

    Private mShipToZip As String
    Public Property ShipToZip() As String
        Get
            Return mShipToZip
        End Get
        Set(ByVal value As String)
            mShipToZip = value
        End Set
    End Property

    Private mQty As Integer
    Public Property Qty() As Integer
        Get
            Return mQty
        End Get
        Set(ByVal value As Integer)
            mQty = value
        End Set
    End Property

    Private mItemNo As String
    Public Property ItemNo() As String
        Get
            Return mItemNo
        End Get
        Set(ByVal value As String)
            mItemNo = value
        End Set
    End Property

    Private mItemDescription As String
    Public Property ItemDescription() As String
        Get
            Return mItemDescription
        End Get
        Set(ByVal value As String)
            mItemDescription = value
        End Set
    End Property

    Private mUOM As String
    Public Property UOM() As String
        Get
            Return mUOM
        End Get
        Set(ByVal value As String)
            mUOM = value
        End Set
    End Property

    Private mFinish As String
    Public Property Finish() As String
        Get
            Return mFinish
        End Get
        Set(ByVal value As String)
            mFinish = value
        End Set
    End Property

    Private mUnitPrice As Decimal
    Public Property UnitPrice() As Decimal
        Get
            Return mUnitPrice
        End Get
        Set(ByVal value As Decimal)
            mUnitPrice = value
        End Set
    End Property

    Private mExtendedPrice As String
    Public Property ExtendedPrice() As String
        Get
            Return mExtendedPrice
        End Get
        Set(ByVal value As String)
            mExtendedPrice = value
        End Set
    End Property

    Private mDiscount As Integer
    Public Property Discount() As Integer
        Get
            Return mDiscount
        End Get
        Set(ByVal value As Integer)
            mDiscount = value
        End Set
    End Property

    Private mShippingInstruction As String
    Public Property ShippingInstruction() As String
        Get
            Return mShippingInstruction
        End Get
        Set(ByVal value As String)
            mShippingInstruction = value
        End Set
    End Property

    Private mSalesPersonNo As String
    Public Property SalesPersonNo() As String
        Get
            Return mSalesPersonNo
        End Get
        Set(ByVal value As String)
            mSalesPersonNo = value
        End Set
    End Property

    Private mSalesPersonName As String
    Public Property SalesPersonName() As String
        Get
            Return mSalesPersonName
        End Get
        Set(ByVal value As String)
            mSalesPersonName = value
        End Set
    End Property

    Private mSalesRepGroup As String
    Public Property SalesRepGroup() As String
        Get
            Return mSalesRepGroup
        End Get
        Set(ByVal value As String)
            mSalesRepGroup = value
        End Set
    End Property


    'Private mRepsForEmail As String
    'Public Property RepsForEmail() As String
    '    Get
    '        Return mRepsForEmail
    '    End Get
    '    Set(ByVal value As String)
    '        mRepsForEmail = value
    '    End Set
    'End Property


#End Region

    Private mParent As OutBoundList
    Public Event PropertyChanged(ByVal sender As Object, ByVal e As System.ComponentModel.PropertyChangedEventArgs) Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
    Friend Overloads Sub SetParent(ByVal parent As OutBoundList)
        mParent = parent
    End Sub

    Public Sub BeginEdit() Implements System.ComponentModel.IEditableObject.BeginEdit

    End Sub

    Public Sub CancelEdit() Implements System.ComponentModel.IEditableObject.CancelEdit

    End Sub

    Public Sub EndEdit() Implements System.ComponentModel.IEditableObject.EndEdit

    End Sub
End Class
