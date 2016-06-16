using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class GolosinaEntidad
    {
        public GolosinaEntidad() { }

        public int? idGolosina { get; set; }
        public string nombre { get; set; }
        public float precioCompra { get; set; }
        public float precioVenta { get; set; }
        public int stockActual { get; set; }
        public int stockMinimo { get; set; }
        public bool listoParaPedir { get; set; }
        public int idTipoGolosina { get; set; }
        public bool esAptoCeliaco { get; set; }


    }
}
