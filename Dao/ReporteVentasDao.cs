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

        public static List<FacturaXClienteXEmpleadoEntidad> ObtenerVentaPorFiltro(
    string apellidoYNombreCliente, int? idEmpleado, DateTime? fecha)
        {
            List<FacturaXClienteXEmpleadoEntidad> ventas = new List<FacturaXClienteXEmpleadoEntidad>();
            FacturaXClienteXEmpleadoEntidad f = null;

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = stringConexion();
            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = @"
            SELECT        Factura.fecha, Cliente.nombreYApellido, Empleado.nombreYApellido, Factura.Total
            FROM            Factura INNER JOIN
                         Cliente ON Factura.IdCliente = Cliente.IdCliente
                                    INNER JOIN
                         Empleado ON Factura.idEmpleado = Empleado.idEmpleado
            where 1 = 1";

            if (!string.IsNullOrEmpty(apellidoYNombreCliente))
            {
                cmd.CommandText += " and Cliente.nombreYApellido like @apeCli %";
                cmd.Parameters.AddWithValue("@apeCli", apellidoYNombreCliente);
            }
            if (idEmpleado.HasValue)
            {
                cmd.CommandText += " and Empleado.idEmpleado = @idEmp";
                cmd.Parameters.AddWithValue("@idEmp", idEmpleado);
            }
            if (!string.IsNullOrEmpty(fecha.ToString()))
            {
                cmd.CommandText += " and Factura.fecha like @fecha";
                cmd.Parameters.AddWithValue("@fecha", fecha);
            }


            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                f = new FacturaXClienteXEmpleadoEntidad();

                f.fechaFactura = (DateTime)dr["Factura.fecha"];
                f.nombreYapellidoCliente = dr["Cliente.nombreYApellido"].ToString();
                f.nombreYapellidoEmpleado = dr["Empleado.nombreYApellido"].ToString();
                f.totalFactura = decimal.Parse(dr["Factura.total"].ToString());

                ventas.Add(f);
            }
            dr.Close();
            cn.Close();
            return ventas;
        }
    }
}
