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
    public class AdaptadorTipoTalle : Adaptador<TipoTalle>
    {
        string url = "https://localhost:44347/api/TipoTalle";
        public AdaptadorTipoTalle()
        {
            
        }
        public List<TipoTalle> GetTipoTalle()
        {
            return base.Get(url);
        }
    }
}
