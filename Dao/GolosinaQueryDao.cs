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
    public class GolosinaQueryDao
    {
        public static List<GolosinaQuery> ObtenerGolosinasPorFiltro(int? idTipo, double? precioCDesde, double? precioCHasta, bool? celiaco)
        {
            List<GolosinaQuery> listaQuery = new List<GolosinaQuery>();
            GolosinaQuery g = null;
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["miConexion"].ConnectionString);
            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = @"SELECT Golosina.nombre, TipoGolosina.descripcion, Golosina.esAptoCeliaco, Golosina.precioCompra, Golosina.precioVenta,
                                Golosina.stockActual, Golosina.stockMinimo, Golosina.listoParaPedir
                                FROM TipoGolosina INNER JOIN Golosina ON TipoGolosina.idTipoGolosina = Golosina.idTipoGolosina WHERE 1=1";
            if(idTipo.HasValue)
            {
                cmd.CommandText += " AND TipoGolosina.idTipoGolosina = @idTipoGolosina";
                cmd.Parameters.AddWithValue("@idTipoGolosina", idTipo.Value);
            }

            if(precioCDesde.HasValue)
            {
                cmd.CommandText += " AND Golosina.precioCompra >= @precioCDesde";
                cmd.Parameters.AddWithValue("@precioCDesde", precioCDesde.Value);

            }
            if (precioCHasta.HasValue)
            {
                cmd.CommandText += " AND Golosina.precioCompra <= @precioCHasta";
                cmd.Parameters.AddWithValue("@precioCHasta", precioCHasta.Value);

            }

            if (celiaco.HasValue)
            {
                cmd.CommandText += " AND Golosina.esAptoCeliaco = @celiaco";
                cmd.Parameters.AddWithValue("@celiaco", celiaco.Value);

            }

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                g = new GolosinaQuery();

                g.nombre = dr["nombre"].ToString();
                g.precioCompra = float.Parse(dr["precioCompra"].ToString());
                g.precioVenta = float.Parse(dr["precioVenta"].ToString());
                g.stockActual = int.Parse(dr["stockActual"].ToString());
                g.stockMinimo = int.Parse(dr["stockMinimo"].ToString());
                g.listoParaPedir = (bool)dr["listoParaPedir"];            
                g.esAptoCeliaco = (bool)dr["esAptoCeliaco"];
                g.nombreTipo = dr["descripcion"].ToString();

                listaQuery.Add(g);

            }
            dr.Close();
            cn.Close();
            return listaQuery;

        }
    }
}
