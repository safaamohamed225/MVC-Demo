using Demo.Models;
using Demo.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    public class PassDataController : Controller
    {
        ITIEntity context=new ITIEntity();



      
        //public IActionResult TestViewData(int id)
        //{
            


        //    Employee emp = context.Employees.FirstOrDefault(e=>e.Id==id);
        //    string message = "Muhammad Loves Safa";
        //    int temp = 27;
        //    string color = "blue";
        //    List<string> Branches = new List<string>();
        //    Branches.Add("Alex");
        //    Branches.Add("Bani Seuf");
        //    Branches.Add("Smart");
        //    Branches.Add("Sohag");
        //    Branches.Add("Zagazig");

        //    ViewData["message"] = message;
        //    ViewData["temp"] = temp;
        //    ViewData["color"] = color;
        //    ViewData["Branches"] = Branches;

        //    return View(emp);
        //}


        public IActionResult TestViewModel(int id)
        {

            Employee emp = context.Employees.FirstOrDefault(e => e.Id == id);
            string message = "Muhammad Loves Safa";
            int temp = 27;
            string color = "blue";
            List<string> Branches = new List<string>();
            Branches.Add("Alex");
            Branches.Add("Bani Seuf");
            Branches.Add("Smart");
            Branches.Add("Sohag");
            Branches.Add("Zagazig");


            EmployeeWithMessageAndBranchListViewModel empModel = new EmployeeWithMessageAndBranchListViewModel();

            empModel.Color=color;
            empModel.Message = message;
            empModel.Temp = temp;
            empModel.Branches = Branches;
            empModel.EmpID = emp.Id;
            empModel.EmpName = emp.Name;

            return View(empModel);

        }
    }
}
