
Imports System.ComponentModel
Imports System.Data.DataRowView
Imports System.Data.SqlClient
Imports System.Data
Imports System.Text
Imports System
Public Class RepGroupObj

#Region "   Methods   "

    Public Shared Sub Save(ByVal Rep As String, ByVal cn As SqlConnection)
        Dim ssql As String
        ssql = "Update OEOBSETTINGS2012_MAS Set ob_rep_organization = '" & Rep & "'"
        DAC.Execute_NonSQL(ssql, cn)
    End Sub

#End Region



#Region "   Properties   "

    Private mRepGroup As String
    Public Property RepGroup() As String
        Get
            Return mRepGroup
        End Get
        Set(ByVal value As String)
            mRepGroup = value
        End Set
    End Property

#End Region

End Class
