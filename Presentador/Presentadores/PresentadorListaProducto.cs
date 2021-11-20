using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentador.Presentadores
{
    class PresentadorListaProducto
    {
        private ListaProducto _vistaListaProducto;   
        private Repositorio _repositorio;
        private DataGridView tabla;

        public PresentadorListaProducto(ListaProducto vista, DataGridView dgv)
        {
            _vistaListaProducto = vista;
            _repositorio = new Repositorio();
            tabla = dgv;
        }

        public void Load()
        {
            ActulizarTabla();

            DataGridViewButtonColumn btngrid = new DataGridViewButtonColumn();
            btngrid.Name = "Especificaciones";
            btngrid.HeaderText = "Visualizar Especificaciones";
            btngrid.Text = "Ver Mas";
            btngrid.UseColumnTextForButtonValue = true;
            tabla.Columns.Add(btngrid);
        }
        public void VerMas(int codigo)
        {
            var _vistaEspecificaciones = new EspecificacionProducto(codigo, _repositorio);
            _vistaEspecificaciones.ShowDialog();            
        }
        public void Agregar()
        {
            var cod = 0;
            var vistaProducto = new VistaProducto(cod,_repositorio);
            vistaProducto.ShowDialog();
            ActulizarTabla();
        }

        public void ActulizarTabla()
        {
            tabla.DataSource = (from productos in _repositorio._productos
                                select new
                                {
                                    Codigo = productos.CodigoProducto,
                                    Descripcion = productos.Descripcion,
                                    Costo = productos.Costo,
                                    PorcentajeIva = productos.PorcentajeIva,
                                    MargenGanacia = productos.MargenGanacia,
                                    
                                }
               ).ToList();
        }
    }
}
