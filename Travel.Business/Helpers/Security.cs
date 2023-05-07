using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Travel.Business.Helpers
{
    /// <summary>
    /// Clase que maneja la seguridad y el estado de la sesión del usuario.
    /// </summary>
    public class Security : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var usu = context.HttpContext.Session.GetString("usuario");
            var uni = context.HttpContext.Session.GetString("unidad");

            if ((usu == null) & (uni == null))
            {
                context.Result = new RedirectResult("~/Login");
            }
        }
    }
}
