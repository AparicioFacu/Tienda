using AccesoExterno.Adaptadores;
using Dominio;
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
    public partial class VistaVenta : Form
    {
        private PresentadorVenta _presentadorVenta;
        public int codigo1;

        public VistaVenta()
        {
            InitializeComponent();           
            _presentadorVenta = new PresentadorVenta(this, dgvVentas,dgvProductos, MenuInicio.idSucursal);
            txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtFecha.Enabled = false;
            txtTotal.Enabled = false;
            txtNumVenta.Enabled = false;
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
            _presentadorVenta.TotalVenta(txtTotal,txtCuit,txtCondicTributaria,txtNombre);
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            _presentadorVenta.FinalizarVenta(cbxPago,txtTotal,txtFecha,txtCuit,txtNumVenta,txtCondicTributaria);
            _presentadorVenta.ImprimirComprobante(txtNumVenta,txtCuit,txtNombre,txtCondicTributaria,dgvVentas,txtTotal);
            Limpiar();
        }
        public void Limpiar()
        {
            txtBuscar.Text = "";
            txtCondicTributaria.Text = "";
            txtCuit.Text = "";
            txtFecha.Text = "";
            txtNombre.Text = "";
            txtNumVenta.Text = "";
            txtStock.Text = "";
            txtTotal.Text = "";
            cbxPago.Text = "";
            dgvVentas.Rows.Clear();
            panelCliente.Visible = true;
        }

        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            panelCliente.Visible = false;
        }

        private void btnCrearCliente_Click(object sender, EventArgs e)
        {

        }

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            _presentadorVenta.BuscarProducto(txtBuscar);
        }
    }
}
