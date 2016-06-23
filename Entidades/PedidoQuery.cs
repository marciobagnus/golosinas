using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class PedidoQuery
    {
        public string razonSocial { get; set; }
        public DateTime fechaPedido { get; set; }
        public double total { get; set; }
        public string apeNom { get; set; }
    }
}
