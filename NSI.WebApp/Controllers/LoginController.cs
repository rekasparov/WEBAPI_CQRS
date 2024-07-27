using Microsoft.AspNetCore.Mvc;

namespace NSI.WebApp.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
