<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TransaccionVenta.aspx.cs" Inherits="TransaccionVenta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Registrar venta</title>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" runat="Server">
    <br />
    <br />
    <br />
    <h1 class="text-center">Registrar Venta</h1>
    <br />
    <br />

      <label for="ddlEmpleados">Empleado:</label>
        <asp:DropDownList ID="ddlEmpleados" CssClass="form-control" runat="server" AppendDataBoundItems="true">
            <asp:ListItem Value="0">Seleccione..</asp:ListItem>
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="rfvEmpleados"
            runat="server" ControlToValidate="ddlEmpleados"
            ErrorMessage="Seleccione un Empleado" InitialValue="0"
            CssClass="alert-danger"
            Display="Dynamic"></asp:RequiredFieldValidator>
    <br />    
        <label for="ddlClientes">Cliente:</label>
        <asp:DropDownList ID="ddlClientes" CssClass="form-control" runat="server" AppendDataBoundItems="true">
            <asp:ListItem Value="0">Seleccione..</asp:ListItem>
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="rvfClientes"
            runat="server" ControlToValidate="ddlClientes"
            ErrorMessage="Seleccione un Cliente" InitialValue="0"
            CssClass="alert-danger"
            Display="Dynamic"></asp:RequiredFieldValidator>
    <br />
        <label for="ddlTipoFac">Tipo de Factura:</label>
        <asp:DropDownList ID="ddlTipoFac" CssClass="form-control" runat="server" AppendDataBoundItems="true">
            <asp:ListItem Value="0">Seleccione..</asp:ListItem>
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="rfvTipoFac"
            runat="server" ControlToValidate="ddlTipoFac"
            ErrorMessage="Seleccione un Tipo de Factura" InitialValue="0"
            CssClass="alert-danger"
            Display="Dynamic"></asp:RequiredFieldValidator>
    <br />
        <label>Fecha: </label>
        <asp:Label ID="lblFecha" runat="server"></asp:Label>
    <br />

    <br />

                <label>Productos: </label>

                <asp:GridView ID="gvGolosinas" runat="server"
                    AutoGenerateColumns="false" CssClass="table table-hover table-striped"
                    DataKeyNames="idGolosina" GridLines="None" AllowPaging="True" PageSize="5" Width="438px"
                    OnPageIndexChanging="gvGolosinas_PageIndexChanging">
                    <Columns>
                        <asp:TemplateField HeaderText="Producto">
                            <ItemTemplate>
                                <asp:Label ID="lblIdGolosina" Visible="false" Text='<%# Eval("idGolosina") %>' runat="server"></asp:Label>
                                <asp:Label ID="lblProducto" runat="server" Text='<%# Eval("nombre") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Cantidad">
                            <ItemTemplate>
                                <asp:Button ID="btnMinus" runat="server" Text="-" OnClick="btnMinus_Click"></asp:Button>
                                <asp:Label ID="lblCantidad" runat="server" Text="0"></asp:Label>
                                <asp:Button ID="btnPlus" runat="server" Text="+" OnClick="btnPlus_Click"></asp:Button>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-Width="50" HeaderText="Precio Unitario">
                            <ItemTemplate>
                                <asp:Label ID="lblSigno" Text="$" runat="server"></asp:Label>
                                <asp:Label ID="lblPrecioUnitario" runat="server" Text='<%# Eval("precioGolosina") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Precio">
                            <ItemTemplate>
                                <asp:Label ID="lblSigno2" Text="$" runat="server"></asp:Label>
                                <asp:Label ID="lblSubtotal" Text='<%# Eval("subtotal") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btnAgregarAlResumen" runat="server" Text="Agregar" OnClick="btnAgregarAlResumen_Click"></asp:Button>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:GridView ID="gvPromociones" runat="server"
                    AutoGenerateColumns="false" CssClass="table table-hover table-striped"
                    DataKeyNames="idPromocion" GridLines="None" AllowPaging="True" PageSize="5" Width="438px"
                    OnPageIndexChanging="gvPromociones_PageIndexChanging">
                    <Columns>
                        <asp:TemplateField HeaderText="Promocion">
                            <ItemTemplate>
                                <asp:Label ID="lblIdPromocion" Visible="false" Text='<%# Eval("idPromocion") %>' runat="server"></asp:Label>
                                <asp:Label ID="lblNombrePromocion" runat="server" Text='<%# Eval("nombre") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Cantidad">
                            <ItemTemplate>
                                <asp:Button ID="btnMinus0" runat="server" Text="-" OnClick="btnMinus0_Click"></asp:Button>
                                <asp:Label ID="lblCantidad0" runat="server" Text="0"></asp:Label>
                                <asp:Button ID="btnPlus0" runat="server" Text="+" OnClick="btnPlus0_Click"></asp:Button>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-Width="50" HeaderText="Precio Unitario">
                            <ItemTemplate>
                                <asp:Label ID="lblSigno3" Text="$" runat="server"></asp:Label>
                                <asp:Label ID="lblPrecioUnitario0" runat="server" Text='<%# Eval("precioPromocion") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Precio">
                            <ItemTemplate>
                                <asp:Label ID="lblSigno4" Text="$" runat="server"></asp:Label>
                                <asp:Label ID="lblSubtotal0" Text='<%# Eval("subtotal") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btnAgregarAlResumen0" runat="server" Text="Agregar" OnClick="btnAgregarAlResumen0_Click"></asp:Button>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

                <label>Resumen de Venta: </label>
     
                <asp:GridView ID="gvResumen" runat="server"
                    AutoGenerateColumns="False" CssClass="table table-hover table-striped"
                    DataKeyNames="idGolosina" GridLines="None" AllowPaging="True" PageSize="5" Width="438px"
                    OnPageIndexChanging="gvResumen_PageIndexChanging">
                    <Columns>
                        <asp:BoundField HeaderText="Producto" DataField="nombre" />
                        <asp:BoundField HeaderText="Cantidad" DataField="cantidad" />
                        <asp:BoundField HeaderText="Subtotal" DataField="subtotal" />

                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btnQuitar" Text="Quitar" runat="server" OnClick="btnQuitar_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <br />

                    <asp:Label Text="Total: $" runat="server"></asp:Label>
                    <asp:Label ID="lblTotal" Text='<%# Eval("precioTotal") %>' runat="server"></asp:Label>

    <br />
    <br />
    <asp:Button ID="btnRegistrarVenta" Text="Registrar Venta" CssClass="btn btn-primary" runat="server" OnClick="btnRegistrarVenta_Click" />
    <br />
    <br />
    <br />
    <br />


</asp:Content>