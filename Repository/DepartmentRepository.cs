using Demo.Models;
using Microsoft.EntityFrameworkCore;
namespace Demo.Repository
{
    public class DepartmentRepository:IDepartmentRepository
    {
        ITIEntity context;//= new ITIEntity();
        public DepartmentRepository(ITIEntity dbContext)
        {
            context=dbContext;
        }

        public List<Department> GetAll()
        {
            List<Department> departments = context.Departments.ToList();
            return departments;
        }

        public List<Department> GetAllDepartmentsWithEmployeesName()
        {
            return context.Departments.Include(e => e.Employees).ToList();
        }

        public Department GetById(int id)
        {
            Department department=context.Departments.FirstOrDefault(d=>d.Id==id);
            return department;
        }
        public void Insert(Department department)
        {
            context.Departments.Add(department);
            context.SaveChanges();
        }

        public void Update(int id, Department newDepartment) 
        {
            Department oldDepartment = GetById(id);
            oldDepartment.Name = newDepartment.Name;
            oldDepartment.ManagerName = newDepartment.ManagerName;
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            Department dept = GetById(id);
            context.Departments.Remove(dept);
            context.SaveChanges();
        }
   

    }
}
