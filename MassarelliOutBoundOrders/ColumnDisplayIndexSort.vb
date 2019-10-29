Public Class ColumnDisplayIndexSort

    Private mColName As String
    Public Property ColName() As String
        Get
            Return mColName
        End Get
        Set(ByVal value As String)
            mColName = value
        End Set
    End Property

    Private mDisplayIndex As Integer
    Public Property DisplayIndex() As Integer
        Get
            Return mDisplayIndex
        End Get
        Set(ByVal value As Integer)
            mDisplayIndex = value
        End Set
    End Property

    Public Sub New(ByVal ColNam As String, ByVal DispIdx As Integer)
        Me.ColName = ColNam
        Me.DisplayIndex = DispIdx
    End Sub

    Public Shared Function SortColumns( _
        ByVal x As ColumnDisplayIndexSort, ByVal y As ColumnDisplayIndexSort) As Integer
        Return x.DisplayIndex.CompareTo(y.DisplayIndex)
    End Function
End Class
