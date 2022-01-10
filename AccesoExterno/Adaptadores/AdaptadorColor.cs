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
    public class AdaptadorColor
    {
        List<Color> listColor;

        public AdaptadorColor()
        {
            ActulizarColor();
        }
        public async void ActulizarColor()
        {
            string respuesta = await GetHttp();
            listColor = JsonConvert.DeserializeObject<List<Color>>(respuesta);
        }

        private async Task<string> GetHttp()
        {
            WebRequest oRequest = WebRequest.Create("https://localhost:44347/api/Color");
            WebResponse oResponse = oRequest.GetResponse();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());
            return await sr.ReadToEndAsync();
        }

        public List<Color> GetColor()
        {
            return listColor;
        }
    }
}
