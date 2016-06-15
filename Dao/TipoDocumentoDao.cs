using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Entidades;

namespace Dao
{
    public class TipoDocumentoDao
    {
        public static string stringConexion()
        {
            return ConfigurationManager.ConnectionStrings["miConexion"].ConnectionString;
        }

        public static List<TipoDocumentoEntidad> ObtenerTodosTiposDocumento()
        {
            List<TipoDocumentoEntidad> tiposDocumento = new List<TipoDocumentoEntidad>();

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = stringConexion();
            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = @"SELECT * FROM TipoDocumento";
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                TipoDocumentoEntidad t = new TipoDocumentoEntidad();

                t.idTipoDocumento = int.Parse(dr["idTipoDocumento"].ToString());
                t.descripcion = dr["descripcion"].ToString();

                tiposDocumento.Add(t);
            }
            dr.Close();
            cn.Close();
            return tiposDocumento;
        }
    }
}
