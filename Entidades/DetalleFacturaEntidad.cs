using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DetalleFacturaEntidad
    {
        public int? idFactura { get; set; }
        public int? idDetalleFactura { get; set; }
        public int cantidad { get; set; }
        public int? idPromocion { get; set; }
        public string nombre { get; set; }
        public double precioPromocion { get; set; }
        public double subtotal { get; set; }
        public int? idGolosina { get; set; }
        //public string nombreGolosina { get; set; }
        public double precioGolosina { get; set; }
    }
}

