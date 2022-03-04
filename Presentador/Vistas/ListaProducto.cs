using Presentador.Presentadores;
using Presentador.Vistas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentador
{
    public partial class ListaProducto : Form
    {
        private PresentadorListaProducto _presentadorLista;       
        public int codigo1;
        public ListaProducto()
        {
            InitializeComponent();
            _presentadorLista = new PresentadorListaProducto(this, dvgProductos, MenuInicio.idSucursal);
            btnBuscar.Enabled = false;
        }
        private void ListaProducto_Load(object sender, EventArgs e)
        {
            _presentadorLista.LoadProducto();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow fila = dvgProductos.SelectedRows[0] as DataGridViewRow;
                codigo1 = int.Parse(fila.Cells["Codigo"].Value.ToString());
                VistaModificarProducto vista = new VistaModificarProducto(codigo1, 1);
                vista.Show();
            }
            catch(Exception)
            {

            }
            
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow fila = dvgProductos.SelectedRows[0] as DataGridViewRow;
                codigo1 = int.Parse(fila.Cells["Codigo"].Value.ToString());
                VistaModificarProducto vista = new VistaModificarProducto(codigo1, 2);
                vista.Show();
            }
            catch (Exception)
            {

            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow fila = dvgProductos.SelectedRows[0] as DataGridViewRow;
                codigo1 = int.Parse(fila.Cells["Codigo"].Value.ToString());
                _presentadorLista.EliminarProducto(codigo1);
            }
            catch (Exception)
            {

            }            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            _presentadorLista.ActulizarTablaProducto();
        }
        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            _presentadorLista.BuscarProducto(txtBuscar);
        }
    }
}
