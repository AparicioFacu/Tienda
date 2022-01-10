using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Rubro
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public Rubro(int id)
        {
            this.Id = id;
        }
        public Rubro()
        {
            
        }
    }
}
