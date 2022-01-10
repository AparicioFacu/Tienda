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
    public class AdaptadorMarca
    {
        List<Marca> listMarca;
        public AdaptadorMarca()
        {
            ActulizarMarca();
        }
       
        public async void ActulizarMarca()
        {
            string respuesta = await GetHttp();
            listMarca = JsonConvert.DeserializeObject<List<Marca>>(respuesta);
        }

        private async Task<string> GetHttp()
        {
            WebRequest oRequest = WebRequest.Create("https://localhost:44347/api/Marca");
            WebResponse oResponse = oRequest.GetResponse();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());
            return await sr.ReadToEndAsync();
        }

        public List<Marca> GetMarcas()
        {
            return listMarca;
        }
    }
}
