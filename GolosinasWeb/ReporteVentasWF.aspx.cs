using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Dao;

public partial class ReporteVentasWF : System.Web.UI.Page
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
            Response.Redirect("Login.aspx");
        }
        if (!IsPostBack)
        {
            CargarComboEmpleados();
        }
    }

    protected void CargarComboEmpleados()
    {
        List<EmpleadoEntidad> empleados = EmpleadoDao.ObtenerTodosEmpleados();

        ddlEmpleados.DataSource = null;

        ddlEmpleados.DataValueField = "idEmpleado";

        ddlEmpleados.DataTextField = "nombreYApellido";

        ddlEmpleados.DataSource = empleados;

        ddlEmpleados.DataBind();
    }

    protected void CargarGrillaVentas()
    {
        int contador = 0;
        try
        {
            FacturaXClienteXEmpleadoEntidad f = new FacturaXClienteXEmpleadoEntidad();

            string apeCliente = "";
            int? idEmp = null;
            DateTime? fechaDesde = null;
            DateTime? fechaHasta= null;
            int id;

            if (txtApellido.Text != string.Empty)
                apeCliente = txtApellido.Text;
            if (int.TryParse(ddlEmpleados.Text, out id))
                idEmp = id;
            if (txtFechaDesde.Text != string.Empty)
                fechaDesde = DateTime.Parse(txtFechaDesde.Text);
            if (txtFechaHasta.Text != string.Empty)
                fechaHasta = DateTime.Parse(txtFechaHasta.Text);

            gvVentas.DataSource = ReporteVentasDao.ObtenerVentaPorFiltro(apeCliente, idEmp, fechaDesde, fechaHasta);
            gvVentas.DataKeyNames = new string[] { "idFactura" };
            gvVentas.DataBind();
        }
        catch (Exception ex)
        {
            lblMensajeError.Text = ex.Message;
        }

        if (contador > 1)
            lblMensajeExito.Text = " Se encontraron " + contador + " ventas";
        else if (contador == 1)
            lblMensajeExito.Text = " Se encontro " + contador + " venta";
    }

    protected void gvVentas_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvVentas.PageIndex = e.NewPageIndex;
        CargarGrillaVentas();
    }

    protected void btnBuscarVentas_Click(object sender, EventArgs e)
    {
        lblMensajeError.Text = String.Empty;
        lblMensajeExito.Text = String.Empty;
        CargarGrillaVentas();
        Limpiar();
    }

    protected void Limpiar()
    {
        ddlEmpleados.SelectedIndex = 0;
        txtApellido.Text = string.Empty;
        txtFechaDesde.Text = string.Empty;
        txtFechaHasta.Text = string.Empty;
    }
}