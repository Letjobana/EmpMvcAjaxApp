using ECommerceApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApp.Persistance
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Designation> Designations { get; set; }
    }
}
