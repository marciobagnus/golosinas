using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ClienteEntidad
    {
        public int? idCliente { get; set; }
        public int idTipoDocumento { get; set; }
        public string nombreYapellido { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public string sexo { get; set; }
        public string domicilio { get; set; }
        public int numeroDocumento { get; set; }
        //public string nombreUsuario { get; set; }

        public static int int_NullValue = int.MinValue;
        public static string string_NullValue = "";
        public static DateTime dateTime_NullValue = DateTime.MinValue;
        public bool IsNew { get; set; }

        public ClienteEntidad()
        {
            idCliente = int_NullValue;
            idTipoDocumento = int_NullValue;
            nombreYapellido = string_NullValue;
            fechaNacimiento = dateTime_NullValue;
            sexo = string_NullValue;
            domicilio = string_NullValue;
            numeroDocumento = int_NullValue;
            //nombreUsuario = string_NullValue;
            IsNew = true;
        }
    }
}
