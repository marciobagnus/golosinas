using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TipoFacturaEntidad
    {
        public int? idTipoFactura { get; set; }
        public string descripcion { get; set; }

        public static int int_NullValue = int.MinValue;
        public static string string_NullValue = "";
        public bool IsNew { get; set; }

        public TipoFacturaEntidad()
        {
            idTipoFactura = int_NullValue;
            descripcion = string_NullValue;
            IsNew = true;
        }
    }
}
