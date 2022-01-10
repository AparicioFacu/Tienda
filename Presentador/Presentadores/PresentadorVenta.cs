
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
        private DataGridView tabla;       

        public PresentadorVenta(VistaVenta vista, DataGridView tabla)
        {
            vistaVenta = vista;
            this.tabla = tabla;
        }

        public void LoadVenta()
        {
            ActulizarTablaVenta();

            DataGridViewButtonColumn btngrid = new DataGridViewButtonColumn();
            btngrid.Name = "Especificaciones";
            btngrid.HeaderText = "Visualizar Especificaciones";
            btngrid.Text = "Ver Mas";
            btngrid.UseColumnTextForButtonValue = true;
            tabla.Columns.Add(btngrid);
        }

        public void ActulizarTablaVenta()
        {

        }
    }
}
