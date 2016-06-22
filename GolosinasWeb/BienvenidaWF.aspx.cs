using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BienvenidaWF : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblUsuario.Text = Session["Usuario"].ToString();
        lblRol.Text = Session["Rol"].ToString();
    }
}