using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    interface IRepositorio
    {
        Producto BuscarProducto(int codigo);
        Producto AgregarProducto(Producto producto);
        void ActulizarProducto(Producto producto);
        
    }
}
