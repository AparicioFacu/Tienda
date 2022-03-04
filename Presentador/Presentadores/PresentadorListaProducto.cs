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
        int idSucursal;
        public PresentadorListaProducto()
        {
        }
        public PresentadorListaProducto(ListaProducto vista, DataGridView dgv,int idSucursal)
        {
            _vistaListaProducto = vista;
            tabla = dgv;
            this.idSucursal = idSucursal;
        }
        public void LoadProducto()
        {
            ActulizarTablaProducto();                     
        }             
        public void ActulizarTablaProducto()
        {
            _adaptadorInventario = new AdaptadorInventario();
            List<Inventario> inventario = _adaptadorInventario.GetProductos();
            tabla.DataSource = (from prod in inventario
                                where prod.Sucursal.Id == idSucursal
                                select new
                                {
                                    Codigo = prod.Producto.CodigoProducto,
                                    Descripcion = prod.Producto.Descripcion,
                                    Costo = prod.Producto.Costo,
                                    PorcentajeIva = prod.Producto.PorcentajeIva,
                                    NombreMarca = prod.Producto.Marca.Descripcion,
                                    NombreRubro = prod.Producto.Rubro.Descripcion,
                                    PrecioVenta = prod.Producto.PrecioVenta
                                }
                ).Distinct().ToList();           
        }
        public void BuscarProducto(TextBox codigo)
        {
            if (codigo.Text.Length==0)
            {
                ActulizarTablaProducto();
            }
            else
            {
                _adaptadorInventario = new AdaptadorInventario();
                List<Inventario> inventario = _adaptadorInventario.GetProductos();
                tabla.DataSource = (from prod in inventario
                                    where prod.Sucursal.Id == idSucursal
                                    where prod.Producto.CodigoProducto == codigo.Text
                                    select new
                                    {
                                        Codigo = prod.Producto.CodigoProducto,
                                        Descripcion = prod.Producto.Descripcion,
                                        Costo = prod.Producto.Costo,
                                        PorcentajeIva = prod.Producto.PorcentajeIva,
                                        NombreMarca = prod.Producto.Marca.Descripcion,
                                        NombreRubro = prod.Producto.Rubro.Descripcion,
                                        PrecioVenta = prod.Producto.PrecioVenta
                                    }
                    ).Distinct().ToList();
            }            
        }
        public void EliminarProducto(int codigo)
        {
            _adaptadorInventario = new AdaptadorInventario(codigo.ToString());
            List<Inventario> inventario = _adaptadorInventario.GetProducto();
            foreach (var inv in inventario)
            {
                string urlInventario = "https://localhost:44347/api/Inventario";
                _adaptadorInventario = new AdaptadorInventario();
                _adaptadorInventario.Delete<Inventario>(urlInventario, inv, "DELETE");
            }
            _adaptadorProducto = new AdaptadorProducto(codigo.ToString());
            List<Producto> producto = _adaptadorProducto.GetProducto();
            foreach (var pro in producto)
            {
                string urlProducto = "https://localhost:44347/api/Product";
                _adaptadorProducto = new AdaptadorProducto();
                _adaptadorProducto.Delete<Producto>(urlProducto, pro, "DELETE");
            }
            ActulizarTablaProducto();
        }
    }
}
