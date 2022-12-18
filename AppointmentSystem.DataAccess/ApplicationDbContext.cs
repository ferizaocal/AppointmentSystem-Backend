using System;
using AppointmentSystem.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppointmentSystem.DataAccess
{
	public class ApplicationDbContext:DbContext
	{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContext) : base(dbContext)
        { }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("server=.;database=AppointmentDB;Integrated Security=true");
        //    base.OnConfiguring(optionsBuilder);
        //}
        //dbset nedir
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<AppointmentService> AppointmentServices { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeService> EmployeeServices { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Coiffeur> Coiffeurs { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<WorkingHours> WorkingHours { get; set; }
    }
}

