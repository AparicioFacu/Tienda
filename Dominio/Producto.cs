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
        private bool _precioEspecifico;
        private double _precioFinal;

        public Marca Marca { get; set; }
        public Rubro Rubro { get; set; }
        public int CodigoProducto { get; set; }
        public string Descripcion { get; set; }
        public double Costo { get; set; }
        public double PorcentajeIva { get; set; }
        public double NetoGravado => Costo + (Costo*_margenGanancia);
        public double Iva => NetoGravado * PorcentajeIva;
        
        public double MargenGanacia
        {
            get => _margenGanancia;
            set
            {
                _margenGanancia = value;
                _precioEspecifico = false;
                _precioFinal = 0;
            }          
        }

        public double PrecioFinal
        {
            get
            {
                if (!_precioEspecifico)
                {
                    return Math.Round(NetoGravado + Iva, 2);
                }
                else
                {
                    return Math.Round(_precioFinal, 2);
                }
            }
            set
            {
                _precioFinal = value;
                _precioEspecifico = true;
                MargenGanacia = (_precioFinal - Iva) / Iva;
            }
        }
    }
}
