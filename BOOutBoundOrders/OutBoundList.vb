Imports System.Collections.Generic
Imports System.Collections
Imports System.ComponentModel
Public Class OutBoundList
    Inherits BindingListView(Of OutBoundObj)
    Protected Overrides Function AddNewCore() As Object

        Dim ob As OutBoundObj = OutBoundObj.NewOutboundObj _
        ("", 0, 0, 0, "", CDate("01/01/1900"), "", "", "", "", "", "", "", "", "", "", "", _
         "", "", "", "", "", "", 0, "", "", "", "", 0, 0, 0, "", "", "", "")
        ob.SetParent(Me)
        Add(ob)
        Return ob

    End Function
End Class
