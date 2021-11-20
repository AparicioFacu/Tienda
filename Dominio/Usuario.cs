using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuario
    {
        public string nombre { get; set; }               
        public string contraseña { get; set; }
        public string rol { get; set; }

        public Usuario()
        {
           
        }
        public Usuario(string nombre, string contraseña)
        {
            this.nombre = nombre;
            this.contraseña = contraseña;
        }
    }
}
