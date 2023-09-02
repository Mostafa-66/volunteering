using Microsoft.EntityFrameworkCore;
using Volunteering.Models;

namespace Volunteering.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        public DbSet<Sector> Sectors { get; set; }
        public DbSet<Opportunity> Opportunities { get; set; }
        public DbSet<Volunteer> Volunteers { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }
}
