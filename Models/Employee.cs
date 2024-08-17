using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        [UniqueName]
        public string? Name { get; set; }

        //[Range(2000,5000)]
        //[RegularExpression(@"[0-9]{4}")]

        [Required]
        [Remote("CheckSalary","Employee",ErrorMessage ="Salary must be greater than 2000")]
        public int Salary { get; set; }
        [Required]
        [RegularExpression("Alex|Cairo|Asuit")]
        
        public string? Address { get; set; }
        [RegularExpression(@"[a-z]+\.(jpg|png)",ErrorMessage ="Image must start with char or more and ends with jpg or png")]
        public string Image { get; set; }

        [ForeignKey("Department")]
        public int Dept_Id { get; set; }
        
        public Department? Department { get; set; }
  


    }
}
