using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DetallePedidoEntidad
    {
        public int? idPedido { get; set; }
        public int? idDetallePedido { get; set; }
        public int cantidad { get; set; }
        public double subtotal { get; set; }
        public int? idGolosina { get; set; }
        public string nombreGolosina { get; set; }
        public  double precioGolosina { get; set; }
    }
}
