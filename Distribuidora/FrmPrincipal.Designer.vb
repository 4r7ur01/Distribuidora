<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPrincipal
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnPub = New System.Windows.Forms.Button()
        Me.btnPedido = New System.Windows.Forms.Button()
        Me.PanelCentro = New System.Windows.Forms.Panel()
        Me.btnDescuento = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.Panel1.Controls.Add(Me.btnDescuento)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.btnPub)
        Me.Panel1.Controls.Add(Me.btnPedido)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(198, 572)
        Me.Panel1.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(-2, 391)
        Me.Button1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(198, 181)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Anular Pedido"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnPub
        '
        Me.btnPub.Location = New System.Drawing.Point(2, 276)
        Me.btnPub.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnPub.Name = "btnPub"
        Me.btnPub.Size = New System.Drawing.Size(196, 109)
        Me.btnPub.TabIndex = 1
        Me.btnPub.Text = "Publicaciones"
        Me.btnPub.UseVisualStyleBackColor = True
        '
        'btnPedido
        '
        Me.btnPedido.Location = New System.Drawing.Point(0, 0)
        Me.btnPedido.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnPedido.Name = "btnPedido"
        Me.btnPedido.Size = New System.Drawing.Size(198, 75)
        Me.btnPedido.TabIndex = 0
        Me.btnPedido.Text = "Venta"
        Me.btnPedido.UseVisualStyleBackColor = True
        '
        'PanelCentro
        '
        Me.PanelCentro.BackColor = System.Drawing.Color.Silver
        Me.PanelCentro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelCentro.Location = New System.Drawing.Point(198, 0)
        Me.PanelCentro.Name = "PanelCentro"
        Me.PanelCentro.Size = New System.Drawing.Size(655, 572)
        Me.PanelCentro.TabIndex = 1
        '
        'btnDescuento
        '
        Me.btnDescuento.Location = New System.Drawing.Point(-3, 114)
        Me.btnDescuento.Margin = New System.Windows.Forms.Padding(2)
        Me.btnDescuento.Name = "btnDescuento"
        Me.btnDescuento.Size = New System.Drawing.Size(196, 109)
        Me.btnDescuento.TabIndex = 3
        Me.btnDescuento.Text = "Descuento"
        Me.btnDescuento.UseVisualStyleBackColor = True
        '
        'FrmPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(853, 572)
        Me.Controls.Add(Me.PanelCentro)
        Me.Controls.Add(Me.Panel1)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "FrmPrincipal"
        Me.Text = "FrmPrincipal"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btnPub As System.Windows.Forms.Button
    Friend WithEvents btnPedido As System.Windows.Forms.Button
    Friend WithEvents PanelCentro As Panel
    Friend WithEvents btnDescuento As Button
End Class
