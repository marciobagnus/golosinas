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
    public class TipoGolosinaDao
    {
        public static List<TipoGolosinaEntidad> ObtenerTodos()
        {
            List<TipoGolosinaEntidad> listaTipos = new List<TipoGolosinaEntidad>();
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["miConexion"].ConnectionString);
            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = @"SELECT idTipoGolosina, descripcion
                                FROM TipoGolosina";
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                TipoGolosinaEntidad t = new TipoGolosinaEntidad();

                t.idTipoGolosina = int.Parse(dr["idTipoGolosina"].ToString());
                t.descripcion = dr["descripcion"].ToString();
            

                listaTipos.Add(t);

            }
            dr.Close();
            cn.Close();
            return listaTipos;
        }
    }
}
