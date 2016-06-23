using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class FacturaEntidad
    {
        public int? idFactura { get; set; }
        public int? idTipoFactura { get; set; }
        public DateTime fecha { get; set; }
        public int? idEmpleado { get; set; }
        public double total { get; set; }
        public int? idCliente { get; set; }
    }
}
