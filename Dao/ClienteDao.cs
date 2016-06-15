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
    public class ClienteDao
    {
        public static string stringConexion()
        {
            return ConfigurationManager.ConnectionStrings["miConexion"].ConnectionString;
        }

        public static void InsertarCliente(ClienteEntidad cliente)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = stringConexion();
            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = @"INSERT into Cliente(idTipoDocumento, nombreYApellido, 
                                fechaNacimiento, sexo, domicilio,   
                                numeroDocumento)
                                values(@idTipoDoc,
                                @nombreYap, @fechaNac,
                                @sexo, @domicilio,
                                @numDoc);select Scope_Identity() as ID";

            cmd.Parameters.AddWithValue("@idTipoDoc", cliente.idTipoDocumento);
            cmd.Parameters.AddWithValue("@nombreYap", cliente.nombreYapellido);
            cmd.Parameters.AddWithValue("@fechaNac", cliente.fechaNacimiento);
            cmd.Parameters.AddWithValue("@sexo", cliente.sexo);
            cmd.Parameters.AddWithValue("@domicilio", cliente.domicilio);
            cmd.Parameters.AddWithValue("@numDoc", cliente.numeroDocumento);
            //cmd.Parameters.AddWithValue("@nomUsuario", cliente.nombreUsuario);   

           cliente.idCliente = Convert.ToInt32(cmd.ExecuteScalar());

            cn.Close();
        }

        public static void ActualizarCliente(ClienteEntidad cliente)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = stringConexion();
            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = @"UPDATE Cliente SET idTipoDocumento=@idTipoDoc,
                                nombreYApellido=@nombreYap, fechaNacimiento=@fechaNac,
                                sexo=@sexo, domicilio=@domicilio,
                                numeroDocumento=@numDoc
                                WHERE idCliente=@idCliente";

            cmd.Parameters.AddWithValue("@idCliente", cliente.idCliente);
            cmd.Parameters.AddWithValue("@idTipoDoc", cliente.idTipoDocumento);
            cmd.Parameters.AddWithValue("@nombreYap", cliente.nombreYapellido);
            cmd.Parameters.AddWithValue("@fechaNac", cliente.fechaNacimiento);
            cmd.Parameters.AddWithValue("@sexo", cliente.sexo);
            cmd.Parameters.AddWithValue("@domicilio", cliente.domicilio);
            cmd.Parameters.AddWithValue("@numDoc", cliente.numeroDocumento);
            //cmd.Parameters.AddWithValue("@nomusuario", cliente.nombreUsuario);

            cmd.ExecuteNonQuery();

            cn.Close();
        }

        public static void EliminarCliente(int id)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = stringConexion();
            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = @"DELETE from Cliente WHERE idCliente=@idCliente";

            cmd.Parameters.AddWithValue("@idCliente", id);

            cmd.ExecuteNonQuery();

            cn.Close();
        }

        public static List<ClienteEntidad> ObtenerTodosClientes()
        {
            List<ClienteEntidad> clientes = new List<ClienteEntidad>();

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = stringConexion();
            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = @"SELECT * FROM Cliente";
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                ClienteEntidad c = new ClienteEntidad();

                c.idCliente = int.Parse(dr["idCliente"].ToString());
                c.idTipoDocumento = int.Parse(dr["idTipoDocumento"].ToString());
                c.nombreYapellido = dr["nombreYApellido"].ToString();
                c.fechaNacimiento = DateTime.Parse(dr["fechaNacimiento"].ToString());
                c.sexo = dr["sexo"].ToString();
                c.domicilio = dr["domicilio"].ToString();
                c.numeroDocumento = int.Parse(dr["numeroDocumento"].ToString());
                //c.nombreUsuario = dr["nombreUsuario"].ToString();

                clientes.Add(c);
            }
            dr.Close();
            cn.Close();
            return clientes;
        }

        public static ClienteEntidad ObtenerClientesPorID(int id)
        {
            ClienteEntidad c = null;

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = stringConexion();
            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = @"SELECT *
                                FROM Cliente where idCliente=@id";
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                c = new ClienteEntidad();

                c.idCliente = int.Parse(dr["idCliente"].ToString());
                c.idTipoDocumento = int.Parse(dr["idTipoDocumento"].ToString());
                c.nombreYapellido = dr["nombreYApellido"].ToString();
                c.fechaNacimiento = DateTime.Parse(dr["fechaNacimiento"].ToString());
                c.sexo = dr["sexo"].ToString();
                c.domicilio = dr["domicilio"].ToString();
                c.numeroDocumento = int.Parse(dr["numeroDocumento"].ToString());
                //c.nombreUsuario = dr["nombreUsuario"].ToString();
            }
            dr.Close();
            cn.Close();
            return c;
        }
    }
}
