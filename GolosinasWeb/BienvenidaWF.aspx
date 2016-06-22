<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BienvenidaWF.aspx.cs" Inherits="BienvenidaWF" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" runat="Server">
    <div class="panel panel-default ">
        <br />
        <br />
        <div class="col-lg-2"></div>
        <div class="col-lg-8">
            Bienvenido al sistema Usuario:
        <asp:Label ID="lblUsuario" CssClass="text-info" runat="server" />.
    <br />
            Su rol es:
        <asp:Label ID="lblRol" CssClass="text-info" runat="server"></asp:Label>.
        </div>
        <div class="col-lg-2"></div>
        <br />
        <br />
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>

