using ClinicWebSite.Areas.ViewModels;
using ClinicWebSite.Areas.ViewModels.Doctor;
using ClinicWebSite.Data;
using ClinicWebSite.Models;
using ClinicWebSite.Utilities.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClinicWebSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DoctorController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public DoctorController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index(GetDoctorVM doctorVM)
        {
            var doctorVMs = await _context.Doctors.Include(d=>d.Department).Select(d=> new GetDoctorVM
            {
                Id = d.Id,
                DoctorName = d.DoctorName,
                Image = d.Image,
                DepartmentName = d.Department.DepartmentName
            }).ToListAsync();

            return View(doctorVMs);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateDoctorVM doctorVM)
        {
            if (!ModelState.IsValid)
            {
                return View(doctorVM);
            }

            if (!doctorVM.Photo.ValidateType("image/"))
            {
                ModelState.AddModelError("Photo", "File type is incorrect");
                return View();
            }
            if (!doctorVM.Photo.ValidateSize(Utilities.Enums.FileSize.MB, 2))
            {
                ModelState.AddModelError("Photo", "File size is incorrect");
                return View();
            }


            //var department = await _context.Departments
            //                               .FirstOrDefaultAsync(d => d.DepartmentName.Trim() == doctorVM.DepartmentName.Trim());

            //if (department == null)
            //{
            //    department = new Department { DepartmentName = doctorVM.DepartmentName };
            //    _context.Departments.Add(department);
            //    await _context.SaveChangesAsync();
            //}

            Doctor doctor = new Doctor()
            {
                DoctorName = doctorVM.DoctorName,
                Image = doctorVM.Image,
                FacebookLink = doctorVM.FacebookLink,
                TwitterLink = doctorVM.TwitterLink,
                InstagramLink = doctorVM.InstagramLink,
                DepartmentId = doctorVM.DepartmentId
            };

            doctor.Image = await doctorVM.Photo.CreateFileAsync(_env.WebRootPath, "assets", "img");
           
            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null || id < 1) return BadRequest();

            Doctor doctor = await _context.Doctors.FirstOrDefaultAsync(d => d.Id == id);

            if (doctor == null) return NotFound();

            doctor.Image.DeleteFile(_env.WebRootPath, "assets", "img");

            _context.Doctors.Remove(doctor);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id is null || id < 1) return BadRequest();

            Doctor doctor = await _context.Doctors.Include(d => d.Department).FirstOrDefaultAsync(d => d.Id == id);

            if (doctor == null) return NotFound();

            UpdateDoctorVM doctorVM = new UpdateDoctorVM()
            {
                DoctorName = doctor.DoctorName,
                DepartmentName = doctor.Department.DepartmentName,
                FacebookLink = doctor.FacebookLink,
                TwitterLink = doctor.TwitterLink,
                InstagramLink = doctor.InstagramLink,
                Image = doctor.Image,
            };

            return View(doctorVM);
        }
    }
}
