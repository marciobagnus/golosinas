using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
      public class ProvinciaEntidad
    {
        private int _idProvincia;
            public int idProvincia
        {
            get { return _idProvincia; }
            set { _idProvincia = value; }
        }
        private string _nombre;
        public string nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
    }
}
