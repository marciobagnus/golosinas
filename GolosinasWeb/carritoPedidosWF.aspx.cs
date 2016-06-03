﻿using System;
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

        // Check
        if (!IsPostBack)
        {
            {
                Session.Clear();

                string[] golosina = { "Caramelo Arcor", "Chocolate 20g", "Chocolate 100g", "Chupetin", "Chicle" };
                string[] precioUnitario = { "2", "10", "25", "5", "1" };
                string[] subtotal = { "0", "0", "0", "0", "0" };
                string[] idGolosina = { "0", "1", "2", "3", "4" };
                DataTable dt = new DataTable();
                dt.Columns.Add("idGolosina");
                dt.Columns.Add("nombre");
                dt.Columns.Add("precioUnitario");
                dt.Columns.Add("subtotal");


                for (int i = 0; i < golosina.Length; i++)
                {
                    DataRow workRow = dt.NewRow();
                    workRow[0] = idGolosina[i];
                    workRow[1] = golosina[i];
                    workRow[2] = precioUnitario[i];
                    workRow[3] = subtotal[i];
                    dt.Rows.Add(workRow);
                }



                grillaGolosinas.DataSource = dt;
                grillaGolosinas.DataBind();

                // Dispose
                dt.Dispose();

            }

            DateTime hoy = DateTime.Today;
            lbl_fechaPedido.Text = hoy.ToString("dd/MM/yyyy");
            lbl_fechaEntrega.Text = hoy.AddDays(5).ToString("dd/MM/yyyy");
            cargarProveedores();

            // Variable
            //grillaGolosinas.DataSource = ProvinciaDao.ObtenerProvincias();
            //grillaGolosinas.DataBind();

        }
    }
    private void cargarProveedores()
    {
        List<ProveedoresEntidad> listaProv = ProveedoresDao.ObtenerTodos();
        //Vaciar comboBox
        cmb_proveedores.DataSource = null;

        //Indicar qué propiedad se verá en la lista
        cmb_proveedores.DataTextField = "razonSocial";

        //Indicar qué valor tendrá cada ítem
        cmb_proveedores.DataValueField = "idProveedor";

        //Asignar la propiedad DataSource
        cmb_proveedores.DataSource = listaProv;

        cmb_proveedores.SelectedIndex = 1;
        cmb_proveedores.DataBind();


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


    protected List<GolosinasXCarritoEntidad> ListaCarrito
    {

        get
        {
            if (Session["ListaGolisinas"] == null)
                Session["ListaGolisinas"] = new List<GolosinasXCarritoEntidad>();
            return (List<GolosinasXCarritoEntidad>)Session["ListaGolisinas"];
        }
        set
        {
            Session["ListaTExAlumno"] = value;
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
            ListaCarrito.Add(new GolosinasXCarritoEntidad
            {
                idGolosina = int.Parse(lbl_idGolosina.Text),
                nombre = lbl_nombre.Text,
                precioUnitario = double.Parse(lbl_precioUnitario.Text),
                subtotal = double.Parse(lbl_subtotal.Text),
                cantidad = int.Parse(lbl_cantidad.Text)
            }
      );

        }

        grillaCarrito.DataSource = ListaCarrito;
        grillaCarrito.DataBind();

        sumarCarrito();
        lbl_cantidad.Text = "0";
        lbl_subtotal.Text = "0";




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

        Label lbl_idGolosina = row.FindControl("lbl_idGolosinaCarrito") as Label;
       
        for (int i = 0; i < ListaCarrito.Count; i++)
        {
            if (int.Parse(lbl_idGolosina.Text) == ListaCarrito[i].idGolosina)
            {
                ListaCarrito.RemoveAt(i);
                break;
            }
        }

        sumarCarrito();
        grillaCarrito.DataSource = ListaCarrito;
        grillaCarrito.DataBind();
    }

    protected void btn_generarPedido_Click(object sender, EventArgs e)
    {

    }
}