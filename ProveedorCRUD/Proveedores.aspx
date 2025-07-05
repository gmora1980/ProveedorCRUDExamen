<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Proveedores.aspx.vb" Inherits="Proveedores" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CRUD de Proveedores</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="max-width: 800px; margin: auto; padding: 20px;">
            <h2>Gestión de Proveedores</h2>

            <!-- GridView -->
            <asp:GridView ID="gvProveedores" runat="server" AutoGenerateColumns="False"
                DataKeyNames="ProveedorId" OnSelectedIndexChanged="gvProveedores_SelectedIndexChanged"
                OnRowCommand="gvProveedores_RowCommand" CssClass="table table-bordered">
                <Columns>
                    <asp:BoundField DataField="ProveedorId" HeaderText="ID" ReadOnly="True" />
                    <asp:BoundField DataField="NombreEmpresa" HeaderText="Nombre Empresa" />
                    <asp:BoundField DataField="Contacto" HeaderText="Contacto" />
                    <asp:BoundField DataField="Telefono" HeaderText="Teléfono" />
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:ButtonField ButtonType="Button" CommandName="Delete" Text="Eliminar" />
                </Columns>
            </asp:GridView>

            <br />

            <!-- Formulario -->
            <h4><% If hfProveedorId.Value = "" Then %>Nuevo Proveedor<% Else %>Editar Proveedor<% End If %></h4>

            <table>
                <tr>
                    <td>Nombre Empresa:</td>
                    <td><asp:TextBox ID="txtNombreEmpresa" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Contacto:</td>
                    <td><asp:TextBox ID="txtContacto" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Teléfono:</td>
                    <td><asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
                        &nbsp;
                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>