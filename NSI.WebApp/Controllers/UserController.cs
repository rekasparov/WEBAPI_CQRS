using Microsoft.AspNetCore.Mvc;

namespace NSI.WebApp.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("users")]
        public IActionResult GetUsers()
        {
            return Content("List of all users.");
        }

        [Route("users/{userId}")]
        public IActionResult GetUserById(string userId)
        {
            return Content("User with id: " + userId);
        }
    }
}
