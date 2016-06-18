using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class PedidoEntidad
    {
        public int? idPedido { get; set; }
        public int? nroPedido { get; set; }
        public int idProveedor { get; set; }
        public DateTime fechaPedido { get; set; }
        public DateTime fechaEntrega { get; set; }
        public int idEmpleado { get; set; }
        public double total { get; set; }
    }
}
