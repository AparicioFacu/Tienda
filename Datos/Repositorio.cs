using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Datos
{
    public class Repositorio : IRepositorio
    {
        public List<Marca> _marcas { get; set; }
        public List<Producto> _productos { get; set; }
        public List<Rubro> _rubros { get; set; }
        public List<Stock> _stocks { get; set; }
        public List<Talle> _talles { get; set; }
        public List<Color> _colores { get; set; }
        public List<Usuario> _usuarios { get; set; }


        public Repositorio()
        {
            _usuarios = new List<Usuario>()
            {
                new Usuario()
                {
                    legajo="45412",
                    contraseña="123",
                    email="chino@gmail.com",
                    nombre="Facu",
                    rol="admin"
                }
            };

            _colores = new List<Color>()
            {
                 new Color()
                {
                    descripcion = "azul"
                },
                new Color()
                {
                    descripcion = "rojo"
                },
                new Color()
                {
                    descripcion = "verde"
                },
                new Color()
                {
                    descripcion = "blanco"
                },
                new Color()
                {
                    descripcion = "negro"
                },
                new Color()
                {
                    descripcion = "celeste"
                },
            };

            _talles = new List<Talle>()
            {
                 new Talle()
                {
                    descripcion = "S"
                },
                new Talle()
                {
                    descripcion = "M"
                },
                new Talle()
                {
                    descripcion = "L"
                },
                new Talle()
                {
                    descripcion = "XL"
                },
                new Talle()
                {
                    descripcion = "34"
                },
                new Talle()
                {
                    descripcion = "36"
                },
                new Talle()
                {
                    descripcion = "38"
                },
                new Talle()
                {
                    descripcion = "40"
                },
                new Talle()
                {
                    descripcion = "42"
                },
                new Talle()
                {
                    descripcion = "44"
                },
            };
            _rubros = new List<Rubro>()
            {
                new Rubro()
                {
                    descripcion = "Remera Corta"
                },
                new Rubro()
                {
                    descripcion = "Pantalon Corto"
                },
                new Rubro()
                {
                    descripcion = "Remera Larga"
                },
                new Rubro()
                {
                    descripcion = "Pantalon Largo"
                },
                new Rubro()
                {
                    descripcion = "Zapatillas"
                },
                new Rubro()
                {
                    descripcion = "Zapatos"
                },
                new Rubro()
                {
                    descripcion = "Musculosa"
                },
            };
            _marcas = new List<Marca>()
            {
                new Marca()
                {
                    descripcion="Nike"
                },
                new Marca()
                {
                    descripcion="Adida"
                },
                new Marca()
                {
                    descripcion="Puma"
                },
                new Marca()
                {
                    descripcion="Reebok"
                },
                new Marca()
                {
                    descripcion="Under Armour"
                },
            };
            _productos = new List<Producto>()
            {
                new Producto()
                {
                    CodigoProducto = 100,
                    Descripcion = "Remera",
                    Costo = 1000,
                    PorcentajeIva = 0.21,
                    MargenGanacia = 0.20,
                    Marca = _marcas[0],
                    Rubro = _rubros[0],
                },
                new Producto()
                {
                    CodigoProducto = 101,
                    Descripcion = "Pantalon",
                    Costo = 1000,
                    PorcentajeIva = 0.21,
                    MargenGanacia = 0.20,
                    Marca = _marcas[0],
                    Rubro = _rubros[0],
                },
                new Producto()
                {
                    CodigoProducto = 102,
                    Descripcion = "Musculosa",
                    Costo = 1000,
                    PorcentajeIva = 0.21,
                    MargenGanacia = 0.20,
                    Marca = _marcas[0],
                    Rubro = _rubros[0],
                }
            };
            _stocks = new List<Stock>()
            {
                new Stock()
                {
                    CodigoProducto = _productos[0],
                    StockDisponible=20,
                    talle = _talles[0],
                    color = _colores[0]

                },
                new Stock()
                {
                    CodigoProducto = _productos[0],
                    StockDisponible=40,
                    talle = _talles[1],
                    color = _colores[1],

                },
                new Stock()
                {
                    CodigoProducto = _productos[1],
                    StockDisponible=100,
                    talle = _talles[2],
                    color = _colores[3],

                },

            };
        }


        public void ActulizarProducto(Producto producto)
        {
            
        }

        public Producto AgregarProducto(Producto producto)
        {
            _productos.Add(producto);
            return producto;
        }
        public void AgregarStock(Stock stock)
        {
            _stocks.Add(stock);
        }

        public Producto BuscarProducto(int codigo)
        {
            throw new NotImplementedException();
        }
        public string IngresarUsuario(string legajo, string contraseña)
        {
            foreach(var usuario in _usuarios)
            {
                if(legajo == usuario.legajo && contraseña == usuario.contraseña)
                {
                    return usuario.rol;
                }
            }
            return null;
        }
   
    }
}
