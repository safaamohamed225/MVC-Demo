using Demo.Models;

namespace Demo.Repository
{
    public interface IDepartmentRepository
    {

        List<Department> GetAll();

        List<Department> GetAllDepartmentsWithEmployeesName();


        Department GetById(int id);

        void Insert(Department department);


        void Update(int id, Department newDepartment);

        void Delete(int id);
 

    }
}
