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
        CargarGrilla();
    }
    protected void CargarGrilla()
    {
        GolosinaQueryDao g = new GolosinaQueryDao();

        int? idTipo = null;
        double? precioCDesde = null;
        double? precioCHasta = null;
        bool? celiaco = null;

        int id;
        if (int.TryParse(ddlTipo.Text, out id))
            idTipo = id;        
        if(txtPrecioCDesde.Text != string.Empty)
            precioCDesde = double.Parse(txtPrecioCDesde.Text);
        if (txtPrecioCHasta.Text != string.Empty)
            precioCHasta = double.Parse(txtPrecioCHasta.Text);
        if (ddlCeliaco.Text != "null")
            celiaco = Convert.ToBoolean(ddlCeliaco.Text);
         

        gvInforme.DataSource = GolosinaQueryDao.ObtenerGolosinasPorFiltro(idTipo, precioCDesde, precioCHasta, celiaco);
        gvInforme.DataBind();




    }

    protected void gvInforme_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void gvInforme_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvInforme.PageIndex = e.NewPageIndex;
        CargarGrilla();

    }
}