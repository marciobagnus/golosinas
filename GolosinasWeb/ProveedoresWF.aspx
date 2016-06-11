<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ProveedoresWF.aspx.cs" Inherits="GolosinasWF" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <title>Proovedores</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" runat="Server">
    <br />
    <br />
    <br />
    <h1 class="text-center">Proveedores</h1>
    <br />
    <br />
    <label>Nombre:</label>
    <asp:TextBox ID="txt_nombre" placeholder="Ingrese nombre del proovedor" CssClass="form-control" runat="server"></asp:TextBox>
    <br />
    <label>Razon Social:</label>
    <asp:TextBox ID="txt_razonSocial" placeholder="Ingrese la razon social del proovedor" CssClass="form-control" runat="server"></asp:TextBox>
    <br />
    <label>CUIT:</label>
    <asp:TextBox ID="txt_cuit" placeholder="Ingrese cuit el proovedor" CssClass="form-control" runat="server"></asp:TextBox>
    <br />
    <label>Fecha Alta:</label>
    <asp:TextBox ID="txt_fechaAlta" placeholder="Ingrese fecha de alta del proovedor" CssClass="form-control " runat="server"></asp:TextBox>
    <br />
    <label>Domicilio:</label>
    <asp:TextBox ID="txt_domicilio" placeholder="Ingrese domicilio del proovedor" CssClass="form-control" runat="server"></asp:TextBox>
    <br />
    <label>Provincia:</label>
    <asp:DropDownList ID="cmb_provincia" placeholder="Ingrese la provincia del proovedor" CssClass="form-control" runat="server"></asp:DropDownList>
    <br />
    <asp:CheckBox ID="chk_esNacional" Text=" Es Nacional" runat="server" />
    <br />
    <asp:Button ID="btn_guardar" runat="server" CssClass="btn btn-primary" Text="Guardar" OnClick="btn_guardar_Click" />
    <asp:Button ID="btnNuevo" runat="server" Text="Limpiar" class="btn btn-default" OnClick="btnNuevo_Click" />
    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" class="btn btn-warning " OnClick="btnEliminar_Click" />

    <br />
    <br />
    <asp:GridView ID="grid_proveedores" CssClass="table table-hover table-striped" AutoGenerateColumns="false" OnSelectedIndexChanged="grid_proveedores_SelectedIndexChanged" runat="server">
        <Columns>
            <asp:CommandField SelectText="Seleccionar" ItemStyle-CssClass="col-lg-3 text-center" ShowSelectButton="True" />
            <asp:BoundField DataField="razonSocial" ItemStyle-CssClass="col-lg-3 text-center" HeaderText="Razon Social" />
            <asp:BoundField DataField="cuit" ItemStyle-CssClass="col-lg-3 text-center" HeaderText="CUIT" />

        </Columns>


    </asp:GridView>


    <label></label>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script>
        $(function () {
            $("#txt_fechaAlta").datepicker({ dateFormat: 'dd/mm/yy' }).val();
        });
    </script>
</asp:Content>

