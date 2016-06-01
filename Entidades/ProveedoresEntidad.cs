using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ProveedoresEntidad
    {
        private string _nombre;
        public string nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        private int _idProveedor;
        public int idProveedor
        {
           get { return _idProveedor; }
           set { _idProveedor = value; }
        }

        private long _cuit;
        public long cuit
        {
            get { return _cuit; }
            set { _cuit = value; }
        }

        private DateTime _fechaAlta;
        public DateTime fechaAlta
        {
            get { return _fechaAlta; }
            set { _fechaAlta = value; }
        }

        private string _razonSocial;
        public string razonSocial
        {
            get { return _razonSocial; }
            set { _razonSocial = value; }
        }

        private string _domicilio;
        public string domicilio
        {
            get { return _domicilio; }
            set { _domicilio = value; }
        }

        private bool _esNacional;
        public bool esNacional
        {
            get { return _esNacional; }
            set { _esNacional = value; }
        }

        private int _idProvincia;
        public int idProvincia
        {
            get { return  _idProvincia;}
            set { _idProvincia = value; }
        }
    }
}
