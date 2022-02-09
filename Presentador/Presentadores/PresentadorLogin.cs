using AccesoExterno.Adaptadores;
using Dominio;
using Presentador.Vistas;
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
        AdaptadorUsuario AdaptadorUsuario = new AdaptadorUsuario();
        List<Usuario> usuarios;
        public void iniciarSesion(string nombre, string contraseña)
        {
            usuarios = AdaptadorUsuario.GetUsuarios();
            foreach(var user in usuarios)
            {
                if (nombre.Equals(user.Nombre) && contraseña.Equals(user.Contraseña))
                {
                    if(user.Rol == "admin")
                    {
                        MenuInicio menu = new MenuInicio();
                        menu.Show();
                    }
                    else if(user.Rol == "vendedor")
                    {
                        //restringir acceso
                    }
                    
                }
                else
                {
                    //MessageBox.Show("Legajo o contraseña incorrectos");
                }
            }
        }
        

    }
}
