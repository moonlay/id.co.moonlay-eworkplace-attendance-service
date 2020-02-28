using System;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace AbsenApi.Models
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
         {
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                AbsenceId = 1,
                Username = "dummy",
                Name = "dummy",
                State = "dummt",
               // DateAttendece = new DateTime(1979, 04, 25),
                CheckIn = new DateTime(1979, 04, 25),
                //Photo = "dummy",
                Location = "dummy",
                CheckOut = new DateTime(1979, 04, 25),
            });
         } 
    }
}
