using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuario
    {
        public string Nombre { get; set; }               
        public string Contraseña { get; set; }
        public string Rol { get; set; }

        public Usuario()
        {
           
        }
        public Usuario(string nombre, string contraseña)
        {
            this.Nombre = nombre;
            this.Contraseña = contraseña;
        }
    }
}
