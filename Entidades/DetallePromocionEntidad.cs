using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DetallePromocionEntidad
    {
        public int? idPromocion { get; set; }
        public int? idDetallePromocion { get; set; }
        public int cantidad { get; set; }
        public int idGolosina { get; set; }
        public float subtotal { get; set; }

    }
}
