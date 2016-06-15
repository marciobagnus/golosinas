<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="GolosinaQueryWF.aspx.cs" Inherits="GolosinaQueryWF" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" runat="Server">

    <label id="lblTipo">Tipo Golosina</label>
     <asp:DropDownList ID="ddlTipo" runat="server" AppendDataBoundItems="true">
            <asp:ListItem Value="null">Seleccione..</asp:ListItem>
        </asp:DropDownList>
    
    <br />
    <label id="lblCeliaco">Celiacos</label>
    <asp:DropDownList ID="ddlCeliaco" runat="server" AppendDataBoundItems="true">
        <asp:ListItem Value="null">Todos</asp:ListItem>
        <asp:ListItem Value="true">Si</asp:ListItem>
        <asp:ListItem Value="false">No</asp:ListItem>
    </asp:DropDownList>
      
    
    <br />
    <label id="lblPrecioCDesde">Precio Compra Desde</label>
    <asp:TextBox ID="txtPrecioCDesde" runat="server"></asp:TextBox>
    <br />
    <label id="lblPrecioCHasta">Precio Compra Hasta</label>
    <asp:TextBox ID="txtPrecioCHasta" runat="server"></asp:TextBox>
    <br />
    <asp:Button ID="btnBuscar" Text="Buscar" runat="server" OnClick="btnBuscar_Click" />
    <br />
    <asp:GridView ID="gvInforme" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="nombreTipo" HeaderText="Tipo" />
            <asp:TemplateField HeaderText="Celiacos">
                <ItemTemplate><%# (Boolean.Parse(Eval("esAptoCeliaco").ToString())) ? "Si" : "No" %></ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="precioCompra" HeaderText="Precio Cpra" />
            <asp:BoundField DataField="precioVenta" HeaderText="Precio Vta" />
            <asp:BoundField DataField="stockActual" HeaderText="Stock Actual" />
            <asp:BoundField DataField="stockMinimo" HeaderText="StockMinimo" />
            <asp:TemplateField HeaderText="¿Pedir?">
                <ItemTemplate><%# (Boolean.Parse(Eval("listoParaPedir").ToString())) ? "Si" : "No" %></ItemTemplate>
            </asp:TemplateField>            

        </Columns>

    </asp:GridView>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>

