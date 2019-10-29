Public Class DataGridColumnsList

    Public Sub New(ByVal Company As String, ByVal SalesAmt_SubTotal As String, ByVal Freight As String, _
                   ByVal SalesAmt As String, ByVal ShipViaDesc As String, ByVal ShipDate As String, _
                   ByVal Terms As String, ByVal OrderNumber As String, ByVal PONumber As String, _
                   ByVal BillToNo As String, ByVal BillToName As String, ByVal BillToAddr1 As String, _
                   ByVal BillToAddr2 As String, ByVal BillToCity As String, ByVal BillToState As String, _
                   ByVal BillToZip As String, ByVal ShipToNo As String, ByVal ShipToName As String, _
                   ByVal ShipToAddr1 As String, ByVal ShipToAddr2 As String, ByVal ShipToCity As String, _
                   ByVal ShipToState As String, ByVal ShipToZip As String, ByVal Qty As String, _
                   ByVal ItemNo As String, ByVal ItemDescription As String, ByVal UOM As String, _
                   ByVal Finish As String, ByVal UnitPrice As String, ByVal ExtendedPrice As String, _
                   ByVal Discount As String, ByVal ShippingInstruction As String, _
                   ByVal SalesPersonNo As String, ByVal SalesPersonName As String, ByVal InvoiceNumber As String, _
                   ByVal Invoice As String, ByVal InvoiceAmt As String, ByVal SalesRepGroup As String)

        ' Set fields.
        Me.mCompany = Company
        Me.mSalesAmt_SubTotal = SalesAmt_SubTotal
        Me.mFreight = Freight
        Me.mSalesAmt = SalesAmt
        Me.mShipViaDesc = ShipViaDesc
        Me.mShipDate = ShipDate
        Me.mTerms = Terms
        Me.mOrderNumber = OrderNumber
        Me.mPONumber = PONumber
        Me.mBillToNo = BillToNo
        Me.mBillToName = BillToName
        Me.mBillToAddr1 = BillToAddr1
        Me.mBillToAddr2 = BillToAddr2
        Me.mBillToCity = BillToCity
        Me.mBillToState = BillToState
        Me.mBillToZip = BillToZip
        Me.mShipToNo = ShipToNo
        Me.mShipToName = ShipToName
        Me.mShipToAddr1 = ShipToAddr1
        Me.mShipToAddr2 = ShipToAddr2
        Me.mShipToCity = ShipToCity
        Me.mShipToState = ShipToState
        Me.mShipToZip = ShipToZip
        Me.mQty = Qty
        Me.mItemNo = ItemNo
        Me.mItemDescription = ItemDescription
        Me.mUOM = UOM
        Me.mFinish = Finish
        Me.mUnitPrice = UnitPrice
        Me.mExtendedPrice = ExtendedPrice
        Me.mDiscount = Discount
        Me.mShippingInstruction = ShippingInstruction
        Me.mSalesPersonNo = SalesPersonNo
        Me.mSalesPersonName = SalesPersonName
        Me.mInvoiceNumber = InvoiceNumber
        Me.mInvoice = Invoice
        Me.mInvoiceAmt = InvoiceAmt
        Me.mSalesRepGroup = SalesRepGroup
    End Sub

    ' Storage of column data.
    Public mCompany As String
    Public mSalesAmt_SubTotal As String
    Public mFreight As String
    Public mSalesAmt As String
    Public mShipViaDesc As String
    Public mShipDate As String
    Public mTerms As String
    Public mOrderNumber As String
    Public mPONumber As String
    Public mBillToNo As String
    Public mBillToName As String
    Public mBillToAddr1 As String
    Public mBillToAddr2 As String
    Public mBillToCity As String
    Public mBillToState As String
    Public mBillToZip As String
    Public mShipToNo As String
    Public mShipToName As String
    Public mShipToAddr1 As String
    Public mShipToAddr2 As String
    Public mShipToCity As String
    Public mShipToState As String
    Public mShipToZip As String
    Public mQty As String
    Public mItemNo As String
    Public mItemDescription As String
    Public mUOM As String
    Public mFinish As String
    Public mUnitPrice As String
    Public mExtendedPrice As String
    Public mDiscount As String
    Public mShippingInstruction As String
    Public mSalesPersonNo As String
    Public mSalesPersonName As String
    Public mInvoiceNumber As String
    Public mInvoice As String
    Public mInvoiceAmt As String
    Public mSalesRepGroup As String
End Class
