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
        private EspecificacionProducto _especificacionProducto;
        private DataGridView tabla;
        private AdaptadorProducto _adaptadorProducto;       

        public PresentadorListaProducto(ListaProducto vista, DataGridView dgv)
        {
            _vistaListaProducto = vista;
            tabla = dgv;
        }
        public void LoadProducto()
        {
            ActulizarTablaProducto();          

            DataGridViewButtonColumn btngrid = new DataGridViewButtonColumn();
            btngrid.Name = "Especificaciones";
            btngrid.HeaderText = "Visualizar Especificaciones";
            btngrid.Text = "Ver Mas";
            btngrid.UseColumnTextForButtonValue = true;
            tabla.Columns.Add(btngrid);
        }       
        public void VerMasProducto(int codigo)
        {
            _especificacionProducto = new EspecificacionProducto(codigo);
            _especificacionProducto.Show();
        }
        public void Agregar()
        {
            var cod = 0;
            var vistaProducto = new VistaProducto(cod);
            vistaProducto.ShowDialog();
            ActulizarTablaProducto();
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
