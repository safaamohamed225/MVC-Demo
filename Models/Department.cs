using System.ComponentModel.DataAnnotations;

namespace Demo.Models
{
    public class Department
    {
        public int Id { get; set; }

        [Display(Name="Depatment Name")]
        //[DataType(DataType.Password)]
        public string Name { get; set; }
        public string ManagerName { get; set; }

        public virtual List<Employee>? Employees { get; set; }
    }
}
