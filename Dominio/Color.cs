using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Color
    {
        public int? Id { get; set; }
        public string Descripcion { get; set; }

        public Color()
        {          
        }
        public Color(int id)
        {
            this.Id = id;
        }
    }
}
