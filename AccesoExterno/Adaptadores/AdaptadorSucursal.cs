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
    public class AdaptadorSucursal
    {
        List<Sucursal> listSucursal;
        public AdaptadorSucursal()
        {
            ActulizarSucursal();
        }

        public async void ActulizarSucursal()
        {
            string respuesta = await GetHttp();
            listSucursal = JsonConvert.DeserializeObject<List<Sucursal>>(respuesta);
        }

        private async Task<string> GetHttp()
        {
            WebRequest oRequest = WebRequest.Create("https://localhost:44347/api/Sucursal");
            WebResponse oResponse = oRequest.GetResponse();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());
            return await sr.ReadToEndAsync();
        }

        public List<Sucursal> GetSucursal()
        {
            return listSucursal;
        }
    }
}
