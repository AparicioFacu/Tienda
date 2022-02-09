using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Producto
    {
        private double _margenGanancia;
        private double _porcentajeIva;

        public int Id { get; set; }
        public string CodigoProducto { get; set; }
        public string Descripcion { get; set; }
        public double Costo { get; set; }

        public double PrecioVenta { get; set; }
        public double NetoGravado { get; set; }
        public double Iva { get; set; }
        public Marca Marca { get; set; }
        public Rubro Rubro { get; set; }

        public Producto(Marca marca, Rubro rubro)
        {
            this.Marca = marca;
            this.Rubro = rubro;
        }
        public Producto()
        {
           
        }
        public double MargenGanancia
        {
            get => _margenGanancia*100;
            set
            {
                _margenGanancia = (value/100);              
            }          
        }
        public double PorcentajeIva
        {
            get => _porcentajeIva * 100;
            set
            {
                _porcentajeIva = (value / 100);
            }
        }      
        public double NetoGravados()
        {
            NetoGravado = Costo + (Costo * MargenGanancia);
            return NetoGravado;
        }

        public double IVA()
        {
            Iva = NetoGravado * PorcentajeIva;
            return Iva;
        }
        public double precioFinal()
        {
            PrecioVenta = NetoGravado + Iva;
            return PrecioVenta;
        }
    }
}
