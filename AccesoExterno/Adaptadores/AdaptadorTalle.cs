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
    public class AdaptadorTalle : Adaptador<Talle>
    {
        int idTipoTalle;
        public AdaptadorTalle(int id)
        {            
            this.idTipoTalle = id;           
        }
        public List<Talle> GetTalle()
        {
            return base.GetUnico($"https://localhost:44347/api/Talle?idTipoTalle={idTipoTalle}");
        }        
    }
}
