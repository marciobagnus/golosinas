using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Dao;
using System.Data;

public partial class Pedidos : System.Web.UI.Page
{
    //protected void Page_Load(object sender, EventArgs e)
    //{

    //    
    //    grillaGolosinas.DataBind();
    //}

    protected void Page_Load(object sender, EventArgs e)
    {
        // Check
        if (!IsPostBack)
        {
            // Variable
            //grillaGolosinas.DataSource = ;
            // string[] product = { "Dell", "Asus", "Acer", "Toshiba", "Fujishu", "VAIO" };
            //DataTable dt = new DataTable();
            //dt.Columns.Add("Product");

            //for (int i = 0; i < product.Length; i++)
            //    dt.Rows.Add(product[i]);

            grillaGolosinas.DataSource = ProvinciaDao.ObtenerProvincias();
            grillaGolosinas.DataBind();

            // Dispose
            //dt.Dispose();

        }
    }

    private void DoTheMath(GridViewRow row, bool isAdd)
    {
        // Variable
        bool isNumberA = false;
        int valorActualCantidad = 0;

        // Find Control
        Label lbl_cantidad = row.FindControl("lbl_cantidad") as Label;
        Label lbl_subtotal = row.FindControl("lbl_subtotal") as Label;
        Label lbl_precioUnitario = row.FindControl("lbl_precioUnitario") as Label;

        // Check
        if (lbl_cantidad != null)
        {
            // Check
            if (lbl_cantidad.Text.Trim() != string.Empty)
            {
                isNumberA = int.TryParse(lbl_cantidad.Text.Trim(), out valorActualCantidad);

                // Check
                if (isNumberA)
                {
                    // Is Add
                    if (isAdd)
                        valorActualCantidad++;
                    else
                    {
                        // Check cannot be less than 0
                        if (valorActualCantidad > 0)
                            valorActualCantidad--;
                    }
                }

                // Set to TextBox
                lbl_subtotal.Text = (double.Parse(lbl_precioUnitario.Text.Trim()) * valorActualCantidad).ToString();
                lbl_precioTotal.Text = (double.Parse(lbl_precioTotal.Text.Trim()) + double.Parse(lbl_subtotal.Text.Trim())).ToString();
                lbl_cantidad.Text = valorActualCantidad.ToString();
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

    protected void btn_agregarAlCarrito_Click(object sender, EventArgs e)
    {
        lbl_precioTotal.Text = "millones";
    }
}

