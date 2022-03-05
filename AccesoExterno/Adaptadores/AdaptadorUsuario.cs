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
    public class AdaptadorUsuario : Adaptador<Usuario>
    {
        string url = "https://localhost:44347/api/Usuario";


        public AdaptadorUsuario()
        {
            
        }
        public List<Usuario> GetUsuarios()
        {
            return base.Get(url);
        }
    }
}
