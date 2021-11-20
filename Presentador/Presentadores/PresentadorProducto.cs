using Datos;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentador.Presentadores
{
    class PresentadorProducto
    {
        private VistaProducto _vistaProducto;
        private Repositorio _rep;
        private DataGridView tabla;

        private Producto _producto = new Producto();
        private Stock _stock = new Stock();        

        public PresentadorProducto(VistaProducto vista, Repositorio rep, DataGridView dgv)
        {
            tabla = dgv;
            _vistaProducto = vista;
            _rep = rep;
        }

        public void Load(int cod, ComboBox cbxColor, ComboBox cbxMarca, ComboBox cbxRubro, ComboBox cbxTalle)
        {
            cbxColor.DataSource = _rep._colores;
            cbxColor.ValueMember = "descripcion";
            cbxColor.DisplayMember = "descripcion"; 
            cbxMarca.DataSource = _rep._marcas;
            cbxMarca.ValueMember = "descripcion";
            cbxMarca.DisplayMember = "descripcion";
            cbxRubro.DataSource = _rep._rubros;
            cbxRubro.ValueMember = "descripcion";
            cbxRubro.DisplayMember = "descripcion";
            cbxTalle.DataSource = _rep._talles;
            cbxTalle.ValueMember = "descripcion";
            cbxTalle.DisplayMember = "descripcion";
        }

        public void Agregar(ComboBox cbxColor, ComboBox cbxTalle, TextBox txtStock)
        {
            tabla.Rows.Add(cbxColor.Text, cbxTalle.Text, Convert.ToInt32(txtStock.Text));      
        }
        public void Guardar(TextBox txtCodigo, TextBox txtCosto, TextBox txtDescripcion, TextBox txtMargenGanancia, TextBox txtPorcentajeIVA, TextBox txtPrecioFinal, ComboBox cbxRubro, ComboBox cbxMarca, ComboBox cbxColor, ComboBox cbxTalle, TextBox txtStock)
        {
            _stock.StockDisponible = Convert.ToInt32(txtStock.Text);
            _stock.color = new Color()
            {
                descripcion = cbxColor.Text
            };
            _stock.talle = new Talle()
            {
                descripcion = cbxTalle.Text
            };
            _stock.CodigoProducto = new Producto()
            {
                CodigoProducto = Convert.ToInt32(txtCodigo.Text),
                Costo = Convert.ToDouble(txtCosto.Text),
                Descripcion = txtDescripcion.Text,
                MargenGanacia = Convert.ToDouble(txtMargenGanancia.Text),
                PorcentajeIva = Convert.ToDouble(txtPorcentajeIVA.Text),
                //PrecioFinal = Convert.ToDouble(txtPrecioFinal.Text),               
                
            };
            MessageBox.Show(_stock.CodigoProducto.CodigoProducto.ToString());
            _rep.AgregarStock(_stock);
            _rep.AgregarProducto(_stock.CodigoProducto);                       
        }
    }
}
