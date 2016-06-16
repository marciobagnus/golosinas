<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="true" CodeFile="GolosinasWF.aspx.cs" Inherits="GolosinasWF" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" runat="Server">
    <script type="text/javascript" src="../js/jquery-3.0.0.min.js"></script>
    <link href="../css/jquery-uii.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            $("[id*=btnEliminar]").removeAttr("onclick");
            $("#dialog").dialog({
                modal: true,
                autoOpen: false,
                title: "Confirmación",
                width: 350,
                height: 180,
                buttons: [
            {
                id: "Yes",
                text: "Si",
                click: function () {
                    $("[id*=btnEliminar]").attr("rel", "delete");
                    $("[id*=btnEliminar]").click();
                }
            },
            {
                id: "No",
                text: "No",
                click: function () {
                    $(this).dialog('close');
                }
            }
                ]
            });
            $("[id*=btnEliminar]").click(function () {
                if ($(this).attr("rel") != "delete") {
                    $('#dialog').dialog('open');
                    return false;
                } else {
                    __doPostBack(this.name, '');
                }
            });
        });
    </script>
    <div class="row">
        <div class="col-md-11">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <h4>Golosina</h4>
                </div>
                <div class="panel-body">

                    <div class="form-group">
                        <label for="txtNombre">Nombre</label>
                        <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" title="Ingrese nombre de golosina" MaxLength="50"></asp:TextBox>
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
                            ValidationGroup="A"
                            CssClass="alert-danger"
                            Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label for="txtPrecioC">Precio de Compra</label>
                        <asp:TextBox runat="server" ID="txtPrecioC" CssClass="form-control" placeholder="Ingrese precio de compra" MaxLength="50"></asp:TextBox>
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
                        <asp:RegularExpressionValidator ID="revPrecioC"
                            runat="server" ControlToValidate="txtPrecioC"
                            CssClass="alert-danger" Display="Dynamic" ErrorMessage="Ingrese Solo numeros"
                            ValidationExpression="[0-9]*\,?[0-9]*">
                        </asp:RegularExpressionValidator>
                    </div>
                    <div class="form-group">
                        <label for="txtPrecioV">Precio de Venta</label>
                        <asp:TextBox runat="server" ID="txtPrecioV" CssClass="form-control" placeholder="Ingrese precio de venta" MaxLength="50"></asp:TextBox>
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
                        <asp:RegularExpressionValidator ID="revPrecioV"
                            runat="server" ControlToValidate="txtPrecioV"
                            CssClass="alert-danger" Display="Dynamic" ErrorMessage="Ingrese Solo numeros"
                            ValidationExpression="[0-9]*\,?[0-9]*">
                        </asp:RegularExpressionValidator>
                        <asp:CompareValidator ID="cvPrecioV" runat="server" ErrorMessage="El precio de Venta debe ser mayor al de Compra" ControlToCompare="txtPrecioC" ControlToValidate="txtPrecioV" Operator="GreaterThan" Type="Double" ValidateRequestMode="Enabled" ValidationGroup="A"></asp:CompareValidator>

                    </div>
                    <div class="form-group">
                        <label for="txtStockA">Stock Actual</label>
                        <asp:TextBox runat="server" ID="txtStockA" CssClass="form-control" placeholder="Ingrese stock actual" MaxLength="50"></asp:TextBox>
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
                        <asp:RegularExpressionValidator ID="revStockA"
                            runat="server" ControlToValidate="txtStockA"
                            CssClass="alert-danger" Display="Dynamic" ErrorMessage="Ingrese Solo numeros"
                            ValidationExpression="[0-9]{1,9}(\[0-9]{0,2})?$">
                        </asp:RegularExpressionValidator>
                    </div>
                    <div class="form-group">
                        <label for="txtStockM">Stock Mínimo</label>
                        <asp:TextBox runat="server" ID="txtStockM" CssClass="form-control" placeholder="Ingrese stock minimo" MaxLength="50"></asp:TextBox>
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
                        <asp:RegularExpressionValidator ID="revStockM"
                            runat="server" ControlToValidate="txtStockM"
                            CssClass="alert-danger" Display="Dynamic" ErrorMessage="Ingrese Solo numeros"
                            ValidationExpression="[0-9]{1,9}(\[0-9]{0,2})?$">
                        </asp:RegularExpressionValidator>

                    </div>
                    <div class="checkbox">
                        <label>
                            <asp:CheckBox ID="chkCeliaco" Text="Apto para celíacos" runat="server" />
                        </label>
                    </div>
                    <div class="btn-group-lg text-center">
                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" class="btn btn-default" ValidationGroup="A" OnClick="btnGuardar_Click" />
                        <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" class="btn btn-default" ValidationGroup="B" OnClick="btnNuevo_Click" />
                        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" class="btn btn-warning" CausesValidation="False" OnClick="btnEliminar_Click" UseSubmitBehavior="false" />
                    </div>
                    <div id="dialog" style="display: none" align="center">
                        ¿Desea eliminar la golosina?
                    </div>
                    <div class="form-group">
                        <label for="txtGolosinaABuscar">Golosina a buscar:</label>
                        <asp:TextBox runat="server" ID="txtGolosinaABuscar" CssClass="form-control" placeholder="" MaxLength="50"></asp:TextBox>
                        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" class="btn btn-default" OnClick="btnBuscar_Click" CausesValidation="False" />
                    </div>
                </div>
            </div>
            <div class="btn-group-lg text-center">
                <h3>
                    <asp:Label ID="lblMensajeExito" class="label label-success" runat="server"></asp:Label></h3>
                <h3>
                    <asp:Label ID="lblMensajeError" class="label label-danger" runat="server"></asp:Label></h3>
            </div>
        </div>        
    </div>
    <div class="row">
        <div class="col-md-11">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <h4>Listado de Golosinas</h4>
                </div>
                <div class="panel-body" id="divGrilla" runat="server">
                    <asp:GridView ID="grdGolosinas" AutoGenerateColumns="False" runat="server" CssClass="table table-hover table-striped"
                        DataKeyNames="idGolosina" OnSelectedIndexChanged="grdGolosinas_SelectedIndexChanged"
                        GridLines="None" AllowPaging="True" PageSize="5" Width="438px" OnPageIndexChanging="grdGolosinas_PageIndexChanging">
                        <Columns>
                            <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
                            <asp:BoundField DataField="nombre" HeaderText="Nombre Golosina" />
                            <asp:BoundField DataField="precioCompra" HeaderText="Precio Cpra" DataFormatString="${0:0.00}" />
                            <asp:BoundField DataField="precioVenta" HeaderText="Precio Vta" DataFormatString="${0:0.00}" />
                            <asp:BoundField DataField="stockActual" HeaderText="Stock Actual" />
                            <asp:BoundField DataField="stockMinimo" HeaderText="Stock Minimo" />

                            <asp:TemplateField HeaderText="¿Pedir?">
                                <ItemTemplate><%# (Boolean.Parse(Eval("listoParaPedir").ToString())) ? "Si" : "No" %></ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Celiacos">
                                <ItemTemplate><%# (Boolean.Parse(Eval("esAptoCeliaco").ToString())) ? "Si" : "No" %></ItemTemplate>
                            </asp:TemplateField>

                        </Columns>

                    </asp:GridView>

                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>

