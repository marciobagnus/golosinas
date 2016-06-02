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
        if (!Page.IsPostBack)
        {
            cargarProvincias();
            CargarGrilla();
            btnEliminar.Enabled = false;
            btnEliminar.CssClass = "btn btn-warning";
        }
    }

    protected void CargarGrilla()
    {
        grid_proveedores.DataSource = null;
        //Establezco la fuente de los datos de la grilla
        grid_proveedores.DataSource = (from prov in ProveedoresDao.ObtenerTodos()
                                       orderby prov.razonSocial
                                       select prov);
        //Establezco un atributo identificador de cada una de las filas de la grilla, en nuestro caso la clave primaria
        grid_proveedores.DataKeyNames = new string[] { "idProveedor" };
        //Indico que llene la grilla
        grid_proveedores.DataBind();
    }


    private void cargarProvincias()
    {
        List<ProvinciaEntidad> listaProv = ProvinciaDao.ObtenerProvincias();
        //Vaciar comboBox
        cmb_provincia.DataSource = null;

        //Indicar qué propiedad se verá en la lista
        cmb_provincia.DataTextField = "nombre";

        //Indicar qué valor tendrá cada ítem
        cmb_provincia.DataValueField = "idProvincia";

        //Asignar la propiedad DataSource
        cmb_provincia.DataSource = listaProv;

        cmb_provincia.SelectedIndex=1;
        cmb_provincia.DataBind();


    }
    protected void btn_guardar_Click(object sender, EventArgs e)
    {
        ProveedoresEntidad proveedor = new ProveedoresEntidad();
        long cuit;
        if (long.TryParse(txt_cuit.Text, out cuit))
            proveedor.cuit = cuit;

        proveedor.nombre = txt_nombre.Text;
        proveedor.razonSocial = txt_razonSocial.Text;
        proveedor.domicilio = txt_domicilio.Text;

        if (chk_esNacional.Checked)
            proveedor.esNacional = true;
        else
            proveedor.esNacional = false;

        int provincia;
        if (int.TryParse(cmb_provincia.Text, out provincia))
            proveedor.idProvincia = provincia;
        DateTime fechaAlta;
        if (DateTime.TryParse(txt_fechaAlta.Text, out fechaAlta))
            proveedor.fechaAlta = fechaAlta;

        if (ID.HasValue)
        {
            proveedor.idProveedor = ID.Value;
            ProveedoresDao.actualizarProveedor(proveedor);
        }
        else
        {

            ProveedoresDao.Insertar(proveedor);
        }
        CargarGrilla();
        Limpiar();

    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        ProveedoresDao.eliminarProveedor(ID.Value);
        CargarGrilla();
        Limpiar();
    }

    private void Limpiar()
    {
        txt_cuit.Text = null;
        txt_domicilio.Text = string.Empty;
        txt_fechaAlta.Text = string.Empty;
        txt_nombre.Text = string.Empty;
        txt_razonSocial.Text = string.Empty;
        cmb_provincia.SelectedIndex = 0;
        chk_esNacional.Checked = false;
        ID = null;
        btnEliminar.Enabled = false;
        btnEliminar.CssClass = "btn btn-warning";
    }
    protected void grid_proveedores_SelectedIndexChanged(object sender, EventArgs e)
    {
        Limpiar();
        int idSeleccionado = int.Parse(grid_proveedores.SelectedDataKey.Value.ToString());
        ID = idSeleccionado;
        ProveedoresEntidad provSelec = ProveedoresDao.ObtenerPorId(idSeleccionado);

        txt_razonSocial.Text = provSelec.razonSocial;
        txt_cuit.Text = provSelec.cuit.ToString();
        txt_fechaAlta.Text = provSelec.fechaAlta.ToString();
        txt_domicilio.Text = provSelec.domicilio;
        chk_esNacional.Checked = provSelec.esNacional;
        cmb_provincia.SelectedIndex = provSelec.idProvincia - 1;
        btnEliminar.Enabled = true;
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
}