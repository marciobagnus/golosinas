using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using Entidades;

namespace Dao
{
    public class VentaDao
    {
        public static string stringConexion()
        {
            return ConfigurationManager.ConnectionStrings["miConexion"].ConnectionString;
        }

        public static void insertarFactura(FacturaEntidad factura, List<DetalleFacturaEntidad> detalles)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = stringConexion();
            cn.Open();
            SqlTransaction tran = cn.BeginTransaction();

            try
            {        
                SqlCommand cmd1 = new SqlCommand();
                cmd1.Connection = cn;
                cmd1.Transaction = tran;
                cmd1.CommandText = @"INSERT INTO Factura
                                    (idTipoFactura, fecha, 
                                    idEmpleado, total, idCliente)
                                    VALUES
                                   (@idTipoFac, @fecha,
                                    @idEmpleado, @total,
                                    @idCliente);select Scope_Identity() as ID";

                cmd1.Parameters.AddWithValue("@idTipoFac", factura.idTipoFactura);
                cmd1.Parameters.AddWithValue("@fecha", factura.fecha);
                cmd1.Parameters.AddWithValue("@idEmpleado", factura.idEmpleado);
                cmd1.Parameters.AddWithValue("@total", factura.total);
                cmd1.Parameters.AddWithValue("@idCliente", factura.idCliente);

                factura.idFactura = Convert.ToInt32(cmd1.ExecuteScalar());

                for (int i = 0; i < detalles.Count; i++)
                {
                    SqlCommand cmd2 = new SqlCommand();
                    cmd2.Connection = cn;
                    cmd2.CommandText = @"INSERT INTO DetalleFactura
                                         (idFactura, cantidad,
                                         idPromocion, subtotal, idGolosina)
                                   VALUES
                                         (@idFactura, @cantidad,
                                          @idPromocion, @subtotal, @idGolosina)";
                                                      
                    cmd2.Parameters.AddWithValue("@idFactura", factura.idFactura);
                    cmd2.Parameters.AddWithValue("@cantidad", detalles[i].cantidad);
                    if (detalles[i].idPromocion.HasValue)
                    {
                        cmd2.Parameters.AddWithValue("@idPromocion", detalles[i].idPromocion);
                    }
                    else cmd2.Parameters.AddWithValue("@idPromocion", System.DBNull.Value);
                    cmd2.Parameters.AddWithValue("@subtotal", detalles[i].subtotal);
                    if (detalles[i].idGolosina.HasValue)
                    {
                        cmd2.Parameters.AddWithValue("@idGolosina", detalles[i].idGolosina);
                    }
                    else cmd2.Parameters.AddWithValue("@idGolosina", System.DBNull.Value);

                    cmd2.Transaction = tran;
                    cmd2.ExecuteNonQuery();
                }
                tran.Commit();
            }
            catch (SqlException ex)
            {
                tran.Rollback();
            }
            finally
            {
                cn.Close();
            }
        }

        public static List<PromocionEntidad> ObtenerTodasPromociones()
        {
            List<PromocionEntidad> promociones = new List<PromocionEntidad>();

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = stringConexion();
            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = @"SELECT idPromocion, nombre, fechaDesde, fechaHasta, 
                                       total, idEmpleado, descuento
                                  FROM Promocion
                                  WHERE fechaHasta >= getdate()";
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                PromocionEntidad p = new PromocionEntidad();

                p.idPromocion = int.Parse(dr["idPromocion"].ToString());
                p.nombre = dr["nombre"].ToString();
                p.fechaDesde = DateTime.Parse(dr["fechaDesde"].ToString());
                p.fechaHasta = DateTime.Parse(dr["fechaHasta"].ToString());
                p.total = float.Parse(dr["total"].ToString());
                p.idEmpleado = int.Parse(dr["idEmpleado"].ToString());
                p.descuento = float.Parse(dr["descuento"].ToString());

                promociones.Add(p);
            }
            dr.Close();
            cn.Close();
            return promociones;
        }
    }
}
