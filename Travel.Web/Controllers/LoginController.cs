using Microsoft.AspNetCore.Mvc;
using System.Data;
using Travel.Business.Business;
using Travel.Business.Helpers;

namespace Travel.Web.Controllers
{
    public class LoginController : Controller
    {
        /// <summary>
        /// Método para acceder a la vista Index.
        /// </summary>
        public IActionResult Index()
        {
            return View();
        }

        #region "Function"
        /// <summary>
        /// Métodos para iniciar sesion.
        /// <param name="user">Recibe un parámetro user desde la vista.</param>
        /// <param name="pass">Recibe un parámetro pass desde la vista..</param>
        /// </summary>
        public string Login(string user, string pass)
        {
            string rpta = "";

            string clavecrifrada = Generic.MD5Hash(pass);
            string usuario = user.Trim();

            if ((user != null) && (pass != null))
            {
                bUsuarios oUser = new bUsuarios();
                DataTable dt = oUser.Login(usuario, clavecrifrada);
                if (dt.Rows.Count > 0)
                {
                    string? Username = dt.Rows[0]["Nombre_Usuario"].ToString();
                    HttpContext.Session.SetString("usuario", Username);

                    rpta = "Ok"; // Aquí se asigna el valor "Ok" a la variable rpta
                }
                else
                {
                    // Si no se obtiene un resultado de la consulta, puedes asignar un mensaje de error a la variable rpta
                    rpta = "Error de autenticación";
                }
            }
            else
            {
                // Si los parámetros son nulos, puedes asignar un mensaje de error a la variable rpta
                rpta = "";
            }
            return rpta;
        }
        /// <summary>
        /// Método para cerrar sesion.
        /// </summary>
        public ActionResult Cerrar()
        {
            HttpContext.Session.Remove("usuario");
            return RedirectToAction("Index");
        }
        #endregion
    }
}
