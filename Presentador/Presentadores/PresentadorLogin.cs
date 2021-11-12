using Datos;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentador.Presentadores
{
    public class PresentadorLogin
    {
        private Repositorio repo;       


        public String iniciarSesion(Usuario user)
        {
            repo = new Repositorio();
            var rol = repo.IngresarUsuario(user.legajo, user.contraseña);
            if (rol == "admin")
            {
                Menu menu = new Menu();
                menu.Show();
                //this.Hide();
                return "LoginExitoso";
            }
            else if (rol == "vendedor")
            {
                //Restringir Accesos
                return null;
            }
            else
            {
                MessageBox.Show("Legajo o contraseña incorrectos");
                return "LoginNoesExitoso";
                //txtContraseña.Clear();
                //txtUsuario.Focus();
            }
        }

    }
}
