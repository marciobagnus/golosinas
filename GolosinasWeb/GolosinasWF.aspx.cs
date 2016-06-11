using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Dao;

public partial class GolosinasWF : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            btnEliminar.Enabled = false;
            btnEliminar.CssClass = "btn btn-warning disabled";
            CargarGrilla();
            CargarCombo();
        }

    }

    protected void CargarGrilla()
    {
        grdGolosinas.DataSource = GolosinaDao.ObtenerTodos();
        grdGolosinas.DataBind();

    }

    protected void CargarCombo()
    {
        ddlTipoG.DataSource = TipoGolosinaDao.ObtenerTodos();
        ddlTipoG.DataValueField = "idTipoGolosina";
        ddlTipoG.DataTextField = "descripcion";
        ddlTipoG.DataBind();

    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        GolosinaEntidad golosina = new GolosinaEntidad();

        golosina.nombre = txtNombre.Text;
        int id;
        if (int.TryParse(ddlTipoG.Text, out id))
            golosina.idTipoGolosina = id;
        golosina.precioCompra = float.Parse(txtPrecioC.Text);
        golosina.precioVenta = float.Parse(txtPrecioV.Text);
        golosina.stockActual = int.Parse(txtStockA.Text);
        golosina.stockMinimo = int.Parse(txtStockM.Text);
        
        golosina.listoParaPedir = false;

        if (chkCeliaco.Checked)
            golosina.esAptoCeliaco = true;
        else
            golosina.esAptoCeliaco = false;

        if (ID.HasValue)
        {
            golosina.idGolosina = ID.Value;
            GolosinaDao.Actualizar(golosina);
            
        }
        else
        {

            GolosinaDao.Insertar(golosina);
        }

        
        CargarGrilla();
        Limpiar();
    }

    protected void Limpiar()
    {
        txtNombre.Text = string.Empty;
        txtPrecioC.Text = string.Empty;
        txtPrecioV.Text = string.Empty;
        txtStockA.Text = string.Empty;
        txtStockM.Text = string.Empty;
        chkCeliaco.Checked = false;
        ddlTipoG.SelectedIndex = 0;
        

        btnEliminar.Enabled = false;
        btnEliminar.CssClass = "btn btn-warning";
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

    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        Limpiar();
    }

    protected void grdGolosinas_SelectedIndexChanged(object sender, EventArgs e)
    {
        Limpiar();
        int idSeleccionado = int.Parse(grdGolosinas.SelectedDataKey.Value.ToString());
        ID = idSeleccionado;
        GolosinaEntidad goloSelec = GolosinaDao.ObtenerPorID(idSeleccionado);

        txtNombre.Text = goloSelec.nombre;
        ddlTipoG.SelectedIndex = goloSelec.idTipoGolosina;
        txtPrecioC.Text = goloSelec.precioCompra.ToString();
        txtPrecioV.Text = goloSelec.precioVenta.ToString();
        txtStockA.Text = goloSelec.stockActual.ToString();
        txtStockM.Text = goloSelec.stockMinimo.ToString();
        chkCeliaco.Checked = goloSelec.esAptoCeliaco;
             
        btnEliminar.Enabled = true;

    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        GolosinaDao.Eliminar(ID.Value);
        CargarGrilla();
        Limpiar();
    }
}