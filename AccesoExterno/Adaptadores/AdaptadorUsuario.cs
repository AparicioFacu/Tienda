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
    public class AdaptadorUsuario
    {
        List<Usuario> listUsuario;  
        
        public AdaptadorUsuario()
        {
            ActulizarUsuarios();
        }
        public async void ActulizarUsuarios()
        {
            string respuesta = await GetHttp();
            listUsuario = JsonConvert.DeserializeObject<List<Usuario>>(respuesta);            
        }

        private async Task<string> GetHttp()
        {
            WebRequest oRequest = WebRequest.Create("https://localhost:44347/api/Usuario");
            WebResponse oResponse = oRequest.GetResponse();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());
            return await sr.ReadToEndAsync();
        }

        public List<Usuario> GetUsuarios()
        {
            return listUsuario;
        }
    }
}
