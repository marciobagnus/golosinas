using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class GolosinasXCarritoEntidad
    {
        private string _nombre;
        public string nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        private int _idGolosina;
        public int idGolosina
        {
            get { return _idGolosina; }
            set { _idGolosina = value; }
        }
        private double _subtotal;
        public double subtotal
        {
            get { return _subtotal; }
            set { _subtotal = value; }
        }

        private double _precioUnitario;
        public double precioUnitario
        {
            get { return _precioUnitario; }
            set { _precioUnitario = value; }
        }

        private int _cantidad;
        public int cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; }
        }
    }
}
