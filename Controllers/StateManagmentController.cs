
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    public class StateManagmentController : Controller
    {


        public IActionResult SetCookie()
        {

            CookieOptions cookie = new CookieOptions();
            cookie.Expires=DateTimeOffset.Now.AddHours(1);
            Response.Cookies.Append("name", "Muhammad");
            Response.Cookies.Append("age", "30");

            return Content("Cookie Data Saved");
        }

        public IActionResult GetCookie()
        {
            string name = Request.Cookies["name"];
            int age =int.Parse( Request.Cookies["age"]);
            return Content($"Data From Cookie: Name {name} and Age: {age}");
        }
        public IActionResult SetSessionData()
        {
            HttpContext.Session.SetString("name", "Safa");
            HttpContext.Session.SetInt32("age", 20);
            return Content("Session Data Saved");
        }

        public IActionResult GetSessionData()
        {
            string? name=HttpContext.Session.GetString("name");
            int? age = HttpContext.Session.GetInt32("age");
            return Content($"Name: {name} and Age: {age}");
        }
        public IActionResult SetTempData()
        {
            TempData["msg"] = "Muhammad Loves Safa";
            return Content("Data Saved");
        }

        public IActionResult Get1()
        {
            string message = TempData["msg"].ToString();
            TempData.Keep();
            return Content("Get1"+message);
        }

        public IActionResult Get2()
        {
            string message = TempData["msg"].ToString();
            return Content("Get2"+message);
        }
    }
}
