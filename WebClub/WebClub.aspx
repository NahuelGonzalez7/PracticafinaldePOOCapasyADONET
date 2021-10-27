<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebClub.aspx.cs" Inherits="WebClub.WebClub" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblJugador" runat="server" Text="Jugador"></asp:Label>
        </div>
        <p>
            <asp:Label ID="lblID" runat="server" Text="ID:"></asp:Label>
            <asp:TextBox ID="txtID" runat="server" style="margin-bottom: 0px"></asp:TextBox>
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
        </p>
        <p>
            <asp:Label ID="lblNombre" runat="server" Text="Nombre:"></asp:Label>
            <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
            <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click" />
        </p>
        <p>
            <asp:Label ID="lblApellido" runat="server" Text="Apellido:"></asp:Label>
            <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox>
            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
        </p>
        <p>
            <asp:Label ID="lblFechaNacimiento" runat="server" Text="Fecha Nacimiento:"></asp:Label>
            <asp:TextBox ID="txtFechaNacimiento" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="lblPuesto" runat="server" Text="Puesto"></asp:Label>
            <asp:DropDownList ID="ddlPuesto" runat="server">
            </asp:DropDownList>
        </p>
        <asp:Label ID="lblJugadorXPuesto" runat="server" Text="Buscar jugador por Puesto"></asp:Label>
        <asp:DropDownList ID="ddlJugadorxPuesto" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlJugadorxPuesto_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:GridView ID="gridJugadores" runat="server">
        </asp:GridView>
    </form>
</body>
</html>
