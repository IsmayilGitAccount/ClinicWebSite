using ClinicWebSite.Data;
using ClinicWebSite.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ClinicWebSite
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<AppDbContext>(
                opt =>
                opt.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

            builder.Services.AddIdentity<AppUser, IdentityRole>(opt =>
            {
                opt.Password.RequiredLength = 8;
                opt.Lockout.AllowedForNewUsers = true;
                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);
            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

            var app = builder.Build();
            
            app.UseStaticFiles();

            app.MapControllerRoute(
               name: "admin",
               pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
               );

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}"
                );

            app.Run();
        }
    }
}
