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
        List<GridViewRow> filaGrilla = new List<GridViewRow>();
        // Check
        if (!IsPostBack)
        {
            // Variable
            grillaGolosinas.DataSource = ProvinciaDao.ObtenerProvincias();
            grillaGolosinas.DataBind();

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


    protected List<GolosinasXCarritoEntidad> ListaTE
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
        // Variable
        bool isNumber = false;
       double subtotal = 0;

        // Find Control

        double total = 0;
        for (int i = 0; i < grillaGolosinas.Rows.Count; i++)
        {
            Label lbl_subtotal = grillaGolosinas.Rows[i].FindControl("lbl_subtotal") as Label;

             total =total + double.Parse(lbl_subtotal.Text.Trim());

        }
           lbl_precioTotal.Text = total.ToString();


    }


}