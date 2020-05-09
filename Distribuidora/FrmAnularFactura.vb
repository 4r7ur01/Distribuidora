Public Class FrmAnularFactura
    Private con As New Conexion
    Private Sub FrmAnularFactura_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        con.CargarVentas(DataGridView1)
    End Sub

    Private Sub btnAnular_Click(sender As Object, e As EventArgs) Handles btnAnular.Click
        If MsgBoxResult.Yes = MessageBox.Show("¿Esta seguro de eliminar esta factura?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
            con.AnularVenta(DataGridView1.Rows(DataGridView1.CurrentCell.RowIndex).Cells(0).Value)
            MsgBox("Eliminado exitoso")
        End If
        con.CargarVentas(DataGridView1)
    End Sub
End Class