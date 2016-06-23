using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Dao;

public partial class GolosinaQueryWF : System.Web.UI.Page
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
        if (!IsPostBack)
        {
            CargarCombo();
        }

    }
    protected void CargarCombo()
    {
        ddlTipo.DataSource = TipoGolosinaDao.ObtenerTodos();
        ddlTipo.DataValueField = "idTipoGolosina";
        ddlTipo.DataTextField = "descripcion";
        ddlTipo.DataBind();

    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        lblMensajeError.Text = String.Empty;
        lblMensajeExito.Text = String.Empty;
        CargarGrilla();
        Limpiar();
    }

    protected void Limpiar()
    {
        ddlTipo.SelectedIndex = 0;
        ddlCeliaco.SelectedIndex = 0;
        txtPrecioCDesde.Text = string.Empty;
        txtPrecioCHasta.Text = string.Empty;
    }
    protected void CargarGrilla()
    {
        int contador = 0;
        try
        {
            GolosinaQueryDao g = new GolosinaQueryDao();

            int? idTipo = null;
            double? precioCDesde = null;
            double? precioCHasta = null;
            bool? celiaco = null;

            int id;
            if (int.TryParse(ddlTipo.Text, out id))
                idTipo = id;
            if (txtPrecioCDesde.Text != string.Empty)
                precioCDesde = double.Parse(txtPrecioCDesde.Text);
            if (txtPrecioCHasta.Text != string.Empty)
                precioCHasta = double.Parse(txtPrecioCHasta.Text);
            if (ddlCeliaco.Text != "null")
                celiaco = Convert.ToBoolean(ddlCeliaco.Text);

            contador = GolosinaQueryDao.ObtenerGolosinasPorFiltro(idTipo, precioCDesde, precioCHasta, celiaco).Count();
            gvInforme.DataSource = GolosinaQueryDao.ObtenerGolosinasPorFiltro(idTipo, precioCDesde, precioCHasta, celiaco);
            gvInforme.DataBind();
        }
        catch (Exception ex)
        {
            lblMensajeError.Text = ex.Message;
        }

        if (contador > 1)
            lblMensajeExito.Text = " Se encontraron " + contador + " golosinas con esta busqueda";
        else if (contador == 1)
            lblMensajeExito.Text = " Se encontro " + contador + " golosina con esta busqueda";        
    }

    protected void gvInforme_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvInforme.PageIndex = e.NewPageIndex;
        CargarGrilla();
    }
}