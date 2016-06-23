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
                cmd.Transaction = tran;
                cmd.CommandText = @" UPDATE ultimoNroPromocion
                                        SET ultimoNroPromocion = ultimoNroPromocion +1";
                cmd.ExecuteNonQuery();


                SqlCommand cmdA = new SqlCommand();
                cmdA.Connection = cn;
                cmdA.Transaction = tran;
                cmdA.CommandText = "SELECT ultimoNroPromocion FROM ultimoNroPromocion";
                SqlDataReader dr = cmdA.ExecuteReader();
                if (dr.Read())
                    promocion.nroPromocion = int.Parse(dr[0].ToString());

                dr.Close();

                SqlCommand cmdB = new SqlCommand();
                cmdB.Connection = cn;
                cmdB.Transaction = tran;
                cmdB.CommandText =
                    @"INSERT INTO Promocion
                (nombre, fechaDesde, fechaHasta, total, idEmpleado, descuento, nroPromocion )
                VALUES(@nombre, @fechaDesde, @fechaHasta, @total, @idEmpleado, @descuento, @nroPromocion) select Scope_Identity() as ID";

                //cmd.Parameters.AddWithValue("@idPromocion", promocion.idPromocion);
                cmdB.Parameters.AddWithValue("@nombre", promocion.nombre);
                cmdB.Parameters.AddWithValue("@fechaDesde", promocion.fechaDesde);
                cmdB.Parameters.AddWithValue("@fechaHasta", promocion.fechaHasta);
                cmdB.Parameters.AddWithValue("@total", promocion.total);
                cmdB.Parameters.AddWithValue("@idEmpleado", promocion.idEmpleado);
                cmdB.Parameters.AddWithValue("@descuento", promocion.descuento);
                cmdB.Parameters.AddWithValue("@nroPromocion", promocion.nroPromocion);
                cmdB.Transaction = tran;

                promocion.idPromocion = Convert.ToInt32(cmdB.ExecuteScalar());


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
                   // GolosinaDao.ActualizarStock(de.idGolosina, de.cantidad, false);
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
