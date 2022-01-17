
using AccesoExterno.Adaptadores;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentador.Presentadores
{
    public class PresentadorVenta
    {
        private VistaVenta vistaVenta;
        private DataGridView _tablaProductoVenta;
        private DataGridView _tablaVenta;
        private AdaptadorCliente _adaptadorCliente;
        private AdaptadorInventario _adaptadorInventario;
       
        public PresentadorVenta(VistaVenta vista, DataGridView tablaVenta, DataGridView tablaProductoVenta)
        {
            vistaVenta = vista;
            this._tablaProductoVenta = tablaProductoVenta;
            this._tablaVenta = tablaVenta;
        }
        public PresentadorVenta()
        {

        }
        public void LoadProductoVenta()
        {
            _adaptadorInventario = new AdaptadorInventario();
            List<Inventario> productos = _adaptadorInventario.GetProductos();
            _tablaProductoVenta.DataSource = (from inv in productos
                                              select new
                                              {
                                                  Codigo = inv.Producto.CodigoProducto,
                                                  Descripcion = inv.Producto.Descripcion,
                                                  TalleProducto = inv.Talle.Descripcion,
                                                  ColorProducto = inv.Color.Descripcion,
                                                  PrecioUnitario = inv.Producto.PrecioVenta,
                                                  StockDisponible = inv.StockDisponible
                                              }
                                              ).ToList();
        }

        public void BuscarCliente(TextBox txtCuit,TextBox txtCondicionTributario, TextBox txtNombre)
        {
            _adaptadorCliente = new AdaptadorCliente(txtCuit.Text);
            List<Cliente> clientes = _adaptadorCliente.GetCliente();
            foreach (var cli in clientes)
            {
                txtCondicionTributario.Text = cli.CondicionTributaria.Descripcion;
                txtNombre.Text = cli.Nombre;              
            }

        }
        public void AgregarCarrito(TextBox txtStock)
        {
            DataGridViewRow fila = _tablaProductoVenta.SelectedRows[0] as DataGridViewRow;

            String Codigo = fila.Cells["Codigo"].Value.ToString();
            String Descripcion = fila.Cells["Descripcion"].Value.ToString();
            String TalleProducto = fila.Cells["TalleProducto"].Value.ToString();
            String ColorProducto = fila.Cells["ColorProducto"].Value.ToString();
            String PrecioUnitario = fila.Cells["PrecioUnitario"].Value.ToString();
            String Cantidad = txtStock.Text;
            double CantidadSubTotal = double.Parse(txtStock.Text);
            double PrecioUnitarioSubTotal = double.Parse(PrecioUnitario);
            String SubTotal = (CantidadSubTotal * PrecioUnitarioSubTotal).ToString();

            _tablaVenta.Rows.Add(new[] { Codigo, Descripcion, TalleProducto, ColorProducto, PrecioUnitario, Cantidad, SubTotal });
        }
        public void FinalizarVenta()
        {

        }
    }

}
