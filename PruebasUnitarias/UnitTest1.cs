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
        
        public void crearNuevoProductoExitoso()
        {

            Producto producto = new Producto
            {
                CodigoProducto = 100,
                Descripcion = "Remera Mangas Corta",
                Costo = 1000,
                PorcentajeIva = 0.21,
                MargenGanacia = 0.20
            };

            Repositorio rep = new Repositorio();
            var resultadoEsperado = rep.AgregarProducto(producto);
            Assert.IsNotNull(resultadoEsperado);            

        }
        [TestMethod]
        public void netoGravadoExitoso()
        {
            Producto producto = new Producto
            {
                CodigoProducto = 100,
                Descripcion = "Remera Mangas Corta",
                Costo = 1000,
                PorcentajeIva = 0.21,
                MargenGanacia = 0.20
            };

            double netoGravadoEsperado = 1200;
            double resultado = producto.NetoGravado();
            Assert.AreEqual(netoGravadoEsperado, resultado);
        }
        [TestMethod]
        public void ivaExitoso()
        {
            Producto producto = new Producto
            {
                CodigoProducto = 100,
                Descripcion = "Remera Mangas Corta",
                Costo = 1000,
                PorcentajeIva = 0.21,
                MargenGanacia = 0.20
            };
            producto.NetoGravado();
            double ivaEsperado = 252;
            double resultado = producto.IVA();
            Assert.AreEqual(ivaEsperado, resultado);
        }
        [TestMethod]
        public void precioExitoso()
        {
            Producto producto = new Producto
            {
                CodigoProducto = 100,
                Descripcion = "Remera Mangas Corta",
                Costo = 1000,
                PorcentajeIva = 0.21,
                MargenGanacia = 0.20
            };
            producto.NetoGravado();
            producto.IVA();
            double precioFinalEsperado = 1452;
            double resultado = producto.precioFinal();
            Assert.AreEqual(precioFinalEsperado, resultado);
        }
        [TestMethod]
        public void loginExitoso()
        {
            Usuario user = new Usuario
            {
                nombre = "chino",
                contraseña= "12345678",
                rol = "admin"
            };            
            Repositorio _repo = new Repositorio();           
            string respestaEsperado = "Login Exitoso";
            string resultado = _repo.IngresarUsuario(user.nombre, user.contraseña);      
            Assert.AreEqual(respestaEsperado, resultado);
        }
    }
}
