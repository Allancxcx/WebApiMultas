using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi4645.Entidad
{
        public class Clientes
        {

            public int codigo_cliente { get; set; }
            public string nombre { get; set; }
            public string apellido { get; set; }
            public string dirección { get; set; }
            public string telefono { get; set; }
            public string codigo_de_credito { get; set; }
            public string tipo_de_credito { get; set; }
            public decimal monto_préstamo { get; set; }
            public decimal abono { get; set; }
            public decimal saldo { get; set; }
            public int estado_eliminado { get; set; }

        }
    
}