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
    public partial class Menu : Form
    {
        private readonly PresentadorPrincipal _presentador;
        public Menu()
        {
            InitializeComponent();
            _presentador = new PresentadorPrincipal(this);
        }

        private void btnProducto_Click(object sender, EventArgs e)
        {
            _presentador.IniciarVistaProducto(this);
        }
        private void VistaProducto_VisibleChanged(object sender, EventArgs e)
        {
            _presentador.VP_VisibleChanged(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VistaVenta vista = new VistaVenta();
            vista.Show();
        }
    }
}
