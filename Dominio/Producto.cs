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
        private double _netoGravado;
        private double _iva;
        private double _precioVenta;

       // public Marca Marca { get; set; }
       // public Rubro Rubro { get; set; }
        public int CodigoProducto { get; set; }
        public string Descripcion { get; set; }
        public double Costo { get; set; }             
        
        public double MargenGanacia
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

        public double NetoGravado()
        {
           _netoGravado = Costo + (Costo * MargenGanacia);
            return _netoGravado;
        }

        public double IVA()
        {
            _iva = _netoGravado * PorcentajeIva;
            return _iva;
        }
        public double precioFinal()
        {
            _precioVenta = _netoGravado + _iva;
            return _precioVenta;
        }
    }
}
