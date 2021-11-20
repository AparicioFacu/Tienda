using Dominio;
using System;
using Presentador.Presentadores;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Pruebas.Steps
{
    class LoginSteps
    {
        Usuario? user;
        String respuesta = "";

        [Given(@"que somos un usuario")]
        public void GivenQueSomosUnUsuario()
        {
            user = new Usuario();
        }

        [When(@"iniciamos sesión con ""(.*)"" y ""(.*)""")]
        public void WhenIniciamosSesionConY(int legajo, int contraseña)
        {
            PresentadorLogin login = new PresentadorLogin();
#pragma warning disable CS8602 // Desreferencia de una referencia posiblemente NULL.
            user.nombre = legajo.ToString();
#pragma warning restore CS8602 // Desreferencia de una referencia posiblemente NULL.
            user.contraseña = contraseña.ToString();
            respuesta = login.iniciarSesion(user);
        }

        [Then(@"el inicio de sesión ""(.*)""")]
        public void ThenElInicioDeSesion(string respuestaEsperada)
        {
            Assert.AreEqual(respuestaEsperada, respuesta);
        }

    }
}
