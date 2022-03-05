using AccesoExterno.Adaptadores;
using Dominio;
using Presentador.Vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentador.Presentadores
{
    public class PresentadorModificarProducto
    {
        VistaModificarProducto vista;
        //Adaptadores
        private AdaptadorProducto _adaptadorBuscarProducto;
        private AdaptadorProducto _adaptadorProducto;
        private AdaptadorInventario _adaptadorInventario;
        private AdaptadorMarca _adaptadorMarca;
        private AdaptadorRubro _adaptadorRubro;
        private AdaptadorColor _adaptadorColor;
        private AdaptadorTipoTalle _adaptadorTipoTalle;
        private AdaptadorTalle _adaptadorTalle;
        private AdaptadorSucursal _adaptadorSucursal;
        //Dominio
        List<Producto> productos;
        Producto _producto = new Producto();
        int codigo;
        private int idSucursal;
        public PresentadorModificarProducto(VistaModificarProducto vista,int codigo, int idSucursal)
        {
            this.vista = vista;
            this.codigo = codigo;
            this.idSucursal = idSucursal;
            _adaptadorSucursal = new AdaptadorSucursal();
        }
        public void Load(TextBox txtCodigo, TextBox txtCosto, TextBox txtDescripcion, TextBox txtMargenGanancia, TextBox txtPorcentajeIVA, TextBox txtPrecioFinal, TextBox txtStock, ComboBox cbxColor, ComboBox cbxMarca, ComboBox cbxRubro, ComboBox cbxTalle, ComboBox cbxTipoTalle, DataGridView dgvTalleColor)
        {
            ActulizarCbxMarca(cbxMarca);
            ActulizarCbxRubro(cbxRubro);
            ActulizarCbxColor(cbxColor);
            ActulizarCbxTipoTalle(cbxTipoTalle);
            ActualizarCbxTalle(cbxTalle, cbxTipoTalle);
            txtCodigo.Text = codigo.ToString();
            BuscarProducto(txtCodigo, txtCosto, txtDescripcion, txtMargenGanancia, txtPorcentajeIVA, txtPrecioFinal, cbxRubro, cbxMarca);
            TalleColor(codigo, dgvTalleColor);            
        }
        public void BuscarProducto(TextBox txtCodigo, TextBox txtCosto, TextBox txtDescripcion, TextBox txtMargenGanancia, TextBox txtPorcentajeIVA, TextBox txtPrecioFinal, ComboBox cbxRubro, ComboBox cbxMarca)
        {
            _adaptadorBuscarProducto = new AdaptadorProducto(txtCodigo.Text);
            productos = _adaptadorBuscarProducto.GetProducto();
            foreach (var pro in productos)
            {
                txtCodigo.Text = pro.CodigoProducto.ToString();
                txtCosto.Text = pro.Costo.ToString();
                txtDescripcion.Text = pro.Descripcion.ToString();
                txtMargenGanancia.Text = pro.MargenGanancia.ToString();
                txtPorcentajeIVA.Text = pro.PorcentajeIva.ToString();
                txtPrecioFinal.Text = pro.PrecioVenta.ToString();
                cbxMarca.Text = pro.Marca.Descripcion;
                cbxRubro.Text = pro.Rubro.Descripcion;
            }

        }         
        public void TalleColor(int codigo, DataGridView dgvTalleColor)
        {
            _adaptadorInventario = new AdaptadorInventario();
            List<Inventario> inventarios = _adaptadorInventario.GetProductos();
            dgvTalleColor.DataSource = (from inv in inventarios
                                        where inv.Producto.CodigoProducto == codigo.ToString()
                                        select new
                                        {
                                            TalleProducto = inv.Talle.Descripcion,
                                            ColorProducto = inv.Color.Descripcion,
                                            StockDisponible = inv.StockDisponible
                                        }                                        
                ).ToList();            
        }
        public void ModificarProducto(TextBox txtCosto, TextBox txtDescripcion, TextBox txtMargenGanancia, TextBox txtPorcentajeIVA, TextBox txtPrecioFinal, ComboBox cbxMarca, ComboBox cbxRubro)
        {
            //Producto
            foreach (var pro in productos)
            {
                pro.Costo = Double.Parse(txtCosto.Text);
                pro.Descripcion = txtDescripcion.Text;
                pro.MargenGanancia = Double.Parse(txtMargenGanancia.Text);
                pro.PorcentajeIva = Double.Parse(txtPorcentajeIVA.Text);
                pro.PrecioVenta = Double.Parse(txtPrecioFinal.Text);
                pro.Marca.Descripcion = cbxMarca.Text;
                pro.Rubro.Descripcion = cbxRubro.Text;
            }
            foreach (var pro in productos)
            {
                _adaptadorProducto = new AdaptadorProducto();
                _adaptadorProducto.Put(pro);
            }
            
        }      
        public void Agregar(TextBox txtCodigo, ComboBox cbxColor, ComboBox cbxTalle, TextBox txtStock, ComboBox cbxTipoTalle, DataGridView dgvTalleColor)
        {
            int idColor = cbxColor.SelectedIndex + 1;
            int idTipoTalle = cbxTipoTalle.SelectedIndex + 1;
            int idTalle = 0;

            if (idTipoTalle == 1)
            {
                idTalle = cbxTalle.SelectedIndex + 7;
            }
            if (idTipoTalle == 2)
            {
                idTalle = cbxTalle.SelectedIndex + 1;
            }
            if (idTipoTalle == 3)
            {
                idTalle = cbxTalle.SelectedIndex + 17;
            }

            Talle _talle = new Talle(idTalle);
            _talle.Descripcion = cbxTalle.Text;
            TipoTalle _tipoTalle = new TipoTalle(idTipoTalle);
            _tipoTalle.Descripcion = cbxTipoTalle.Text;
            Color _color = new Color(idColor);
            _color.Descripcion = cbxColor.Text;
            Sucursal _sucursal = new Sucursal();

            Inventario _newInventario = new Inventario(_sucursal);
            _newInventario.Producto = new Producto();
            _newInventario.Color = _color;
            _newInventario.Talle = _talle;

            _adaptadorProducto = new AdaptadorProducto();

            List<Sucursal> sucursales = _adaptadorSucursal.GetSucursal();
            List<Producto> productos = _adaptadorProducto.GetProductos();

            foreach (var suc in sucursales)
            {
                if (suc.Id == idSucursal)
                {
                    _newInventario.Sucursal.Id = suc.Id;
                }
            }
            foreach (var pro in productos)
            {
                if (pro.CodigoProducto == (txtCodigo.Text))
                {
                    _newInventario.Producto.Id = pro.Id;
                    _newInventario.Producto = pro;
                }
            }
            _newInventario.Color.Id = _color.Id;
            _newInventario.StockDisponible = int.Parse(txtStock.Text);
            _newInventario.Talle.Id = _talle.Id;

            _adaptadorInventario = new AdaptadorInventario();
            _adaptadorInventario.Post(_newInventario);
            TalleColor(codigo, dgvTalleColor);

        }
        public void Eliminar(TextBox codigo, DataGridView dgvTalleColor)
        {
            _adaptadorInventario = new AdaptadorInventario(codigo.Text);
            List<Inventario> inventario = _adaptadorInventario.GetProducto();
            foreach (var inv in inventario)
            {
                _adaptadorInventario = new AdaptadorInventario();
                _adaptadorInventario.Delete(inv);
            }
            TalleColor(int.Parse(codigo.Text), dgvTalleColor);
        }
        public void CalcularPrecioFinal(TextBox txtMargenGanancia, TextBox txtCosto, TextBox txtPrecioFinal, TextBox txtPorcentajeIVA)
        {
            if (!string.IsNullOrEmpty(txtMargenGanancia.Text) && !string.IsNullOrEmpty(txtCosto.Text) && !string.IsNullOrEmpty(txtPorcentajeIVA.Text))
            {
                _producto.Costo = double.Parse(txtCosto.Text);
                _producto.MargenGanancia = double.Parse(txtMargenGanancia.Text);
                _producto.PorcentajeIva = double.Parse(txtPorcentajeIVA.Text);
                _producto.NetoGravados();
                _producto.IVA();
                txtPrecioFinal.Text = _producto.precioFinal().ToString();
            }
        }
        public void ActulizarCbxMarca(ComboBox cbxMarca)
        {
            _adaptadorMarca = new AdaptadorMarca();
            cbxMarca.DataSource = _adaptadorMarca.GetMarcas();
            cbxMarca.ValueMember = "Id";
            cbxMarca.DisplayMember = "descripcion";
        }
        public void ActulizarCbxRubro(ComboBox cbxRubro)
        {
            _adaptadorRubro = new AdaptadorRubro();
            cbxRubro.DataSource = _adaptadorRubro.GetRubros();
            cbxRubro.ValueMember = "Id";
            cbxRubro.DisplayMember = "descripcion";
        }
        public void ActulizarCbxColor(ComboBox cbxColor)
        {
            _adaptadorColor = new AdaptadorColor();
            cbxColor.DataSource = _adaptadorColor.GetColor();
            cbxColor.ValueMember = "Id";
            cbxColor.DisplayMember = "Descripcion";
        }
        public void ActulizarCbxTipoTalle(ComboBox cbxTipoTalle)
        {
            _adaptadorTipoTalle = new AdaptadorTipoTalle();
            cbxTipoTalle.DataSource = _adaptadorTipoTalle.GetTipoTalle();
            cbxTipoTalle.ValueMember = "Id";
            cbxTipoTalle.DisplayMember = "Descripcion";
        }
        public void ActualizarCbxTalle(ComboBox cbxTalle, ComboBox cbxTipoTalle)
        {
            int idTipoTalle = cbxTipoTalle.SelectedIndex + 1;
            _adaptadorTalle = new AdaptadorTalle(idTipoTalle);
            cbxTalle.DataSource = _adaptadorTalle.GetTalle();
            cbxTalle.ValueMember = "Id";
            cbxTalle.DisplayMember = "Descripcion";
        }
    }
}
