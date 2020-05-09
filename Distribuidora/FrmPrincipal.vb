Public Class FrmPrincipal
    Private Sub btnPedido_Click(sender As Object, e As EventArgs) Handles btnPedido.Click
        FrmPublicaciones.Close()
        FrmDescuentos.Close()
        FrmAnularFactura.Close()
        FrmPedido.TopLevel = False
        FrmPedido.Dock = DockStyle.Fill
        PanelCentro.Controls.Add(FrmPedido)
        FrmPedido.Show()
    End Sub
    Private Sub btnPub_Click(sender As Object, e As EventArgs) Handles btnPub.Click
        FrmDescuentos.Close()
        FrmAnularFactura.Close()
        FrmPedido.Close()
        FrmPublicaciones.TopLevel = False
        FrmPublicaciones.Dock = DockStyle.Fill
        PanelCentro.Controls.Add(FrmPublicaciones)
        FrmPublicaciones.Show()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FrmDescuentos.Close()
        FrmPublicaciones.Close()
        FrmPedido.Close()
        FrmAnularFactura.TopLevel = False
        FrmAnularFactura.Dock = DockStyle.Fill
        PanelCentro.Controls.Add(FrmAnularFactura)
        FrmAnularFactura.Show()
    End Sub

    Private Sub btnDescuento_Click(sender As Object, e As EventArgs) Handles btnDescuento.Click
        FrmPedido.Close()
        FrmPublicaciones.Close()
        FrmAnularFactura.Close()
        FrmDescuentos.TopLevel = False
        FrmDescuentos.Dock = DockStyle.Fill
        PanelCentro.Controls.Add(FrmDescuentos)
        FrmDescuentos.Show()
    End Sub
End Class