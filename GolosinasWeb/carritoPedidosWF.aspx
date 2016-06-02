<%@ Page Title="" Language="C#" MasterPageFile="~/MasterCarrito.master" AutoEventWireup="true" CodeFile="carritoPedidosWF.aspx.cs" Inherits="Pedidos" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceCabecera" runat="Server">
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlacePrincipal" runat="Server">


    <div class="col-lg-2"></div>
    <div class="panel panel-default center-block col-lg-8">
        <h1>Listado Golosinas para Pedido</h1>
        <br />
        <br />



        <asp:ScriptManager ID="sm" runat="server"></asp:ScriptManager>

        <asp:UpdatePanel ID="up" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:GridView ID="grillaGolosinas" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered bs-table" HeaderStyle-BackColor="#cc6600">

                    <Columns>
                        <asp:TemplateField HeaderText="Producto">
                            <ItemTemplate>
                                <asp:Label ID="lbl_Golosina" runat="server" Text='<%# Eval("nombre") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Cantidad">
                            <ItemTemplate>
                                <asp:Button ID="btnPlus" runat="server" Width="25" Text="+" OnClick="btnPlus_Click"></asp:Button>
                                &nbsp;
                                <asp:Label ID="lbl_Cantidad" runat="server" Text="0"></asp:Label>
                                &nbsp;
                        <asp:Button ID="btnMinus" runat="server" Width="25" Text="-" OnClick="btnMinus_Click"></asp:Button>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Precio Unitario">
                            <ItemTemplate>
                                <asp:Label ID="lbl_signo" Text="$" runat="server"></asp:Label>
                                <asp:Label ID="lbl_precioUnitario" runat="server" Text="0"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Precio">
                            <ItemTemplate>
                                <asp:Label ID="lbl_signo" Text="$" runat="server"></asp:Label>
                                <asp:Label ID="lbl_subtotal" Text="0" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btn_agregarAlCarrito" runat="server" Text="Agregar al Carrito" OnClick="btn_agregarAlCarrito_Click"></asp:Button>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="grillaGolosinas" />
            </Triggers>
        </asp:UpdatePanel>

        <div class="text-right">
            <asp:Label Text="Total: $" runat="server"></asp:Label>
            <asp:Label ID="lbl_precioTotal" Text="0" runat="server"></asp:Label>
            <span></span>
        </div>


        <%--   <%-- <asp:GridView ID="grillaGolosinas" CssClass="table table-bordered bs-table" HeaderStyle-BackColor="#cc6600" AutoGenerateColumns="false" runat="server" OnSelectedIndexChanged="grillaGolosinas_SelectedIndexChanged">
          <Columns>
                <asp:BoundField HeaderText="ID" DataField="idProvincia" />
                <asp:BoundField HeaderText="Provincia" DataField="nombre" />

                <asp:TemplateField HeaderText="Cantidad">
                    <ItemTemplate>
                        <asp:TextBox ID="txt_cantidad" Text='<%# Bind("cantidad") %>' Width="20px" CssClass="center" runat="server"></asp:TextBox>
                        <asp:Button ID="btn_cantidad" OnClick="btn_agregar_Click" Text="+" CssClass="center" runat="server"></asp:Button>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:ButtonField Text="Agregar" />

            </Columns>


            <HeaderStyle BackColor="#CC6600"></HeaderStyle>


        </asp:GridView>--%>
        <br />
    </div>
    <div class="col-lg-2"></div>
</asp:Content>

