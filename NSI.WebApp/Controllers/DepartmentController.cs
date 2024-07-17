using Microsoft.AspNetCore.Mvc;

namespace NSI.WebApp.Controllers
{
    public class DepartmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
