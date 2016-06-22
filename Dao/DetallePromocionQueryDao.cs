using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades;
using System.Configuration;


namespace Dao
{
    public class DetallePromocionQueryDao
    {
        public static List<DetallePromocionQuery> ObtenerTodos()
        {
            List<DetallePromocionQuery> listaDetalles = new List<DetallePromocionQuery>();
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["miConexion"].ConnectionString);
            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = @"SELECT DetallePromocion.idGolosina,
                                       DetallePromocion.subtotal, DetallePromocion.cantidad,
                                       Golosina.nombre, Golosina.precioVenta
                             FROM     DetallePromocion INNER JOIN
                  Golosina ON DetallePromocion.idGolosina = Golosina.idGolosina";
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                DetallePromocionQuery d = new DetallePromocionQuery();

                d.cantidad = int.Parse(dr["cantidad"].ToString());
                d.idDetallePromocion = int.Parse(dr["idDetallePromocion"].ToString());
                d.idGolosina = int.Parse(dr["idGolosina"].ToString());
                d.idPromocion = int.Parse(dr["idPromocion"].ToString());
                d.nombre = dr["nombre"].ToString();
                d.precioVenta = float.Parse(dr["precioVenta"].ToString());
                d.subtotal = float.Parse(dr["subtotal"].ToString());

                listaDetalles.Add(d);

            }
            dr.Close();
            cn.Close();
            return listaDetalles;
        }

    }
}
