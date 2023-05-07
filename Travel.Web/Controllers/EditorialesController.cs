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
    public class EditorialesController : Controller
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
            return obj.ListEditoriales("Ed");
        }
        /// <summary>
        /// Métodos para buscar autor por Id.
        /// <param name="Id">Id que envio desde el controller para realizar la busqueda por parámetro Id_Editorial.</param>
        /// </summary>
        public List<eEditoriales> ListEditorialesXId(string Id)
        {
            bEditoriales obj = new bEditoriales();
            return obj.ListEditorialesXId(Convert.ToInt32(Id));
        }
        /// <summary>
        /// Métodos para insertar y editar un editorial.
        /// <param name="autores">Envío el modelo cómo parámetro para realizar la inserción.</param>
        /// </summary>
        [HttpPost]
        public async Task<string> Save(EditorialesViewModel editorialesViewModel)
        {
            string rpta = "";

            if (ModelState.IsValid)
            {
                bEditoriales objEditB = new bEditoriales();
                eEditoriales objEditE = new eEditoriales();

                objEditE.Nombre_Editorial = editorialesViewModel.Nombre_Editorial;
                objEditE.Sede = editorialesViewModel.Sede;

                if (editorialesViewModel.Id_Editorial != 0)
                {
                    objEditE.Id_Editorial = editorialesViewModel.Id_Editorial;

                    await objEditB.UpdateEditoriales(objEditE);
                    rpta = "Ok";
                }
                else
                {
                    await objEditB.InsertEditoriales(objEditE);
                    rpta = "Ok";
                }
            }
            return rpta;
        }
    }
}
