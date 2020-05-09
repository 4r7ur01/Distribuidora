Imports System.Data.SqlClient
Public Class FrmGraficos
    Private con As New Conexion
    Private Sub cbModelChart_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbModelChart.SelectedIndexChanged
        If cbModelChart.SelectedIndex = 0 Then
            Chart1.Series(0).ChartType = DataVisualization.Charting.SeriesChartType.Column
        ElseIf cbModelChart.SelectedIndex = 1 Then
            Chart1.Series(0).ChartType = DataVisualization.Charting.SeriesChartType.Bar
        ElseIf cbModelChart.SelectedIndex = 2 Then
            Chart1.Series(0).ChartType = DataVisualization.Charting.SeriesChartType.Point
        End If
    End Sub

    Private Sub FrmGraficos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarChart()

        cbModelChart.Items.Add("Columnas")
        cbModelChart.Items.Add("Barras")
        cbModelChart.Items.Add("Puntos")
        cbModelChart.SelectedIndex = 0
    End Sub
    Public Sub CargarChart()
        Dim reader As SqlDataReader
        Try
            con._Getcon.Open()
            Dim com As New SqlCommand("select p.Titulo,sum(Cantidad) as acumulado from ventas v,Publicaciones p,Cabe_Ventas c where v.Cod_Pub =p.Cod_Pub and v.Cabe_Venta=c.Cabe_Venta and datepart(mm,c.Fec_Ven) = datepart(mm,GETDATE())  group by  p.Titulo having count(*) > 0 ", con._Getcon)
            reader = com.ExecuteReader
            While reader.Read
                Chart1.Series("Factura_VS_Pub").Points.AddXY(reader("Titulo"), reader("acumulado"))
            End While
            con._Getcon.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Sub CargarUltimosagnos()
        Dim reader As SqlDataReader
        Try
            con._Getcon.Open()
            Dim com As New SqlCommand("select p.Titulo,sum(Cantidad) as acumulado from ventas v,Publicaciones p,Cabe_Ventas c where v.Cod_Pub =p.Cod_Pub and v.Cabe_Venta=c.Cabe_Venta and datepart(yy,c.Fec_Ven) > datepart(yy,GETDATE())-" & txtAgno.Text & "  group by  p.Titulo having count(*) > 0 ")
            reader = com.ExecuteReader
            While reader.Read
                Chart1.Series(0).Points.AddXY(reader("Titulo"), reader("acumulado"))
            End While
            con._Getcon.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub CargarxFechas()
        Dim reader As SqlDataReader
        Try
            con._Getcon.Open()
            Dim com As New SqlCommand("select p.Titulo,sum(Cantidad) as acumulado from ventas v,Publicaciones p,Cabe_Ventas c where v.Cod_Pub =p.Cod_Pub and v.Cabe_Venta=c.Cabe_Venta and c.Fec_Ven between " & dtpFecha1.Value & " and " & dtpFecha2.Value & " group by  p.Titulo having count(*) > 0 ")
            reader = com.ExecuteReader
            While reader.Read
                Chart1.Series(0).Points.AddXY(reader("Titulo"), reader("acumulado"))
            End While
            con._Getcon.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub txtAgno_TextChanged(sender As Object, e As EventArgs) Handles txtAgno.TextChanged
        Try
            CargarUltimosagnos()
        Catch ex As Exception
            txtAgno.Text = 0
        End Try
    End Sub

    Private Sub btnBuscarFechas_Click(sender As Object, e As EventArgs) Handles btnBuscarFechas.Click
        CargarxFechas()
    End Sub
End Class