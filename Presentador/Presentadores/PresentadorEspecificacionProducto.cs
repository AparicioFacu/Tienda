
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentador.Presentadores
{
    class PresentadorEspecificacionProducto
    {
        private EspecificacionProducto _vistaEspecificaciones;        
        private DataGridView tabla;        

        public PresentadorEspecificacionProducto(EspecificacionProducto vista, DataGridView dgv)
        {
            _vistaEspecificaciones = vista;
            tabla = dgv;
        }
        public void Cargar(int codigo)
        {           
        }
    }
}
