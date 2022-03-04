using Dominio;
using Newtonsoft.Json;
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
    public class AdaptadorInventario
    {
        List<Inventario> listInventario;
        List<Inventario> listProductBuscar;
        List<Inventario> listProductBuscarPorId;
        List<Inventario> listProductBuscarSucursal;
        string codigo;
        int id;
        int idSucursal;
        public AdaptadorInventario()
        {
            ActulizarProductos();
        }
        public AdaptadorInventario(string cod)
        {
            this.codigo = cod;
            ActulizarUnProducto();
        }
        public AdaptadorInventario(int? id)
        {
            this.id = (int)id;
            ActulizarUnProductoPorId();
        }
        public AdaptadorInventario(int idSucursal)
        {
            this.idSucursal = (int)idSucursal;
            ActulizarUnProductoSucursal();
        }
        ////GET
        public async void ActulizarProductos()
        {
            string respuesta = await GetHttp();
            listInventario = JsonConvert.DeserializeObject<List<Inventario>>(respuesta);

        }
        private async Task<string> GetHttp()
        {
            WebRequest oRequest = WebRequest.Create("https://localhost:44347/api/Inventario");
            WebResponse oResponse = oRequest.GetResponse();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());
            return await sr.ReadToEndAsync();
        }
        public List<Inventario> GetProductos()
        {
            return listInventario;
        }

        //Get unico

        public async void ActulizarUnProducto()
        {
            string respuesta = await GetHttpBuscar();
            listProductBuscar = JsonConvert.DeserializeObject<List<Inventario>>(respuesta);

        }
        private async Task<string> GetHttpBuscar()
        {
            WebRequest oRequest = WebRequest.Create($"https://localhost:44347/api/Inventario?codigo={codigo}");
            WebResponse oResponse = oRequest.GetResponse();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());
            return await sr.ReadToEndAsync();
        }
        public List<Inventario> GetProducto()
        {
            return listProductBuscar;
        }

        //Get unico por id

        public async void ActulizarUnProductoPorId()
        {
            string respuesta = await GetHttpBuscarPorId();
            listProductBuscarPorId = JsonConvert.DeserializeObject<List<Inventario>>(respuesta);

        }
        private async Task<string> GetHttpBuscarPorId()
        {
            WebRequest oRequest = WebRequest.Create($"https://localhost:44347/api/Inventario/{id}");
            WebResponse oResponse = oRequest.GetResponse();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());
            return await sr.ReadToEndAsync();
        }
        public List<Inventario> GetProductoPorId()
        {
            return listProductBuscarPorId;
        }
        //Get unico por Sucursal

        public async void ActulizarUnProductoSucursal()
        {
            string respuesta = await GetHttpBuscarSucursal();
            listProductBuscarSucursal = JsonConvert.DeserializeObject<List<Inventario>>(respuesta);

        }
        private async Task<string> GetHttpBuscarSucursal()
        {
            WebRequest oRequest = WebRequest.Create($"https://localhost:44347/api/Inventario/{idSucursal}");
            WebResponse oResponse = oRequest.GetResponse();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());
            return await sr.ReadToEndAsync();
        }
        public List<Inventario> GetProductoSucursal()
        {
            return listProductBuscarSucursal;
        }
        ////POST

        public string Add<T>(string url, T objectRequest, string method = "POST")
        {
            string result = "";

            try
            {

                JavaScriptSerializer js = new JavaScriptSerializer();
                //Serializamos el objeto
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(objectRequest);
                //Peticion
                WebRequest request = WebRequest.Create(url);
                //headers
                request.Method = method;
                request.PreAuthenticate = true;
                request.ContentType = "application/json;charset=utf-8'";
                request.Timeout = 10000; //esto es opcional

                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(json);
                    streamWriter.Flush();
                }

                var httpResponse = (HttpWebResponse)request.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                }

            }
            catch (Exception e)
            {
                result = e.Message;
            }
            return result;
        }

        //PUT
        public string Put<T>(string url, T objectRequest, string method = "PUT")
        {
            string result = "";

            try
            {

                JavaScriptSerializer js = new JavaScriptSerializer();
                //Serializamos el objeto
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(objectRequest);
                //Peticion
                WebRequest request = WebRequest.Create(url);
                //headers
                request.Method = method;
                request.PreAuthenticate = true;
                request.ContentType = "application/json;charset=utf-8'";
                request.Timeout = 10000; //esto es opcional

                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(json);
                    streamWriter.Flush();
                }

                var httpResponse = (HttpWebResponse)request.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                }

            }
            catch (Exception e)
            {
                result = e.Message;
            }
            return result;
        }
        //DELETE
        public string Delete<T>(string url, T objectRequest, string method = "DELETE")
        {
            string result = "";

            try
            {

                JavaScriptSerializer js = new JavaScriptSerializer();
                //Serializamos el objeto
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(objectRequest);
                //Peticion
                WebRequest request = WebRequest.Create(url);
                //headers
                request.Method = method;
                request.PreAuthenticate = true;
                request.ContentType = "application/json;charset=utf-8'";
                request.Timeout = 10000; //esto es opcional

                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(json);
                    streamWriter.Flush();
                }

                var httpResponse = (HttpWebResponse)request.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                }

            }
            catch (Exception e)
            {
                result = e.Message;
            }
            return result;
        }
    }
}
