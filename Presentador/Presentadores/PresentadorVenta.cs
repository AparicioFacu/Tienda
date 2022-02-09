
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
        //AFIP
        private ServiceSolicitarAFIP.ServiceSoapClient _serviceSolicitarAFIP;
        private long _cuit;
        private string _token;
        private string _sign;
        public PresentadorVenta(VistaVenta vista, DataGridView tablaVenta, DataGridView tablaProductoVenta)
        {
            vistaVenta = vista;
            this._tablaProductoVenta = tablaProductoVenta;
            this._tablaVenta = tablaVenta;
            //SolicitarAutorizacion();
            //FECompUltimoAutorizado();
            //FECAESolicitar();
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
                                                  MarcaPro = inv.Producto.Marca.Descripcion,
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
            AgregarLineaVenta(txtStock);

            String Codigo = _lineaVenta._productos.Producto.CodigoProducto.ToString();
            String Descripcion = _lineaVenta._productos.Producto.Descripcion;
            String TalleProducto = _lineaVenta._productos.Talle.Descripcion;
            String ColorProducto = _lineaVenta._productos.Color.Descripcion;
            String PrecioUnitario = _lineaVenta.PrecioUnitario.ToString();
            String Cantidad = _lineaVenta.Cantidad.ToString();
            String SubTotal = _lineaVenta.Total.ToString();

            _tablaVenta.Rows.Add(new[] { Codigo, Descripcion, TalleProducto, ColorProducto, PrecioUnitario, Cantidad, SubTotal });
        }        
        public void FinalizarVenta(ComboBox cbxPago, TextBox txtTotal,DateTimePicker txtFecha,TextBox txtCuit)
        {
            SolicitarAutorizacion();           
            _venta.fechaEmision = DateTime.Now;
            _venta.SubTotal = double.Parse(txtTotal.Text);
            _venta.Total = double.Parse(txtTotal.Text);
            _venta.Empleado = new Empleado
            {
                Id =1,
                Legajo= "44444",
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
            _venta.Comprobante = new Comprobante
            {
                Id = 1,
                Descripcion = "Factura B"
            };
            _comprobante = _venta.Comprobante;
            _venta.LineaVentas = _listaLineaVenta;
            string urlVenta = "https://localhost:44347/api/Venta";
            _adaptadorVenta = new AdaptadorVenta();
            _adaptadorVenta.Add<Venta>(urlVenta, _venta, "POST");
        }

        public void AgregarLineaVenta(TextBox txtStock)
        {
            DataGridViewRow fila = _tablaProductoVenta.SelectedRows[0] as DataGridViewRow;

            _lineaVenta = new LineaVenta();
            foreach(var inv in _adaptadorInventario.GetProductos())
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
                    
                }
            }         
            _lineaVenta._sucursal = _lineaVenta._productos.Sucursal;
            _surcursal = _lineaVenta._sucursal;
            _lineaVenta.PrecioUnitario = _lineaVenta._productos.Producto.PrecioVenta;
            _lineaVenta.Cantidad = int.Parse(txtStock.Text);
            _lineaVenta.PrecioFinal();
            _listaLineaVenta.Add(_lineaVenta);
        }
        public void TotalVenta(TextBox txtTotal)
        {                     
                double total = _listaLineaVenta.Sum(item => item.Total);
                txtTotal.Text = total.ToString();                        
        }

        public void SolicitarAutorizacion()
        {
            var oServicio = new ServiceAFIP.LoginServiceClient();
            var datos = oServicio.SolicitarAutorizacion("44B486BA-F7BA-4C11-9877-1C142F59179C");
            _cuit = datos.Cuit;
            _token = datos.Token;
            _sign = datos.Sign;
        }
        public void FECAESolicitar()
        {
            _serviceSolicitarAFIP = new ServiceSolicitarAFIP.ServiceSoapClient();
            var auth = new ServiceSolicitarAFIP.FEAuthRequest();
            auth.Cuit = _cuit;
            auth.Sign = _sign;
            auth.Token = _token;
            //Comprabante Completo    
            int valor = FECompUltimoAutorizado();
            var feCaeRequest = new ServiceSolicitarAFIP.FECAERequest();           
            //cabezera del comprobante
            feCaeRequest.FeCabReq = new ServiceSolicitarAFIP.FECAECabRequest();
            feCaeRequest.FeCabReq.CantReg = 1;
            feCaeRequest.FeCabReq.CbteTipo = 1;
            feCaeRequest.FeCabReq.PtoVta = 20;
            //detalle del comprobante           
            feCaeRequest.FeDetReq = new ServiceSolicitarAFIP.FECAEDetRequest[0];           
            foreach (var e in feCaeRequest.FeDetReq)
            {
                e.Concepto = 1;
                e.DocTipo = 80;
                e.DocNro = 20406986374;
                e.CbteDesde = valor + 1;
                e.CbteHasta = 9999;
                e.CbteFch = "20220130";
                e.ImpTotal = 184.05;
                e.ImpTotConc = 0;
                e.ImpNeto = 150;
                e.ImpOpEx = 0;
                e.ImpTrib = 7.8;
                e.ImpIVA = 26.25;
                e.MonId = "PES";
                e.MonCotiz = 1;
                foreach(var cbt in e.CbtesAsoc)
                {
                    cbt.Tipo = 1;
                    cbt.PtoVta = 20;
                    cbt.Nro = 02;
                }
                foreach(var tri in e.Tributos)
                {
                    tri.Id = 99;
                    tri.Desc = "Impuesto Municipal Matanza";
                    tri.BaseImp = 100;                    
                    tri.Alic = 5.2;
                    tri.Importe = 7.8;
                }
                foreach(var iva in e.Iva)
                {
                    iva.Id = 5;
                    iva.BaseImp = 100;
                    iva.Importe = 21;
                }
            }                  
            _serviceSolicitarAFIP.FECAESolicitar(auth, feCaeRequest);
            //var response = new ServiceSolicitarAFIP.FECAESolicitarResponse();
            //var bodyResponse = response.Body.FECAESolicitarResult.FeCabResp;
            //bodyResponse.PtoVta = 20;
            //bodyResponse.CbteTipo = 1;
            //bodyResponse.FchProceso = "20220130";
            //bodyResponse.CantReg = 1;           
        }
        public int FECompUltimoAutorizado()
        {
            _serviceSolicitarAFIP = new ServiceSolicitarAFIP.ServiceSoapClient();
            var auth = new ServiceSolicitarAFIP.FEAuthRequest();
            auth.Cuit = _cuit;
            auth.Sign = _sign;
            auth.Token = _token;
            return  _serviceSolicitarAFIP.FECompUltimoAutorizado(auth,20,1).CbteNro;
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
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@EMPLEADO", _empleado.Nombre);
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@CLIENTE", txtNombre.Text);
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@CUIT", txtCuit.Text);
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
                    //iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(Properties.Resources.shop, System.Drawing.Imaging.ImageFormat.Png);
                    //img.ScaleToFit(60, 60);
                    //img.Alignment = iTextSharp.text.Image.UNDERLYING;

                    //img.SetAbsolutePosition(10,100);
                    //img.SetAbsolutePosition(pdfDoc.LeftMargin, pdfDoc.Top - 60);
                    //pdfDoc.Add(img);


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
