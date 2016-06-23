using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class FacturaXClienteXEmpleadoEntidad
    {
        public int? idCliente { get; set; }
        public string nombreYapellidoCliente { get; set; }
        public int? idEmpleado { get; set; }
        public string nombreYapellidoEmpleado { get; set; }
        public int? idFactura { get; set; }
        public DateTime fechaFactura { get; set; }
        public decimal totalFactura { get; set; }

        //public static int int_NullValue = int.MinValue;
        //public static string string_NullValue = "";
        //public static DateTime dateTime_NullValue = DateTime.MinValue;
        //public static decimal decimal_NullValue = decimal.MinValue;
        //public bool IsNew { get; set; }

        //public FacturaXClienteXEmpleadoEntidad()
        //{
        //    idCliente = int_NullValue;
        //    nombreYapellidoCliente = string_NullValue;
        //    idEmpleado = int_NullValue;
        //    nombreYapellidoEmpleado = string_NullValue;
        //    idFactura = int_NullValue;
        //    fechaFactura = dateTime_NullValue;
        //    totalFactura = decimal_NullValue;
        //    IsNew = true;
        //}
    }
}
