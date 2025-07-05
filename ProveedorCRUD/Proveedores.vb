Imports System.Data.SqlClient
Imports ProveedorCRUD.Proveedor

Public Class Proveedor
    Public Property ProveedorId As Integer
    Public Property NombreEmpresa As String
    Public Property Contacto As String
    Public Property Telefono As String

    ' Constructor parametrizado
    Public Sub New(ByVal proveedorId As Integer, ByVal nombreEmpresa As String, ByVal contacto As String, ByVal telefono As String)
        Me.ProveedorId = proveedorId
        Me.NombreEmpresa = nombreEmpresa
        Me.Contacto = contacto
        Me.Telefono = telefono
    End Sub
    Imports System.Data
    Imports System.Data.SqlClient

    Partial Class Proveedores
        Inherits System.Web.UI.Page

        Private connString As String = ConfigurationManager.ConnectionStrings("MiConexion").ConnectionString

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            If Not IsPostBack Then
                CargarGrid()
            End If
        End Sub

        Private Sub CargarGrid()
            Using conn As New SqlConnection(connString)
                Dim cmd As New SqlCommand("SELECT * FROM Proveedores", conn)
                conn.Open()
                gvProveedores.DataSource = cmd.ExecuteReader()
                gvProveedores.DataBind()
            End Using
        End Sub

        Protected Sub btnGuardar_Click(sender As Object, e As EventArgs)
            Using conn As New SqlConnection(connString)
                Dim cmd As SqlCommand
                If hfProveedorId.Value = "" Then
                    ' Insertar
                    cmd = New SqlCommand("INSERT INTO Proveedores (NombreEmpresa, Contacto, Telefono) VALUES (@nombre, @contacto, @telefono)", conn)
                Else
                    ' Actualizar
                    cmd = New SqlCommand("UPDATE Proveedores SET NombreEmpresa=@nombre, Contacto=@contacto, Telefono=@telefono WHERE ProveedorId=@id", conn)
                    cmd.Parameters.AddWithValue("@id", hfProveedorId.Value)
                End If

                cmd.Parameters.AddWithValue("@nombre", txtNombreEmpresa.Text)
                cmd.Parameters.AddWithValue("@contacto", txtContacto.Text)
                cmd.Parameters.AddWithValue("@telefono", txtTelefono.Text)

                conn.Open()
                cmd.ExecuteNonQuery()
                conn.Close()

                LimpiarFormulario()
                CargarGrid()
            End Using
        End Sub

        Protected Sub gvProveedores_SelectedIndexChanged(sender As Object, e As EventArgs)
            Dim row As GridViewRow = gvProveedores.SelectedRow
            hfProveedorId.Value = gvProveedores.DataKeys(row.RowIndex).Value.ToString()
            txtNombreEmpresa.Text = row.Cells(1).Text
            txtContacto.Text = row.Cells(2).Text
            txtTelefono.Text = row.Cells(3).Text
        End Sub

        Protected Sub gvProveedores_RowCommand(sender As Object, e As GridViewCommandEventArgs)
            If e.CommandName = "Delete" Then
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                Dim proveedorId As Integer = Convert.ToInt32(gvProveedores.DataKeys(index).Value)

                Using conn As New SqlConnection(connString)
                    Dim cmd As New SqlCommand("DELETE FROM Proveedores WHERE ProveedorId = @id", conn)
                    cmd.Parameters.AddWithValue("@id", proveedorId)
                    conn.Open()
                    cmd.ExecuteNonQuery()
                    conn.Close()
                    CargarGrid()
                    LimpiarFormulario()
                End Using
            End If
        End Sub

        Protected Sub btnCancelar_Click(sender As Object, e As EventArgs)
            LimpiarFormulario()
        End Sub

        Private Sub LimpiarFormulario()
            txtNombreEmpresa.Text = ""
            txtContacto.Text = ""
            txtTelefono.Text = ""
            hfProveedorId.Value = ""
        End Sub
    End Class
End Class


