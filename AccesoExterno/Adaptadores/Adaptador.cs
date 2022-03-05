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
    public class Adaptador<T>
    {
        List<T> list;
        public Adaptador()
        {
            
        }      
        ////GET
        public async void ActulizarGet(string url)
        {
            string respuesta = await GetHttp(url);
            list = JsonConvert.DeserializeObject<List<T>>(respuesta);            
        }
        private async Task<string> GetHttp(string url)
        {
            WebRequest oRequest = WebRequest.Create(url);
            WebResponse oResponse = oRequest.GetResponse();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());
            return await sr.ReadToEndAsync();
        }
        public List<T> Get(string url)
        {
            ActulizarGet(url);
            return list;
        }
        //Get unico
        public async void ActulizarGetUnico(string url)
        {
            string respuesta = await GetHttpBuscar(url);
            list = JsonConvert.DeserializeObject<List<T>>(respuesta);

        }
        private async Task<string> GetHttpBuscar(string url)
        {
            WebRequest oRequest = WebRequest.Create(url);
            WebResponse oResponse = oRequest.GetResponse();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());
            return await sr.ReadToEndAsync();
        }
        public List<T> GetUnico(string url)
        {
            ActulizarGetUnico(url);
            return list;
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
        //Inventario

        //Get unico por id

        public async void ActulizarInventarioId(string url)
        {
            string respuesta = await GetHttpBuscarPorId(url);
            list = JsonConvert.DeserializeObject<List<T>>(respuesta);

        }
        private async Task<string> GetHttpBuscarPorId(string url)
        {
            WebRequest oRequest = WebRequest.Create(url);
            WebResponse oResponse = oRequest.GetResponse();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());
            return await sr.ReadToEndAsync();
        }
        public List<T> GetProductoPorId(string url)
        {
            ActulizarInventarioId(url);
            return list;
        }
        //Get unico por Sucursal

        public async void ActulizarInventarioSucursal(string url)
        {
            string respuesta = await GetHttpBuscarSucursal(url);
            list = JsonConvert.DeserializeObject<List<T>>(respuesta);

        }
        private async Task<string> GetHttpBuscarSucursal(string url)
        {
            WebRequest oRequest = WebRequest.Create(url);
            WebResponse oResponse = oRequest.GetResponse();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());
            return await sr.ReadToEndAsync();
        }
        public List<T> GetProductoSucursal(string url)
        {
            ActulizarInventarioSucursal(url);
            return list;
        }
    }
}
