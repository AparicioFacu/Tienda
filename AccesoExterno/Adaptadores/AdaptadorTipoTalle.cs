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
    public class AdaptadorTipoTalle
    {
        List<TipoTalle> listTipoTalle;
        public AdaptadorTipoTalle()
        {
            ActulizarTipoTalle();
        }

        public async void ActulizarTipoTalle()
        {
            string respuesta = await GetHttp();
            listTipoTalle = JsonConvert.DeserializeObject<List<TipoTalle>>(respuesta);
        }

        private async Task<string> GetHttp()
        {
            WebRequest oRequest = WebRequest.Create("https://localhost:44347/api/TipoTalle");
            WebResponse oResponse = oRequest.GetResponse();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());
            return await sr.ReadToEndAsync();
        }

        public List<TipoTalle> GetTipoTalle()
        {
            return listTipoTalle;
        }
    }
}
