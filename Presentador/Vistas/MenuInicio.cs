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

namespace Presentador.Vistas
{
    public partial class MenuInicio : Form
    {
        Form activarForm = null;
        public static int idSucursal;
        private PresentadorListaProducto _presentadorListaProducto;
        public MenuInicio(int idSucursal)
        {
            InitializeComponent();
            PersonalizarMenu();           
            lblSucursal.Text = "Sucursal " + idSucursal;
            MenuInicio.idSucursal = idSucursal;
        }

        private void btnProducto_Click(object sender, EventArgs e)
        {
            MostrarSubMenu(panelSubMenuProducto);
        }
        private void btnListaProducto_Click_1(object sender, EventArgs e)
        {
            abriFormulario<ListaProducto>();            
            OcultarSubMenu();
        }
        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            //abriFormulario<VistaProducto>();
            abrirVistar(new VistaProducto(0));
            OcultarSubMenu();
        }

        private void btnVenta_Click(object sender, EventArgs e)
        {
            MostrarSubMenu(panelSubMenuVenta);
        }

        private void btnListaVenta_Click(object sender, EventArgs e)
        {
            ///Codigo
            OcultarSubMenu();
        }

        private void btnRealizarVenta_Click(object sender, EventArgs e)
        {
            abriFormulario<VistaVenta>();
            //abrirVistar(new VistaVenta());
            OcultarSubMenu();
        }

        private void btnComprobantes_Click(object sender, EventArgs e)
        {
            MostrarSubMenu(panelSubMenuCliente);
        }

        private void btnListaComprobantes_Click(object sender, EventArgs e)
        {
            ///Codigo
            OcultarSubMenu();
        }




        /// <summary>
        /// Edicion Vista
        /// </summary>

        void PersonalizarMenu()
        {
            panelSubMenuProducto.Visible = false;
            panelSubMenuVenta.Visible = false;
            panelSubMenuCliente.Visible = false;
        }
        void OcultarSubMenu()
        {
            if (panelSubMenuProducto.Visible == true)
            {
                panelSubMenuProducto.Visible = false;
            }
            if (panelSubMenuVenta.Visible == true)
            {
                panelSubMenuVenta.Visible = false;
            }
            if (panelSubMenuCliente.Visible == true)
            {
                panelSubMenuCliente.Visible = false;
            }
        }
        void MostrarSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                OcultarSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }

        void abrirVistar(Form formHijo)
        {

            if (activarForm != null)
            {
                activarForm.Close();
            }
            activarForm = formHijo;
            formHijo.TopLevel = false;
            formHijo.FormBorderStyle = FormBorderStyle.None;
            formHijo.Dock = DockStyle.Fill;
            panelForm.Controls.Add(formHijo);
            panelForm.Tag = formHijo;
            formHijo.BringToFront();
            formHijo.Show();
        }
        void abriFormulario<Miform>() where Miform : Form, new()
        {
            Form formulario;
            formulario = panelForm.Controls.OfType<Miform>().FirstOrDefault();
            if(formulario == null)
            {
                formulario = new Miform();
                formulario.TopLevel = false;
                formulario.FormBorderStyle = FormBorderStyle.None;
                formulario.Dock = DockStyle.Fill;
                panelForm.Controls.Add(formulario);
                panelForm.Tag = formulario;
                formulario.Show();
                formulario.BringToFront();
            }
            else
            {
                formulario.BringToFront();
            }
        }
    }
}
