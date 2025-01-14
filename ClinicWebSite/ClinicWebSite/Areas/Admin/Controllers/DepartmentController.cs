using ClinicWebSite.Areas.ViewModels.Department;
using ClinicWebSite.Data;
using ClinicWebSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClinicWebSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DepartmentController : Controller
    {
        private readonly AppDbContext _context;

        public DepartmentController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(GetDepartmentVM departmentVM)
        {
            var departments = await _context.Departments.Select(d=> new GetDepartmentVM
            {
                Id = d.Id,
                DepartmentName = d.DepartmentName
            }).ToListAsync();
            
            return View(departments);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateDepartmentVM departmentVM)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }

            bool result = await _context.Departments.AnyAsync(d=>d.DepartmentName.Trim() == departmentVM.DepartmentName.Trim());

            if (result)
            {
                ModelState.AddModelError(nameof(Department.DepartmentName), $"{departmentVM.DepartmentName} is already taken");
                return View(departmentVM);
            }

            Department department = new Department() 
            { 
                DepartmentName =departmentVM.DepartmentName
            };

            _context.Departments.Add(department);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null || id < 1) return BadRequest();

            Department department = await _context.Departments.FirstOrDefaultAsync(d => d.Id == id);

            if (department == null) return NotFound();

            _context.Departments.Remove(department);

            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(int? id)
        {
            if (id is null || id < 1) return BadRequest();

            Department department = _context.Departments.FirstOrDefault(d => d.Id == id);

            if (department == null) return NotFound();

            UpdateDepartmentVM departmentVM = new UpdateDepartmentVM()
            {
                DepartmentName = department.DepartmentName,
            };

            return View(departmentVM);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int? id, UpdateDepartmentVM departmentVM)
        {
            if (id is null || id < 1) return BadRequest();

            Department existed = await _context.Departments.FirstOrDefaultAsync(d => d.Id == id);

            if (existed == null) return NotFound();

            if (!ModelState.IsValid)
            {
                return View(departmentVM);
            }

            bool result = await _context.Departments.AnyAsync(d => d.DepartmentName.Trim() == departmentVM.DepartmentName.Trim() && d.Id != id);

            if (result)
            {
                ModelState.AddModelError(nameof(Department.DepartmentName), $"{departmentVM.DepartmentName} is already taken");
                return View(departmentVM);
            }

            existed.DepartmentName = departmentVM.DepartmentName;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
