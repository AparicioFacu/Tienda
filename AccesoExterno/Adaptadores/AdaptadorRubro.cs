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
    public class AdaptadorRubro
    {
        List<Rubro> listRubro;
        public AdaptadorRubro()
        {
            ActulizarRubro();
        }

        public async void ActulizarRubro()
        {
            string respuesta = await GetHttp();
            listRubro = JsonConvert.DeserializeObject<List<Rubro>>(respuesta);
        }

        private async Task<string> GetHttp()
        {
            WebRequest oRequest = WebRequest.Create("https://localhost:44347/api/Rubro");
            WebResponse oResponse = oRequest.GetResponse();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());
            return await sr.ReadToEndAsync();
        }

        public List<Rubro> GetRubros()
        {
            return listRubro;
        }
    }
}
