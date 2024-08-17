using Demo.Models;
using Demo.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    public class EmployeeController : Controller
    {
        //ITIEntity context = new ITIEntity();

        IEmployeeRepository empRepo;//= new EmployeeRepository();
        IDepartmentRepository deptRepo;// = new DepartmentRepository();

        public EmployeeController(IEmployeeRepository empRepo , IDepartmentRepository deptRepo)
        {
            this.deptRepo = deptRepo;
            this.empRepo = empRepo;
        }
        public IActionResult Details(int id)
        {
            //return View(context.Employees.FirstOrDefault(e=>e.Id == id));
            return View(empRepo.GetById(id));

        }
        public IActionResult DetailsUdingPartial(int id)
        {
            //Employee emp = context.Employees.FirstOrDefault(e => e.Id == id);
            Employee emp = empRepo.GetById(id);

            return PartialView("_EmployeeCardPartial", emp);
        }
        public IActionResult CheckSalary(int Salary)
        {
            if(Salary > 2000)
            {
                return Json(true);
            }
            return Json(false);
        }
        [Authorize]
        public IActionResult Index()
        {
            //return View(context.Employees.ToList());
            return View(empRepo.GetAll());

        }

        public IActionResult Edit(int id)
        {
            //Employee empModel=context.Employees.FirstOrDefault(e=>e.Id==id);
            Employee empModel=empRepo.GetById(id);


            //ViewData["DeptList"] = context.Departments.ToList();
            ViewData["DeptList"] = deptRepo.GetAll();

            //ViewData["addressList"] = "Alex,Assuit,Sohag";

            return View(empModel);
        }
        [HttpPost]
        public IActionResult SaveEdit(int id, Employee newEmp)
        {
            //if(newEmp.Name !=null && newEmp.Salary>1000)
            if (ModelState.IsValid)
            {
                //Employee oldEmp = context.Employees.FirstOrDefault(e => e.Id == id);
                Employee oldEmp = empRepo.GetById(id);

                //if (oldEmp!=null)
                //{
                //oldEmp.Name = newEmp.Name;
                //oldEmp.Salary = newEmp.Salary;
                //oldEmp.Address = newEmp.Address;
                //oldEmp.Image = newEmp.Image;
                //oldEmp.Dept_Id = newEmp.Dept_Id;


                   empRepo.Update(id, newEmp);

                    //context.SaveChanges();
                    return RedirectToAction("Index");
                //}
         
            }
            //ViewData["DeptList"] = context.Departments.ToList();
            ViewData["DeptList"] = deptRepo.GetAll();

            //ViewData["addressList"] = "Alex,Assuit,Sohag";


            return View("Edit", newEmp);
            
        }

             
        public IActionResult New()
        {
            ViewData["DropDownList"] = deptRepo.GetAll();
            //ViewData["addressList"] = "Alex,Assuit,Sohag";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveNew(Employee newEmp)
        {
            //if(newEmp.Name !=null)
            if (ModelState.IsValid)
            {
                try
                {
                    //context.Employees.Add(newEmp);
                    //context.SaveChanges();
                    empRepo.Insert(newEmp);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    //ModelState.AddModelError(String.Empty, ex.Message.ToString());
                    ModelState.AddModelError("Dept_Id", ex.InnerException.Message);
                }
                
                //ViewData["addressList"] = "Alex,Assuit,Sohag";     
            }

            //ViewData["DropDownList"] = context.Departments.ToList();
            ViewData["DropDownList"] = deptRepo.GetAll();

            return View("New", newEmp);

        }
    }
}
