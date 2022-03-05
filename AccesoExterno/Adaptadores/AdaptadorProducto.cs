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
    public class AdaptadorProducto : Adaptador<Producto>
    {
        string url = "https://localhost:44347/api/Product";       
        string idCodigo;
        public AdaptadorProducto()
        {
            
        }
        public AdaptadorProducto(string cod)
        {
            this.idCodigo = cod;            
        }        
        public List<Producto> GetProductos()
        {
            return base.Get(url);
        }       
        public List<Producto> GetProducto()
        {
            return base.GetUnico("$https://localhost:44347/api/Product?cod={idCodigo}");
        }
        public void Post(Producto producto)
        {
            base.Add<Producto>(url, producto, "POST");
        }
        public void Put(Producto producto)
        {
            base.Put<Producto>(url, producto, "PUT");
        }
        public void Delete(Producto producto)
        {
            base.Delete<Producto>(url, producto, "DELETE");
        }



    }
}
