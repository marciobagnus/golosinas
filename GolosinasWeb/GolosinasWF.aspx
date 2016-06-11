<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master"
     AutoEventWireup="true" CodeFile="GolosinasWF.aspx.cs" Inherits="GolosinasWF" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" runat="Server">
    <br />
    <br />
    <br />
    <h1 class="text-center">Golosinas</h1>
    <br />
    <br />
    <div class="form-group">
        <label for="txtNombre">Nombre</label>
        <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" placeholder="Ingrese nombre de golosina"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvNombre"
            runat="server"
            ControlToValidate="txtNombre"
            ErrorMessage="Ingrese Nombre"
            CssClass="alert-danger" Display="Dynamic"
            Text="*" ValidationGroup="A" />
        <asp:RegularExpressionValidator ID="rvNombre"
             runat="server" ErrorMessage="Ingrese un Nombre valido"
             ControlToValidate="txtNombre" ValidationExpression="^[a-zA-Z ]*$"
             CssClass="alert-danger"
             Display="Dynamic"></asp:RegularExpressionValidator>
    </div>
    <div class="form-group">
        <label for="ddlTipoG">Tipo de golosina</label>
        <asp:DropDownList ID="ddlTipoG" CssClass="form-control" runat="server" AppendDataBoundItems="true">
            <asp:ListItem Value="0">Seleccione..</asp:ListItem>
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="rfvTipoG"
            runat="server" ControlToValidate="ddlTipoG"
            ErrorMessage="Seleccione un Tipo de Golosina" InitialValue="0"
            CssClass="alert-danger"
            Display="Dynamic"></asp:RequiredFieldValidator>
    </div>
    <div class="form-group">
        <label for="txtPrecioC">Precio de Compra</label>
        <asp:TextBox runat="server" ID="txtPrecioC" CssClass="form-control" placeholder="Ingrese precio de compra"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvPrecioC"
            ControlToValidate="txtPrecioC"
            runat="server"
            ErrorMessage="Ingrese el Precio de Compra"
            CssClass="alert-danger" Display="Dynamic"
            Text="*"
            ValidationGroup="A"></asp:RequiredFieldValidator>
        <asp:RangeValidator ID="rvPrecioC"
            ControlToValidate="txtPrecioC"
            runat="server" Type="Double"
            CssClass="alert-danger" Display="Dynamic"
            MaximumValue="50000"
            MinimumValue="1"
            ErrorMessage="Precio de Compra debe estar entre 1 y 50000"
            Text="*" ValidationGroup="A">
        </asp:RangeValidator>
    </div>

    <div class="form-group">
        <label for="txtPrecioV">Precio de Venta</label>
        <asp:TextBox runat="server" ID="txtPrecioV" CssClass="form-control" placeholder="Ingrese precio de venta"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvPrecioV"
            ControlToValidate="txtPrecioV"
            runat="server"
            CssClass="alert-danger" Display="Dynamic"
            ErrorMessage="Ingrese el Precio de venta"
            Text="*"
            ValidationGroup="A"></asp:RequiredFieldValidator>
        <asp:RangeValidator ID="rvPrecioV"
            ControlToValidate="txtPrecioV"
            runat="server" Type="Double"
            MaximumValue="70000"
            MinimumValue="1"
            ErrorMessage="Precio de venta debe estar entre 1 y 70000"
            CssClass="alert-danger" Display="Dynamic"
            Text="*" ValidationGroup="A">
        </asp:RangeValidator>
    </div>

    <div class="form-group">
        <label for="txtStockA">Stock Actual</label>
        <asp:TextBox runat="server" ID="txtStockA" CssClass="form-control" placeholder="Ingrese stock actual"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvStockA"
            ControlToValidate="txtStockA"
            runat="server"
            CssClass="alert-danger" Display="Dynamic"
            ErrorMessage="Ingrese el Stock Actual"
            Text="*"
            ValidationGroup="A"></asp:RequiredFieldValidator>
        <asp:RangeValidator ID="rvStockA"
            ControlToValidate="txtStockA"
            runat="server" Type="Integer"
            MaximumValue="10000"
            MinimumValue="1"
            ErrorMessage="Stock actual debe estar entre 1 y 10000"
            CssClass="alert-danger" Display="Dynamic"
            Text="*" ValidationGroup="A">
        </asp:RangeValidator>
    </div>
    <div class="form-group">
        <label for="txtStockM">Stock Mínimo</label>
        <asp:TextBox runat="server" ID="txtStockM" CssClass="form-control" placeholder="Ingrese stock minimo"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
            ControlToValidate="txtStockM"
            runat="server"
            CssClass="alert-danger" Display="Dynamic"
            ErrorMessage="Ingrese el Stock minimo"
            Text="*"
            ValidationGroup="A"></asp:RequiredFieldValidator>
        <asp:RangeValidator ID="rvStockM"
            ControlToValidate="txtStockm"
            runat="server" Type="Integer"
            MaximumValue="10000"
            MinimumValue="1"
            ErrorMessage="Stock minimo debe estar entre 1 y 10000"
            CssClass="alert-danger" Display="Dynamic"
            Text="*" ValidationGroup="A">
        </asp:RangeValidator>
    </div>

    <div class="checkbox">
        <label>
            <asp:CheckBox ID="chkCeliaco" Text="Apto para celíacos" runat="server" />
        </label>
    </div>

    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" class="btn btn-default" ValidationGroup="A" OnClick="btnGuardar_Click" />
    <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" class="btn btn-default" ValidationGroup="B" OnClick="btnNuevo_Click" />
    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" class="btn btn-warning" CausesValidation="False" OnClick="btnEliminar_Click" />

    <div class="form-group" id="divGrilla" runat="server">
        <asp:GridView ID="grdGolosinas" AutoGenerateColumns="False" runat="server" CssClass="table table-bordered bs-table" DataKeyNames="idGolosina" OnSelectedIndexChanged="grdGolosinas_SelectedIndexChanged">
            <Columns>
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
                <asp:BoundField DataField="nombre" HeaderText="Nombre Golosina" />
                <asp:BoundField DataField="precioCompra" HeaderText="Precio Cpra" />
                <asp:BoundField DataField="precioVenta" HeaderText="Precio Vta" />
                <asp:BoundField DataField="stockActual" HeaderText="Stock Actual" />
                <asp:BoundField DataField="stockMinimo" HeaderText="StockMinimo" />
                <asp:BoundField DataField="listoParaPedir" HeaderText="Pedir?" />
                <asp:BoundField DataField="esAptoCeliaco" HeaderText="Celiacos" />
            </Columns>
        </asp:GridView>
    </div>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>

