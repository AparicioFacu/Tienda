using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentador.Presentadores
{
    class PresentadorEspecificacionProducto
    {
        private EspecificacionProducto _vistaEspecificaciones;
        private Repositorio _rep;
        private DataGridView tabla;        

        public PresentadorEspecificacionProducto(EspecificacionProducto vista, Repositorio rep, DataGridView dgv)
        {
            _vistaEspecificaciones = vista;
            _rep = rep;
            tabla = dgv;
        }
        public void Cargar(int codigo)
        {
            var codigoValido = false;
            foreach (var producto in _rep._productos)
            {
                if (codigo == producto.CodigoProducto)
                {
                    codigoValido = true;
                }
            }
            if (codigoValido)
            {
                tabla.DataSource = (from productos in _rep._productos
                                                           join stock in _rep._stocks
                                                           on productos.CodigoProducto equals stock.CodigoProducto.CodigoProducto
                                                           where productos.CodigoProducto == codigo
                                                           select new
                                                           {
                                                               Stock = stock.StockDisponible,
                                                               Talle = stock.talle.descripcion,
                                                               Color = stock.color.descripcion
                                                           }

                        ).ToList();
            }
        }
    }
}
