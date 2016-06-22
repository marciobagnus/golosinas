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
    public class RolDao
    {
        public static string obtenerRol(int id)
        {

            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["miConexion"].ConnectionString);
            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = @"SELECT * FROM [dbo].[Rol] WHERE idRol = @idRol";
            cmd.Parameters.AddWithValue("@idRol", id);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                string desc = dr["descripcion"].ToString();
                cn.Close();
                return desc;
            }
            else
            {
                cn.Close();
                return null;
            }


        }
    }
}
