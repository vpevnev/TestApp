using Microsoft.AspNetCore.Mvc;

namespace TestApp.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
