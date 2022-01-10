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
    public partial class VistaVenta : Form
    {

        private PresentadorListaProducto _presentadorLista;
        private PresentadorVenta _presentadorVenta;

        public VistaVenta()
        {
            InitializeComponent();
            _presentadorLista = new PresentadorListaProducto(this, dgvProductos);
            _presentadorVenta = new PresentadorVenta(this, dgvVentas);
        }
        private void VistaVenta_Load(object sender, EventArgs e)
        {
            _presentadorLista.LoadVenta();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
