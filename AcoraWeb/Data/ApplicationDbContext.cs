using AcoraWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace AcoraWeb.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Department>? Departments { get; set; }
        public DbSet<Employee>? Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasData(
                new Department
                {
                    Id=1,
                    Name = "HR"
                },
                new Department
                {
                    Id=2,
                  Name = "IT"
               }
            );

          modelBuilder.Entity<Employee>().HasData(
          new Employee { Id=1,DateOfBirth = DateTime.Now, FirstName = "David", LastName = "Warner" ,Address="City Center Bham", City="Birmingham", DepartmentId=1 }
          );

        }

    }
}
