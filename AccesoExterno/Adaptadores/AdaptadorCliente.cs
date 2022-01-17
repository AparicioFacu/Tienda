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
    public class AdaptadorCliente
    {
        List<Cliente> listCliente;
        List<Cliente> listClienteBuscar;
        string cuit;
        public AdaptadorCliente()
        {
            ActulizarCliente();
        }

        public AdaptadorCliente(string cuit)
        {
            this.cuit = cuit;
            ActulizarClienteUnico();
        }
        public async void ActulizarCliente()
        {
            string respuesta = await GetHttp();
            listCliente = JsonConvert.DeserializeObject<List<Cliente>>(respuesta);
        }

        private async Task<string> GetHttp()
        {
            WebRequest oRequest = WebRequest.Create("https://localhost:44347/api/Cliente");
            WebResponse oResponse = oRequest.GetResponse();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());
            return await sr.ReadToEndAsync();
        }

        public List<Cliente> GetClientes()
        {
            return listCliente;
        }

        /// GET Unico                
        public async void ActulizarClienteUnico()
        {
            string respuesta = await GetHttpUnico();
            listClienteBuscar = JsonConvert.DeserializeObject<List<Cliente>>(respuesta);
        }

        private async Task<string> GetHttpUnico()
        {
            WebRequest oRequest = WebRequest.Create($"https://localhost:44347/api/Cliente?cuit={cuit}");
            WebResponse oResponse = oRequest.GetResponse();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());
            return await sr.ReadToEndAsync();
        }

        public List<Cliente> GetCliente()
        {
            return listClienteBuscar;
        }
    }
}
