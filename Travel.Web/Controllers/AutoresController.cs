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
    public class AutoresController : Controller
    {
        /// <summary>
        /// Método para acceder a la vista Index.
        /// </summary>
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Métodos para listar todos los autores.
        /// </summary>
        public List<eAutores> ListAutores()
        {
            bAutores obj = new bAutores();
            return obj.ListAutores("Aut");
        }
        /// <summary>
        /// Métodos para buscar autor por Id.
        /// <param name="Id">Id que envio desde el controller para realizar la busqueda por parámetro Id_Autor.</param>
        /// </summary>
        public List<eAutores> ListAutoresXId(string Id)
        {
            bAutores obj = new bAutores();
            return obj.ListAutoresXId(Convert.ToInt32(Id));
        }
        /// <summary>
        /// Métodos para insertar y editar un autor.
        /// <param name="autores">Envío el modelo cómo parámetro para realizar la inserción.</param>
        /// </summary>
        [HttpPost]
        public async Task<string> Save(AutoresViewModel autores)
        {
            string rpta = "";

            if (ModelState.IsValid)
            {
                bAutores objAutB = new bAutores();
                eAutores objAutE = new eAutores();

                objAutE.Nombres_Autor = autores.Nombres_Autor;
                objAutE.Apellidos_Autor = autores.Apellidos_Autor;

                if (autores.Id_Autor != 0)
                {
                    objAutE.Id_Autor = autores.Id_Autor;

                    await objAutB.UpdateAutores(objAutE);
                    rpta = "Ok";
                }
                else
                {
                    await objAutB.InsertAutores(objAutE);
                    rpta = "Ok";
                }
            }
            return rpta;
        }
    }
}
