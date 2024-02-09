using EmployeeManagementSystemAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystemAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
    }
}
