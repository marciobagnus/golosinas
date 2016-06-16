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
    public class EmpleadoDao
    {
        public static string stringConexion()
        {
            return ConfigurationManager.ConnectionStrings["miConexion"].ConnectionString;
        }

        public static List<EmpleadoEntidad> ObtenerTodosEmpleados()
        {
            List<EmpleadoEntidad> empleados = new List<EmpleadoEntidad>();

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = stringConexion();
            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = @"SELECT * FROM Empleado";
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                EmpleadoEntidad e = new EmpleadoEntidad();

                e.idEmpleado = int.Parse(dr["idEmpleado"].ToString());
                e.nombreYapellido = dr["nombreYApellido"].ToString();
                e.fechaNacimiento = DateTime.Parse(dr["fechaNacimiento"].ToString());
                e.idRol = int.Parse(dr["idRol"].ToString());
                e.nombreUsuario = dr["nombreUsuario"].ToString();

                empleados.Add(e);
            }
            dr.Close();
            cn.Close();
            return empleados;
        }
    }
}
