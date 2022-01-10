using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class LineaVenta
    {
        public int Cantidad { get; set; }
        public double PrecioUnitario { get; set; }
        public double Total { get; set; }
        public Producto _productos { get; set; }

        public double PrecioFinal()
        {
            Total = PrecioUnitario * Cantidad;
            return Total;
        }
    }

    


}
