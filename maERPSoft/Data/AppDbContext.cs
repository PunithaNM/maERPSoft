
using Microsoft.EntityFrameworkCore;
using maERPSoft.Models;

namespace maERPSoft.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        // Add your DbSets (tables)
        public DbSet<Employee> Employee { get; set; }
    }
}