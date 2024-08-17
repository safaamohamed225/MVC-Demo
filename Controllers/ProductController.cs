using Demo.Models;
using Demo.Models.ProductSampleData;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json ;

namespace Demo.Controllers
{
    public class ProductController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}

        #region First
        //public string ShowMsg()
        //{
        //    return "Hello Everyone";
        //}

        //public ContentResult ShowContent()
        //{
        //    ContentResult contentResult = new ContentResult();
        //    contentResult.Content = "Muhammad married Safa";
        //    return contentResult;
        //}

        //public ViewResult ShowView()
        //{
        //    //ViewResult viewResult = new ViewResult();
        //    //viewResult.ViewName = "View Page";
        //    //return viewResult;

        //    return View("View Page");
        //}

        //public JsonResult ShowJson()
        //{
        //    //    JsonResult jsonResult = new JsonResult(new { ID = 1, Name = "Muhammad and Safa" });
        //    //    return jsonResult;
        //    return Json(new { ID = 1, Name = "Muhammad and Safa" });
        //}


        //public IActionResult Show(int id , int age)
        //{
        //    if(id%2==0)
        //    {
        //        //ContentResult contentResult = new ContentResult();
        //        //contentResult.Content = "This number is Even";
        //        //return contentResult;

        //        return Content("This number is Even");
        //    }

        //    else
        //    {
        //        //JsonResult jsonResult=new JsonResult("Odd Number");

        //        //return jsonResult;

        //        return Json("Odd Number");
        //    }
        //} 
        #endregion

        ProductSampleData productSampleData = new ProductSampleData();


        public IActionResult Details(int id)
        {
            //ProductSampleData productSampleData = new ProductSampleData();
            Product productData= productSampleData.GetById(id);

            return View("productDetails", productData);
        }


        public IActionResult GetAll()
        {
            List<Product> products = productSampleData.GetAll();

            return View("ShowAll",products);
        }

    }
}
