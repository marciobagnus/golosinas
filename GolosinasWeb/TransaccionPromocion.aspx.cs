using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Dao;

public partial class TransaccionPromocion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CargarComboEmpleados();
            CargarComboGolosinas();
            CargarGrilla();
            txtFechaD.Text = DateTime.Today.ToShortDateString();
        }

    }

    protected void CargarComboEmpleados()
    {
        ddlEmpleados.DataSource = EmpleadoDao.ObtenerTodosEmpleados();
        ddlEmpleados.DataValueField = "idEmpleado";
        ddlEmpleados.DataTextField = "nombreYApellido";
        ddlEmpleados.DataBind();
    }

    protected void CargarComboGolosinas()
    {
        ddlGolosinas.DataSource = GolosinaDao.ObtenerTodos();
        ddlGolosinas.DataValueField = "idGolosina";
        ddlGolosinas.DataTextField = "nombre";
        ddlGolosinas.DataBind();
    }

    protected void btnRegistrar_Click(object sender, EventArgs e)
    {
        lblMensajeError.Text = string.Empty;
        lblMensajeExito.Text = string.Empty;
        lblSinProductos.Text = string.Empty;
        lblYaIngresado.Text = string.Empty;
        lblSinStock.Text = string.Empty;

        if (gvPromocion.Rows.Count != 0)
        {
            try
            {

                if (!Page.IsValid) return;

                PromocionEntidad promocion = new PromocionEntidad();
                promocion.nombre = txtNombre.Text;
                promocion.fechaDesde = DateTime.Parse(txtFechaD.Text);
                promocion.fechaHasta = DateTime.Parse(txtFechaH.Text);
                promocion.total = float.Parse(txtTotal.Text);
                int id;
                if (int.TryParse(ddlEmpleados.Text, out id))
                    promocion.idEmpleado = id;
                promocion.descuento = float.Parse(txtDescuento.Text);

                PromocionDao.Insertar(promocion, Detalles);

                Detalles = new List<DetallePromocionEntidad>();
                DetallesQuery = new List<DetallePromocionQuery>();

                Limpiar();
                CargarGrilla();

                lblMensajeExito.Text = "Promocion grabada con éxito";

            }
            catch (Exception ex)
            {
                lblMensajeError.Text = ex.Message;
            }
        }
        else
            lblSinProductos.Text = "Agregue al menos una Golosina";




    }

    protected void Limpiar()
    {
        txtCantidad.Text = string.Empty;
        txtDescuento.Text = string.Empty;
        txtFechaD.Text = string.Empty;
        txtFechaH.Text = string.Empty;
        txtNombre.Text = string.Empty;
        txtPorcentaje.Text = string.Empty;
        txtPrecio.Text = string.Empty;
        txtSubtotal.Text = string.Empty;
        txtTotal.Text = string.Empty;

        ddlEmpleados.SelectedIndex = 0;
        ddlGolosinas.SelectedIndex = 0;



    }

    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        lblMensajeError.Text = string.Empty;
        lblMensajeExito.Text = string.Empty;
        lblSinProductos.Text = string.Empty;
        lblYaIngresado.Text = string.Empty;
        lblSinStock.Text = string.Empty;
        if (!Page.IsValid) return;
        if (txtCantidad.Text != string.Empty && ddlGolosinas.SelectedIndex != 0)
        {
            try
            {
                int idGolosina = Int32.Parse(ddlGolosinas.SelectedItem.Value);
                int cantidad = int.Parse(txtCantidad.Text);
                float subtotal = float.Parse(txtPrecio.Text);

                LlenarDetalles(idGolosina, cantidad, subtotal);
                LlenarDetallesQuery(idGolosina, cantidad, subtotal);

                CargarGrilla();

                ddlGolosinas.SelectedIndex = 0;
                txtPrecio.Text = string.Empty;
                txtCantidad.Text = string.Empty;
            }
            catch (Exception ex)
            {
                lblMensajeError.Text = ex.Message;
            }
        }
        else
            lblYaIngresado.Text = "Seleccione una golosina";


    }

    private void LlenarDetalles(int idGolosina, int cantidad, float subtotal)
    {
        try
        {

            GolosinasEntidad golosina = GolosinaDao.ObtenerPorID(idGolosina);
            DetallePromocionEntidad detalle = new DetallePromocionEntidad();

            detalle.idGolosina = idGolosina;
            detalle.cantidad = cantidad;
            detalle.subtotal = subtotal;
                        
            Detalles.Add(detalle);
        }
        catch (Exception ex)
        {
            lblMensajeError.Text = ex.Message;
        }

    }

    private void LlenarDetallesQuery(int idGolosina, int cantidad, float subtotal)
    {
        try
        {
            GolosinasEntidad golosina = GolosinaDao.ObtenerPorID(idGolosina);
            DetallePromocionQuery detalleQuery = new DetallePromocionQuery();

            detalleQuery.idGolosina = idGolosina;
            detalleQuery.nombre = golosina.nombre;
            detalleQuery.cantidad = cantidad;
            detalleQuery.precioVenta = subtotal;

            detalleQuery.totalParcial = cantidad * subtotal;
            DetallesQuery.Add(detalleQuery);

        }
        catch (Exception ex)
        {
            lblMensajeError.Text = ex.Message;
        }

    }


    private void CargarGrilla()
    {
        gvPromocion.DataSource = DetallesQuery;
        gvPromocion.DataKeyNames = new string[] { "idGolosina" };
        gvPromocion.DataBind();

    }

    public List<DetallePromocionEntidad> Detalles
    {
        get
        {
            if (Session["detalles"] == null)
            {
                Session["detalles"] = new List<DetallePromocionEntidad>();
            }
            return (List<DetallePromocionEntidad>)Session["detalles"];
        }
        set
        {
            Session["detalles"] = value;
        }

    }

    public List<DetallePromocionQuery> DetallesQuery
    {
        get
        {
            if (Session["detallesQuery"] == null)
            {
                Session["detallesQuery"] = new List<DetallePromocionQuery>();
            }
            return (List<DetallePromocionQuery>)Session["detallesQuery"];
        }
        set
        {
            Session["detallesQuery"] = value;
        }

    }

    protected void ddlGolosinas_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Int32.Parse(ddlGolosinas.SelectedItem.Value) != 0)
        {
            lblMensajeExito.Text = string.Empty;
            int idGolosina = Int32.Parse(ddlGolosinas.SelectedItem.Value);
            GolosinasEntidad golosina = GolosinaDao.ObtenerPorID(idGolosina);
            txtPrecio.Text = golosina.precioVenta.ToString();
        }
        else
            Limpiar();
    }


    public double suma;
    protected void gvPromocion_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            suma += double.Parse(e.Row.Cells[5].Text);
            txtSubtotal.Text = suma.ToString();
            float descuento = (float.Parse(txtSubtotal.Text) * float.Parse(txtPorcentaje.Text)) / 100;
            txtDescuento.Text = descuento.ToString();
            float total = float.Parse(txtSubtotal.Text) - descuento;
            txtTotal.Text = total.ToString();

        }
        /* else if (e.Row.RowType == DataControlRowType.Footer)
         {
             e.Row.Cells[2].Text = "Grand Total";
             e.Row.Cells[2].Font.Bold = true;

             e.Row.Cells[3].Text = suma.ToString();
             e.Row.Cells[3].Font.Bold = true;

         }*/

    }

    protected void gvPromocion_SelectedIndexChanged(object sender, EventArgs e)
    {
        int idGolosina = int.Parse(gvPromocion.SelectedDataKey.Value.ToString());

        foreach (DetallePromocionQuery deq in DetallesQuery)
        {
            if (deq.idGolosina == idGolosina)
            {
                DetallesQuery.Remove(deq);
                break;
            }

        }
        foreach (DetallePromocionEntidad de in Detalles)
        {
            if (de.idGolosina == idGolosina)
            {
                Detalles.Remove(de);
                break;
            }

        }

        txtSubtotal.Text = string.Empty;
        txtDescuento.Text = string.Empty;
        txtTotal.Text = string.Empty;

        CargarGrilla();


    }



    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("home.aspx");
    }
}