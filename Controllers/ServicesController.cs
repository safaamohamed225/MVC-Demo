using Demo.Filters;
using Demo.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Demo.Controllers
{
    public class ServicesController : Controller
    {
        //[MyFilter]

        [Authorize]
        public IActionResult TestClaims()
        {
            string name = User.Identity.Name;
            Claim idClaim=User.Claims.FirstOrDefault(c=>c.Type==ClaimTypes.NameIdentifier);
            return Content("User ID = " + idClaim.Value);
        }
        public IActionResult TestFilter()
        {
            return Content("Test");
        }

        IEmployeeRepository empRepository;
        private readonly IConfiguration config;

        public ServicesController(IEmployeeRepository empRepo)
        {
            empRepository= empRepo;
        }
        public IActionResult Index()
        {
           //string name= config.GetSection("ProjectName").Value;
            ViewBag.Id = empRepository.Id;
            return View();
        }
    }
}
