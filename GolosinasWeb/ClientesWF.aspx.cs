using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Dao;

public partial class ClientesWF : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            cargarTiposDocumento();
            CargarGrillaClientes();
            btnEliminar.Enabled = false;
            btnEliminar.CssClass = "btn btn-warning";
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
    private void Limpiar()
    {
        txtNombre.Text = string.Empty;
        txtApellido.Text = string.Empty;
        ddlTipoDoc.SelectedIndex = 0;
        txtNumDoc.Text = null;
        txtFechaNacimiento.Text = string.Empty;
        txtDomicilio.Text = string.Empty;
        rdbFemenino.Checked = false;
        rdbMasculino.Checked = false;
        //txtUsuario.Text = string.Empty;
        ID = null;
        btnEliminar.Enabled = false;
        btnEliminar.CssClass = "btn btn-warning";
    }
    
    private void cargarTiposDocumento()
    {
        List<TipoDocumentoEntidad> tiposDocumento = TipoDocumentoDao.ObtenerTodosTiposDocumento();

        ddlTipoDoc.DataSource = null;

        ddlTipoDoc.DataTextField = "descripcion";

        ddlTipoDoc.DataValueField = "idTipoDocumento";

        ddlTipoDoc.DataSource = tiposDocumento;

        ddlTipoDoc.SelectedIndex = 1;
        ddlTipoDoc.DataBind();
    }

    protected void CargarGrillaClientes()
    {
        gvClientes.DataSource = null;

        gvClientes.DataSource = (from cli in ClienteDao.ObtenerTodosClientes()
                                       orderby cli.nombreYapellido
                                       select cli);

        gvClientes.DataKeyNames = new string[] { "idCliente" };
        gvClientes.DataBind();
    }



    protected void btn_guardar_Click(object sender, EventArgs e)
    {
        ClienteEntidad cliente = new ClienteEntidad();

        int numDocumento;
        if (int.TryParse(txtNumDoc.Text, out numDocumento))
            cliente.numeroDocumento = numDocumento;

        cliente.nombreYapellido = txtApellido.Text + " " + txtNombre.Text;
        cliente.domicilio = txtDomicilio.Text;
        //cliente.nombreUsuario = txtUsuario.Text;

        if (rdbFemenino.Checked)
            cliente.sexo = "femenino";
        else if (rdbMasculino.Checked)
            cliente.sexo = "masculino";

        int tipoDoc;
        if (int.TryParse(ddlTipoDoc.Text, out tipoDoc))
            cliente.idTipoDocumento = tipoDoc;

        DateTime fechaNacimiento;
        if (DateTime.TryParse(txtFechaNacimiento.Text, out fechaNacimiento))
            cliente.fechaNacimiento = fechaNacimiento;

        if (ID.HasValue)
        {
            cliente.idCliente = ID.Value;
            ClienteDao.ActualizarCliente(cliente);
        }
        else
        {

            ClienteDao.InsertarCliente(cliente);
        }
        CargarGrillaClientes();
        Limpiar();
    }



    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        ClienteDao.EliminarCliente(ID.Value);
        CargarGrillaClientes();
        Limpiar();
    }

    protected void grid_clientes_SelectedIndexChanged(object sender, EventArgs e)
    {
        Limpiar();
        int idSeleccionado = int.Parse(gvClientes.SelectedDataKey.Value.ToString());
        ID = idSeleccionado;
        ClienteEntidad cliSelec = ClienteDao.ObtenerClientesPorID(idSeleccionado);

        string[] cadenasNyA = cliSelec.nombreYapellido.Split(' ');
        string fecha = cliSelec.fechaNacimiento.ToString();
        string[] cadenaFechas = fecha.Split(' ');
        txtNombre.Text = cadenasNyA[1];
        txtApellido.Text = cadenasNyA[0];
        ddlTipoDoc.SelectedIndex = cliSelec.idTipoDocumento - 1;
        txtNumDoc.Text = cliSelec.numeroDocumento.ToString();
        txtFechaNacimiento.Text = cadenaFechas[0];
        txtDomicilio.Text = cliSelec.domicilio;
        if (cliSelec.sexo == "femenino")
        {
            rdbFemenino.Checked = true;
        }
        else if (cliSelec.sexo == "masculino")
        {
            rdbMasculino.Checked = true;
        }
        //txtUsuario.Text = cliSelec.nombreUsuario;

        btnEliminar.Enabled = true;
    }

    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        Limpiar();
    }

    protected void rdbFemenino_CheckedChanged(object sender, EventArgs e)
    {
        //if (rdbFemenino.Checked == true)
        //{
            rdbMasculino.Checked = false;
        //}
    }

    protected void rdbMasculino_CheckedChanged(object sender, EventArgs e)
    {
        //if (rdbMasculino.Checked == true)
        //{
            rdbFemenino.Checked = false;
        //}
    }
}