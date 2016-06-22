using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class PromocionEntidad
    {
        public int? idPromocion { get; set; }
        public string nombre { get; set; }
        public DateTime fechaDesde { get; set; }
        public DateTime fechaHasta { get; set; }
        public float total { get; set; }
        public int? idEmpleado { get; set; }
        public float descuento { get; set; }
    }
}
