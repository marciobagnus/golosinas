<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TransaccionPromocion.aspx.cs" Inherits="TransaccionPromocion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" runat="Server">
    <div class="row">
        <div class="col-md-12">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <h4>Promocion</h4>
                </div>
                <div class="panel-body">

                    <div class="form-group">
                        <label for="txtNombre" class="col-md-6 control-label">
                            Nombre de la Promo:
                        </label>
                        <div class="col-md-6">
                            <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>


                    <div class="form-group">
                        <label for="txtFechaD" class="col-md-6 control-label">
                            Fecha Desde:
                        </label>
                        <div class="col-md-6">
                            <asp:TextBox ID="txtFechaD" CssClass="form-control" runat="server" Enabled="false"></asp:TextBox>
                        </div>
                    </div>


                    <div class="form-group">
                        <label for="txtFechaH" class="col-md-6 control-label">
                            Fecha Hasta:
                        </label>
                        <div class="col-md-6">
                            <asp:TextBox ID="txtFechaH" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>


                    <div class="form-group">
                        <label for="ddlEmpleados" class="col-md-6 control-label">
                            Empleado:</label>
                        <div class="col-md-6">
                            <asp:DropDownList ID="ddlEmpleados" CssClass="form-control" runat="server" AppendDataBoundItems="true">
                                <asp:ListItem Value="0">Seleccione..</asp:ListItem>
                            </asp:DropDownList>

                        </div>
                    </div>

                    <div class="form-group">
                        <label for="txtPorcentaje" class="col-md-6 control-label">
                            Porcentaje Descuento:
                        </label>
                        <div class="col-md-6">
                            <asp:TextBox ID="txtPorcentaje" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>


                </div>

                <div class="panel panel-info">
                    <div class="panel-heading small">
                        <h4>Golosinas</h4>
                    </div>
                    <div class="panel-body">

                        <div class="form-group">
                            <label for="ddlGolosinas" class="col-md-6 control-label">
                                Golosina:</label>
                            <div class="col-md-6">
                                <asp:DropDownList ID="ddlGolosinas" CssClass="form-control" runat="server" AppendDataBoundItems="true"
                                    AutoPostBack="True" OnSelectedIndexChanged="ddlGolosinas_SelectedIndexChanged">
                                    <asp:ListItem Value="0">Seleccione..</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="txtPrecio" class="col-md-6 control-label">
                                Precio:</label>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtPrecio" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="txtCantidad" class="col-md-6 control-label">
                                Cantidad:</label>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtCantidad" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>


                        <div class="btn-group-lg text-center col-md-12">
                            <h3>
                                <asp:Label ID="lblYaIngresado" class="label label-info" runat="server"></asp:Label>
                            </h3>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="btn-group-lg text-center col-md-12">
            <asp:Button ID="btnAgregar" runat="server" class="btn btn-success" Text="Agregar" OnClick="btnAgregar_Click" />
            <h3>
                <asp:Label ID="Label1" class="label label-warning" runat="server"></asp:Label>
            </h3>
        </div>
        <div class="col-md-12">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <h4>Detalle de Promocion
                    </h4>
                </div>
                <div class="panel-body">
                    <asp:GridView ID="gvPromocion" runat="server" CssClass="table table-hover table-striped"
                        GridLines="None" AutoGenerateColumns="False" OnRowDataBound="gvPromocion_RowDataBound" ShowFooter="True" OnSelectedIndexChanged="gvPromocion_SelectedIndexChanged">
                        <Columns>
                            <asp:CommandField SelectText="Eliminar" ShowSelectButton="True" />
                            <asp:BoundField DataField="idGolosina" HeaderText="Codigo" />
                            <asp:BoundField DataField="nombre" HeaderText="Descripcion" />
                            <asp:BoundField DataField="cantidad" HeaderText="Cantidad" />
                            <asp:BoundField DataField="precioVenta" HeaderText="Precio Unitario" DataFormatString="{0:0.00}" />
                            <asp:BoundField DataField="totalParcial" HeaderText="Total Unitario" DataFormatString="{0:0.00}" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>


            <div class="panel panel-info">
                <div class="panel-body">

                    <div class="form-group">
                        <label for="txtSubtotal" class="col-md-6 control-label">
                            Subtotal:</label>
                        <div class="col-md-6">
                            <asp:TextBox ID="txtSubtotal" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="txtDescuento" class="col-md-6 control-label">
                            Descuento:</label>
                        <div class="col-md-6">
                            <asp:TextBox ID="txtDescuento" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="txtTotal" class="col-md-6 control-label">
                            Total:</label>
                        <div class="col-md-6">
                            <asp:TextBox ID="txtTotal" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>

                </div>
            </div>



            <div class="btn-group-lg text-center">
                <asp:Button ID="btnRegistrar" runat="server" class="btn btn-success" Text="Registrar"
                    ValidationGroup="Registrar" OnClick="btnRegistrar_Click" />
                <asp:Button ID="btnCancelar" runat="server" class="btn btn-danger" Text="Cancelar"
                    OnClientClick="return window.confirm('¿Desea cancelar el registro?');" OnClick="btnCancelar_Click" />
            </div>
            <div class="btn-group-lg text-center">
                <h3>
                    <asp:Label ID="lblMensajeExito" class="label label-success" runat="server"></asp:Label></h3>
                <h3>
                    <asp:Label ID="lblMensajeError" class="label label-danger" runat="server"></asp:Label></h3>
                <h3>
                    <asp:Label ID="lblSinProductos" class="label label-warning" runat="server"></asp:Label></h3>
            </div>
        </div>
    </div>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--   <script type="text/javascript">
        $(document).ready(function () {
            $('[id$=txtFechaH]').datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: "dd-mm-yy",
                showAnim: 'slideDown'
            });
        });
    </script>--%>

    <script>
        $.datepicker.regional['es'] = {
            closeText: 'Cerrar',
            prevText: '<Ant',
            nextText: 'Sig>',
            currentText: 'Hoy',
            monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
            monthNamesShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun', 'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'],
            dayNames: ['Domingo', 'Lunes', 'Martes', 'Miércoles', 'Jueves', 'Viernes', 'Sábado'],
            dayNamesShort: ['Dom', 'Lun', 'Mar', 'Mié', 'Juv', 'Vie', 'Sáb'],
            dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'Sá'],
            weekHeader: 'Sm',
            dateFormat: 'dd/mm/yy',
            firstDay: 1,
            isRTL: false,
            showMonthAfterYear: false,
            yearSuffix: ''
        };
        $.datepicker.setDefaults($.datepicker.regional['es']);
        $(function () {
            $('[id$=txtFechaH]').datepicker();
        });
    </script>

</asp:Content>

