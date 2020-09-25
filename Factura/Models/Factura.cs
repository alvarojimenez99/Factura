using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Factura.Models
{
    public class FacturaDatos
    {
        public int FacturaId { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
        public decimal Impuesto { get; set; }


    }
}