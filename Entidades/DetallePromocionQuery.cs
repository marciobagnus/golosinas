using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DetallePromocionQuery: DetallePromocionEntidad
    {
        public string nombre { get; set; }
        public float precioVenta { get; set; }
        public float totalParcial { get; set; }
    }
}
