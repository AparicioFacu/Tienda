using Datos;
using Dominio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Presentador.Presentadores;
using System;
using System.Windows.Forms;

namespace PruebasUnitarias
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        
        public void nuevoProducto()
        {
            Rubro rubro = new Rubro();
            Marca marca = new Marca();
            Producto producto = new Producto();
            producto.CodigoProducto = 100;
            producto.Descripcion = "Remera";
            producto.Costo = 1000;
            producto.PorcentajeIva = 0.21;
            producto.MargenGanacia = 0.20;
            producto.Marca = marca;
            producto.Rubro = rubro;

            Repositorio rep = new Repositorio();
            var resultadoEsperado = rep.AgregarProducto(producto);
            Assert.IsNotNull(resultadoEsperado);            

        }
        [TestMethod]
        public void validarInicioSesion()
        {
            Usuario user = new Usuario("45412", "123");
            PresentadorLogin login = new PresentadorLogin();
            string respuestaEsperada = login.iniciarSesion(user);
            Assert.AreEqual("LoginExitoso", respuestaEsperada);

        }
    }
}
