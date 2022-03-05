using Dominio;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AccesoExterno.Adaptadores
{
    public class AdaptadorRubro :Adaptador<Rubro>
    {
        string url = "https://localhost:44347/api/Rubro";
        public AdaptadorRubro()
        {
            
        }
        public List<Rubro> GetRubros()
        {
            return base.Get(url);
        }
    }
}
