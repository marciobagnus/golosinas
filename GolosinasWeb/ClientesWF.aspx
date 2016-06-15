<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ClientesWF.aspx.cs" Inherits="ClientesWF" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <title>Clientes</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" runat="Server">
    <br />
    <br />
    <br />
    <h1 class="text-center">Clientes</h1>
    <br />
    <br />
    <label>Nombre:</label>
    <asp:TextBox ID="txtNombre" placeholder="Ingrese nombre del cliente" CssClass="form-control" runat="server"></asp:TextBox>
      <asp:RequiredFieldValidator ID="rfvNombre"
            runat="server"
            ControlToValidate="txtNombre"
            ErrorMessage="Ingrese Nombre"
            CssClass="alert-danger" Display="Dynamic"
            Text="*" ValidationGroup="A" />
        <asp:RegularExpressionValidator ID="rvNombre"
             runat="server" ErrorMessage="Ingrese un Nombre válido"
             ControlToValidate="txtNombre" ValidationExpression="^[a-zA-Z ]*$"
             CssClass="alert-danger"
             Display="Dynamic"></asp:RegularExpressionValidator>
    <br />
    <label>Apellido:</label>
    <asp:TextBox ID="txtApellido" placeholder="Ingrese apellido del cliente" CssClass="form-control" runat="server"></asp:TextBox>
      <asp:RequiredFieldValidator ID="rfvApellido"
            runat="server"
            ControlToValidate="txtApellido"
            ErrorMessage="Ingrese Apellido"
            CssClass="alert-danger" Display="Dynamic"
            Text="*" ValidationGroup="A" />
        <asp:RegularExpressionValidator ID="rvApellido"
             runat="server" ErrorMessage="Ingrese un Apellido válido"
             ControlToValidate="txtApellido" ValidationExpression="^[a-zA-Z ]*$"
             CssClass="alert-danger"
             Display="Dynamic"></asp:RegularExpressionValidator>
    <br />
    <label for="ddlTipoDoc">Tipo de Documento:</label>
        <asp:DropDownList ID="ddlTipoDoc" CssClass="form-control" runat="server" AppendDataBoundItems="true">
            <asp:ListItem Value="0">Seleccione..</asp:ListItem>
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="rfvTipoDoc"
            runat="server" ControlToValidate="ddlTipoDoc"
            ErrorMessage="Seleccione un Tipo de Documento" InitialValue="0"
            CssClass="alert-danger"
            Display="Dynamic"></asp:RequiredFieldValidator>
    <br />
    <label>Número de Documento:</label>
    <asp:TextBox ID="txtNumDoc" placeholder="Ingrese número de documento del cliente" CssClass="form-control" runat="server"></asp:TextBox>
      <asp:RequiredFieldValidator ID="rfvNumDoc"
            runat="server"
            ControlToValidate="txtNumDoc"
            ErrorMessage="Ingrese Numero de Documento"
            CssClass="alert-danger" Display="Dynamic"
            Text="*" ValidationGroup="A" />
        <asp:RegularExpressionValidator ID="rvNumDoc"
             runat="server" ErrorMessage="Ingrese un Numero válido"
             ControlToValidate="txtNumDoc" ValidationExpression="^[0-9]*"
             CssClass="alert-danger"
             Display="Dynamic"></asp:RegularExpressionValidator>
    <br />
    <label>Fecha de Nacimiento:</label>
    <asp:TextBox ID="txtFechaNacimiento" placeholder="DD/MM/AAAA" CssClass="form-control " runat="server"></asp:TextBox>
     <asp:RequiredFieldValidator ID="rfvFecha"
            runat="server"
            ControlToValidate="txtFechaNacimiento"
            ErrorMessage="Ingrese Fecha de Nacimiento"
            CssClass="alert-danger" Display="Dynamic"
            Text="*" ValidationGroup="A" />
       <%-- <asp:RegularExpressionValidator ID="rvFecha"
             runat="server" ErrorMessage="Ingrese una Fecha válida"
             ControlToValidate="txtNumDoc" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[-/.](0[1-9]|1[012])[-/.](19|20)\d\d$"
             CssClass="alert-danger"
             Display="Dynamic"></asp:RegularExpressionValidator>--%>
    <br />
    <label>Domicilio:</label>
    <asp:TextBox ID="txtDomicilio" placeholder="Ingrese domicilio del cliente" CssClass="form-control" runat="server"></asp:TextBox>
       <asp:RequiredFieldValidator ID="rfvDomicilio"
            runat="server"
            ControlToValidate="txtDomicilio"
            ErrorMessage="Ingrese Domicilio"
            CssClass="alert-danger" Display="Dynamic"
            Text="*" ValidationGroup="A" />
    <br />
    <label>Sexo:</label>
    <asp:RadioButton ID="rdbFemenino" Text=" Femenino" runat="server" AutoPostBack="True" OnCheckedChanged="rdbFemenino_CheckedChanged" /> &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:RadioButton ID="rdbMasculino" Text=" Masculino" runat="server" AutoPostBack="True" OnCheckedChanged="rdbMasculino_CheckedChanged" />
    <br />
    <br />
   <%-- <label>Nombre de Usuario:</label>
    <asp:TextBox ID="txtUsuario" placeholder="Ingrese nombre de usuario" CssClass="form-control" runat="server"></asp:TextBox>
    <br />--%>
    <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-primary" Text="Guardar" OnClick="btn_guardar_Click" ValidationGroup="A"/>
    <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" class="btn btn-default" OnClick="btnNuevo_Click" />
    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" class="btn btn-warning " OnClick="btnEliminar_Click" />

    <br />
    <br />
    <asp:GridView ID="gvClientes" CssClass="table table-hover table-striped" AutoGenerateColumns="false" OnSelectedIndexChanged="grid_clientes_SelectedIndexChanged" runat="server">
        <Columns>
            <asp:CommandField SelectText="Seleccionar" ItemStyle-CssClass="col-lg-3 text-center" ShowSelectButton="True" />
            <asp:BoundField DataField="nombreYApellido" ItemStyle-CssClass="col-lg-3 text-center" HeaderText="Apellido y Nombre" />
            <asp:BoundField DataField="numeroDocumento" ItemStyle-CssClass="col-lg-3 text-center" HeaderText="Nº Documento" />

        </Columns>


    </asp:GridView>

</asp:Content>