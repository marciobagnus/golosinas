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
        if (!IsPostBack)
        {
            CargarComboEmpleados();
        }
    }

    protected void CargarComboEmpleados()
    {
        ddlEmpleados.DataSource = EmpleadoDao.ObtenerTodosEmpleados();
        ddlEmpleados.DataValueField = "idEmpleado";
        ddlEmpleados.DataTextField = "nombreYApellido";
        ddlEmpleados.DataBind();
    }

    protected void CargarGrillaVentas()
    {
        FacturaXClienteXEmpleadoEntidad f = new FacturaXClienteXEmpleadoEntidad();

        string apeCliente = "";
        int? idEmp = null;
        DateTime? fecha = null;
        int id;

        if (txtApellido.Text != string.Empty)
            apeCliente = txtApellido.Text;
        if (int.TryParse(ddlEmpleados.Text, out id))
            idEmp = id;  
        if (txtFechaFactura.Text != string.Empty)
            fecha = DateTime.Parse(txtFechaFactura.Text);

        gvVentas.DataSource = ReporteVentasDao.ObtenerVentaPorFiltro(apeCliente, idEmp, fecha);
        gvVentas.DataKeyNames = new string[] { "idFactura" };
        gvVentas.DataBind();
    }

    protected void gvVentas_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvVentas.PageIndex = e.NewPageIndex;
        CargarGrillaVentas();
    }

    protected void btnBuscarVentas_Click(object sender, EventArgs e)
    {
        CargarGrillaVentas();
    }
}