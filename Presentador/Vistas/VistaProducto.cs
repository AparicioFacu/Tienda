
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
    public partial class VistaProducto : Form
    {
        private PresentadorProducto _presentador;       
        int cod;
        public VistaProducto(int codigo)
        {
            InitializeComponent();
            cod = codigo;
            _presentador = new PresentadorProducto(this,cbxMarca,cbxRubro,cbxColor,cbxTipoTalle,cbxTalle, MenuInicio.idSucursal);
        }
        private void VistaProducto_Load(object sender, EventArgs e)
        {
            _presentador.Load();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {           
            panelTalleColor.Visible = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            _presentador.CargarTabla(dataGridView1);
            _presentador.Guardar(txtCodigo,txtCosto,txtDescripcion,txtMargenGanancia,txtPorcentajeIVA,txtPrecioFinal,cbxRubro,cbxMarca, cbxColor, cbxTalle, txtStock, cbxTipoTalle);          
        }
        private void cbxTipoTalle_SelectedIndexChanged(object sender, EventArgs e)
        {
            _presentador.ActualizarCbxTalle(cbxTipoTalle);
        }      
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("El producto se Agrego Correctamente");
            this.Close();
        }

        private void txtMargenGanancia_TextChanged(object sender, EventArgs e)
        {
            _presentador.CalcularPrecioFinal(txtMargenGanancia, txtCosto, txtPrecioFinal, txtPorcentajeIVA);
        }

        private void txtPorcentajeIVA_TextChanged(object sender, EventArgs e)
        {
            _presentador.CalcularPrecioFinal(txtMargenGanancia, txtCosto, txtPrecioFinal, txtPorcentajeIVA);
        }

        private void txtCosto_TextChanged(object sender, EventArgs e)
        {
            _presentador.CalcularPrecioFinal(txtMargenGanancia, txtCosto, txtPrecioFinal, txtPorcentajeIVA);
        }
    }
}
