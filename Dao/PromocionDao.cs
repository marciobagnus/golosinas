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
    public class PromocionDao
    {
        public static void Insertar(PromocionEntidad promocion, List<DetallePromocionEntidad> detalles)
        {


            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["miConexion"].ConnectionString);
            SqlTransaction tran = null;

            try
            {
                cn.Open();
                tran = cn.BeginTransaction();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText =
                    @"INSERT INTO Promocion
                (nombre, fechaDesde, fechaHasta, total, idEmpleado, descuento)
                VALUES(@nombre, @fechaDesde, @fechaHasta, @total, @idEmpleado, @descuento) select Scope_Identity() as ID";

                //cmd.Parameters.AddWithValue("@idPromocion", promocion.idPromocion);
                cmd.Parameters.AddWithValue("@nombre", promocion.nombre);
                cmd.Parameters.AddWithValue("@fechaDesde", promocion.fechaDesde);
                cmd.Parameters.AddWithValue("@fechaHasta", promocion.fechaHasta);
                cmd.Parameters.AddWithValue("@total", promocion.total);
                cmd.Parameters.AddWithValue("@idEmpleado", promocion.idEmpleado);
                cmd.Parameters.AddWithValue("@descuento", promocion.descuento);
                cmd.Transaction = tran;

                promocion.idPromocion = Convert.ToInt32(cmd.ExecuteScalar());


                foreach (DetallePromocionEntidad de in detalles)
                {
                    de.idPromocion = promocion.idPromocion;

                    SqlCommand cmdDe = new SqlCommand();
                    cmdDe.Connection = cn;
                    cmdDe.CommandText = @"
                            INSERT INTO DetallePromocion
                            (idPromocion,cantidad,subtotal,idGolosina)
                            VALUES (@idPromocion, @cantidad,@subtotal,@idGolosina) select Scope_Identity() as ID";
                    cmdDe.Parameters.AddWithValue("@idPromocion", de.idPromocion.Value);
                    //cmdDe.Parameters.AddWithValue("@idDetallePromocion", de.idDetallePromocion);
                    cmdDe.Parameters.AddWithValue("@cantidad", de.cantidad);
                    cmdDe.Parameters.AddWithValue("@subtotal", de.subtotal);
                    cmdDe.Parameters.AddWithValue("@idGolosina", de.idGolosina);
                    cmdDe.Transaction = tran;
                    de.idDetallePromocion = Convert.ToInt32(cmdDe.ExecuteScalar());
                    GolosinaDao.ActualizarStock(de.idGolosina, de.cantidad, false);
                }
                tran.Commit();
            }
            catch (SqlException ex)
            {
                tran.Rollback();
                throw new ApplicationException("Error: " + ex.Message);
            }
            finally
            {
                cn.Close();
            }

            cn.Close();


        }


    }
}
