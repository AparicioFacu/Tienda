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
    public class AdaptadorProducto
    {
        List<Producto> listProduct;
        List<Producto> listProductBuscar;
        string idCodigo;
        public AdaptadorProducto()
        {
            ActulizarProductos();
        }
        public AdaptadorProducto(string cod)
        {
            this.idCodigo = cod;
            ActulizarUnProducto();
        }
        ////GET
        public async void ActulizarProductos()
        {
            string respuesta = await GetHttp();
            listProduct = JsonConvert.DeserializeObject<List<Producto>>(respuesta);
            
        }
        private async Task<string> GetHttp()
        {
            WebRequest oRequest = WebRequest.Create("https://localhost:44347/api/Product");
            WebResponse oResponse = oRequest.GetResponse();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());
            return await sr.ReadToEndAsync();
        }
        public List<Producto> GetProductos()
        {
            return listProduct;
        }

        //Get unico

        public async void ActulizarUnProducto()
        {
            string respuesta = await GetHttpBuscar();
            listProductBuscar = JsonConvert.DeserializeObject<List<Producto>>(respuesta);

        }
        private async Task<string> GetHttpBuscar()
        {
            WebRequest oRequest = WebRequest.Create($"https://localhost:44347/api/Product?cod={idCodigo}");
            WebResponse oResponse = oRequest.GetResponse();
            StreamReader sr = new StreamReader(oResponse.GetResponseStream());
            return await sr.ReadToEndAsync();
        }
        public List<Producto> GetProducto()
        {
            return listProductBuscar;
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
