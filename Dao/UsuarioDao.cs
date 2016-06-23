using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data.SqlClient;
using System.Configuration;

namespace Dao
{
    public class UsuarioDao
    {
        public static bool esUsuarioRegistrado(UsuarioEntidad user)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["miConexion"].ConnectionString);
            con.Open();
            //Crear objeto command 
            SqlCommand cmdA = new SqlCommand();
            cmdA.Connection = con;
            cmdA.CommandText = @"SELECT * FROM Usuario WHERE nombreUsuario =@nombreUsuario AND pass=@pass";
            cmdA.Parameters.AddWithValue("@nombreUsuario", user.nombreUsuario);
            cmdA.Parameters.AddWithValue("@pass", user.pass);
            SqlDataReader dr = cmdA.ExecuteReader();

            if (dr.Read())
            {
                con.Close();
                return true;
            }
            else
            {
                con.Close();
                return false;
            }
        }
    }
}
