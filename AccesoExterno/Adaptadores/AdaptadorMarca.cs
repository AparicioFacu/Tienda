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
    public class AdaptadorMarca : Adaptador<Marca>
    {
        string url = "https://localhost:44347/api/Marca";
        public AdaptadorMarca()
        {
            
        }
        public List<Marca> GetMarcas()
        {
            return base.Get(url);
        }
    }
}
