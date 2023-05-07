using Travel.Entities.Entities;
using Travel.Web.Controllers;
using Travel.Web.Models;

namespace Travel.Test
{
    public class Libros
    {
        private LibrosController _controller;

        [SetUp]
        public void Setup()
        {
            // Crea una instancia del controlador
            _controller = new LibrosController();
        }

        [Test]
        public void TestListLibros()
        {
            // Llama a un método del controlador y realiza pruebas
            var result = _controller.ListLibros();

            // Añade aserciones para verificar el resultado
            Assert.IsNotNull(result); // verifica que el resultado no sea nulo
            Assert.IsInstanceOf<List<eLibros>>(result); // verifica que el resultado sea una lista de eAutores

        }
        [Test]
        public void TestListLibrosXId_ReturnsValidResult()
        {
            // Llama al método ListAutoresXId() en el controlador con un ID válido
            var result = _controller.ListLibrosXId("1");

            // Verifica que el resultado no sea nulo
            Assert.IsNotNull(result);

            // Verifica que el resultado sea una lista de eAutores
            Assert.IsInstanceOf<List<eLibros>>(result);

            // Verifica que el resultado tenga un solo elemento
            Assert.AreEqual(1, result.Count);

            // Verifica que el elemento tenga el ID y nombre esperados
            Assert.AreEqual(1, result[0].Id_Libro);
        }
        [Test]
        public void TestListLibrosXId_InvalidId_ReturnsEmptyList()
        {
            // Llama al método ListAutoresXId() en el controlador con un ID inválido
            var result = _controller.ListLibrosXId("100");

            // Verifica que el resultado no sea nulo
            Assert.IsNotNull(result);

            // Verifica que el resultado sea una lista de eAutores vacía
            Assert.IsEmpty(result);
        }
        [Test]
        public async Task TestSave_ValidModel_ReturnsOk()
        {
            // Crea un objeto LibrosViewModel válido
            var model = new LibrosViewModel
            {
                ISBN = 1234567,
                Id_Editorial = 1,
                Titulo = "Mi libro de prueba",
                Sinopsis = "Esta es la sinopsis de mi libro de prueba",
                N_Paginas = "100",
                Id_Autor = 1,
                Id_Autor_Libro = 0
            };

            // Llama al método Save() en el controlador con el modelo válido
            var result = await _controller.Save(model);

            // Verifica que el resultado sea "Ok"
            Assert.AreEqual("Ok", result);
        }
        [Test]
        public async Task Save_InvalidModel_ReturnsEmptyString()
        {
            // Creamos un objeto LibrosViewModel con datos inválidos
            var invalidLibros = new LibrosViewModel
            {
                ISBN = 2525,
                Titulo = "",
                Id_Editorial = 2,
                Sinopsis = "Esto es una prueba",
                N_Paginas = "21"
            };

            // Configuramos el ModelState para que el modelo sea inválido
            var controller = new LibrosController();
            controller.ModelState.AddModelError("Nombres_Autor", "El campo Nombres_Autor es requerido");

            // Llamamos al método Save() con el objeto AutoresViewModel inválido
            var result = await controller.Save(invalidLibros);

            // Verificamos que se haya devuelto una cadena vacía
            Assert.AreEqual("", result);
        }
        [Test]
        public void TestListAutores()
        {
            // Llama a un método del controlador y realiza pruebas
            var result = _controller.ListAutores();

            // Añade aserciones para verificar el resultado
            Assert.IsNotNull(result); // verifica que el resultado no sea nulo
            Assert.IsInstanceOf<List<eAutores>>(result); // verifica que el resultado sea una lista de eAutores

        }
        [Test]
        public void ListEditoriales()
        {
            // Llama a un método del controlador y realiza pruebas
            var result = _controller.ListEditoriales();

            // Añade aserciones para verificar el resultado
            Assert.IsNotNull(result); // verifica que el resultado no sea nulo
            Assert.IsInstanceOf<List<eEditoriales>>(result); // verifica que el resultado sea una lista de eAutores

        }
    }
}
