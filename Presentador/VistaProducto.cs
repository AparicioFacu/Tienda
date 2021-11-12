using Datos;
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
    public partial class VistaProducto : Form
    {
        private PresentadorProducto _presentador;
        int cod;
        public VistaProducto(int codigo, Repositorio rep)
        {
            InitializeComponent();
            cod = codigo;
            _presentador = new PresentadorProducto(this, rep, dgvEspecificaciones);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void VistaProducto_Load(object sender, EventArgs e)
        {
            _presentador.Load(cod, cbxColor, cbxMarca, cbxRubro, cbxTalle);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            _presentador.Agregar(cbxColor, cbxTalle,txtStock);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
           _presentador.Guardar(txtCodigo,txtCosto,txtDescripcion,txtMargenGanancia,txtPorcentajeIVA,txtPrecioFinal,cbxRubro,cbxMarca, cbxColor, cbxTalle, txtStock);
        }
    }
}
