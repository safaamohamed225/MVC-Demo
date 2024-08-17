using System.ComponentModel.DataAnnotations;

namespace Demo.Models
{
    public class UniqueNameAttribute :ValidationAttribute
    {
        protected override ValidationResult? IsValid
            (object? value, ValidationContext validationContext)
        {
            //return base.IsValid(value, validationContext);
            ITIEntity context = new ITIEntity();
            string name = value.ToString();
            Employee emp= context.Employees.FirstOrDefault(e => e.Name == name);

            if(emp==null)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Name is Found");
        }
    }
}
