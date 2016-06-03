﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterCarrito.master" AutoEventWireup="true" CodeFile="carritoPedidosWF.aspx.cs" Inherits="carritoPedidos" %>

<script runat="server">

    protected void btn_quitar_Click(object sender, EventArgs e)
    {

    }
</script>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceCabecera" runat="Server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlacePrincipal1" runat="Server">
    <div class="jumbotron">
        <h1>Listado Golosinas para Pedido</h1>
    </div>


    <div class="row center-block panel panel-default">

        <br />
        <label>Listado de Proveedores: </label>
        <asp:DropDownList ID="cmb_proveedores" runat="server"></asp:DropDownList>
        <br />
        <br />
        <label>Fecha de Pedido: </label>
        <asp:Label ID="lbl_fechaPedido" runat="server"></asp:Label>
        <br />
        <br />
        <label>Fecha de Entrega: </label>
        <asp:Label ID="lbl_fechaEntrega" runat="server"></asp:Label>

    </div>

    <br />
    <br />
    <div class="row">
        <div class="panel panel-default col-lg-6">



            <asp:GridView ID="grillaGolosinas" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered bs-table left" HeaderStyle-BackColor="#cc6600">
                <Columns>


                    <asp:TemplateField HeaderText="Producto">
                        <ItemTemplate>
                            <asp:Label ID="lbl_idGolosina" Visible="false" Text='<%# Eval("idGolosina") %>' runat="server"></asp:Label>
                            <asp:Label ID="lbl_producto" runat="server" Text='<%# Eval("nombre") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Cantidad">
                        <ItemTemplate>
                            <asp:Button ID="btnMinus" runat="server" Text="-" OnClick="btnMinus_Click"></asp:Button>
                            <asp:Label ID="lbl_Cantidad" runat="server" Text="0"></asp:Label>
                            <asp:Button ID="btnPlus" runat="server" Text="+" OnClick="btnPlus_Click"></asp:Button>

                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-Width="50" HeaderText="Precio Unitario">
                        <ItemTemplate>
                            <asp:Label ID="lbl_signo" Text="$" runat="server"></asp:Label>
                            <asp:Label ID="lbl_precioUnitario" runat="server" Text='<%# Eval("precioUnitario") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Precio">
                        <ItemTemplate>
                            <asp:Label ID="lbl_signo2" Text="$" runat="server"></asp:Label>
                            <asp:Label ID="lbl_subtotal" Text='<%# Eval("subtotal") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btn_agregarAlCarrito" runat="server" Text="Agregar al Carrito" OnClick="btn_agregarAlCarrito_Click"></asp:Button>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

        </div>
        <div class="col-lg-1"></div>

        <div class="panel panel-default col-lg-5">

            <div class="text-uppercase text-right text-info">
                <asp:Label Text="Precio Total: $" runat="server"></asp:Label>
                <asp:Label ID="lbl_precioTotal" Text='<%# Eval("precioTotal") %>' runat="server"></asp:Label>
            </div>


            <asp:GridView ID="grillaCarrito" runat="server" CssClass="table table-bordered bs-table right" AutoGenerateColumns="false" HeaderStyle-BackColor="#009900">
                <Columns>
                    <asp:TemplateField HeaderText="Producto">
                        <ItemTemplate>
                            <asp:Label ID="lbl_idGolosinaCarrito" Visible="false" Text='<%# Eval("idGolosina") %>' runat="server"></asp:Label>
                            <asp:Label ID="lbl_golosinaCarrito" runat="server" Text='<%# Eval("nombre") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Cantidad">
                        <ItemTemplate>
                            <asp:Label ID="lbl_CantidadCarrito" Text='<%# Eval("cantidad") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Subtotal">
                        <ItemTemplate>
                            <asp:Label ID="lbl_signo2Carrito" Text="$" runat="server"></asp:Label>
                            <asp:Label ID="lbl_subtotalCarrito" Text='<%# Eval("subtotal") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>

                            <asp:Button ID="btnQuitar" Text="Quitar" runat="server" OnClick="btnQuitar_Click" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>




            <br />
        </div>
    </div>

    <asp:Button ID="btn_generarPedido" Text="Generar Pedido" CssClass="btn btn-danger center-block" runat="server" OnClick="btn_generarPedido_Click" />



</asp:Content>

