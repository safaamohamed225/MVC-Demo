using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Demo.ViewModel
{
    [Keyless]
    public class RoleViewModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}
