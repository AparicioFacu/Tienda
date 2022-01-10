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
    public class AdaptadorTalle
    {
        List<Talle> listTalle;
        int idTipoTalle;
        public AdaptadorTalle(int id)
        {            
            this.idTipoTalle = id;
            ActulizarTalle();
        }

        public async void ActulizarTalle()
        {
            string respuesta = await GetHttp();
            listTalle = JsonConvert.DeserializeObject<List<Talle>>(respuesta);
        }

        private async Task<string> GetHttp()
        {           
            WebRequest oRequest = WebRequest.Create($"https://localhost:44347/api/Talle?idTipoTalle={idTipoTalle}");
            WebResponse oResponse = oRequest.GetResponse();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());
            return await sr.ReadToEndAsync();
        }

        public List<Talle> GetTalle()
        {
            return listTalle;
        }        
    }
}
