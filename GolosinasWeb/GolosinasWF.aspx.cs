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
            lblMensajeError.Text = string.Empty;
            lblMensajeExito.Text = string.Empty;
            //divResultado.Visible = false;
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
        lblMensajeError.Text = string.Empty;
        lblMensajeExito.Text = string.Empty;
        if (!Page.IsValid) return;
        try
        {
            GolosinasEntidad golosina = new GolosinasEntidad();

            golosina.nombre = txtNombre.Text;
            int id;
            if (int.TryParse(ddlTipoG.Text, out id))
                golosina.idTipoGolosina = id;
            golosina.precioCompra = float.Parse(txtPrecioC.Text);
            golosina.precioVenta = float.Parse(txtPrecioV.Text);
            golosina.stockActual = int.Parse(txtStockA.Text);
            golosina.stockMinimo = int.Parse(txtStockM.Text);
            if(int.Parse(txtStockA.Text) > int.Parse(txtStockM.Text))
                golosina.listoParaPedir = false;
            else
                golosina.listoParaPedir = true;


            if (chkCeliaco.Checked)
                golosina.esAptoCeliaco = true;
            else
                golosina.esAptoCeliaco = false;

            if (ID.HasValue)
            {
                golosina.idGolosina = ID.Value;
                GolosinaDao.Actualizar(golosina);
                lblMensajeExito.Text = "Golosina actualizada con éxito";
            }
            else
            {
                GolosinaDao.Insertar(golosina);
                lblMensajeExito.Text = "Golosina grabada con éxito";
            }



            ID = golosina.idGolosina.Value;
            btnEliminar.CssClass = "btn btn-warning";
            btnEliminar.Enabled = true;
            Limpiar();
            CargarGrilla();
            
        }
        catch (Exception ex)
        {
            lblMensajeError.Text = ex.Message;
            /*divResultado.Visible = true;
            txtResultado.Text = "Ha ocurrido el siguiente error: " + ex.Message;*/
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

    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        Limpiar();
        lblMensajeError.Text = string.Empty;
        lblMensajeExito.Text = string.Empty;
    }

    protected void grdGolosinas_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblMensajeError.Text = string.Empty;
        lblMensajeExito.Text = string.Empty;
        Limpiar();
        int idSeleccionado = int.Parse(grdGolosinas.SelectedDataKey.Value.ToString());
        ID = idSeleccionado;
        GolosinasEntidad goloSelec = GolosinaDao.ObtenerPorID(idSeleccionado);

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
        lblMensajeError.Text = string.Empty;
        lblMensajeExito.Text = string.Empty;
        try
        {
            if (ID.HasValue)
            {
                GolosinaDao.Eliminar(ID.Value);
                CargarGrilla();
                Limpiar();
                lblMensajeExito.Text = "Golosina eliminada con éxito";
            }

            else
            {
                lblMensajeError.Text = "Debe seleccionar una golosina para poder eliminarla";
            }
        }
        catch (ApplicationException ex)
        {
            lblMensajeError.Text = ex.Message;
        }
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
      
        lblMensajeError.Text = string.Empty;
        lblMensajeExito.Text = string.Empty;
        //Establezco la fuente de los datos de la grilla
        grdGolosinas.DataSource = GolosinaDao.ObtenerPorIncremento(txtGolosinaABuscar.Text);
       
        //Indico que llene la grilla
        grdGolosinas.DataBind();
    }

    protected void grdGolosinas_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        lblMensajeError.Text = string.Empty;
        lblMensajeExito.Text = string.Empty;
        grdGolosinas.PageIndex = e.NewPageIndex;
        CargarGrilla();
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

        txtGolosinaABuscar.Text = string.Empty;

     
        //divResultado.Visible = false;
        btnEliminar.Enabled = false;
        btnEliminar.CssClass = "btn btn-warning";
    }
}