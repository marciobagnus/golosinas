<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" runat="Server">
    <div class="panel panel-primary row">
        <div class="col-lg-2"></div>
        <div class="col-lg-8">

            <div>
                <br />
                <label>Usuario: </label>
                <asp:TextBox ID="txtUsuario" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvUsuario"
                    runat="server"
                    Text="*"
                    ErrorMessage="Ingrese usuario"
                    ValidationGroup="A"
                    CssClass="alert-danger" Display="Dynamic"
                    ControlToValidate="txtUsuario"></asp:RequiredFieldValidator>
            </div>

            <div>
                <label>Clave: </label>
                <asp:TextBox ID="txtClave" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvClave"
                    runat="server"
                    Text="*"
                    ErrorMessage="Ingrese contraseña"
                    ValidationGroup="A"
                    CssClass="alert-danger" Display="Dynamic"
                    ControlToValidate="txtClave"></asp:RequiredFieldValidator>
                <br />
            </div>

            <div>
                <asp:ValidationSummary ValidationGroup="A" runat="server" />
                <asp:Label ID="txtAlerta" runat="server" CssClass="alert-danger"></asp:Label>
            </div>
            <asp:Button ID="btnLogin" runat="Server" Text="Iniciar sesión" CssClass="btn btn-success" OnClick="btnLogin_Click" ValidationGroup="A" />
            <br />
        </div>
        <br />
        <div class="col-lg-2"></div>
        <br />
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>

