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
    public class ReporteVentasDao
    {
        public static string stringConexion()
        {
            return ConfigurationManager.ConnectionStrings["miConexion"].ConnectionString;
        }

        public static List<FacturaXClienteXEmpleadoEntidad> ObtenerVentaPorFiltro(string apellidoYNombreCliente, int? idEmpleado, DateTime? fechaDesde, DateTime? fechaHasta)
        {
            List<FacturaXClienteXEmpleadoEntidad> ventas = new List<FacturaXClienteXEmpleadoEntidad>();
            FacturaXClienteXEmpleadoEntidad f = null;

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = stringConexion();
            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = @"
            SELECT        Factura.fecha, c.nombreYApellido as nombreCli, Empleado.nombreYApellido as nombreEmp, Factura.Total
            FROM            Factura INNER JOIN
                         Cliente c ON Factura.IdCliente = c.IdCliente
                                    INNER JOIN
                         Empleado ON Factura.idEmpleado = Empleado.idEmpleado
            where 1 = 1";

            if (!string.IsNullOrEmpty(apellidoYNombreCliente))
            {
                cmd.CommandText += " and c.nombreYApellido like @apeCli";
                cmd.Parameters.AddWithValue("@apeCli", "%" + apellidoYNombreCliente + "%");
            }
            if (idEmpleado.HasValue)
            {
                cmd.CommandText += " and Empleado.idEmpleado = @idEmp";
                cmd.Parameters.AddWithValue("@idEmp", idEmpleado);
            }
            if (fechaDesde.HasValue)
            {
                cmd.CommandText += " and Factura.fecha >= @fechaDesde";
                cmd.Parameters.AddWithValue("@fechaDesde", fechaDesde);
            }
            if (fechaHasta.HasValue)
            {
                cmd.CommandText += " and Factura.fecha <= @fechaHasta";
                cmd.Parameters.AddWithValue("@fechaHasta", fechaHasta);
            }

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                f = new FacturaXClienteXEmpleadoEntidad();

                f.fechaFactura = DateTime.Parse(dr["fecha"].ToString());
                f.nombreYapellidoCliente = dr["nombreCli"].ToString();
                f.nombreYapellidoEmpleado = dr["nombreEmp"].ToString();
                f.totalFactura = decimal.Parse(dr["total"].ToString());

                ventas.Add(f);
            }
            dr.Close();
            cn.Close();
            return ventas;
        }
    }
}
