<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PedidosQuery.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" runat="Server">
    <div class="row">
        <div class="col-md-4">
            <div class="panel panel-primary">

                <div class="panel-body">

                    <div class="form-group">
                        <label>Razon Social Proveedor:</label>
                        <asp:DropDownList ID="ddl_proveedores" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                            <asp:ListItem Value="null">Seleccione..</asp:ListItem>
                        </asp:DropDownList>

                    </div>

                    <div class="form-group">
                        <label>Fecha Compra Desde:</label>
                        <asp:TextBox ID="txt_fechaPedidoDesde" placeholder="DD/MM/AAAA" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
                        <asp:RangeValidator ID="rvpfechaPedidoDesde"
                            ControlToValidate="txt_fechaPedidoDesde"
                            runat="server" Type="Date"
                            CssClass="alert-danger" Display="Dynamic"
                            MaximumValue="01/01/2900"
                            MinimumValue="01/01/1900"
                            ErrorMessage="Fecha de compra debe estar entre 01/01/1900-01/01/2900"
                            Text="*" ValidationGroup="A"> </asp:RangeValidator>

                    </div>

                    <div class="form-group">
                        <label>Fecha Compra Hasta:</label>
                        <asp:TextBox ID="txt_fechaPedidoHasta" placeholder="DD/MM/AAAA" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RangeValidator ID="rvfechaPedidoHasta"
                            ControlToValidate="txt_fechaPedidoHasta"
                            runat="server" Type="Date"
                            CssClass="alert-danger" Display="Dynamic"
                            MaximumValue="01/01/2900"
                            MinimumValue="01/01/1900"
                            ErrorMessage="Fecha de compra debe estar entre 01/01/1900-01/01/2900"
                            Text="*" ValidationGroup="A"> </asp:RangeValidator>


                    </div>

                    <div class="form-group">
                        <label>Empleado:</label>
                        <asp:TextBox ID="txt_apeNom" placeholder="Ingrese Apellido y Nombre del Empleado" CssClass="form-control" runat="server"></asp:TextBox>


                    </div>
                </div>
                <div class="btn-group-lg text-center">
                    <asp:ValidationSummary runat="server" ValidationGroup="A" />
                    <asp:Button ID="btnBuscar" Text="Buscar" runat="server" OnClick="btnBuscar_Click" class="btn btn-primary" ValidationGroup="A" />
                    <asp:Button ID="btnLimpiar" Text="Limpiar" runat="server" OnClick="btnLimpiar_Click" class="btn btn-default" />
                    <br />
                </div>

            </div>
            <div class="btn-group-lg text-center">
                <h3>
                    <asp:Label ID="lblMensajeExito" class="label label-success" runat="server"></asp:Label></h3>
                <h3>
                    <asp:Label ID="lblMensajeError" class="label label-danger" runat="server"></asp:Label></h3>
            </div>


        </div>


        <div class="col-md-8">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <h4>Reporte de Compras
                    </h4>
                </div>
                <div class="panel-body" id="divGrilla" runat="server">
                    <asp:GridView ID="gvInforme" runat="server" AutoGenerateColumns="False"
                        HeaderStyle-BackColor="#009900"
                        CssClass="table table-hover table-striped"
                        EmptyDataText="No se encontraron compras en esta busqueda"
                        GridLines="None" AllowPaging="True" Width="438px"
                        OnPageIndexChanging="gvInforme_PageIndexChanging">
                        <Columns>
                            <asp:BoundField DataField="razonSocial" HeaderText="Razon Social" />
                            <asp:BoundField DataField="fechaPedido" HeaderText="Fecha Pedido" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:BoundField DataField="apeNom" HeaderText="Empleado" />
                            <asp:BoundField DataField="total" HeaderText="Monto Total" />
                        </Columns>

<HeaderStyle BackColor="#009900"></HeaderStyle>

                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>



</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>

