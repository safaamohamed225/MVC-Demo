using Demo.Models;

namespace Demo.ViewModel
{
    public class EmployeeWithMessageAndBranchListViewModel
    {

        public string Message { get;set; }
        public int Temp { get; set; }
        public List<string> Branches { get; set; } 
        public string Color { get; set; }
        public int EmpID { get; set; }

        public string EmpName { get; set; }

    }
}
