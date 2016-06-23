using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Dao;
using Entidades;

public partial class carritoPedidos : System.Web.UI.Page
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
        // Check
        if (!Page.IsPostBack)
        {

            cargarGrillaGolosinas();
            DateTime hoy = DateTime.Today;
            lbl_fechaPedido.Text = hoy.ToString("dd/MM/yyyy");
            lbl_fechaEntrega.Text = hoy.AddDays(5).ToString("dd/MM/yyyy");
            cargarProveedores();
            btn_generarPedido.Visible = false;
            Session["ListaDetallesPedido"] = null;
            

        }
    }

    private void cargarGrillaGolosinas()
    {
        //Obtengo la lista de todas las golosinas
        List<GolosinasEntidad> listaGolosinasCompleta = new List<GolosinasEntidad>();
        listaGolosinasCompleta = GolosinaDao.ObtenerTodos();

        //Creo la nueva lista de golosinas con datos para el carrito (objeto GolosinasXCarritoEntidad)

        List<DetallePedidoEntidad> listaGolosinasCarrito = new List<DetallePedidoEntidad>();


        //le cargo los datos a la nueva lista

        for (int i = 0; i < listaGolosinasCompleta.Capacity - 1; i++)
        {
            DetallePedidoEntidad goCarrito = new DetallePedidoEntidad();

            goCarrito.idGolosina = listaGolosinasCompleta[i].idGolosina;
            goCarrito.cantidad = 0;
            goCarrito.nombreGolosina = listaGolosinasCompleta[i].nombre;
            goCarrito.subtotal = 0;
            goCarrito.precioGolosina = double.Parse(listaGolosinasCompleta[i].precioCompra.ToString("#.###"));
            listaGolosinasCarrito.Add(goCarrito);
        }

        grillaGolosinas.DataSource = listaGolosinasCarrito;
        grillaGolosinas.DataBind();
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

    private void DoTheMath(GridViewRow row, bool isAdd)
    {
        // Variable
        bool isNumber = false;
        int currentValue = 0;

        // Find Control
        Label lbl_Cantidad = row.FindControl("lbl_Cantidad") as Label;
        Label lbl_subtotal = row.FindControl("lbl_subtotal") as Label;
        Label lbl_precioUnitario = row.FindControl("lbl_precioUnitario") as Label;

        // Check
        if (lbl_Cantidad != null)
        {
            // Check
            if (lbl_Cantidad.Text.Trim() != string.Empty)
            {
                isNumber = int.TryParse(lbl_Cantidad.Text.Trim(), out currentValue);

                // Check
                if (isNumber)
                {
                    // Is Add
                    if (isAdd)
                        currentValue++;
                    else
                    {
                        // Check cannot be less than 0
                        if (currentValue > 0)
                            currentValue--;
                    }
                }

                // Set to TextBox
                lbl_subtotal.Text = (currentValue * double.Parse(lbl_precioUnitario.Text.Trim())).ToString();
                lbl_Cantidad.Text = currentValue.ToString();
                lbl_alerta.Text = string.Empty;
            } 
        }
    }

    protected void btnPlus_Click(object sender, EventArgs e)
    {

        // Get
        Button btn = sender as Button;
        GridViewRow row = btn.NamingContainer as GridViewRow;

        DoTheMath(row, true);
    }

    protected void btnMinus_Click(object sender, EventArgs e)
    {
        // Get
        Button btn = sender as Button;
        GridViewRow row = btn.NamingContainer as GridViewRow;

        DoTheMath(row, false);
    }


    protected List<DetallePedidoEntidad> ListaCarrito
    {
        get
        {
            if (Session["ListaDetallesPedido"] == null)
                Session["ListaDetallesPedido"] = new List<DetallePedidoEntidad>();
            return (List<DetallePedidoEntidad>)Session["ListaDetallesPedido"];
        }
        set
        {
            Session["ListaDetallesPedido"] = value;
        }
    }

    protected void btn_agregarAlCarrito_Click(object sender, EventArgs e)
    {
        
        // Get
        Button btn = sender as Button;
        GridViewRow row = btn.NamingContainer as GridViewRow;

        Label lbl_idGolosina = row.FindControl("lbl_idGolosina") as Label;
        Label lbl_nombre = row.FindControl("lbl_producto") as Label;
        Label lbl_precioUnitario = row.FindControl("lbl_precioUnitario") as Label;
        Label lbl_subtotal = row.FindControl("lbl_subtotal") as Label;
        Label lbl_cantidad = row.FindControl("lbl_cantidad") as Label;

        if(lbl_cantidad.Text != "0") { 
        int aux = -1;
        for (int i = 0; i < ListaCarrito.Count; i++)
        {
            if (int.Parse(lbl_idGolosina.Text) == ListaCarrito[i].idGolosina)
            {
                aux = i;
                break;
            }
        }

        if (aux != -1)
        {
            ListaCarrito[aux].subtotal = ListaCarrito[aux].subtotal + double.Parse(lbl_subtotal.Text);
            ListaCarrito[aux].cantidad = ListaCarrito[aux].cantidad + int.Parse(lbl_cantidad.Text);
        }
        else
        {
            ListaCarrito.Add(new DetallePedidoEntidad
            {
                idGolosina = int.Parse(lbl_idGolosina.Text),
                nombreGolosina = lbl_nombre.Text,
                precioGolosina = double.Parse(lbl_precioUnitario.Text),
                subtotal = double.Parse(lbl_subtotal.Text),
                cantidad = int.Parse(lbl_cantidad.Text)
            }
      );

        }

        cargarGrillaCarrito();

        sumarCarrito();
        lbl_cantidad.Text = "0";
        lbl_subtotal.Text = "0";
        }
        else
        {
            lbl_alerta.Text = "No se puede agregar golosinas sin elegir cantidad";
        }
    }

    private void cargarGrillaCarrito()
    {
        btn_generarPedido.Visible = true;
        grillaCarrito.DataSource = ListaCarrito;
        grillaCarrito.DataBind();
    }


    private void sumarCarrito()
    {
        double total = 0;
        for (int i = 0; i < ListaCarrito.Count; i++)
            total = total + ListaCarrito[i].subtotal;

        lbl_precioTotal.Text = total.ToString();
    }


    protected void btnQuitar_Click(object sender, EventArgs e)
    {
        // Get
        Button btn = sender as Button;
        GridViewRow row = btn.NamingContainer as GridViewRow;

        Label lbl_nombreGolosina = row.FindControl("nombreGolosina") as Label;


        for (int i = 0; i < grillaCarrito.Rows.Count; i++)
        {
            if (grillaCarrito.Rows[i].Cells[0].Text == ListaCarrito[i].nombreGolosina)
            {
                ListaCarrito.RemoveAt(i);
                break;
            }
        }
        sumarCarrito();
        cargarGrillaCarrito();
    }


    protected void btn_generarPedido_Click(object sender, EventArgs e)
    {
        if (grillaCarrito.Rows.Count != 0 && ddl_proveedores.SelectedIndex != 0)
        {
            PedidoEntidad pedido = new PedidoEntidad();
            pedido.idProveedor = int.Parse(ddl_proveedores.SelectedValue);

            pedido.fechaPedido = DateTime.Parse(lbl_fechaPedido.Text);
            pedido.fechaEntrega = DateTime.Parse(lbl_fechaEntrega.Text);

            pedido.total = double.Parse(lbl_precioTotal.Text);

            List<DetallePedidoEntidad> listaDetalles = new List<DetallePedidoEntidad>();

            for (int i = 0; i < ListaCarrito.Count; i++)
            {
                DetallePedidoEntidad detalle = new DetallePedidoEntidad();

                detalle.idGolosina = ListaCarrito[i].idGolosina;
                detalle.nombreGolosina = ListaCarrito[i].nombreGolosina;
                detalle.cantidad = ListaCarrito[i].cantidad;
                detalle.subtotal = ListaCarrito[i].subtotal;

                listaDetalles.Add(detalle);
            }

            PedidosDao.insertarPedido(pedido, listaDetalles);
            limpiar();
        }
        else
        {
            lbl_alerta.Text = "Faltan datos";
        }
    }

    private void limpiar()
    {
        Session["ListaDetallesPedido"] = null;
        cargarGrillaCarrito();
        lbl_precioTotal.Text = string.Empty;
        btn_generarPedido.Visible = false;
        lbl_alerta.Text = string.Empty;
        ddl_proveedores.SelectedIndex = 0;

    }


    protected void grillaCarrito_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grillaCarrito.PageIndex = e.NewPageIndex;
        cargarGrillaCarrito();
    }

    protected void grillaGolosinas_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grillaGolosinas.PageIndex = e.NewPageIndex;
        cargarGrillaGolosinas();

    }
}