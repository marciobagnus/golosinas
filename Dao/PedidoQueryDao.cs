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
    public class PedidoQueryDao
    {
        public static List<PedidoQuery> ObtenerPedidosPorFiltro(int? idProv, DateTime? fechaDesde, DateTime? fechaHasta, string apellidoYNombreEmpleado)
        {
            List<PedidoQuery> listaQuery = new List<PedidoQuery>();
            PedidoQuery p = null;
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["miConexion"].ConnectionString);
            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = @"
                            SELECT        Pr.RazonSocial,Pe.fechaPedido, E.nombreYApellido, Pe.total
                            FROM          Pedido Pe 
                            INNER JOIN
                                          Proveedor Pr ON Pe.idProveedor = Pr.idProveedor
                            INNER JOIN
                                          Empleado E ON Pe.idEmpleado = E.idEmpleado
                            WHERE 1 = 1";

            if (!string.IsNullOrEmpty(apellidoYNombreEmpleado))
            {
                cmd.CommandText += " AND E.nombreYApellido LIKE @apeNom";
                cmd.Parameters.AddWithValue("@apeNom","%"+ apellidoYNombreEmpleado+"%");
            }
            if (fechaDesde.HasValue)
            {
                cmd.CommandText += " AND Pe.fechaPedido >= @fechaDesde";
                cmd.Parameters.AddWithValue("@fechaDesde", fechaDesde.Value);

            }
            if (fechaHasta.HasValue)
            {
                cmd.CommandText += " AND Pe.fechaPedido <= @fechaHasta";
                cmd.Parameters.AddWithValue("@fechaHasta", fechaHasta.Value);

            }
            if (idProv.HasValue)
            {
                cmd.CommandText += " AND Pr.idProveedor = @idProv";
                cmd.Parameters.AddWithValue("@idProv", idProv);
            }
            

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                p = new PedidoQuery();

                p.razonSocial = dr["razonSocial"].ToString();
                p.fechaPedido = DateTime.Parse(dr["fechaPedido"].ToString());
                p.apeNom = dr["nombreYApellido"].ToString();
                p.total = double.Parse(dr["total"].ToString());

                listaQuery.Add(p);

            }
            dr.Close();
            cn.Close();
            return listaQuery;

        }
    }
}
