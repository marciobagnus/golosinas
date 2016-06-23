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
    public class PedidosDao
    {
        public static void insertarPedido(PedidoEntidad pedido, List<DetallePedidoEntidad> detalles)
        {
            //Abrir la conexion
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["miConexion"].ConnectionString);
            con.Open();
            SqlTransaction tran = con.BeginTransaction();

            //Crear objeto command 

         

            try
            {
                //Actualizo el ultimo nro de pedido en la tabla UltimoNroPedido
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.Transaction = tran;
                cmd.CommandText = @"UPDATE [dbo].[UltimoNroPedido]
                                    SET[ultimoNroPedido] = [ultimoNroPedido] +  1";
                cmd.ExecuteNonQuery();

                //leo este ultimo numero actualizado
                SqlCommand cmdA = new SqlCommand();
                cmdA.Connection = con;
                cmdA.Transaction = tran;
                cmdA.CommandText = "SELECT ultimoNroPedido FROM [dbo].[UltimoNroPedido]";
                SqlDataReader dr = cmdA.ExecuteReader();
                if (dr.Read())
                    pedido.nroPedido = int.Parse(dr[0].ToString());

                dr.Close();   
                         
                SqlCommand cmdB = new SqlCommand();
                cmdB.Connection = con;
                cmdB.Transaction = tran;
                cmdB.CommandText = @"INSERT INTO [dbo].[Pedido]
                                        ([idProveedor]
                                       ,[fechaPedido]
                                       ,[fechaEntrega]
                                       ,[idEmpleado]
                                       ,[total]
                                       ,[nroPedido])
                                 VALUES
                                       (@idProveedor
                                       ,@fechaPedido
                                       ,@fechaEntrega
                                       ,@idEmpleado
                                       ,@total
                                       ,@nroPedido); select Scope_Identity() as ID";
                cmdB.Parameters.AddWithValue("@idProveedor", pedido.idProveedor);
                cmdB.Parameters.AddWithValue("@fechaPedido", pedido.fechaPedido);
                cmdB.Parameters.AddWithValue("@fechaEntrega", pedido.fechaEntrega);
                cmdB.Parameters.AddWithValue("@idEmpleado", 1); //pedido.idEmpleado);
                cmdB.Parameters.AddWithValue("@total", pedido.total);
                cmdB.Parameters.AddWithValue("@nroPedido", pedido.nroPedido) ;

                pedido.idPedido= Convert.ToInt32(cmdB.ExecuteScalar());



                for (int i = 0; i < detalles.Count; i++)
                {
                    SqlCommand cmdC = new SqlCommand();
                    cmdC.Connection = con;
                    cmdC.CommandText = @"INSERT INTO [dbo].[DetallePedido]
                                         ([idPedido]
                                         ,[cantidad]
                                         ,[subtotal]
                                         ,[idGolosina])
                                   VALUES
                                         (@idPedido
                                         ,@cantidad
                                         ,@subtotal
                                         ,@idGolosina)
                                                      ";

                    cmdC.Parameters.AddWithValue("@idPedido", pedido.idPedido);
                    cmdC.Parameters.AddWithValue("@cantidad", detalles[i].cantidad);
                    cmdC.Parameters.AddWithValue("@subtotal", detalles[i].subtotal);
                    cmdC.Parameters.AddWithValue("@idGolosina", detalles[i].idGolosina);
                    cmdC.Transaction = tran;
                    cmdC.ExecuteNonQuery();
                }
                tran.Commit();
            }
            catch (SqlException ex)
            {
                tran.Rollback();
            }
            finally
            {
                con.Close();
            }
        }
    }
}
