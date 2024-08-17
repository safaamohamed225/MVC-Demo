using Demo.Models;

namespace Demo.Repository
{


    public interface IEmployeeRepository
    {
        Guid Id { get; set; }

        List<Employee> GetAll();

        Employee GetById(int id);

        List<Employee> GetByDeptId(int deptId);

        void Insert(Employee employee);

        void Update(int id, Employee newEmployee);


        void Delete(int id);
       
    }
}
