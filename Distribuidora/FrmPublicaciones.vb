Public Class FrmPublicaciones
    Private con As New Conexion
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtCodigo.Text = con.ObtenerCodigoPubs()
        con.CargarPublicaciones(DataGridView1)
        EnlaceDatos()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnAccion.Click
        If btnAccion.Text = "Ingresar" Then
            con.IngresarPub(txtCodigo.Text, txtTitulo.Text, txtPrecio.Text)
            con.CargarPublicaciones(DataGridView1)
        ElseIf btnAccion.Text = "Modificar" Then
            con.ModificarPrecio(txtCodigo.Text, CDbl(txtPrecio.Text))
            con.CargarPublicaciones(DataGridView1)
        End If
    End Sub

    Private Sub btnNoVendidos_Click(sender As Object, e As EventArgs) Handles btnNoVendidos.Click
        con.NoVendidos(DataGridView1)
    End Sub

    Public Sub EnlaceDatos()

        txtCodigo.DataBindings.Add("text", con._GetdtPubs, "Cod_Pub")
        txtTitulo.DataBindings.Add("text", con._GetdtPubs, "titulo")
        txtPrecio.DataBindings.Add("text", con._GetdtPubs, "Pre_Unit")

    End Sub
    Public Sub DesenlaceDatos()
        txtCodigo.DataBindings.Clear()
        txtTitulo.DataBindings.Clear()
        txtPrecio.DataBindings.Clear()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        txtPrecio.Text = ""
        txtTitulo.Text = ""
        txtCodigo.Text = con.ObtenerCodigoPubs
        btnAccion.Text = "Ingresar"
        DesenlaceDatos()
    End Sub

    

    Private Sub DataGridView1_Click(sender As Object, e As EventArgs) Handles DataGridView1.Click
        DesenlaceDatos()
        EnlaceDatos()
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        btnAccion.Text = "Modificar"
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        con.BuscarPub(txtBuscar.Text, DataGridView1)
    End Sub
End Class
