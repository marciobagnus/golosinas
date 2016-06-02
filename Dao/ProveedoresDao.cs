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
    public class ProveedoresDao
    {
        public static void Insertar(ProveedoresEntidad proveedor)
        {
            //Abrir la conexion
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["miConexion"].ConnectionString);
            con.Open();
            SqlTransaction tran = con.BeginTransaction();

            //Crear objeto command 
            SqlCommand cmdA = new SqlCommand();
            cmdA.Connection = con;
            cmdA.CommandText = @"SELECT max(idProveedor) FROM[BDGolosinas].[dbo].[Proveedor]";
            cmdA.Transaction = tran;

            try
            {
                SqlDataReader dr = cmdA.ExecuteReader();
                if (dr.Read())
                {
                    proveedor.idProveedor = 1 + int.Parse(dr[0].ToString());
                }
                dr.Close();
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = @"INSERT INTO [dbo].[Proveedor]
                            ([idProveedor]
                           ,[razonSocial]
                              ,[cuit]
                            ,[fechaAlta]
                           ,[esNacional]
                            ,[domicilio]
                             ,[idProvincia])
                            VALUES(@idProovedor,@razonSocial,@cuit, @fechaAlta,@esNacional,@domicilio,@idProvincia)";

                    cmd.Parameters.AddWithValue("@idProovedor", proveedor.idProveedor);
                    cmd.Parameters.AddWithValue("@razonSocial", proveedor.razonSocial);
                    cmd.Parameters.AddWithValue("@cuit", proveedor.cuit);
                    cmd.Parameters.AddWithValue("@fechaAlta", proveedor.fechaAlta);
                    cmd.Parameters.AddWithValue("@esNacional", proveedor.esNacional);
                    cmd.Parameters.AddWithValue("@domicilio", proveedor.domicilio);
                    cmd.Parameters.AddWithValue("@idProvincia", proveedor.idProvincia);

                    cmd.Transaction = tran;
                    cmd.ExecuteNonQuery();
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

        public static List<ProveedoresEntidad> ObtenerTodos()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["miConexion"].ConnectionString);
            con.Open();
            SqlCommand cmdA = new SqlCommand();
            cmdA.Connection = con;
            cmdA.CommandText = @"SELECT * FROM [dbo].[Proveedor]";
            SqlDataReader dr = cmdA.ExecuteReader();

            List<ProveedoresEntidad> listaProv = new List<ProveedoresEntidad>();

            while (dr.Read())
            {
                listaProv.Add(cargarProveedor(dr));
            }

            con.Close();
            return listaProv;

        }

        public static ProveedoresEntidad ObtenerPorId(int id)
        {
            //Abrir la conexion
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["miConexion"].ConnectionString);
            con.Open();
            //Crear objeto command 
            SqlCommand cmdA = new SqlCommand();
            cmdA.Connection = con;
            cmdA.CommandText = @"SELECT * FROM[BDGolosinas].[dbo].[Proveedor] WHERE idProveedor =@id";
            cmdA.Parameters.AddWithValue("@id", id);
            SqlDataReader dr = cmdA.ExecuteReader();

            if (dr.Read())
            {
                ProveedoresEntidad prov = cargarProveedor(dr);
                return prov;
                con.Close();
            }
            else
            {
                con.Close();
                return null;
            }
        }

        private static ProveedoresEntidad cargarProveedor(SqlDataReader dr)
        {
            ProveedoresEntidad prov = new ProveedoresEntidad();
            prov.idProveedor = int.Parse(dr[0].ToString());
            prov.razonSocial = dr[1].ToString();
            prov.cuit = long.Parse(dr[2].ToString());
            prov.fechaAlta = DateTime.Parse(dr[3].ToString());
            prov.esNacional = (bool)dr[4];
            prov.domicilio = dr[5].ToString();
            prov.idProvincia = int.Parse(dr[6].ToString());

            return prov;

        }

        public static void eliminarProveedor(int id)
        {
            //Abrir la conexion
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["miConexion"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = @"DELETE FROM Proveedor WHERE idProveedor = @id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            con.Close();


        }

        public static void actualizarProveedor(ProveedoresEntidad proveedor)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["miConexion"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = @"UPDATE [dbo].[Proveedor]
                                 SET    
                           [razonSocial]=@razonSocial
                              ,[cuit]=@cuit
                            ,[fechaAlta]=@fechaAlta
                           ,[esNacional]=@esNacional
                            ,[domicilio]=@domicilio
                             ,[idProvincia]=@idProvincia
                                 WHERE [idProveedor]=@idProovedor "
                ;
            cmd.Parameters.AddWithValue("@idProovedor", proveedor.idProveedor);
            cmd.Parameters.AddWithValue("@razonSocial", proveedor.razonSocial);
            cmd.Parameters.AddWithValue("@cuit", proveedor.cuit);
            cmd.Parameters.AddWithValue("@fechaAlta", proveedor.fechaAlta);
            cmd.Parameters.AddWithValue("@esNacional", proveedor.esNacional);
            cmd.Parameters.AddWithValue("@domicilio", proveedor.domicilio);
            cmd.Parameters.AddWithValue("@idProvincia", proveedor.idProvincia);

            cmd.ExecuteNonQuery();
            con.Close();
        }

    }






}
