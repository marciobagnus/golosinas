using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Dao;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        string rol = (string)Session["Rol"];
        bool acceso = false;
        if (rol == "administrador" || rol =="empleado")
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
            cargarProveedores();
        }
    }
   
         private void cargarProveedores()
    {
        List<ProveedoresEntidad> listaProv = ProveedoresDao.ObtenerTodos();
        //Vaciar comboBox
        ddl_proveedores.DataSource = null;

        //Indicar qué propiedad se verá en la lista
        ddl_proveedores.DataTextField = "razonSocial";

        //Indicar qué valor tendrá cada ítem
        ddl_proveedores.DataValueField = "idProveedor";

        //Asignar la propiedad DataSource
        ddl_proveedores.DataSource = listaProv;

        ddl_proveedores.DataBind();
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        CargarGrilla();
        Limpiar();
    }

    protected void Limpiar()
    {
        ddl_proveedores .SelectedIndex = 0;
        txt_apeNom.Text = string.Empty;
        txt_fechaPedidoDesde.Text = string.Empty;
        txt_fechaPedidoHasta.Text = string.Empty;
    }
    protected void CargarGrilla()
    {
              try
        {
            //PedidoQuery p = new GolosinaQueryDao();

            int? idProv = null;
            DateTime? fechaPedidoDesde = null;
            DateTime? fechaPedidoHasta = null;
            string apeNom = string.Empty;

            int id;
            if (int.TryParse(ddl_proveedores.Text, out id))
                idProv = id;
            if (txt_fechaPedidoDesde.Text != string.Empty)
                fechaPedidoDesde = DateTime.Parse(txt_fechaPedidoDesde.Text);
            if (txt_fechaPedidoHasta.Text != string.Empty)
                fechaPedidoHasta = DateTime.Parse(txt_fechaPedidoHasta.Text);
            if (txt_apeNom.Text != string.Empty)
                apeNom =txt_apeNom.Text;

            gvInforme.DataSource = PedidoQueryDao.ObtenerPedidosPorFiltro(idProv, fechaPedidoDesde, fechaPedidoHasta, apeNom);
            gvInforme.DataBind();
        }
        catch (Exception ex)
        {
            lblMensajeError.Text = ex.Message;
        }

       
    }

    protected void gvInforme_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvInforme.PageIndex = e.NewPageIndex;
        CargarGrilla();
    }





    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        Limpiar();
    }
}