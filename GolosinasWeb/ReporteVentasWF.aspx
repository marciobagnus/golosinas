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

        <asp:RegularExpressionValidator ID="rvApellido"
             runat="server" ErrorMessage="Ingrese un Apellido válido"
             ControlToValidate="txtApellido" ValidationExpression="^[a-zA-Z ]*$"
             CssClass="alert-danger"
             Display="Dynamic"></asp:RegularExpressionValidator>
    <br />

                        <label>Fecha Desde:</label>
                        <asp:TextBox ID="txtFechaDesde" placeholder="DD/MM/AAAA" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
                        <asp:RangeValidator ID="rvFechaDesde"
                            ControlToValidate="txtFechaDesde"
                            runat="server" Type="Date"
                            CssClass="alert-danger" Display="Dynamic"
                            MaximumValue="01/01/2900"
                            MinimumValue="01/01/1900"
                            ErrorMessage="Fecha de la venta debe estar entre 01/01/1900-01/01/2900"
                            Text="*" ValidationGroup="A"> </asp:RangeValidator>
    <br />
                        <label>Fecha Hasta:</label>
                        <asp:TextBox ID="txtFechaHasta" placeholder="DD/MM/AAAA" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
                        <asp:RangeValidator ID="rvFechaHasta"
                            ControlToValidate="txtFechaHasta"
                            runat="server" Type="Date"
                            CssClass="alert-danger" Display="Dynamic"
                            MaximumValue="01/01/2900"
                            MinimumValue="01/01/1900"
                            ErrorMessage="Fecha de la venta debe estar entre 01/01/1900-01/01/2900"
                            Text="*" ValidationGroup="A"> </asp:RangeValidator>
    <br />
    <label for="ddlEmpleados">Empleado:</label>
        <asp:DropDownList ID="ddlEmpleados" CssClass="form-control" runat="server" AppendDataBoundItems="true">
            <asp:ListItem Value="null">Seleccione..</asp:ListItem>
        </asp:DropDownList>
    <br />
    <br />
    <asp:Button ID="btnBuscarVentas" runat="server" CssClass="btn btn-primary" Text="Buscar ventas" OnClick="btnBuscarVentas_Click" ValidationGroup="A"/>
    <br /> 
    <br />  
    <asp:Label ID="lblMensajeExito" class="label label-success" runat="server"></asp:Label>
    <asp:Label ID="lblMensajeError" class="label label-danger" runat="server"></asp:Label>           
    <br />
    <br />                   
    <asp:GridView ID="gvVentas" CssClass="table table-hover table-striped" AutoGenerateColumns="false" runat="server" 
        GridLines="None" AllowPaging="True" PageSize="10" Width="438px" OnPageIndexChanging="gvVentas_PageIndexChanging">
        <Columns>
            <asp:BoundField DataField="fechaFactura" ItemStyle-CssClass="col-lg-3 text-center" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy}"/>
            <asp:BoundField DataField="nombreYapellidoCliente" ItemStyle-CssClass="col-lg-3 text-center" HeaderText="Cliente" />
            <asp:BoundField DataField="nombreYApellidoEmpleado" ItemStyle-CssClass="col-lg-3 text-center" HeaderText="Empleado" /> 
            <asp:BoundField DataField="totalFactura" ItemStyle-CssClass="col-lg-3 text-center" HeaderText="Monto Total" />
        </Columns>
    </asp:GridView>

</asp:Content>
