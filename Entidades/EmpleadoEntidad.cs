using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EmpleadoEntidad
    {
        public int? idEmpleado { get; set; }
        public string nombreYapellido { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public int? idRol { get; set; }
        public string nombreUsuario { get; set; }

        public static int int_NullValue = int.MinValue;
        public static string string_NullValue = "";
        public static DateTime dateTime_NullValue = DateTime.MinValue;
        public bool IsNew { get; set; }

        public EmpleadoEntidad()
        {
            idEmpleado = int_NullValue;
            nombreYapellido = string_NullValue;
            fechaNacimiento = dateTime_NullValue;
            idRol = int_NullValue;
            nombreUsuario = string_NullValue;
            IsNew = true;
        }
    }
}
