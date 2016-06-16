<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ReporteVentasWF.aspx.cs" Inherits="ReporteVentasWF" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <title>Reporte de Ventas</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" runat="Server">
    <br />
    <br />
    <br />
    <h1 class="text-center">Reporte de Ventas</h1>
    <br />
    <br />
        <label>Apellido del Cliente:</label>
    <asp:TextBox ID="txtApellido" placeholder="Ingrese apellido del cliente" CssClass="form-control" runat="server"></asp:TextBox>
 <%--     <asp:RequiredFieldValidator ID="rfvApellido"
            runat="server"
            ControlToValidate="txtApellido"
            ErrorMessage="Ingrese Apellido"
            CssClass="alert-danger" Display="Dynamic"
            Text="*" ValidationGroup="A" />--%>
        <asp:RegularExpressionValidator ID="rvApellido"
             runat="server" ErrorMessage="Ingrese un Apellido válido"
             ControlToValidate="txtApellido" ValidationExpression="^[a-zA-Z ]*$"
             CssClass="alert-danger"
             Display="Dynamic"></asp:RegularExpressionValidator>
    <br />
 <%--   <label>Nombre del Cliente:</label>
    <asp:TextBox ID="txtNombre" placeholder="Ingrese nombre del cliente" CssClass="form-control" runat="server"></asp:TextBox>
      <asp:RequiredFieldValidator ID="rfvNombre"
            runat="server"
            ControlToValidate="txtNombre"
            ErrorMessage="Ingrese Nombre"
            CssClass="alert-danger" Display="Dynamic"
            Text="*" ValidationGroup="A" />
        <asp:RegularExpressionValidator ID="rvNombre"
             runat="server" ErrorMessage="Ingrese un Nombre válido"
             ControlToValidate="txtNombre" ValidationExpression="^[a-zA-Z ]*$"
             CssClass="alert-danger"
             Display="Dynamic"></asp:RegularExpressionValidator>
    <br />--%>
        <label>Fecha de la Venta:</label>
    <asp:TextBox ID="txtFechaFactura" placeholder="DD/MM/AAAA" CssClass="form-control " runat="server"></asp:TextBox>
    <%-- <asp:RequiredFieldValidator ID="rfvFecha"
            runat="server"
            ControlToValidate="txtFechaFactura"
            ErrorMessage="Ingrese Fecha de Venta"
            CssClass="alert-danger" Display="Dynamic"
            Text="*" ValidationGroup="A" />--%>
       <%-- <asp:RegularExpressionValidator ID="rvFecha"
             runat="server" ErrorMessage="Ingrese una Fecha válida"
             ControlToValidate="txtNumDoc" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[-/.](0[1-9]|1[012])[-/.](19|20)\d\d$"
             CssClass="alert-danger"
             Display="Dynamic"></asp:RegularExpressionValidator>--%>
    <br />
    <label for="ddlEmpleados">Empleado:</label>
        <asp:DropDownList ID="ddlEmpleados" CssClass="form-control" runat="server" AppendDataBoundItems="true">
            <asp:ListItem Value="0">Seleccione..</asp:ListItem>
        </asp:DropDownList>
       <%-- <asp:RequiredFieldValidator ID="rfvEmpleados"
            runat="server" ControlToValidate="ddlEmpleados"
            ErrorMessage="Seleccione un Empleado" InitialValue="0"
            CssClass="alert-danger"
            Display="Dynamic"></asp:RequiredFieldValidator>--%>
    <br />
    <br />
    <asp:Button ID="btnBuscarVentas" runat="server" CssClass="btn btn-primary" Text="Buscar ventas" OnClick="btnBuscarVentas_Click" ValidationGroup="A"/>
    <asp:Button ID="btnNuevoReporte" runat="server" Text="Nuevo Reporte" class="btn btn-default" />

    <br />
    <br />
    <asp:GridView ID="gvVentas" CssClass="table table-hover table-striped" AutoGenerateColumns="false" runat="server" OnPageIndexChanging="gvVentas_PageIndexChanging">
        <Columns>
            <asp:BoundField DataField="Factura.fecha" ItemStyle-CssClass="col-lg-3 text-center" HeaderText="Fecha" />
            <asp:BoundField DataField="Cliente.nombreYapellido" ItemStyle-CssClass="col-lg-3 text-center" HeaderText="Cliente" />
            <asp:BoundField DataField="Empleado.nombreYApellido" ItemStyle-CssClass="col-lg-3 text-center" HeaderText="Empleado" /> 
            <asp:BoundField DataField="Factura.total" ItemStyle-CssClass="col-lg-3 text-center" HeaderText="Monto Total" />
        </Columns>
    </asp:GridView>

</asp:Content>
