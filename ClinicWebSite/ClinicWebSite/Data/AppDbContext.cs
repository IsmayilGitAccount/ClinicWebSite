using ClinicWebSite.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicWebSite.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
