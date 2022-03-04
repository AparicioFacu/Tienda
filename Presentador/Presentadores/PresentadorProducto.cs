
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
        private AdaptadorProducto _adaptadorProducto2;
        private AdaptadorProducto _adaptadorBuscarProducto;
        private AdaptadorMarca _adaptadorMarca;
        private AdaptadorRubro _adaptadorRubro;
        private AdaptadorColor _adaptadorColor;
        private AdaptadorTipoTalle _adaptadorTipoTalle;
        private AdaptadorTalle _adaptadorTalle;
        private AdaptadorInventario _adaptadorInventario;
        private AdaptadorSucursal _adaptadorSucursal;
        //Vista
        private ComboBox cbxMarca;
        private ComboBox cbxRubro;
        private ComboBox cbxColor;
        private ComboBox cbxTipoTalle;
        private ComboBox cbxTalle;
        private DataGridView tablaTalleColor;
        private int idSucursal;

        //Dominio
        private Producto _producto = new Producto();
        private Inventario _newInventario;

        public PresentadorProducto(VistaProducto vista, ComboBox cbxMarca, ComboBox cbxRubro, ComboBox cbxColor, ComboBox cbxTipoTalle, ComboBox cbxTalle,int idSucursal)
        {           
            _vistaProducto = vista;
            this.cbxMarca = cbxMarca;
            this.cbxRubro = cbxRubro;
            this.cbxColor = cbxColor;
            this.cbxTipoTalle = cbxTipoTalle;
            this.cbxTalle = cbxTalle;
            this.idSucursal = idSucursal;
            _adaptadorSucursal = new AdaptadorSucursal();           
        }

        public void Load()
        {
            ActulizarCbxMarca();
            ActulizarCbxRubro();
            ActulizarCbxColor();
            ActulizarCbxTipoTalle();
        }
        public void CargarTabla(DataGridView tablaTalleColor)
        {
            this.tablaTalleColor = tablaTalleColor;
        }
        public void Guardar(TextBox txtCodigo, TextBox txtCosto, TextBox txtDescripcion, TextBox txtMargenGanancia, TextBox txtPorcentajeIVA, TextBox txtPrecioFinal, ComboBox cbxRubro, ComboBox cbxMarca, ComboBox cbxColor, ComboBox cbxTalle, TextBox txtStock, ComboBox cbxTipoTalle)
        {
            Producto _newProducto = new Producto();
            _adaptadorProducto = new AdaptadorProducto(txtCodigo.Text);
            List<Producto> productos = _adaptadorProducto.GetProducto();
            if(productos.Count == 0)
            {
                int idMarca = cbxMarca.SelectedIndex + 1;
                int idRubro = cbxRubro.SelectedIndex + 1;
                Marca _marca = new Marca(idMarca);
                Rubro _rubro = new Rubro(idRubro);
                _marca.Descripcion = cbxMarca.Text;
                _rubro.Descripcion = cbxRubro.Text;

                _newProducto.Marca = _marca;
                _newProducto.Rubro = _rubro;
                _newProducto.CodigoProducto = (txtCodigo.Text);
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
                string urlProducto = "https://localhost:44347/api/Product";
                _adaptadorProducto.Add<Producto>(urlProducto, _newProducto, "POST");
                AgregarTalleColorStock(_newProducto, txtCodigo, txtStock);
                CargarTabla(_newProducto, txtCodigo);
            }
            else
            {
                foreach (var pro in productos)
                {
                    if (pro.CodigoProducto == (txtCodigo.Text))
                    {
                        AgregarTalleColorStock(_newProducto, txtCodigo, txtStock);
                        CargarTabla(_newProducto, txtCodigo);
                    }
                }
            }
            

        }
        public void CargarTabla(Producto _newProducto, TextBox txtCodigo)
        {
                _adaptadorInventario = new AdaptadorInventario();
                List<Inventario> productos = _adaptadorInventario.GetProductos();
                var productosPorCodigo = productos.Where(p => p.Producto.CodigoProducto.Contains(txtCodigo.Text)).ToList();
                tablaTalleColor.DataSource = (from inv in productosPorCodigo
                                    select new
                                    {
                                        TalleProducto = inv.Talle.Descripcion,
                                        ColorProducto = inv.Color.Descripcion,
                                        StockDisponible = inv.StockDisponible
                                    }
                ).ToList();                      
        }
        public void AgregarTalleColorStock(Producto producto, TextBox txtCodigo, TextBox txtStock)
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

            _newInventario = new Inventario(_sucursal);
            _newInventario.Producto = producto;
            _newInventario.Color = _color;
            _newInventario.Talle = _talle;

            _adaptadorProducto2 = new AdaptadorProducto();

            List<Sucursal> sucursales = _adaptadorSucursal.GetSucursal();
            List<Producto> productos = _adaptadorProducto2.GetProductos();

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
                }
            }
            _newInventario.Color.Id = _color.Id;
            _newInventario.StockDisponible = int.Parse(txtStock.Text);
            _newInventario.Talle.Id = _talle.Id;

            _adaptadorInventario = new AdaptadorInventario();
            string urlInventario = "https://localhost:44347/api/Inventario";
            _adaptadorInventario.Add<Inventario>(urlInventario, _newInventario, "POST");
        }
        public void CalcularPrecioFinal(TextBox txtMargenGanancia, TextBox txtCosto, TextBox txtPrecioFinal, TextBox txtPorcentajeIVA)
        {
            if(!string.IsNullOrEmpty(txtMargenGanancia.Text) && !string.IsNullOrEmpty(txtCosto.Text) && !string.IsNullOrEmpty(txtPorcentajeIVA.Text))
            {
                _producto.Costo = double.Parse(txtCosto.Text);
                _producto.MargenGanancia = double.Parse(txtMargenGanancia.Text);
                _producto.PorcentajeIva = double.Parse(txtPorcentajeIVA.Text);
                _producto.NetoGravados();
                _producto.IVA();
                txtPrecioFinal.Text = _producto.precioFinal().ToString();
            }           
        }
        public void BuscarProducto(TextBox txtCodigo, TextBox txtCosto, TextBox txtDescripcion, TextBox txtMargenGanancia, TextBox txtPorcentajeIVA, TextBox txtPrecioFinal, ComboBox cbxRubro, ComboBox cbxMarca)
        {
            _adaptadorBuscarProducto = new AdaptadorProducto(txtCodigo.Text);           
            List<Producto> productos = _adaptadorBuscarProducto.GetProducto();
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
