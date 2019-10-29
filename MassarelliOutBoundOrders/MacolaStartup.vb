Imports System.Environment
Imports System.Data.SqlClient

Module MacolaStartup
    Friend cn As SqlConnection
    Public DefaultServer As String = My.Settings.DefaultSERVER
    Public DefaultDB As String = My.Settings.DefaultDB

    Public Sub MacStartup()

        Try

            Dim ConnStr As String = "Data Source=" & DefaultServer & ";Initial Catalog=" & DefaultDB & ";Persist Security Info=True;User ID=sa;Password=STMARTIN"

            cn = New SqlConnection
            cn.ConnectionString = ConnStr
            cn.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Dim st As Integer = cn.State

    End Sub

End Module
