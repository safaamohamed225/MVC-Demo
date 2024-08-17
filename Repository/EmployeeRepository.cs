using Demo.Models;
namespace Demo.Repository
{
    public class EmployeeRepository:IEmployeeRepository
    {
        ITIEntity context;// = new ITIEntity();
        public EmployeeRepository(ITIEntity dbContext)
        {
            context = dbContext;    
        }

        public Guid Id { get; set; }

        public EmployeeRepository()
        {
            Id=Guid.NewGuid(); 
        }
        public List<Employee> GetAll()
        {
            List<Employee> employees = context.Employees.ToList();
            return employees;
        }
        public Employee GetById(int id)
        {
            Employee employee = context.Employees.FirstOrDefault(e=>e.Id == id);
            return employee;
        }

        public List<Employee> GetByDeptId(int deptId)
        {
            return context.Employees.Where(e => e.Dept_Id == deptId).ToList();
        }

        public void Insert(Employee employee)
        {
            context.Employees.Add(employee);
            context.SaveChanges();
        }
        public void Update(int id, Employee newEmployee)
        {
            Employee oldEmployee = GetById(id);

            oldEmployee.Name = newEmployee.Name;
            oldEmployee.Salary = newEmployee.Salary;
            oldEmployee.Address = newEmployee.Address;
            oldEmployee.Dept_Id = newEmployee.Dept_Id;
            oldEmployee.Image = newEmployee.Image;

            context.SaveChanges();
                 

        }

        public void Delete(int id )
        {
            Employee emp = GetById(id);
            context.Employees.Remove(emp);
            context.SaveChanges();
        }

    }
}
