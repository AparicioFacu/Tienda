
using Dominio;
using Presentador.Presentadores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentador
{
    public partial class EspecificacionProducto : Form
    {
        public int codigo;
        private PresentadorEspecificacionProducto _presentador;
        public EspecificacionProducto(int codigo)
        {
            InitializeComponent();
            this.codigo = codigo;
            _presentador = new PresentadorEspecificacionProducto(this, dgvEspecificaciones);         
        }

        private void EspecificacionProducto_Load(object sender, EventArgs e)
        {
            _presentador.Cargar(codigo);
        }     
    }
}
