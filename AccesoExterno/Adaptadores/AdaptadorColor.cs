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
    public class AdaptadorColor:Adaptador<Color>
    {
        string url = "https://localhost:44347/api/Color";

        public AdaptadorColor()
        {
            
        }       
        public List<Color> GetColor()
        {
            return base.Get(url);
        }
    }
}
