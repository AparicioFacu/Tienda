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

namespace Presentador.Vistas
{
    public partial class VistaModificarProducto : Form
    {
        PresentadorModificarProducto _presentador;
        int codigo;
        public VistaModificarProducto(int codigo,int valor)
        {
            if(valor == 1)
            {
                InitializeComponent();
                this.codigo = codigo;
                _presentador = new PresentadorModificarProducto(this, codigo, MenuInicio.idSucursal);
                Disable();
            }
            if(valor == 2)
            {
                InitializeComponent();
                this.codigo = codigo;
                _presentador = new PresentadorModificarProducto(this, codigo, MenuInicio.idSucursal);
            }
            
        }

        private void VistaModificarProducto_Load(object sender, EventArgs e)
        {
            _presentador.Load(txtCodigo,txtCosto,txtDescripcion,txtMargenGanancia,txtPorcentajeIVA,txtPrecioFinal,txtStock,cbxColor,cbxMarca,cbxRubro,cbxTalle,cbxTipoTalle,dataGridView1);
        }
        public void Disable()
        {
            txtCodigo.Enabled = false;
            txtCosto.Enabled = false;
            txtDescripcion.Enabled = false;
            txtMargenGanancia.Enabled = false;
            txtPorcentajeIVA.Enabled = false;
            txtPrecioFinal.Enabled = false;
            txtStock.Enabled = false;
            cbxColor.Enabled = false;
            cbxMarca.Enabled = false;
            cbxRubro.Enabled = false;
            cbxTalle.Enabled = false;
            cbxTipoTalle.Enabled = false;
            dataGridView1.Enabled = false;
            btnGuardar.Visible = false;
            button1.Visible = false;
            btnEliminar.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _presentador.ModificarProducto(txtCosto,txtDescripcion,txtMargenGanancia,txtPorcentajeIVA,txtPrecioFinal,cbxMarca,cbxRubro);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
           // _presentador.CargarTabla(dataGridView1);
            _presentador.Agregar(txtCodigo, cbxColor, cbxTalle, txtStock, cbxTipoTalle, dataGridView1);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            _presentador.Eliminar(txtCodigo, dataGridView1);
        }

        private void txtMargenGanancia_TextChanged(object sender, EventArgs e)
        {
            _presentador.CalcularPrecioFinal(txtMargenGanancia, txtCosto, txtPrecioFinal, txtPorcentajeIVA);
        }

        private void txtCosto_TextChanged(object sender, EventArgs e)
        {
            _presentador.CalcularPrecioFinal(txtMargenGanancia, txtCosto, txtPrecioFinal, txtPorcentajeIVA);
        }

        private void txtPorcentajeIVA_TextChanged(object sender, EventArgs e)
        {
            _presentador.CalcularPrecioFinal(txtMargenGanancia, txtCosto, txtPrecioFinal, txtPorcentajeIVA);
        }

        private void cbxTipoTalle_SelectedIndexChanged(object sender, EventArgs e)
        {
            _presentador.ActualizarCbxTalle(cbxTalle,cbxTipoTalle);
        }
    }
}
