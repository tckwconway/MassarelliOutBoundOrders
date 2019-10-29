Imports System.Xml
Imports System.Xml.Schema
Imports System.IO
Imports System.Data.SqlTypes

Public Class SaveGridColumnPreset
    Public Shared Sub SaveColumnPreset(ByVal PresetPendingHistoryOrNew As String, ByVal dgv As DataGridView, ByVal GridColPresetName As String, _
                                       PresetType As String, SlsrepGrp As String)
        Dim doc As New XmlDocument
        Dim o As DataGridViewRow
        Dim recstate As String = ""

        Try
            'Dim col As DataGridViewColumn
            Dim dec As XmlDeclaration = doc.CreateXmlDeclaration("1.0", "utf-8", Nothing)
            doc.AppendChild(dec)
            Dim docroot As XmlElement = doc.CreateElement("Columns")
            doc.AppendChild(docroot)
            Dim coln As XmlNode
            Dim colv As XmlNode

            'For Each col In dgv.Columns
            For Each o In dgv.Rows
                Dim colnv As XmlNode = doc.CreateElement("Column")
                coln = colnv.AppendChild(doc.CreateElement("Name"))
                coln.InnerText = o.Cells(1).Value
                colv = colnv.AppendChild(doc.CreateElement("Value"))

                If PresetPendingHistoryOrNew = "Pending" AndAlso o.Cells(1).Value = "Invoice" Then
                    colv.InnerText = "False"
                ElseIf PresetPendingHistoryOrNew = "New" Then
                    colv.InnerText = "False"
                Else
                    colv.InnerText = o.Cells(0).Value.ToString
                End If

                docroot.AppendChild(colnv)
            Next

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Dim sw As New StringWriter
        Dim xw As New XmlTextWriter(sw)
        doc.WriteTo(xw)
        Dim transactionXML As StringReader = New StringReader(sw.ToString)
        Dim xmlReader As New XmlTextReader(transactionXML)
        Dim sqlXml As New SqlXml(xmlReader)

        If PresetPendingHistoryOrNew = "New" Then
            recstate = "New"
        ElseIf PresetPendingHistoryOrNew = "Pending" OrElse PresetPendingHistoryOrNew = "History" Then
            recstate = "Modified"
        ElseIf PresetPendingHistoryOrNew = "Delete" Then
            recstate = "Delete"
        End If


        BusObj.SaveGridColumnView(sqlXml, GridColPresetName, PresetType, SlsrepGrp, recstate, cn)


    End Sub


End Class
