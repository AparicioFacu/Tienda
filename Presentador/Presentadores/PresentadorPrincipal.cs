using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentador.Presentadores
{
    class PresentadorPrincipal
    {
        private readonly Menu _vistaPrincipal;
        private ListaProducto _listaProductos;

        public PresentadorPrincipal(Menu vista)
        {
            _vistaPrincipal = vista;
        }
        public void IniciarVistaProducto(Form vp)
        {                   
            _listaProductos = new ListaProducto();                       
            _listaProductos.VisibleChanged += VP_VisibleChanged;
            _listaProductos.Show();
        }
        public void VP_VisibleChanged(object sender, EventArgs e)
        {
            if (_listaProductos.Visible) return;
            _listaProductos.VisibleChanged -= VP_VisibleChanged;
            _listaProductos = null;
        }
    }
    
}
