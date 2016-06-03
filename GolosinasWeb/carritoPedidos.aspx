<%@ Page Title="" Language="C#" MasterPageFile="~/MasterCarrito.master" AutoEventWireup="true" CodeFile="carritoPedidos.aspx.cs" Inherits="carritoPedidos" %>

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
                        <asp:TemplateField HeaderText="Precio Unitario">
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
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="grillaGolosinas" />
            </Triggers>
        </asp:UpdatePanel>
        

        <div class ="">
            <asp:Label runat="server" Text="Precio Total: "></asp:Label>
          
              <asp:Label runat="server" ID="lbl_precioTotal" Text="0"></asp:Label>
        
        </div>

        <div>
            <asp:GridView ID="grillaCarrito" runat="server" CssClass="table table-bordered bs-table" HeaderStyle-BackColor="#cc6600">
                <Columns>
                     <asp:TemplateField HeaderText="Producto">

                     <ItemTemplate>
                                <asp:Label ID="lbl_producto" runat="server" Text=""></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Cantidad">
                            <ItemTemplate>
                                <asp:Button ID="btnMinus" runat="server" Text="-" OnClick="btnMinus_Click"></asp:Button>
                                <asp:Label ID="lbl_Cantidad" runat="server" Text="0"></asp:Label>
                                <asp:Button ID="btnPlus" runat="server" Text="+" OnClick="btnPlus_Click"></asp:Button>

                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Precio Unitario">
                            <ItemTemplate>
                                <asp:Label ID="lbl_signo" Text="$" runat="server"></asp:Label>
                                <asp:Label ID="lbl_precioUnitario" runat="server" Text=""></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>



                </Columns>
            </asp:GridView>

        </div>


    
        <br /> 
    </div>
    <div class="col-lg-2"></div>

</asp:Content>

