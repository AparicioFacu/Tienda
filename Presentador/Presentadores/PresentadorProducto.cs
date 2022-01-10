
using AccesoExterno.Adaptadores;
using Dominio;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace Presentador.Presentadores
{
    class PresentadorProducto
    {
        private VistaProducto _vistaProducto;
        //Adaptadores
        private AdaptadorProducto _adaptadorProducto;
        private AdaptadorMarca _adaptadorMarca;
        private AdaptadorRubro _adaptadorRubro;
        private AdaptadorColor _adaptadorColor;
        private AdaptadorTipoTalle _adaptadorTipoTalle;
        private AdaptadorTalle _adaptadorTalle;
        //Vista
        private DataGridView tabla;
        private ComboBox cbxMarca;
        private ComboBox cbxRubro;
        private ComboBox cbxColor;
        private ComboBox cbxTipoTalle;
        private ComboBox cbxTalle;

        private Producto _producto = new Producto();

        public PresentadorProducto(VistaProducto vista, DataGridView dgv, ComboBox cbxMarca, ComboBox cbxRubro, ComboBox cbxColor, ComboBox cbxTipoTalle, ComboBox cbxTalle)
        {
            tabla = dgv;
            _vistaProducto = vista;
            this.cbxMarca = cbxMarca;
            this.cbxRubro = cbxRubro;
            this.cbxColor = cbxColor;
            this.cbxTipoTalle = cbxTipoTalle;
            this.cbxTalle = cbxTalle;
        }

        public void Load(int cod, ComboBox cbxColor, ComboBox cbxMarca, ComboBox cbxRubro, ComboBox cbxTalle,ComboBox cbxTipoTalle)
        {
            ActulizarCbxMarca();
            ActulizarCbxRubro();
            ActulizarCbxColor();
            ActulizarCbxTipoTalle();
        }
        public void Agregar(ComboBox cbxColor, ComboBox cbxTalle, TextBox txtStock)
        {
            tabla.Rows.Add(cbxColor.Text, cbxTalle.Text, Convert.ToInt32(txtStock.Text));
        }
        public void Guardar(TextBox txtCodigo, TextBox txtCosto, TextBox txtDescripcion, TextBox txtMargenGanancia, TextBox txtPorcentajeIVA, TextBox txtPrecioFinal, ComboBox cbxRubro, ComboBox cbxMarca, ComboBox cbxColor, ComboBox cbxTalle, TextBox txtStock)
        {
            int idMarca = cbxMarca.SelectedIndex +1;
            int idRubro = cbxRubro.SelectedIndex +1;
            Marca _marca = new Marca(idMarca);
            Rubro _rubro = new Rubro(idRubro);
            _marca.Descripcion = cbxMarca.Text;
            _rubro.Descripcion = cbxRubro.Text;


            Producto _newProducto = new Producto(_marca, _rubro);
   
            _newProducto.CodigoProducto = int.Parse(txtCodigo.Text);
            _newProducto.Costo = Double.Parse(txtCosto.Text);
            _newProducto.Descripcion = txtDescripcion.Text;
            _newProducto.MargenGanancia = Double.Parse(txtMargenGanancia.Text);
            _newProducto.PorcentajeIva = Double.Parse(txtPorcentajeIVA.Text);
            _newProducto.NetoGravado = _newProducto.NetoGravados();
            _newProducto.Iva = _newProducto.IVA();
            _newProducto.PrecioVenta = Double.Parse(txtPrecioFinal.Text);            
            _newProducto.Marca.Id = _marca.Id;
            _newProducto.Rubro.Id = _rubro.Id;

            _adaptadorProducto = new AdaptadorProducto();

            string url = "https://localhost:44347/api/Product";
            _adaptadorProducto.Add<Producto>(url,_newProducto, "POST");
            
        }
      
        public void CalcularPrecioFinal(TextBox txtMargenGanancia, TextBox txtCosto, TextBox txtPrecioFinal, TextBox txtPorcentajeIVA)
        {
            _producto.Costo = double.Parse(txtCosto.Text);
            _producto.MargenGanancia = double.Parse(txtMargenGanancia.Text);
            _producto.PorcentajeIva = double.Parse(txtPorcentajeIVA.Text);
            _producto.NetoGravados();
            _producto.IVA();
            txtPrecioFinal.Text = _producto.precioFinal().ToString();
        }

        /// <summary>
        /// Rellenar Combo Box
        /// </summary>
        public void ActulizarCbxMarca()
        {
            _adaptadorMarca = new AdaptadorMarca();
            cbxMarca.DataSource = _adaptadorMarca.GetMarcas();
            cbxMarca.ValueMember = "Id";
            cbxMarca.DisplayMember = "descripcion";
        }

        public void ActulizarCbxRubro()
        {
            _adaptadorRubro = new AdaptadorRubro();
            cbxRubro.DataSource = _adaptadorRubro.GetRubros();
            cbxRubro.ValueMember = "Id";
            cbxRubro.DisplayMember = "descripcion";
        }

        public void ActulizarCbxColor()
        {
            _adaptadorColor = new AdaptadorColor();
            cbxColor.DataSource = _adaptadorColor.GetColor();
            cbxColor.ValueMember = "Id";
            cbxColor.DisplayMember = "Descripcion";
        }
        public void ActulizarCbxTipoTalle()
        {
            _adaptadorTipoTalle = new AdaptadorTipoTalle();
            cbxTipoTalle.DataSource = _adaptadorTipoTalle.GetTipoTalle();
            cbxTipoTalle.ValueMember = "Id";
            cbxTipoTalle.DisplayMember = "Descripcion";
        }
        public void ActualizarCbxTalle(ComboBox cbxTipoTalle)
        {
            int idTipoTalle = cbxTipoTalle.SelectedIndex + 1;
            _adaptadorTalle = new AdaptadorTalle(idTipoTalle);
            cbxTalle.DataSource = _adaptadorTalle.GetTalle();
            cbxTalle.ValueMember = "Id";
            cbxTalle.DisplayMember = "Descripcion";
        }
    }
}
