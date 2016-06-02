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
    public class ProvinciaDao
    {
        
        public static List<ProvinciaEntidad> ObtenerProvincia()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["miConexion"].ConnectionString);
            con.Open();
            SqlCommand cmdA = new SqlCommand();
            cmdA.Connection = con;
            cmdA.CommandText = @"SELECT * FROM[BDGolosinas].[dbo].[Provincia]";
            SqlDataReader dr = cmdA.ExecuteReader();
            List<ProvinciaEntidad> listaProv= new List<ProvinciaEntidad>();
            
            while (dr.Read())
            {
                ProvinciaEntidad prov = new ProvinciaEntidad();
                prov.idProvincia = int.Parse(dr[0].ToString());
                prov.nombre = dr[1].ToString();
                listaProv.Add(prov);
             }
           

            return listaProv;
        }
    }
}
