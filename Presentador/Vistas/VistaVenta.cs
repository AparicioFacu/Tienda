using AccesoExterno.Adaptadores;
using Dominio;
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
        private PresentadorVenta _presentadorVenta;
        public int codigo1;

        public VistaVenta()
        {
            InitializeComponent();           
            _presentadorVenta = new PresentadorVenta(this, dgvVentas,dgvProductos);
        }
        private void VistaVenta_Load(object sender, EventArgs e)
        {
            _presentadorVenta.LoadProductoVenta();
            dgvVentas.AllowUserToAddRows = false;
        }
        private void btnCliente_Click(object sender, EventArgs e)
        {
            _presentadorVenta.BuscarCliente(txtCuit,txtCondicTributaria,txtNombre);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _presentadorVenta.AgregarCarrito(txtStock);
            _presentadorVenta.TotalVenta(txtTotal);
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            _presentadorVenta.FinalizarVenta(cbxPago,txtTotal,txtFecha,txtCuit);
            _presentadorVenta.ImprimirComprobante(txtNumVenta,txtCuit,txtNombre,txtCondicTributaria,dgvVentas,txtTotal);
        }

    }
}
