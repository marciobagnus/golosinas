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
    public class GolosinaDao
    {
        public static void Insertar(GolosinaEntidad golosina)
        {


            if (!Existe(golosina.nombre))
            {
                SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["miConexion"].ConnectionString);
                cn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = @"INSERT into Golosina(nombre,
                                precioCompra, precioVenta,
                                stockActual, stockMinimo,
                                listoParaPedir, idTipoGolosina, esAptoCeliaco)
                                values(@nombre,
                                @precioCompra, @precioVenta,
                                @stockActual, @stockMinimo,
                                @listoParaPedir, @idTipoGolosina, @esAptoCeliaco);select Scope_Identity() as ID";

                cmd.Parameters.AddWithValue("@nombre", golosina.nombre);
                cmd.Parameters.AddWithValue("@precioCompra", golosina.precioCompra);
                cmd.Parameters.AddWithValue("@precioVenta", golosina.precioVenta);
                cmd.Parameters.AddWithValue("@stockActual", golosina.stockActual);
                cmd.Parameters.AddWithValue("@stockMinimo", golosina.stockMinimo);
                cmd.Parameters.AddWithValue("@listoParaPedir", golosina.listoParaPedir);
                cmd.Parameters.AddWithValue("@idTipoGolosina", golosina.idTipoGolosina);
                cmd.Parameters.AddWithValue("@esAptoCeliaco", golosina.esAptoCeliaco);

                golosina.idGolosina = Convert.ToInt32(cmd.ExecuteScalar());

                cn.Close();
            }
            else
            {
                throw new ApplicationException("El nombre ya existe");
            }

           

        }

        private static bool Existe(string nombre)
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["miConexion"].ConnectionString);
            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = @"SELECT COUNT(*) FROM Golosina WHERE nombre=@nombre";


            cmd.Parameters.AddWithValue("@nombre", nombre);
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count == 0)
                return false;
            else
                return true;
        }

        public static List<GolosinaEntidad> ObtenerPorIncremento(string incr)
        {
            List<GolosinaEntidad> listGolosinas = new List<GolosinaEntidad>();
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["miConexion"].ConnectionString);
            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = @"SELECT idGolosina, nombre,
                                precioCompra, precioVenta,
                                stockActual, stockMinimo,
                                listoParaPedir, idTipoGolosina, esAptoCeliaco
                                FROM Golosina where nombre Like @incr";
                    
            cmd.Parameters.AddWithValue("@incr", incr + "%");
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                GolosinaEntidad g = new GolosinaEntidad();
               g.idGolosina = int.Parse(dr["idGolosina"].ToString());
                g.nombre = dr["nombre"].ToString();
                g.precioCompra = float.Parse(dr["precioCompra"].ToString());
                g.precioVenta = float.Parse(dr["precioVenta"].ToString());
                g.stockActual = int.Parse(dr["stockActual"].ToString());
                g.stockMinimo = int.Parse(dr["stockMinimo"].ToString());
                g.listoParaPedir = (bool)dr["listoParaPedir"];
                g.idTipoGolosina = int.Parse(dr["idTipoGolosina"].ToString());
                g.esAptoCeliaco = (bool)dr["esAptoCeliaco"];

                listGolosinas.Add(g);

            }
            dr.Close();
            cn.Close();
            return listGolosinas;

        }


        public static void Actualizar(GolosinaEntidad golosina)
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["miConexion"].ConnectionString);
            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = @"UPDATE Golosina SET nombre=@nombre,
                                precioCompra=@precioCompra, precioVenta=@precioVenta,
                                stockActual=@stockActual, stockMinimo=@stockMinimo,
                                listoParaPedir=@listoParaPedir, idTipoGolosina=@idTipoGolosina,
                                esAptoCeliaco=@esAptoCeliaco
                                WHERE idGolosina=@idGolosina";

            cmd.Parameters.AddWithValue("@idGolosina", golosina.idGolosina);
            cmd.Parameters.AddWithValue("@nombre", golosina.nombre);
            cmd.Parameters.AddWithValue("@precioCompra", golosina.precioCompra);
            cmd.Parameters.AddWithValue("@precioVenta", golosina.precioVenta);
            cmd.Parameters.AddWithValue("@stockActual", golosina.stockActual);
            cmd.Parameters.AddWithValue("@stockMinimo", golosina.stockMinimo);
            cmd.Parameters.AddWithValue("@listoParaPedir", golosina.listoParaPedir);
            cmd.Parameters.AddWithValue("@idTipoGolosina", golosina.idTipoGolosina);
            cmd.Parameters.AddWithValue("@esAptoCeliaco", golosina.esAptoCeliaco);

            cmd.ExecuteNonQuery();

            cn.Close();

        }

        public static void Eliminar(int id)
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["miConexion"].ConnectionString);
            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = @"DELETE from Golosina WHERE idGolosina=@idGolosina";

            cmd.Parameters.AddWithValue("@idGolosina", id);

            cmd.ExecuteNonQuery();

            cn.Close();
        }

        public static List<GolosinaEntidad> ObtenerTodos()
        {
            List<GolosinaEntidad> listaGolosinas = new List<GolosinaEntidad>();
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["miConexion"].ConnectionString);
            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = @"SELECT idGolosina, nombre,
                                precioCompra, precioVenta,
                                stockActual, stockMinimo,
                                listoParaPedir, idTipoGolosina, esAptoCeliaco
                                FROM Golosina";
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                GolosinaEntidad g = new GolosinaEntidad();

                g.idGolosina = int.Parse(dr["idGolosina"].ToString());
                g.nombre = dr["nombre"].ToString();
                g.precioCompra = float.Parse(dr["precioCompra"].ToString());
                g.precioVenta = float.Parse(dr["precioVenta"].ToString());
                g.stockActual = int.Parse(dr["stockActual"].ToString());
                g.stockMinimo = int.Parse(dr["stockMinimo"].ToString());
                g.listoParaPedir = (bool)dr["listoParaPedir"];
                g.idTipoGolosina = int.Parse(dr["idTipoGolosina"].ToString());
                g.esAptoCeliaco = (bool)dr["esAptoCeliaco"];

                listaGolosinas.Add(g);

            }
            dr.Close();
            cn.Close();
            return listaGolosinas;
        }

        public static GolosinaEntidad ObtenerPorID(int id)
        {
            GolosinaEntidad g = null;

            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["miConexion"].ConnectionString);
            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = @"SELECT idGolosina, nombre,
                                precioCompra, precioVenta,
                                stockActual, stockMinimo,
                                listoParaPedir, idTipoGolosina, esAptoCeliaco
                                FROM Golosina where idGolosina=@id";
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                g = new GolosinaEntidad();
                g.idGolosina = int.Parse(dr["idGolosina"].ToString());
                g.nombre = dr["nombre"].ToString();
                g.precioCompra = float.Parse(dr["precioCompra"].ToString());
                g.precioVenta = float.Parse(dr["precioVenta"].ToString());
                g.stockActual = int.Parse(dr["stockActual"].ToString());
                g.stockMinimo = int.Parse(dr["stockMinimo"].ToString());
                g.listoParaPedir = (bool)dr["listoParaPedir"];
                g.idTipoGolosina = int.Parse(dr["idTipoGolosina"].ToString());
                g.esAptoCeliaco = (bool)dr["esAptoCeliaco"];

            }
            dr.Close();
            cn.Close();
            return g;

        }
    }
}
