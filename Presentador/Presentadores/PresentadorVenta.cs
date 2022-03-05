
using AccesoExterno.Adaptadores;
using Dominio;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System;
using System.Collections.Generic;
using System.IO;
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
        int idSucursal;
        ///Adaptadores
        private AdaptadorCliente _adaptadorCliente;
        private AdaptadorInventario _adaptadorInventario;
        private AdaptadorVenta _adaptadorVenta;
        //Dominio
        private LineaVenta _lineaVenta;
        private Venta _venta = new Venta();
        private List<LineaVenta> _listaLineaVenta = new List<LineaVenta>();
        private Empleado _empleado = new Empleado();
        private Sucursal _surcursal = new Sucursal();
        private Comprobante _comprobante = new Comprobante();
        private Inventario _inventario = new Inventario();
        private List<Inventario> _inventarios = new List<Inventario>();
        //AFIP
        private ServiceSolicitarAFIP.ServiceSoapClient _serviceSolicitarAFIP;
        int ultimoComprobante;
        private long _cuit;
        private string _token;
        private string _sign;
        private Producto[] asd = new Producto[0];
        public PresentadorVenta(VistaVenta vista, DataGridView tablaVenta, DataGridView tablaProductoVenta,int idSucursal)
        {
            vistaVenta = vista;
            this.idSucursal = idSucursal;
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
                                              where inv.Sucursal.Id == idSucursal
                                              select new
                                              {
                                                  Codigo = inv.Producto.CodigoProducto,
                                                  Descripcion = inv.Producto.Descripcion,
                                                  TalleProducto = inv.Talle.Descripcion,
                                                  ColorProducto = inv.Color.Descripcion,
                                                  PrecioUnitario = inv.Producto.PrecioVenta,
                                                  MarcaPro = inv.Producto.Marca.Descripcion,
                                                  StockDisponible = inv.StockDisponible
                                              }
                                              ).Distinct().ToList();
        }
        public void BuscarCliente(TextBox txtCuit, TextBox txtCondicionTributario, TextBox txtNombre)
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
            if(txtStock.Text.Equals(""))
            {
                MessageBox.Show("Ingresa la cantidad a comprar");
                return;
            }
            else
            {
                AgregarLineaVenta(txtStock);
                String Codigo = _lineaVenta._productos.Producto.CodigoProducto.ToString();
                String Descripcion = _lineaVenta._productos.Producto.Descripcion;
                String TalleProducto = _lineaVenta._productos.Talle.Descripcion;
                String ColorProducto = _lineaVenta._productos.Color.Descripcion;
                String PrecioUnitario = _lineaVenta.PrecioUnitario.ToString();
                String Cantidad = _lineaVenta.Cantidad.ToString();
                String SubTotal = _lineaVenta.Total.ToString();

                _tablaVenta.Rows.Add(new[] { Codigo, Descripcion, TalleProducto, ColorProducto, PrecioUnitario, Cantidad, SubTotal });
                int stock = _lineaVenta._productos.StockDisponible - int.Parse(txtStock.Text);
                int? id = _lineaVenta._productos.Id;
                _adaptadorInventario = new AdaptadorInventario(id);
                List<Inventario> inv = _adaptadorInventario.GetProductoPorId();
                foreach(var i in inv)
                {
                    i.Id = _lineaVenta._productos.Id;
                    i.StockDisponible = stock;
                    _inventarios.Add(i);
                }                                
            }

        }
        public void FinalizarVenta(ComboBox cbxPago, TextBox txtTotal, TextBox txtFecha, TextBox txtCuit,TextBox txtNumVenta, TextBox txtCondicTributaria)
        {         
            _venta.fechaEmision = DateTime.Now;
            _venta.SubTotal = double.Parse(txtTotal.Text);
            _venta.Total = double.Parse(txtTotal.Text);
            _venta.Empleado = new Empleado
            {
                Id = 1,
                Legajo = "44444",
                Nombre = "Facundo"
            };
            _empleado = _venta.Empleado;
            foreach (var cli in _adaptadorCliente.GetCliente())
            {
                if (txtCuit.Text.Equals(cli.Cuit))
                {
                    _venta.Cliente = new Cliente
                    {
                        Id = cli.Id,
                        Cuit = cli.Cuit,
                        CondicionTributaria = cli.CondicionTributaria,
                        Direccion = cli.Direccion,
                        Nombre = cli.Nombre
                    };
                }
            }
            if(txtCondicTributaria.Text.Equals("Responsable Inscripto") || txtCondicTributaria.Text.Equals("Monotributo"))
            {
                _venta.Comprobante = new Comprobante
                {
                    Id = 1,
                    Descripcion = "Factura A"
                };
            }
            else
            {
                _venta.Comprobante = new Comprobante
                {
                    Id = 2,
                    Descripcion = "Factura B"
                };
            }           
            _comprobante = _venta.Comprobante;
            _venta.LineaVentas = _listaLineaVenta;            
            SolicitarAutorizacion();
            ultimoComprobante = FECompUltimoAutorizado() + 1;
            txtNumVenta.Text = ultimoComprobante.ToString();
            FECAESolicitar(txtCuit,txtTotal,txtFecha,_comprobante.Id);           
            _adaptadorVenta = new AdaptadorVenta();
            _adaptadorVenta.Post(_venta);
            modificarStock(_inventarios);
        }
        public void AgregarLineaVenta(TextBox txtStock)
        {
            
            try
            {               
                DataGridViewRow fila = _tablaProductoVenta.SelectedRows[0] as DataGridViewRow;
                if (int.Parse(txtStock.Text) > int.Parse(fila.Cells["StockDisponible"].Value.ToString()))
                {
                    MessageBox.Show("No hay stock Disponible");
                    return;
                }
                _lineaVenta = new LineaVenta();
                foreach (var inv in _adaptadorInventario.GetProductos())
                {
                    if (fila.Cells["Codigo"].Value.ToString().Equals(inv.Producto.CodigoProducto))
                    {
                        _lineaVenta._productos = new Inventario
                        {
                            Id = inv.Id,
                            StockDisponible = inv.StockDisponible,
                            Producto = inv.Producto,
                            Color = inv.Color,
                            Sucursal = inv.Sucursal,
                            Talle = inv.Talle
                        };                       
                        _inventario = _lineaVenta._productos;
                    }
                }
                _lineaVenta._sucursal = _lineaVenta._productos.Sucursal;
                _surcursal = _lineaVenta._sucursal;
                _lineaVenta.PrecioUnitario = _lineaVenta._productos.Producto.PrecioVenta;
                _lineaVenta.Cantidad = int.Parse(txtStock.Text);
                _lineaVenta.PrecioFinal();               
                _listaLineaVenta.Add(_lineaVenta);
            }
            catch (Exception)
            {

            }
        }
        public void modificarStock(List<Inventario> newInventario)
        {
            foreach (var inv in newInventario)
            {
                _adaptadorInventario = new AdaptadorInventario();
                _adaptadorInventario.Put(inv);
            }

        }
        public void TotalVenta(TextBox txtTotal, TextBox txtCuit, TextBox txtCondicTributaria, TextBox txtNombre)
        {
            double total = _listaLineaVenta.Sum(item => item.Total);
            txtTotal.Text = total.ToString();           
            txtCuit.Text = "10222222222";
            if (total <= 10000)
            {
                BuscarCliente(txtCuit, txtCondicTributaria, txtNombre);
            }
            else
            {
                txtCuit.Text = "";
            }
            
        }
        public void BuscarProducto(TextBox codigo)
        {
            if (codigo.Text.Length == 0)
            {
                LoadProductoVenta();
            }
            else
            {
                _adaptadorInventario = new AdaptadorInventario();
                List<Inventario> productos = _adaptadorInventario.GetProductos();
                _tablaProductoVenta.DataSource = (from inv in productos
                                                  where inv.Sucursal.Id == idSucursal
                                                  where inv.Producto.CodigoProducto == codigo.Text
                                                  select new
                                                  {
                                                      Codigo = inv.Producto.CodigoProducto,
                                                      Descripcion = inv.Producto.Descripcion,
                                                      TalleProducto = inv.Talle.Descripcion,
                                                      ColorProducto = inv.Color.Descripcion,
                                                      PrecioUnitario = inv.Producto.PrecioVenta,
                                                      MarcaPro = inv.Producto.Marca.Descripcion,
                                                      StockDisponible = inv.StockDisponible
                                                  }
                                                  ).Distinct().ToList();
            }
        }
        public void SolicitarAutorizacion()
        {
            var GUID = "44B486BA-F7BA-4C11-9877-1C142F59179C";
            var oServicio = new ServiceAFIP.LoginServiceClient();
            var datos = oServicio.SolicitarAutorizacion(GUID);
            _cuit = datos.Cuit;
            _token = datos.Token;
            _sign = datos.Sign;
        }
        public void FECAESolicitar(TextBox txtCuit, TextBox txtTotal, TextBox txtFecha,int? tipoComprobante)
        {
            double total = Double.Parse(txtTotal.Text);           
            double neto = total - (total * 0.21);
            double iva = neto * 0.21;
            double totalNetoIva = neto + iva;
            total = totalNetoIva;
            total = Math.Round(total, 2);
            iva = Math.Round(iva, 2);
            long cuit = Convert.ToInt64(txtCuit.Text);
            _serviceSolicitarAFIP = new ServiceSolicitarAFIP.ServiceSoapClient();
            var auth = new ServiceSolicitarAFIP.FEAuthRequest();
            auth.Cuit = _cuit;
            auth.Sign = _sign;
            auth.Token = _token;
            //Comprabante Completo    
            var feCaeRequest = new ServiceSolicitarAFIP.FECAERequest();
            //cabezera del comprobante
            feCaeRequest.FeCabReq = new ServiceSolicitarAFIP.FECAECabRequest();
            feCaeRequest.FeCabReq.CantReg = 1;
            feCaeRequest.FeCabReq.CbteTipo = (int)tipoComprobante;
            feCaeRequest.FeCabReq.PtoVta = 20;
            //detalle del comprobante           
            feCaeRequest.FeDetReq = new ServiceSolicitarAFIP.FECAEDetRequest[]
            {
                new ServiceSolicitarAFIP.FECAEDetRequest()
                {

                    Concepto = 1,//Productos
                    DocTipo = 80,//CUIT
                    DocNro = cuit,
                    CbteDesde = ultimoComprobante,
                    CbteHasta = ultimoComprobante,
                    CbteFch = DateTime.Now.ToString("yyyyMMdd"),                   
                    ImpTotal = total,
                    ImpTotConc = 0,
                    ImpNeto = neto,
                    ImpOpEx = 0,
                    ImpTrib = 0,
                    ImpIVA = iva,
                    MonId = "PES",
                    MonCotiz = 1,                   
                    Iva = new ServiceSolicitarAFIP.AlicIva[]
                    {
                        new ServiceSolicitarAFIP.AlicIva()
                        {
                            Id = 5,
                            BaseImp = neto,
                            Importe = iva,
                        }
                    }
                }
            };            
            var FECAE = _serviceSolicitarAFIP.FECAESolicitar(auth, feCaeRequest);
            string resultado = FECAE.FeDetResp[0].Resultado;
            VerificarResultado(resultado);           
        }
        public int FECompUltimoAutorizado()
        {
            _serviceSolicitarAFIP = new ServiceSolicitarAFIP.ServiceSoapClient();
            var auth = new ServiceSolicitarAFIP.FEAuthRequest();
            auth.Cuit = _cuit;
            auth.Sign = _sign;
            auth.Token = _token;
            return _serviceSolicitarAFIP.FECompUltimoAutorizado(auth, 20, 1).CbteNro;
        }
        public void VerificarResultado(string resultado)
        {
            if(resultado == "A")
            {
                MessageBox.Show("Comprobante Autorizado por AFIP");
            }
            if (resultado == "P")
            {
                MessageBox.Show("Comprobante ParcialMente Autorizado por AFIP");
            }
            if (resultado == "R")
            {
                MessageBox.Show("Comprobante Rechazado por AFIP");
            }
        }
        public void ImprimirComprobante(TextBox txtNumVenta, TextBox txtCuit, TextBox txtNombre, TextBox txtCondicTributaria, DataGridView dgvVentas, TextBox txtTotal)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = string.Format("{0}.pdf", DateTime.Now.ToString("ddMMyyyyHHmmss"));
            string PaginaHTML_Texto = Properties.Resources.Plantilla.ToString();
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@DIRECCION", _surcursal.Direccion);
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@CONDICIONTRIBUTARIA", txtCondicTributaria.Text);
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@FECHA", DateTime.Now.ToString("dd/MM/yyyy"));
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@TIPOFACTURA", _comprobante.Descripcion);
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@NUMEROVENTA", txtNumVenta.Text);           
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@CLIENTE", txtNombre.Text);
            if(txtNombre.Text.Equals("Consumidor Final"))
            {
                PaginaHTML_Texto = PaginaHTML_Texto.Replace("@CUIT", txtNombre.Text);
            }
            else
            {
                PaginaHTML_Texto = PaginaHTML_Texto.Replace("@CUIT", txtCuit.Text);
            }
            
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@TOTAL", txtTotal.Text);

            string filas = string.Empty;

            foreach (DataGridViewRow row in dgvVentas.Rows)
            {
                filas += "<tr>";
                filas += "<td>" + row.Cells["Cantidad"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Descripcion"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["PrecioUnitario"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["SubTotal"].Value.ToString() + "</td>";
                filas += "</tr>";
            }
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@FILAS", filas);

            if (savefile.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(savefile.FileName, FileMode.Create))
                {
                    //Creamos un nuevo documento y lo definimos como PDF
                    Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25);

                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();
                    pdfDoc.Add(new Phrase(""));

                    ////Agregamos la imagen del banner al documento
                    iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(Properties.Resources.icons8_clothing_store_100, System.Drawing.Imaging.ImageFormat.Png);
                    img.ScaleToFit(60, 60);
                    img.Alignment = iTextSharp.text.Image.UNDERLYING;

                    img.SetAbsolutePosition(10, 100);
                    img.SetAbsolutePosition(pdfDoc.LeftMargin, pdfDoc.Top - 60);
                    pdfDoc.Add(img);


                    //pdfDoc.Add(new Phrase("Hola Mundo"));
                    using (StringReader sr = new StringReader(PaginaHTML_Texto))
                    {
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                    }

                    pdfDoc.Close();
                    stream.Close();
                }

            }
        }

    }

}
