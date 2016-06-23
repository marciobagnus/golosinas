using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Entidades;

namespace Dao
{
    public class TipoFacturaDao
    {
        public static string stringConexion()
        {
            return ConfigurationManager.ConnectionStrings["miConexion"].ConnectionString;
        }

        public static List<TipoFacturaEntidad> ObtenerTodosTiposFactura()
        {
            List<TipoFacturaEntidad> tiposFactura = new List<TipoFacturaEntidad>();

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = stringConexion();
            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = @"SELECT * FROM TipoFactura";
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                TipoFacturaEntidad t = new TipoFacturaEntidad();

                t.idTipoFactura = int.Parse(dr["idTipoFactura"].ToString());
                t.descripcion = dr["descripcion"].ToString();

                tiposFactura.Add(t);
            }
            dr.Close();
            cn.Close();
            return tiposFactura;
        }
    }
}
