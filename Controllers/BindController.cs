using Demo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    public class BindController : Controller
    {
       public IActionResult TestPremitive(int id , string name, int age)
        {
            return Content($"Id={id} and Name: {name}");
        }

        public IActionResult TestDic(Dictionary<string,int> phones)
        {
            return Content($"Phones: {phones.ToDictionary()}");
        }

        public IActionResult TestComplex(Department dept)
        {
            return Content("OK");
        }
    }
}
