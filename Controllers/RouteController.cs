using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    public class RouteController : Controller
    {
        public IActionResult Index(string name)
        {
            return Content(name);
        }
    }
}
