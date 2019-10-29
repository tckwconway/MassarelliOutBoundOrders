Imports System.Runtime.Serialization

Module ColumnLayoutXMLSerialize
    <Serializable()> Public Class ColumnXML
        Implements ISerializable
        Public ParmIntName As String
        Public ParmIntValue As Integer
        Public ParmDecName As String
        Public ParmDecValue As Decimal
        Public ParmStrName As String
        Public ParmStrValue As String
        Public ParmDate4Name As String
        Public ParmDateValue As Date

        Public Sub New()


        End Sub

        Public Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
            ParmIntName = info.GetString("Name_Int")
            ParmIntValue = info.GetInt32("Value_Int")
            ParmDecName = info.GetString("Name_Decimal")
            ParmDecValue = info.GetDecimal("Value_Decimal")
            ParmStrName = info.GetString("Name_String")
            ParmStrValue = info.GetString("Value_String")
            ParmDate4Name = info.GetString("Name_Date")
            ParmDateValue = info.GetDateTime("Value_DateTime")
        End Sub
        Public Sub GetObjectData(ByVal info As System.Runtime.Serialization.SerializationInfo, _
                                 ByVal context As System.Runtime.Serialization.StreamingContext) _
                                 Implements System.Runtime.Serialization.ISerializable.GetObjectData

            info.AddValue("Name_String", ParmStrValue)



        End Sub
    End Class
End Module
