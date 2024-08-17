using Demo.Filters;
using Demo.Models;
using Demo.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    public class DepartmentController : Controller
    {
        //ITIEntity context = new ITIEntity();

        IDepartmentRepository deptRepo;//= new DepartmentRepository();
        IEmployeeRepository empRepo;//= new EmployeeRepository();

        public DepartmentController(IDepartmentRepository deptRepo , IEmployeeRepository empRepo)
        {
            this.deptRepo = deptRepo;
            this.empRepo = empRepo;
        }

        //[Authorize]

        //[ResponseCache(Duration =10)]

        [MyFilter]
        public IActionResult ShowDepartmentsList()
        {
            List<Department> DepartList = deptRepo.GetAll(); //context.Departments.ToList();
            return View(DepartList);
        }

        public IActionResult GetEmployeePerDepartment(int deptId)
        {
            List<Employee> emps = empRepo.GetByDeptId(deptId);//context.Employees.Where(e => e.Dept_Id == deptId).ToList();
            return Json(emps);
        }
        public IActionResult Index()
        {
            List<Department> departmentList = deptRepo.GetAllDepartmentsWithEmployeesName(); //context.Departments.Include(d => d.Employees).ToList();

            //return View("Index",departmentList);
            return View(departmentList);
        }

        [HttpGet]
        public IActionResult New()
        {
            return View(new Department());
        }


        [HttpPost]
        public IActionResult SaveNew(Department dept)
        {
            if(dept.Name!=null)
            {
                //context.Departments.Add(dept);
                //context.SaveChanges();
                deptRepo.Insert(dept);
                return RedirectToAction("Index");
            }
            return View("New",dept);
        }
    }
}
