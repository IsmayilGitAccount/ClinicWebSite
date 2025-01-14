using System.ComponentModel.DataAnnotations;

namespace ClinicWebSite.Areas.ViewModels.Department
{
    public class UpdateDepartmentVM
    {
        [Required(ErrorMessage = "Department name is required")]
        public string DepartmentName { get; set; }
    }
}
