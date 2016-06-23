using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Dao;

public partial class TransaccionVenta : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string rol = (string)Session["Rol"];
        bool acceso = false;
        if (rol == "administrador")
        {
            acceso = true;
        }

        if (!acceso) Response.Redirect("Login.aspx");

        if (Session["Usuario"] == string.Empty)
        {
            //Usuario Anónimo
            Response.Redirect("Login.aspx");
        }

        if (!Page.IsPostBack)
        {
            CargarEmpleados();
            CargarClientes();
            CargarTiposFactura();
            CargarFechaHoy();
            CargarGrillaGolosinas();
            CargarGrillaPromociones();
            btnRegistrarVenta.Visible = false;
            Session["ListaDetallesFactura"] = null;
        }
    }

    protected int? ID
    {
        get
        {
            if (ViewState["ID"] != null)
                return (int)ViewState["ID"];
            else
            {
                return null;
            }
        }
        set { ViewState["ID"] = value; }
    }

    private void CargarEmpleados()
    {
        List<EmpleadoEntidad> empleados = EmpleadoDao.ObtenerTodosEmpleados();

        ddlEmpleados.DataSource = null;

        ddlEmpleados.DataTextField = "nombreYApellido";

        ddlEmpleados.DataValueField = "idEmpleado";

        ddlEmpleados.DataSource = empleados;

        ddlEmpleados.SelectedIndex = 0;
        ddlEmpleados.DataBind();
    }

    private void CargarClientes()
    {
        List<ClienteEntidad> clientes = ClienteDao.ObtenerTodosClientes();

        ddlClientes.DataSource = null;

        ddlClientes.DataTextField = "nombreYApellido";

        ddlClientes.DataValueField = "idCliente";

        ddlClientes.DataSource = clientes;

        ddlClientes.SelectedIndex = 0;
        ddlClientes.DataBind();
    }

    private void CargarTiposFactura()
    {
        List<TipoFacturaEntidad> tiposFactura = TipoFacturaDao.ObtenerTodosTiposFactura();

        ddlTipoFac.DataSource = null;

        ddlTipoFac.DataTextField = "descripcion";

        ddlTipoFac.DataValueField = "idTipoFactura";

        ddlTipoFac.DataSource = tiposFactura;

        ddlTipoFac.SelectedIndex = 0;
        ddlTipoFac.DataBind();
    }

    private void CargarFechaHoy()
    {
        DateTime fecha = DateTime.Now;
        lblFecha.Text = fecha.ToShortDateString();
    }

    protected void CargarGrillaGolosinas()
    {
            List<GolosinasEntidad> listaGolosinasCompleta = new List<GolosinasEntidad>();
            listaGolosinasCompleta = GolosinaDao.ObtenerTodos();

            List<DetalleFacturaEntidad> listaGolosinasDetalle = new List<DetalleFacturaEntidad>();

            for (int i = 0; i < listaGolosinasCompleta.Capacity - 1; i++)
            {
            DetalleFacturaEntidad alResumen = new DetalleFacturaEntidad();

            alResumen.idGolosina = listaGolosinasCompleta[i].idGolosina;
            alResumen.cantidad = 0;
            alResumen.nombre = listaGolosinasCompleta[i].nombre;
            alResumen.subtotal = 0;
            alResumen.precioGolosina = double.Parse(listaGolosinasCompleta[i].precioVenta.ToString("#.###"));
            listaGolosinasDetalle.Add(alResumen);
            }
            gvGolosinas.DataSource = listaGolosinasDetalle;
            gvGolosinas.DataBind();
    }

    protected void gvGolosinas_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvGolosinas.PageIndex = e.NewPageIndex;
        CargarGrillaGolosinas();
    }

    protected void CargarGrillaPromociones()
    {
        List<PromocionEntidad> listaPromocionesCompleta = new List<PromocionEntidad>();
        listaPromocionesCompleta = VentaDao.ObtenerTodasPromociones();

        List<DetalleFacturaEntidad> listaPromocionesDetalle = new List<DetalleFacturaEntidad>();

        for (int j = 0; j < listaPromocionesCompleta.Capacity - 2; j++)
        {
            DetalleFacturaEntidad alResumen0 = new DetalleFacturaEntidad();

            alResumen0.idPromocion = listaPromocionesCompleta[j].idPromocion;
            alResumen0.cantidad = 0;
            alResumen0.nombre = listaPromocionesCompleta[j].nombre;
            alResumen0.subtotal = 0;
            alResumen0.precioPromocion = double.Parse(listaPromocionesCompleta[j].total.ToString("#.###"));
            listaPromocionesDetalle.Add(alResumen0);
        }
        gvPromociones.DataSource = listaPromocionesDetalle;
        gvPromociones.DataBind();
    }

    protected void gvPromociones_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvPromociones.PageIndex = e.NewPageIndex;
        CargarGrillaPromociones();
    }

    private void CalculosGolosinas(GridViewRow row, bool isAdd)
    {     
        bool isNumber = false;
        int currentValue = 0;

        Label lblCantidad = row.FindControl("lblCantidad") as Label;
        Label lblSubtotal = row.FindControl("lblSubtotal") as Label;
        Label lblPrecioUnitario = row.FindControl("lblPrecioUnitario") as Label;

        if (lblCantidad != null)
        {
            if (lblCantidad.Text.Trim() != string.Empty)
            {
                isNumber = int.TryParse(lblCantidad.Text.Trim(), out currentValue);

                if (isNumber)
                {
                    if (isAdd)
                        currentValue++;
                    else
                    {
                        if (currentValue > 0)
                            currentValue--;
                    }
                }

                lblSubtotal.Text = (currentValue * double.Parse(lblPrecioUnitario.Text.Trim())).ToString();
                lblCantidad.Text = currentValue.ToString();
            }
        }
    }

    protected void btnPlus_Click(object sender, EventArgs e)
    {
        Button btn = sender as Button;
        GridViewRow row = btn.NamingContainer as GridViewRow;

        CalculosGolosinas(row, true);
    }

    protected void btnMinus_Click(object sender, EventArgs e)
    {
        Button btn = sender as Button;
        GridViewRow row = btn.NamingContainer as GridViewRow;

        CalculosGolosinas(row, false);
    }

    private void CalculosPromociones(GridViewRow row, bool isAdd)
    {
        bool isNumber = false;
        int currentValue = 0;

        Label lblCantidad0 = row.FindControl("lblCantidad0") as Label;
        Label lblSubtotal0 = row.FindControl("lblSubtotal0") as Label;
        Label lblPrecioUnitario0 = row.FindControl("lblPrecioUnitario0") as Label;

        if (lblCantidad0 != null)
        {
            if (lblCantidad0.Text.Trim() != string.Empty)
            {
                isNumber = int.TryParse(lblCantidad0.Text.Trim(), out currentValue);

                if (isNumber)
                {
                    if (isAdd)
                        currentValue++;
                    else
                    {
                        if (currentValue > 0)
                            currentValue--;
                    }
                }

                lblSubtotal0.Text = (currentValue * double.Parse(lblPrecioUnitario0.Text.Trim())).ToString();
                lblCantidad0.Text = currentValue.ToString();
            }
        }
    }

    protected void btnPlus0_Click(object sender, EventArgs e)
    {
        Button btn = sender as Button;
        GridViewRow row = btn.NamingContainer as GridViewRow;

        CalculosPromociones(row, true);
    }

    protected void btnMinus0_Click(object sender, EventArgs e)
    {
        Button btn = sender as Button;
        GridViewRow row = btn.NamingContainer as GridViewRow;

        CalculosPromociones(row, false);
    }

    protected List<DetalleFacturaEntidad> ListaResumen
    {
        get
        {
            if (Session["ListaDetallesFactura"] == null)
                Session["ListaDetallesFactura"] = new List<DetalleFacturaEntidad>();
            return (List<DetalleFacturaEntidad>)Session["ListaDetallesFactura"];
        }
        set
        {
            Session["ListaDetallesFactura"] = value;
        }
    }

    protected void btnAgregarAlResumen_Click(object sender, EventArgs e)
    {
        Button btn = sender as Button;
        GridViewRow row = btn.NamingContainer as GridViewRow;

        Label lblIdGolosina = row.FindControl("lblIdGolosina") as Label;
        Label lblNombre = row.FindControl("lblProducto") as Label;
        Label lblPrecioUnitario = row.FindControl("lblPrecioUnitario") as Label;
        Label lblSubtotal = row.FindControl("lblSubtotal") as Label;
        Label lblCantidad = row.FindControl("lblCantidad") as Label;

        int aux = -1;
        for (int i = 0; i < ListaResumen.Count; i++)
        {
            if (int.Parse(lblIdGolosina.Text) == ListaResumen[i].idGolosina)
            {
                aux = i;
                break;
            }
        }

        if (aux != -1)
        {
            ListaResumen[aux].subtotal = ListaResumen[aux].subtotal + double.Parse(lblSubtotal.Text);
            ListaResumen[aux].cantidad = ListaResumen[aux].cantidad + int.Parse(lblCantidad.Text);
        }
        else
        {
            ListaResumen.Add(new DetalleFacturaEntidad
            {
                idGolosina = int.Parse(lblIdGolosina.Text),
                nombre = lblNombre.Text,
                precioGolosina = double.Parse(lblPrecioUnitario.Text),
                subtotal = double.Parse(lblSubtotal.Text),
                cantidad = int.Parse(lblCantidad.Text)
            }
      );

        }

        CargarGrillaResumen();

        TotalVenta();
        lblCantidad.Text = "0";
        lblSubtotal.Text = "0";
    }

    protected void btnAgregarAlResumen0_Click(object sender, EventArgs e)
    {
        Button btn = sender as Button;
        GridViewRow row = btn.NamingContainer as GridViewRow;

        Label lblIdPromocion = row.FindControl("lblIdPromocion") as Label;
        Label lblNombrePromocion = row.FindControl("lblNombrePromocion") as Label;
        Label lblPrecioUnitario0 = row.FindControl("lblPrecioUnitario0") as Label;
        Label lblSubtotal0 = row.FindControl("lblSubtotal0") as Label;
        Label lblCantidad0 = row.FindControl("lblCantidad0") as Label;

        int aux = -1;
        for (int i = 0; i < ListaResumen.Count; i++)
        {
            if (int.Parse(lblIdPromocion.Text) == ListaResumen[i].idPromocion)
            {
                aux = i;
                break;
            }
        }

        if (aux != -1)
        {
            ListaResumen[aux].subtotal = ListaResumen[aux].subtotal + double.Parse(lblSubtotal0.Text);
            ListaResumen[aux].cantidad = ListaResumen[aux].cantidad + int.Parse(lblCantidad0.Text);
        }
        else
        {
            ListaResumen.Add(new DetalleFacturaEntidad
            {
                idPromocion = int.Parse(lblIdPromocion.Text),
                nombre = lblNombrePromocion.Text,
                precioPromocion = double.Parse(lblPrecioUnitario0.Text),
                subtotal = double.Parse(lblSubtotal0.Text),
                cantidad = int.Parse(lblCantidad0.Text)
            }
      );

        }

        CargarGrillaResumen();

        TotalVenta();
        lblCantidad0.Text = "0";
        lblSubtotal0.Text = "0";
    }

    private void CargarGrillaResumen()
    {
        btnRegistrarVenta.Visible = true;
        gvResumen.DataSource = ListaResumen;
        gvResumen.DataBind();
    }

    private void TotalVenta()
    {
        double total = 0;
        for (int i = 0; i < ListaResumen.Count; i++)
            total = total + ListaResumen[i].subtotal;

        lblTotal.Text = total.ToString();
    }

    protected void btnQuitar_Click(object sender, EventArgs e)
    {
        Button btn = sender as Button;
        GridViewRow row = btn.NamingContainer as GridViewRow;

        Label lblNombreGolosina = row.FindControl("nombreGolosina") as Label;


        for (int i = 0; i < gvResumen.Rows.Count; i++)
        {
            if (gvResumen.Rows[i].Cells[0].Text == ListaResumen[i].nombre)
            {
                ListaResumen.RemoveAt(i);
                break;
            }
        }
        TotalVenta();
        CargarGrillaResumen();
    }

    protected void gvResumen_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvGolosinas.PageIndex = e.NewPageIndex;
        CargarGrillaResumen();
    }

    protected void btnRegistrarVenta_Click(object sender, EventArgs e)
    {
        FacturaEntidad factura = new FacturaEntidad();
        factura.idEmpleado = int.Parse(ddlEmpleados.SelectedValue);
        factura.idCliente = int.Parse(ddlClientes.SelectedValue);
        factura.idTipoFactura = int.Parse(ddlTipoFac.SelectedValue);
        factura.fecha = DateTime.Parse(lblFecha.Text);
        factura.total = double.Parse(lblTotal.Text);

        List<DetalleFacturaEntidad> listaDetalles = new List<DetalleFacturaEntidad>();

        for (int i = 0; i < ListaResumen.Count; i++)
        {
            DetalleFacturaEntidad detalle = new DetalleFacturaEntidad();

            detalle.idGolosina = ListaResumen[i].idGolosina;
            //detalle.nombreGolosina = ListaResumen[i].nombreGolosina;
            detalle.cantidad = ListaResumen[i].cantidad;
            detalle.subtotal = ListaResumen[i].subtotal;
            detalle.idPromocion = ListaResumen[i].idPromocion;
            //detalle.nombrePromocion = ListaResumen[i].nombrePromocion;

            listaDetalles.Add(detalle);
        }

        VentaDao.insertarFactura(factura, listaDetalles);
        limpiar();
    }

    private void limpiar()
    {
        Session.Clear();
        CargarGrillaResumen();
        lblTotal.Text = string.Empty;
        btnRegistrarVenta.Visible = false;
        ddlClientes.SelectedIndex = 0;
        ddlEmpleados.SelectedIndex = 0;
        ddlTipoFac.SelectedIndex = 0;
    }
}