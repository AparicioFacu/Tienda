using Dominio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace AccesoExterno.Adaptadores
{
    public class AdaptadorVenta : Adaptador<Venta>
    {
        string url = "https://localhost:44347/api/Venta";
        public AdaptadorVenta()
        {

        }

        public void Post(Venta venta)
        {
            base.Add<Venta>(url, venta, "POST");
        }        
    }
}
