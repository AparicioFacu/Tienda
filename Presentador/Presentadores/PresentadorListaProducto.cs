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
        private VistaVenta _listaProductoVenta;        
        private DataGridView tabla;
        private AdaptadorProducto _adaptadorProducto;

        public PresentadorListaProducto(ListaProducto vista, DataGridView dgv)
        {
            _vistaListaProducto = vista;
            tabla = dgv;
        }
        public PresentadorListaProducto(VistaVenta vista, DataGridView dgv)
        {
            _listaProductoVenta = vista;
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
        public void LoadVenta()
        {           
            ActulizarTablaVenta();

            DataGridViewButtonColumn btngrid = new DataGridViewButtonColumn();
            btngrid.Name = "Especificaciones";
            btngrid.HeaderText = "Visualizar Especificaciones";
            btngrid.Text = "Ver Mas";
            btngrid.UseColumnTextForButtonValue = true;
            tabla.Columns.Add(btngrid);
        }
        public void VerMas(int codigo)
        {       
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
            tabla.DataSource = productos;
        }

        public void ActulizarTablaVenta()
        {            
        }
    }
}
