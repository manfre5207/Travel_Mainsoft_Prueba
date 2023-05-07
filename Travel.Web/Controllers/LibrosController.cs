using Microsoft.AspNetCore.Mvc;
using Travel.Business.Business;
using Travel.Business.Helpers;
using Travel.Entities.Entities;
using Travel.Web.Models;

namespace Travel.Web.Controllers
{
    /// <summary>
    /// Etiqueta que activa la seguridad de mi controlador.
    /// </summary>
    [ServiceFilter(typeof(Security))]
    public class LibrosController : Controller
    {
        /// <summary>
        /// Método para acceder a la vista Index.
        /// </summary>
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Métodos para listar todos los editoriales.
        /// </summary>
        public List<eEditoriales> ListEditoriales()
        {
            bEditoriales obj = new bEditoriales();
            return obj.ListEditoriales("Lib");
        }
        /// <summary>
        /// Métodos para listar todos los autores.
        /// </summary>
        public List<eAutores> ListAutores()
        {
            bAutores obj = new bAutores();
            return obj.ListAutores("Lib");
        }
        /// <summary>
        /// Métodos para listar todos los libros.
        /// </summary>
        public List<eLibros> ListLibros()
        {
            bLibros obj = new bLibros();
            return obj.ListLibros();
        }
        /// <summary>
        /// Métodos para buscar autor por Id.
        /// <param name="Id">Id que envio desde el controller para realizar la busqueda por parámetro Id_Libro.</param>
        /// </summary>
        public List<eLibros> ListLibrosXId(string Id)
        {
            bLibros obj = new bLibros();
            return obj.ListLibrosXId(Convert.ToInt32(Id));
        }
        /// <summary>
        /// Métodos para insertar y editar un libro.
        /// <param name="autores">Envío el modelo cómo parámetro para realizar la inserción.</param>
        /// </summary>
        [HttpPost]
        public async Task<string> Save(LibrosViewModel libros)
        {
            string rpta = "";

            if (ModelState.IsValid)
            {
                bLibros objLibB = new bLibros();
                eLibros objLibE = new eLibros();

                objLibE.ISBN = libros.ISBN;
                objLibE.Id_Editorial = libros.Id_Editorial;
                objLibE.Titulo = libros.Titulo;
                objLibE.Sinopsis = libros.Sinopsis;
                objLibE.N_Paginas = libros.N_Paginas;

                if (libros.Id_Libro != 0)
                {
                    objLibE.Id_Libro = libros.Id_Libro;

                    bool sw = await objLibB.UpdateLibros(objLibE);

                    if (sw)
                    {
                        bLibros objAutLibB = new bLibros();
                        eLibros objAutLibE = new eLibros();

                        objAutLibE.Id_Autor_Libro = libros.Id_Autor_Libro;
                        objAutLibE.ISBN = libros.ISBN;
                        objAutLibE.Id_Autor = libros.Id_Autor;

                        await objAutLibB.EditarAutoresLibros(objAutLibE);

                        rpta = "Ok";
                    }


                }
                else
                {
                    bool sw = await objLibB.InsertLibros(objLibE);

                    if (sw)
                    {
                        bLibros objAutLibB = new bLibros();
                        eLibros objAutLibE = new eLibros();

                        objAutLibE.ISBN = libros.ISBN;
                        objAutLibE.Id_Autor = libros.Id_Autor;

                        await objAutLibB.InsertAutoresLibros(objAutLibE);

                        rpta = "Ok";
                    }
                }
            }
            return rpta;
        }

    }
}
