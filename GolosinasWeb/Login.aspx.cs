using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dao;
using Entidades;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        UsuarioEntidad user = new UsuarioEntidad();
        user.nombreUsuario = txtUsuario.Text;
        user.pass = txtClave.Text;
        if (ValidarUsuario(user))
        {
            Session["Usuario"] = txtUsuario.Text;
            Response.Redirect("Home.aspx");
        }
        else
            Session["Usuario"] = string.Empty;
        txtAlerta.Text = "Usuario o contraseña incorrectos";
    }

    private bool ValidarUsuario(UsuarioEntidad user)
    {
        if (UsuarioDao.esUsuarioRegistrado(user)) {
            EmpleadoEntidad empleado = EmpleadoDao.obtenerEmpleadoPorUsuario(user);
            Session["Rol"] = RolDao.obtenerRol(empleado.idRol);      
            return true;
        }
        else
            return false;
    }
}