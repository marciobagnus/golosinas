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

        // Check
        if (!IsPostBack)
        {
            string[] golosina = { "Caramelo Arcor", "Chocolate 20g", "Chocolate 100g", "Chupetin", "Chicle" };
            string[] precioUnitario = { "2", "10", "25", "5", "1" };
            string[] subtotal = { "0", "0", "0", "0", "0" };
            DataTable dt = new DataTable();
            dt.Columns.Add("nombre");
            dt.Columns.Add("precioUnitario");
            dt.Columns.Add("subtotal");


            for (int i = 0; i < golosina.Length; i++)
            {
                DataRow workRow = dt.NewRow();
                workRow[0] = golosina[i];
                workRow[1] = precioUnitario[i];
                workRow[2] = subtotal[i];
                dt.Rows.Add(workRow);
            }



            grillaGolosinas.DataSource = dt;
            grillaGolosinas.DataBind();

            // Dispose
            dt.Dispose();


            // Variable
            //grillaGolosinas.DataSource = ProvinciaDao.ObtenerProvincias();
            //grillaGolosinas.DataBind();

        }
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

        Label lbl_nombre = row.FindControl("lbl_producto") as Label;
        Label lbl_precioUnitario = row.FindControl("lbl_precioUnitario") as Label;
        Label lbl_subtotal = row.FindControl("lbl_subtotal") as Label;
        Label lbl_cantidad = row.FindControl("lbl_cantidad") as Label;

        ListaCarrito.Add(new GolosinasXCarritoEntidad
        {
            nombre = lbl_nombre.Text,
            precioUnitario = double.Parse(lbl_precioUnitario.Text),
            subtotal = double.Parse(lbl_subtotal.Text),
            cantidad=int.Parse(lbl_cantidad.Text)
        }
        );

        grillaCarrito.DataSource = ListaCarrito;
        grillaCarrito.DataBind();




        //// Get
        //Button btn = sender as Button;
        //GridViewRow row = btn.NamingContainer as GridViewRow;
        //// Variable
        //bool isNumber = false;
        //double subtotal = 0;

        //// Find Control

        //double total = 0;
        //for (int i = 0; i < grillaGolosinas.Rows.Count; i++)
        //{
        //    Label lbl_subtotal = grillaGolosinas.Rows[i].FindControl("lbl_subtotal") as Label;

        //    total = total + double.Parse(lbl_subtotal.Text.Trim());

        //}
        //lbl_precioTotal.Text = total.ToString();


    }


}