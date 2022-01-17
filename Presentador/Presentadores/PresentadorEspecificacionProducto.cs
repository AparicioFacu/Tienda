
using AccesoExterno.Adaptadores;
using Dominio;
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
        private AdaptadorInventario _adaptadorInventario;
        private DataGridView tabla;

        public PresentadorEspecificacionProducto(EspecificacionProducto vista, DataGridView dgv)
        {
            _vistaEspecificaciones = vista;
            tabla = dgv;
        }
        public PresentadorEspecificacionProducto()
        {
        }
        public void Cargar(int codigo)
        {
            _adaptadorInventario = new AdaptadorInventario();
            List<Inventario> productos = _adaptadorInventario.GetProductos();
            tabla.DataSource = (from inv in productos
                                where inv.Producto.CodigoProducto == codigo
                                select new
                                {

                                    TalleProducto = inv.Talle.Descripcion,
                                    ColorProducto = inv.Color.Descripcion,
                                    StockDisponible = inv.StockDisponible
                                }
                ).ToList();
        }

    }
}
