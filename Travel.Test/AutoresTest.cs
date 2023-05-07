using Travel.Entities.Entities;
using Travel.Web.Controllers;
using Travel.Web.Models;

namespace Travel.Test
{
    public class Autores
    {
        private AutoresController _controller;

        [SetUp]
        public void Setup()
        {
            // Crea una instancia del controlador
            _controller = new AutoresController();
        }

        [Test]
        public void TestListAutores()
        {
            // Llama a un m�todo del controlador y realiza pruebas
            var result = _controller.ListAutores();

            // A�ade aserciones para verificar el resultado
            Assert.IsNotNull(result); // verifica que el resultado no sea nulo
            Assert.IsInstanceOf<List<eAutores>>(result); // verifica que el resultado sea una lista de eAutores

        }
        [Test]
        public void TestListAutoresXId_ReturnsValidResult()
        {
            // Llama al m�todo ListAutoresXId() en el controlador con un ID v�lido
            var result = _controller.ListAutoresXId("1");

            // Verifica que el resultado no sea nulo
            Assert.IsNotNull(result);

            // Verifica que el resultado sea una lista de eAutores
            Assert.IsInstanceOf<List<eAutores>>(result);

            // Verifica que el resultado tenga un solo elemento
            Assert.AreEqual(1, result.Count);

            // Verifica que el elemento tenga el ID y nombre esperados
            Assert.AreEqual(1, result[0].Id_Autor);
        }
        [Test]
        public void TestListAutoresXId_InvalidId_ReturnsEmptyList()
        {
            // Llama al m�todo ListAutoresXId() en el controlador con un ID inv�lido
            var result = _controller.ListAutoresXId("100");

            // Verifica que el resultado no sea nulo
            Assert.IsNotNull(result);

            // Verifica que el resultado sea una lista de eAutores vac�a
            Assert.IsEmpty(result);
        }
        [Test]
        public async Task TestSave_ValidModel_ReturnsOk()
        {
            // Crea un objeto AutoresViewModel v�lido
            var model = new AutoresViewModel
            {
                Nombres_Autor = "Nombre1",
                Apellidos_Autor = "Apellido1"
            };

            // Llama al m�todo Save() en el controlador con el modelo v�lido
            var result = await _controller.Save(model);

            // Verifica que el resultado sea "Ok"
            Assert.AreEqual("Ok", result);
        }
        [Test]
        public async Task Save_InvalidModel_ReturnsEmptyString()
        {
            // Creamos un objeto AutoresViewModel con datos inv�lidos
            var invalidAutores = new AutoresViewModel
            {
                Nombres_Autor = "", // Campo requerido vac�o
                Apellidos_Autor = "Smith"
            };

            // Configuramos el ModelState para que el modelo sea inv�lido
            var controller = new AutoresController();
            controller.ModelState.AddModelError("Nombres_Autor", "El campo Nombres_Autor es requerido");

            // Llamamos al m�todo Save() con el objeto AutoresViewModel inv�lido
            var result = await controller.Save(invalidAutores);

            // Verificamos que se haya devuelto una cadena vac�a
            Assert.AreEqual("", result);
        }
    }
}