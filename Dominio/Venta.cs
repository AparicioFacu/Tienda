using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Venta
    {
        public int? Id { get; set; }
        public DateTime fechaEmision { get; set; }
        public double SubTotal { get; set; }
        public double Total { get; set; }
        public Empleado Empleado { get; set; }
        public Cliente Cliente { get; set; }
        public Comprobante Comprobante { get; set; }
        public List<LineaVenta> LineaVentas { get; set; }
         
    }
}
