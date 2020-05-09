Public Class FrmDescuentos
    Private con As New Conexion
    Private Sub FrmDescuentos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        con.CargarDescuento(DataGridView1)
        EnlaceDatos()
    End Sub
    Private Sub EnlaceDatos()
        txtTipo.DataBindings.Add("Text", con._GetdtDesuento, "Tipo_Desc")
        txtPorcentaje.DataBindings.Add("Text", con._GetdtDesuento, "Porcentaje")
        nudMin.DataBindings.Add("Value", con._GetdtDesuento, "Can_Min")
        nudMax.DataBindings.Add("Value", con._GetdtDesuento, "Can_Max")
    End Sub
    Private Sub DesenlaceDatos()
        txtTipo.DataBindings.Clear()
        txtPorcentaje.DataBindings.Clear()
        nudMin.DataBindings.Clear()
        nudMax.DataBindings.Clear()
    End Sub

    Private Sub DataGridView1_Click(sender As Object, e As EventArgs) Handles DataGridView1.Click
        DesenlaceDatos()
        EnlaceDatos()
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        con.ModificarDescuento(txtTipo.Text, nudMin.Value, nudMax.Value, txtPorcentaje.Text)
        con.CargarDescuento(DataGridView1)
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        If txtBuscar.Text <> "" Then
            con.ConsultarDescuento(txtBuscar.Text, DataGridView1)
        Else
            con.CargarDescuento(DataGridView1)
        End If
    End Sub
End Class