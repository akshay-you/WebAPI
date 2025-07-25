using DotnetCoreAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace DotnetCoreAPI.DataBase
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
    }
}
