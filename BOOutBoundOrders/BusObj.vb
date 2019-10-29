Imports System.ComponentModel
Imports System.Data.DataRowView
Imports System.Data.SqlClient
Imports System.Data
Imports System.Text
Imports System.Xml
Imports System.IO
Imports System.Data.SqlTypes

Public Class BusObj

    Public Shared Function ExecuteSQL_Scalar(ByVal sSQL As String, ByVal cn As SqlConnection) As Object
        Dim o As Object
        o = DAC.Execute_Scalar(sSQL, cn)

        Return o
    End Function

    Public Shared Function ExecuteSQL_Scalar_ReturnString(ByVal sSQL As String, ByVal cn As SqlConnection) As String
        Dim o As Object
        o = DAC.Execute_Scalar(sSQL, cn)
        If o Is DBNull.Value Then o = ""
        Return o
    End Function

    Public Shared Sub ExecuteNonSQL(ByVal SQL As String, ByVal cn As SqlConnection)
        DAC.Execute_NonSQL(SQL, cn)
    End Sub

    Public Shared Function ExecuteSQLReader(ByVal SQL As String, ByVal cn As SqlConnection) As SqlDataReader
        Dim rd As SqlDataReader
        rd = DAC.ExecuteSQL_Reader(SQL, cn)
        Return rd
    End Function
    Public Shared Sub SaveGridColumnView(ByVal gridcolxml As SqlXml, ByVal gridcolname As String, presettype As String, _
                                         slsrepgrp As String, ByVal recordstate As String, ByVal cn As SqlConnection)
        DAC.ExecuteSaveSP(My.Resources.SP_spoeSaveColLayout_MAS, cn, _
                          DAC.Parameter(My.Resources.Param_iGridColXML, gridcolxml, ParameterDirection.Input, SqlDbType.Xml), _
                          DAC.Parameter(My.Resources.Param_iGridColName, gridcolname, ParameterDirection.Input), _
                          DAC.Parameter(My.Resources.Param_iRecordState, recordstate, ParameterDirection.Input), _
                          DAC.Parameter(My.Resources.Param_iPresetType, presettype, ParameterDirection.Input), _
                          DAC.Parameter(My.Resources.Param_iSlsrep_Grp, slsrepgrp, ParameterDirection.Input))

    End Sub
End Class
