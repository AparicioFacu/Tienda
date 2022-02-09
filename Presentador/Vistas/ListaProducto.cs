using Presentador.Presentadores;
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
            _presentadorLista = new PresentadorListaProducto(this, dvgProductos);           
        }

        private void ListaProducto_Load(object sender, EventArgs e)
        {
            _presentadorLista.LoadProducto();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DataGridViewRow fila = dvgProductos.SelectedRows[0] as DataGridViewRow;

             codigo1 = int.Parse(fila.Cells["Codigo"].Value.ToString());
             _presentadorLista.VerMasProducto(codigo1, dgvTalleColor);
             panel1.Visible = true;
            
        }
    }
}
