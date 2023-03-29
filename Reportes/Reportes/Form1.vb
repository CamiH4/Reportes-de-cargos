Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnImprimirCargos.Click

    End Sub

    Sub verReporte(ByVal t As DataTable, ByVal ds As String, ByVal nombreRpt As String)
        Try
            Dim rpt As New ReportDataSource(ds, t)
            FrmVistaPrevia.ReportViewer1.LocalReport.DataSources.Clear()
            FrmVistaPrevia.ReportViewer1.LocalReport.DataSources.Add(rpt)
            FrmVistaPrevia.ReportViewer1.LocalReport.ReportPath = nombreRpt
            FrmVistaPrevia.ReportViewer1.Refresh()
            FrmVistaPrevia.Show()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al mostrar reporte")
        End Try
    End Sub

    Private Sub btnImprimirCargos_Click(sender As Object, e As EventArgs) Handles btnImprimirCargos.Click
        Try
            Dim tsql As String = "Select * from jobs"
            Dim conex As New SqlConnection(My.Settings.cStrBDHR)
            Dim da As New SqlDataAdapter(tsql, conex)
            Dim t As New DataTable
            da.Fill(t)
            verReporte(t, "dsRegistros", "diseniosRpt\rptCargo.rdlc")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al cargar reporte")

        End Try
    End Sub


End Class
