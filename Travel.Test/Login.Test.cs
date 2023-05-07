using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Travel.Web.Controllers;

namespace Travel.Test
{
    public class Login
    {
        private LoginController _controller;

        [SetUp]
        public void Setup()
        {
            // Crea una instancia del controlador
            _controller = new LoginController();
        }

        [Test]
        public void TestLogin_ValidCredentials_ReturnsOk()
        {
            // Crea un objeto UsersController con un contexto de controlador configurado
            var controller = new LoginController();
            var httpContext = new Mock<HttpContext>();
            var session = new Mock<ISession>();
            httpContext.Setup(x => x.Session).Returns(session.Object);
            controller.ControllerContext = new ControllerContext();
            controller.ControllerContext.HttpContext = httpContext.Object;

            // Llama al método Login() en el controlador con credenciales válidas
            var result = controller.Login("admin", "1234");

            // Verifica que el resultado sea "Ok"
            Assert.AreEqual("Ok", result);
        }
        [Test]
        public void Cerrar_DeberiaRemoverUsuarioDeLaSesionYRedirigirAlIndex()
        {
            // Arrange
            var controlador = new LoginController();
            var contexto = new Mock<HttpContext>();
            var sesion = new Mock<ISession>();
            contexto.SetupGet(c => c.Session).Returns(sesion.Object);
            controlador.ControllerContext.HttpContext = contexto.Object;

            // Act
            var resultado = controlador.Cerrar() as RedirectToActionResult;

            // Assert
            sesion.Verify(s => s.Remove("usuario"), Times.Once);
            Assert.AreEqual("Index", resultado.ActionName);
        }
    }
}
