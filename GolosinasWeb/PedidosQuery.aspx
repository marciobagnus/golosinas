<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PedidosQuery.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" Runat="Server">
      <div class="row">
        <div class="col-md-5">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <h4>Buscar</h4>
                </div>
                <div class="panel-body">
                
                        <div class="form-group">
                        <label for="ddlTipo" id="lblTipo">Tipo Golosina</label>
                        <asp:DropDownList ID="ddlTipo" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                            <asp:ListItem Value="null">Seleccione..</asp:ListItem>
                        </asp:DropDownList>

                    </div>
                    <div class="form-group">
                        <label for="ddlCeliaco" id="lblCeliaco">Celiacos</label>
                        <asp:DropDownList ID="ddlCeliaco" CssClass="form-control" runat="server" AppendDataBoundItems="true">
                            <asp:ListItem Value="null">Todos</asp:ListItem>
                            <asp:ListItem Value="true">Si</asp:ListItem>
                            <asp:ListItem Value="false">No</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label for="txtPrecioCDesde" id="lblPrecioCDesde">Precio Compra Desde</label>
                        <asp:TextBox ID="txtPrecioCDesde" CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
                        <asp:RangeValidator ID="rvPrecioC"
                            ControlToValidate="txtPrecioCDesde"
                            runat="server" Type="Double"
                            CssClass="alert-danger" Display="Dynamic"
                            MaximumValue="50000"
                            MinimumValue="1"
                            ErrorMessage="Precio de Compra debe estar entre 1 y 50000"
                            Text="*" ValidationGroup="A">
                        </asp:RangeValidator>
                        <asp:RegularExpressionValidator ID="revPrecioCD"
                            runat="server" ControlToValidate="txtPrecioCDesde"
                            CssClass="alert-danger" Display="Dynamic" ErrorMessage="Ingrese Solo numeros"
                            ValidationExpression="[0-9]*\,?[0-9]*">
                        </asp:RegularExpressionValidator>
                    </div>
                    <div class="form-group">
                        <label for="txtPrecioCHasta" id="lblPrecioCHasta">Precio Compra Hasta</label>
                        <asp:TextBox ID="txtPrecioCHasta" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RangeValidator ID="rvPrecioCH"
                            ControlToValidate="txtPrecioCHasta"
                            runat="server" Type="Double"
                            CssClass="alert-danger" Display="Dynamic"
                            MaximumValue="50000"
                            MinimumValue="1"
                            ErrorMessage="Precio de Compra debe estar entre 1 y 50000"
                            Text="*" ValidationGroup="A">
                        </asp:RangeValidator>
                        <asp:RegularExpressionValidator ID="revPrecioCH"
                            runat="server" ControlToValidate="txtPrecioCHasta"
                            CssClass="alert-danger" Display="Dynamic" ErrorMessage="Ingrese Solo numeros"
                            ValidationExpression="[0-9]*\,?[0-9]*">
                        </asp:RegularExpressionValidator>
                    </div>
                </div>
                <div class="btn-group-lg text-center">
                    <asp:Button ID="btnBuscar" Text="Buscar" runat="server" OnClick="btnBuscar_Click" class="btn btn-default" />
                </div>
               
            </div>
             <div class="btn-group-lg text-center">
                    <h3>
                        <asp:Label ID="lblMensajeExito" class="label label-success" runat="server"></asp:Label></h3>
                    <h3>
                        <asp:Label ID="lblMensajeError" class="label label-danger" runat="server"></asp:Label></h3>
                </div>
        </div>
        
    </div>
    <div class="row">
        <div class="col-md-11">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <h4>Informe de Stock
                    </h4>
                </div>
                <div class="panel-body" id="divGrilla" runat="server">
                    <asp:GridView ID="gvInforme" runat="server" AutoGenerateColumns="False" CssClass="table table-hover table-striped"
                        EmptyDataText="No se encontraron golosinas con esta busqueda"
                        GridLines="None" AllowPaging="True" PageSize="10" Width="438px" 
                        OnPageIndexChanged="gvInforme_PageIndexChanged">
                        <Columns>
                            <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                            <asp:BoundField DataField="nombreTipo" HeaderText="Tipo" />
                            <asp:TemplateField HeaderText="Celiacos">
                                <ItemTemplate><%# (Boolean.Parse(Eval("esAptoCeliaco").ToString())) ? "Si" : "No" %></ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="precioCompra" HeaderText="Precio Cpra" DataFormatString="${0:0.00}" />
                            <asp:BoundField DataField="precioVenta" HeaderText="Precio Vta" DataFormatString="${0:0.00}" />
                            <asp:BoundField DataField="stockActual" HeaderText="Stock Actual" />
                            <asp:BoundField DataField="stockMinimo" HeaderText="StockMinimo" />
                            <asp:TemplateField HeaderText="¿Pedir?">
                                <ItemTemplate><%# (Boolean.Parse(Eval("listoParaPedir").ToString())) ? "Si" : "No" %></ItemTemplate>
                            </asp:TemplateField>

                        </Columns>

                    </asp:GridView>
                </div>
            </div>
        </div>
        </div>    


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>

