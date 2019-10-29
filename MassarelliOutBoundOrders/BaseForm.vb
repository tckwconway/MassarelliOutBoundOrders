Imports System.Collections.Generic
Imports System.Data.SqlClient

Public Class BaseForm

    Protected Sub Save(Of T)(ByVal objectToSave As T)
        ' Do any pre-processing
        ' Call the appropriate save method on the
        ' business object
        Dim mMethodInfo As Reflection.MethodInfo
        mMethodInfo = GetType(T).GetMethod("Save")
        mMethodInfo.Invoke(objectToSave, Nothing)
        ' Do any post processing
    End Sub

    Protected Sub Save(Of T)(ByVal objectToSave As T, ByVal oArray As System.Array)

        Dim mMethodInfo As Reflection.MethodInfo
        'Dim o() As System.Array = oArray
        Dim i As Integer
        Dim o(oArray.Length - 2) As Object
        ''assumes N is the position In oArray to remove	
        'For i = N To UBound(oArray) - 1
        '    oArray(i) = oArray(i + 1)
        'Next i
        'ReDim Preserve oArray(UBound(oArray) - 1)

        For i = 1 To oArray.Length - 1
            o(i - 1) = oArray(i)
        Next
        mMethodInfo = GetType(T).GetMethod(oArray(0).ToString)
        mMethodInfo.Invoke(objectToSave, o)

    End Sub
    Private Function RemoveAt(Of T)(ByVal arr As T(), ByVal index As Integer) As T()
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
End Class