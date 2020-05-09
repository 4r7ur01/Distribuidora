Imports System.Data.SqlClient
Public Class Conexion
    Private con As New SqlConnection("Data Source=MAQUINA\MAQUINASQL;Initial Catalog=Distribuidoraaprobar;Integrated Security=True")
    Private dtPubs, dtNoVentas, dtFiltroPub, dtDescuento, dtConDescuento, dtVentas As New DataTable
    Public Function _GetdtPubs() As DataTable
        Return dtPubs
    End Function
    Public Function _GetdtDesuento() As DataTable
        Return dtDescuento
    End Function
    Public Function _GetdtConDescuento() As DataTable
        Return dtConDescuento
    End Function
    Public Function _GetdtVenta() As DataTable
        Return dtVentas
    End Function
    Public Function _Getcon() As SqlConnection
        Return con
    End Function

    Public Sub CargarPublicaciones(dgv As DataGridView)
        dtPubs.Clear()
        Dim da As New SqlDataAdapter("select  * from Publicaciones", con)
        da.Fill(dtPubs)
        dgv.DataSource = dtPubs
    End Sub
    Public Function ObtenerCodigoPubs() As String
        Dim codigo As String = ""
        Dim com As New SqlCommand
        com.Connection = con
        com.CommandType = CommandType.StoredProcedure
        com.CommandText = "USP_ObtenerCodPub"
        Dim output As New SqlParameter
        output.ParameterName = "@cod"
        output.SqlDbType = SqlDbType.VarChar
        output.Size = 5
        output.Direction = ParameterDirection.Output
        com.Parameters.Add(output)
        con.Open()
        Try
            com.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        codigo = output.Value
        con.Close()

        Return codigo
    End Function
    Public Sub IngresarPub(cod As String, titulo As String, precio As Double)
        Dim com As New SqlCommand
        com.CommandText = "USP_IngresarPub"
        com.Connection = con
        com.CommandType = CommandType.StoredProcedure
        com.Parameters.Add(New SqlParameter("@cod", SqlDbType.Char, 5, ParameterDirection.Input)).Value = cod
        com.Parameters.Add(New SqlParameter("@titulo", SqlDbType.VarChar, 40, ParameterDirection.Input)).Value = titulo
        com.Parameters.Add(New SqlParameter("@pre", SqlDbType.Float, ParameterDirection.Input)).Value = precio
        con.Open()
        Dim num As Integer = com.ExecuteNonQuery()
        If num > 0 Then
            MsgBox("Dato registrado")
        Else
            MsgBox("Dato no registrado")
        End If
        con.Close()
    End Sub
    Public Sub NoVendidos(dgv As DataGridView)
        dtNoVentas.Clear()
        Dim da As New SqlDataAdapter("select p.cod_pub,p.titulo,p.pre_unit from Publicaciones p,Ventas v where p.Cod_Pub != v.Cod_Pub ", con)
        da.Fill(dtNoVentas)
        dgv.DataSource = dtNoVentas
    End Sub
    Public Sub ModificarPrecio(codigo As String, precio As Double)
        Dim com As New SqlCommand
        com.CommandText = "update Publicaciones set Pre_Unit = " & precio & " where Cod_Pub = '" & codigo & "'"
        com.Connection = con
        con.Open()
        Try
            Dim int As Integer = com.ExecuteNonQuery
            If int > 0 Then
                MsgBox("Dato modificado")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        con.Close()
    End Sub
    Public Sub BuscarPub(titulo As String, dgv As DataGridView)
        dtFiltroPub.Clear()
        Dim da As New SqlDataAdapter("select * from Publicaciones where Titulo like '" & titulo & "%'", con)
        da.Fill(dtFiltroPub)
        dgv.DataSource = dtFiltroPub
    End Sub
    Public Sub CargarDescuento(dgv As DataGridView)
        dtDescuento.Clear()
        Dim da As New SqlDataAdapter("select * from descuento", con)
        da.Fill(dtDescuento)
        dgv.DataSource = dtDescuento
    End Sub
    Public Sub ModificarDescuento(Tipo As String, Min As Integer, Max As Integer, Porcentaje As Double)
        Dim com As New SqlCommand
        com.Connection = con
        com.CommandText = "update Descuento set Can_Min = " & Min & ", Can_Max = " & Max & ",Porcentaje = " & Porcentaje & " where Tipo_Desc = '" & Tipo & "'"
        con.Open()
        Try
            Dim int As Integer = com.ExecuteNonQuery
            If int > 0 Then
                MsgBox("Dato Modificado")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        con.Close()
    End Sub
    Public Sub ConsultarDescuento(cantidad As Integer, dgv As DataGridView)
        dtConDescuento.Clear()
        Dim da As New SqlDataAdapter("select * from Descuento where Can_Min <= " & cantidad & " and Can_Max >= " & cantidad & "", con)
        da.Fill(dtConDescuento)
        dgv.DataSource = dtConDescuento
    End Sub
    Public Sub ConsultarDescuento(cantidad As Integer)
        dtConDescuento.Clear()
        Dim da As New SqlDataAdapter("select * from Descuento where Can_Min <= " & cantidad & " and Can_Max >= " & cantidad & "", con)
        da.Fill(dtConDescuento)
    End Sub
    Public Sub CargarPublicaciones(cb As ListControl, campo As String)
        dtPubs.Clear()
        Dim da As New SqlDataAdapter("select * from Publicaciones", con)
        da.Fill(dtPubs)
        cb.DataSource = dtPubs
        cb.DisplayMember = campo
        cb.ValueMember = "Cod_Pub"
    End Sub
    Public Function ObtenerCodigoPedido() As String
        Dim codigo As String = ""
        Dim com As New SqlCommand
        com.CommandText = "USP_ObtenerCabe_Ventas"
        com.CommandType = CommandType.StoredProcedure
        com.Connection = con
        Dim output As New SqlParameter
        output.Direction = ParameterDirection.Output
        output.SqlDbType = SqlDbType.VarChar
        output.Size = 5
        output.ParameterName = "@cod"
        com.Parameters.Add(output)
        con.Open()
        Try
            com.ExecuteNonQuery()
            codigo = output.Value
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        con.Close()
        Return codigo
    End Function
    Public Sub IngresarCabe_Venta(cabeza As String, fecha As Date, total As Double)
        Dim com As New SqlCommand
        com.CommandType = CommandType.StoredProcedure
        com.CommandText = "USP_IngresarCabe_Ventas"
        com.Connection = con
        com.Parameters.Add(New SqlParameter("@cod", SqlDbType.Char, 5, ParameterDirection.Input)).Value = cabeza
        com.Parameters.Add(New SqlParameter("@fecha", SqlDbType.Date, ParameterDirection.Input)).Value = fecha
        com.Parameters.Add(New SqlParameter("@total", SqlDbType.Float, ParameterDirection.Input)).Value = total
        con.Open()
        com.ExecuteNonQuery()
        con.Close()
    End Sub
    Public Sub IngresarDeta_Venta(cabeza As String, cod_pro As String, descuento As String, cantidad As Integer, importe As Double)
        Dim com As New SqlCommand
        com.CommandText = "USP_IngresarDetaVenta"
        com.Connection = con
        com.CommandType = CommandType.StoredProcedure
        com.Parameters.Add(New SqlParameter("@cab", SqlDbType.Char, 5, ParameterDirection.Input)).Value = cabeza
        com.Parameters.Add(New SqlParameter("@cod_Pro", SqlDbType.Char, 5, ParameterDirection.Input)).Value = cod_pro
        com.Parameters.Add(New SqlParameter("@tipo", SqlDbType.VarChar, 20, ParameterDirection.Input)).Value = descuento
        com.Parameters.Add(New SqlParameter("@can", SqlDbType.Int, ParameterDirection.Input)).Value = cantidad
        com.Parameters.Add(New SqlParameter("@imp", SqlDbType.Float, ParameterDirection.Input)).Value = importe
        con.Open()
        com.ExecuteNonQuery()
        con.Close()
    End Sub
    Public Sub CargarVentas(dgv As DataGridView)
        dtVentas.Clear()
        Dim da As New SqlDataAdapter("select * from cabe_ventas", con)
        da.Fill(dtVentas)
        dgv.DataSource = dtVentas
    End Sub
    Public Sub AnularVenta(cab As String)
        Dim com As New SqlCommand
        com.Connection = con
        com.CommandText = "USP_AnularVenta"
        com.CommandType = CommandType.StoredProcedure
        com.Parameters.Add(New SqlParameter("@cab", SqlDbType.Char, 5, ParameterDirection.Input)).Value = cab
        con.Open()
        com.ExecuteNonQuery()
        con.Close()
        Dim com1 As New SqlCommand
        com1.Connection = con
        com1.CommandText = "USP_AnularCabeVenta"
        com1.CommandType = CommandType.StoredProcedure
        com1.Parameters.Add(New SqlParameter("@cab", SqlDbType.Char, 5, ParameterDirection.Input)).Value = cab
        con.Open()
        com1.ExecuteNonQuery()
        con.Close()
    End Sub

End Class
