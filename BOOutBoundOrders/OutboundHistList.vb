Imports System.Collections.Generic
Imports System.Collections
Imports System.ComponentModel
Public Class OutBoundHistList
    Inherits BindingListView(Of OutBoundHistObj)
    Protected Overrides Function AddNewCore() As Object

        Dim ob As OutBoundHistObj = OutBoundHistObj.NewOutboundHistObj _
        ("", 0, 0, 0, "", CDate("01/01/1900"), "", "", "", 0, "01/01/1900", 0, "", "", "", "", "", "", "", "", "", "", _
         "", "", "", "", 0, "", "", "", "", 0, 0, 0, "", "", "", "")
        ob.SetParent(Me)
        Add(ob)
        Return ob

    End Function
End Class