using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Demo.Models;
using Demo.ViewModel;

namespace Demo.Models
{
    public class ITIEntity:IdentityDbContext<ApplicationUser>//DbContext
    {

        public ITIEntity():base()
        {

        }

        public ITIEntity(DbContextOptions dbContextOptions):base(dbContextOptions)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.; Initial Catalog=Safa; Integrated Security=True;TrustServerCertificate=true;Encrypt=true;");
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Demo.Models.RegisterUserViewModel> RegisterUserViewModel { get; set; } = default!;
        public DbSet<Demo.ViewModel.LoginUserViewModel> LoginUserViewModel { get; set; } = default!;
        public DbSet<Demo.ViewModel.RoleViewModel> RoleViewModel { get; set; } = default!;

    }
}
