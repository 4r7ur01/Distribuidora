Public Class FrmPedido
    Private con As New Conexion
    Dim acum As Double
    Private Sub FrmPedido_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtCabe_Fac.Text = con.ObtenerCodigoPedido
        con.CargarPublicaciones(cbPubs, "Titulo")
        EnlacePubs()
        txtIGV.Text = 0.18
    End Sub
    Private Sub EnlacePubs()
        txtPrecio.DataBindings.Add("text", con._GetdtPubs, "Pre_Unit")
    End Sub
    Private Sub DesenlacePubs()
        txtPrecio.DataBindings.Clear()
    End Sub
    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        DataGridView1.Rows.Add(cbPubs.SelectedValue, cbPubs.Text, lblDescuento.Text, txtPrecio.Text, nudCantidad.Value, txtSubTotal.Text)
        acum += (txtSubTotal.Text * txtIGV.Text) + txtSubTotal.Text
        txtTotal.Text = acum
        txtdolarTotal.Text = acum / 2.71
    End Sub

    Private Sub nudCantidad_ValueChanged(sender As Object, e As EventArgs) Handles nudCantidad.ValueChanged
        txtDescuento.DataBindings.Clear()
        lblDescuento.DataBindings.Clear()
        con.ConsultarDescuento(nudCantidad.Value)
        txtDescuento.DataBindings.Add("Text", con._GetdtConDescuento, "Porcentaje")
        lblDescuento.DataBindings.Add("Text", con._GetdtConDescuento, "Tipo_Desc")
        txtDesPrec.Text = txtPrecio.Text - (txtPrecio.Text * (txtDescuento.Text / 100))
        txtSubTotal.Text = txtDesPrec.Text * nudCantidad.Value
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        con.IngresarCabe_Venta(txtCabe_Fac.Text, dtpFecha.Value, txtTotal.Text)
        For i As Integer = 0 To DataGridView1.Rows.Count - 2
            con.IngresarDeta_Venta(txtCabe_Fac.Text, DataGridView1.Rows(i).Cells(0).Value.ToString, DataGridView1.Rows(i).Cells(2).Value.ToString, DataGridView1.Rows(i).Cells(4).Value.ToString, DataGridView1.Rows(i).Cells(5).Value.ToString)
        Next
        MsgBox("Factura Guardada")
    End Sub
End Class