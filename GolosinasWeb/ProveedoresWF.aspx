<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ProveedoresWF.aspx.cs" Inherits="GolosinasWF" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <title>Proovedores</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" runat="Server">
 
    <h1 class="text-center jumbotron">Proveedores</h1>
 
    <div class="panel panel-primary col-lg-11">
        <div>
            <br />
            <label>Nombre:</label>
            <asp:TextBox ID="txt_nombre" placeholder="Ingrese nombre del proovedor" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator
                ID="rfv_nombre"
                ErrorMessage="Falta ingresar Nombre del Proveedor"
                Text="*"
                ControlToValidate="txt_nombre"
                ValidationGroup="A"
                runat="server"
                CssClass="alert-danger">

            </asp:RequiredFieldValidator>
        </div>
        <br />

        <div>
            <label>Razon Social:</label>
            <asp:TextBox ID="txt_razonSocial" placeholder="Ingrese la razon social del proovedor" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator
                ID="rfv_razonSocial"
                ErrorMessage="Falta ingresar Razon Social del Proveedor"
                Text="*"
                ControlToValidate="txt_razonSocial"
                ValidationGroup="A"
                runat="server"
                CssClass="alert-danger">
            </asp:RequiredFieldValidator>

            <br />
        </div>
        <div>
            <label>CUIT:</label>
            <asp:TextBox ID="txt_cuit" placeholder="Ingrese cuit el proovedor" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator
                ID="rfv_cuit"
                ErrorMessage="Falta ingresar CUIT del Proveedor"
                Text="*"
                ControlToValidate="txt_cuit"
                ValidationGroup="A"
                runat="server"
                CssClass="alert-danger">
            </asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revcuit"
                runat="server" ControlToValidate="txt_cuit"
                CssClass="alert-danger" Display="Dynamic" ErrorMessage="Ingrese Solo numeros"
                ValidationExpression="[0-9]*\,?[0-9]*">
            </asp:RegularExpressionValidator>


            <br />
        </div>
        <div>
            <label>Fecha Alta:</label>
            <asp:TextBox ID="txt_fechaAlta" placeholder="Ingrese fecha de alta del proovedor" CssClass="form-control " runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator
                ID="rfv_fechaAlta"
                ErrorMessage="Falta ingresar fechaAlta del Proveedor"
                Text="*"
                ControlToValidate="txt_nombre"
                ValidationGroup="A"
                runat="server"
                CssClass="alert-danger">
            </asp:RequiredFieldValidator>
            <asp:RangeValidator ID="rv_fechaAlta"
                ControlToValidate="txt_fechaAlta"
                runat="server" Type="Date"
                MinimumValue="01/01/1900"
                MaximumValue="01/01/2900"
                ErrorMessage="La fecha de alta esta fuera de rango (01/01/1900-01/01/2900)"
                CssClass="alert-danger" Display="Dynamic"
                Text="*" ValidationGroup="A">
            </asp:RangeValidator>
            <br />
        </div>
        <div>
            <label>Domicilio:</label>
            <asp:TextBox ID="txt_domicilio" placeholder="Ingrese domicilio del proovedor" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator
                ID="rfv_domicilio"
                ErrorMessage="Falta ingresar Nombre del Proveedor"
                Text="*"
                ControlToValidate="txt_nombre"
                ValidationGroup="A"
                runat="server"
                CssClass="alert-danger">
            </asp:RequiredFieldValidator>

            <br />
        </div>
        <div>
            <label>Provincia:</label>
            <asp:DropDownList ID="ddl_provincia" AppendDataBoundItems="true" CssClass="form-control" runat="server">
                <asp:ListItem Value="0">Seleccione..</asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:RequiredFieldValidator
                ID="rv_Provincia"
                runat="server" ControlToValidate="ddl_provincia"
                ErrorMessage="Seleccione una Provincia" InitialValue="0"
                ValidationGroup="A"
                CssClass="alert-danger"
                Display="Dynamic"></asp:RequiredFieldValidator>
        </div>
        <asp:CheckBox ID="chk_esNacional" Text=" Es Nacional" runat="server" />
        <br />
        <div>
            <asp:ValidationSummary runat="server" ValidationGroup="A" />

        </div>
        <asp:Button ID="btn_guardar" runat="server" CssClass="btn btn-primary" Text="Guardar" OnClick="btn_guardar_Click" ValidationGroup="A" />
        <asp:Button ID="btnNuevo" runat="server" Text="Limpiar" class="btn btn-default" OnClick="btnNuevo_Click" />
        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" class="btn btn-warning " OnClick="btnEliminar_Click" />
        <br />
        <br />
    </div>
    <br />
    <br />

    <div class="form-group">
        <label>Buscador por Razon Social:</label>
        <asp:TextBox runat="server" ID="txt_ProveedorBuscar" CssClass="form-control" placeholder="" MaxLength="50"></asp:TextBox>
        <asp:RequiredFieldValidator
            ID="RequiredFieldValidator1"
            ErrorMessage="Ingrese razon social a buscar"
            Text="*"
            ControlToValidate="txt_ProveedorBuscar"
            ValidationGroup="B"
            runat="server"
            CssClass="alert-danger">
        </asp:RequiredFieldValidator>
        <div>
            <asp:ValidationSummary runat="server" ValidationGroup="B" />

        </div>
        <asp:Button ID="btn_Buscar" runat="server" Text="Buscar" class="btn btn-default" OnClick="btn_Buscar_Click" ValidationGroup="B"  />

    </div>


    <div class="panel panel-primary">
        <div class="panel-heading">
            <h4>Listado de Proveedores</h4>
        </div>
        <div class="panel-body" id="divGrilla" runat="server">
            <asp:GridView ID="grid_proveedores" CssClass="table table-hover table-striped" AutoGenerateColumns="false" runat="server"
                OnSelectedIndexChanged="grid_proveedores_SelectedIndexChanged" DataKeyNames="idProveedor"
                GridLines="None" AllowPaging="True" PageSize="5" Width="438px" OnPageIndexChanging="grid_proveedores_PageIndexChanging">
                <Columns>
                    <asp:CommandField SelectText="Seleccionar" ItemStyle-CssClass="col-lg-3 text-center" ShowSelectButton="True" />
                    <asp:BoundField DataField="razonSocial" ItemStyle-CssClass="col-lg-3 text-center" HeaderText="Razon Social" />
                    <asp:BoundField DataField="cuit" ItemStyle-CssClass="col-lg-3 text-center" HeaderText="CUIT" />

                </Columns>


            </asp:GridView>
        </div>
    </div>

    <label></label>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script>
        $(function () {
            $("#txt_fechaAlta").datepicker({ dateFormat: 'dd/mm/yy' }).val();
        });
    </script>
</asp:Content>

