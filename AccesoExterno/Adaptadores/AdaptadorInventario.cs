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
    public class AdaptadorInventario : Adaptador<Inventario>
    {
        string url = "https://localhost:44347/api/Inventario";
        string urlUnico = "";
        string urlUnicoId = "";
        string urlUnicoSucursal = "";
        string codigo;
        int id;
        int idSucursal;
        public AdaptadorInventario()
        {           
        }
        public AdaptadorInventario(string cod)
        {
            this.codigo = cod;         
        }
        public AdaptadorInventario(int? id)
        {
            this.id = (int)id;            
        }
        public AdaptadorInventario(int idSucursal)
        {
            this.idSucursal = (int)idSucursal;           
        }       
        public List<Inventario> GetProductos()
        {
            return base.Get(url);
        }       
        public List<Inventario> GetProducto()
        {
            return base.GetUnico($"https://localhost:44347/api/Inventario?codigo={codigo}");
        }
        public List<Inventario> GetProductoPorId()
        {
            return base.GetProductoPorId($"https://localhost:44347/api/Inventario/{id}");
        }        
        public List<Inventario> GetProductoSucursal()
        {
            return base.GetProductoSucursal($"https://localhost:44347/api/Inventario/{idSucursal}");
        }
        public void Post(Inventario inventario)
        {
            base.Add<Inventario>(url, inventario, "POST");
        }
        public void Put(Inventario inventario)
        {
            base.Put<Inventario>(url, inventario, "PUT");
        }
        public void Delete(Inventario inventario)
        {
            base.Delete<Inventario>(url, inventario, "DELETE");
        }       
    }
}
