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
    public class AdaptadorSucursal : Adaptador<Sucursal>
    {
        string url = "https://localhost:44347/api/Sucursal";
        public AdaptadorSucursal()
        {
            
        }
        public List<Sucursal> GetSucursal()
        {
            return base.Get(url);
        }
    }
}
