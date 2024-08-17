using Demo.Models;
using Demo.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Demo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews(
                //confg => confg.Filters.Add()
                );//.AddSessionStateTempDataProvider();
            builder.Services.AddSession(conf=>conf.IdleTimeout=TimeSpan.FromMinutes(30));

            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            //builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            //builder.Services.AddSingleton<IEmployeeRepository, EmployeeRepository>();


            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();

            builder.Services.AddDbContext<ITIEntity>(optionBuilder =>
            {
                optionBuilder.UseSqlServer(builder.Configuration.GetConnectionString("cs"));
                });

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequireLowercase = false;
                options.Password.RequireDigit = true;
            })
                .AddEntityFrameworkStores<ITIEntity>();
            var app = builder.Build();

 


            //app.Use(async (httpContext, next) =>
            //{
            //    await httpContext.Response.WriteAsync("1)middleware 1");
            //    await next.Invoke();

            //});

            //app.Use(async (httpContext, next) =>
            //{
            //    await httpContext.Response.WriteAsync("2)middleware 2");
            //    await next.Invoke();
            //});

            //app.Run(async (httpContext) =>
            //{
            //    await httpContext.Response.WriteAsync("3)Terminate");

            //});

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();//hint

            app.UseSession();

            app.MapControllerRoute("safa", "emp/{id}", new
            {
                Controller="Employee",
                action="Details"
            });

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}/{name?}");

            app.Run();
        }
    }
}
