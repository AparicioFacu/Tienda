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
        

        public void iniciarSesion(string nombre, string contraseña)
        {
            repo = new Repositorio();
            var respuesta = repo.IngresarUsuario(nombre, contraseña);
            var rol = repo.rolUsuario(nombre, contraseña);
            if (respuesta == "Login Exitoso")
            {             
                if (rol.Equals("admin"))
                {
                    Menu menu = new Menu();
                    menu.Show();
                    //this.Hide(); 
                }
                else
                {
                    //Restringir Accesos   
                }

            }            
            else
            {
                MessageBox.Show("Legajo o contraseña incorrectos");               
                //txtContraseña.Clear();
                //txtUsuario.Focus();
            }
        }
        

    }
}
