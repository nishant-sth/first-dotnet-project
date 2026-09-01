using Microsoft.AspNetCore.Mvc;

namespace first_dotnet_project.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public IActionResult Home()
        {
            return View();
        }
    }
}
