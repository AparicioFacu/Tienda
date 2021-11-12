using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Stock
    {
        public int StockDisponible { get; set; }
        public Producto CodigoProducto { get; set; }
        public Talle talle { get; set; }
        public Color color { get; set; }

    }
}
