using Microsoft.AspNetCore.Mvc;
using Travel.Business.Helpers;

namespace Travel.Web.Controllers
{
    [ServiceFilter(typeof(Security))]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}