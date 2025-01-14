using ClinicWebSite.Data;
using ClinicWebSite.Models;
using ClinicWebSite.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClinicWebSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            HomeVM homeVM = new HomeVM() 
            {
                Doctors = _context.Doctors.Include(d=>d.Department).ToList()
            };
            return View(homeVM);
        }
    }
}
