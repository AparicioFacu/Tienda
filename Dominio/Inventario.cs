using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Inventario
    {
        public int StockDisponible { get; set; }
        public Producto Producto { get; set; }
        public Talle Talle { get; set; }
        public Color Color { get; set; }
        public Sucursal Sucursal { get; set; }

        public Inventario()
        {

        }
        public Inventario(Sucursal suc)
        {
            this.Sucursal = suc;
        }
    }
}
