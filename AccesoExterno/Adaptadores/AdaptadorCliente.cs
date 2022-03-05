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
    public class AdaptadorCliente : Adaptador<Cliente>
    {
        string url = "https://localhost:44347/api/Cliente";
        string cuit;
        public AdaptadorCliente()
        {            
        }
        public AdaptadorCliente(string cuit)
        {
            this.cuit = cuit;           
        }      
        public List<Cliente> GetClientes()
        {
            return base.Get(url);
        }                             
        public List<Cliente> GetCliente()
        {
            return base.GetUnico($"https://localhost:44347/api/Cliente?cuit={cuit}");
        }
    }
}
