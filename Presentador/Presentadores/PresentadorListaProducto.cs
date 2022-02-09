using AccesoExterno;
using AccesoExterno.Adaptadores;
using Dominio;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentador.Presentadores
{
    class PresentadorListaProducto
    {
        private ListaProducto _vistaListaProducto;       
        private DataGridView tabla;
        private AdaptadorProducto _adaptadorProducto;
        private AdaptadorInventario _adaptadorInventario;

        public PresentadorListaProducto(ListaProducto vista, DataGridView dgv)
        {
            _vistaListaProducto = vista;
            tabla = dgv;
        }
        public void LoadProducto()
        {
            ActulizarTablaProducto();                     
        }       
        public void VerMasProducto(int codigo,DataGridView dgvTalleColor)
        {
            _adaptadorInventario = new AdaptadorInventario();
            List<Inventario> productos = _adaptadorInventario.GetProductos();
            dgvTalleColor.DataSource = (from inv in productos
                                where inv.Producto.CodigoProducto == codigo.ToString()
                                select new
                                {
                                    TalleProducto = inv.Talle.Descripcion,
                                    ColorProducto = inv.Color.Descripcion,
                                    StockDisponible = inv.StockDisponible
                                }
                ).ToList();
        }

        public void ActulizarTablaProducto()
        {
            _adaptadorProducto = new AdaptadorProducto();           
            List<Producto> productos = _adaptadorProducto.GetProductos();            
            tabla.DataSource = (from prod in productos
                                select new
                                {
                                    Codigo = prod.CodigoProducto,
                                    Descripcion = prod.Descripcion,
                                    Costo = prod.Costo,
                                    PorcentajeIva = prod.PorcentajeIva,
                                    NombreMarca = prod.Marca.Descripcion,
                                    NombreRubro = prod.Rubro.Descripcion,
                                    PrecioVenta = prod.PrecioVenta
                                }
                ).ToList();
        }       
    }
}
