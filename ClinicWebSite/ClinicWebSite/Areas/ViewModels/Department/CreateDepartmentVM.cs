using System.ComponentModel.DataAnnotations;

namespace ClinicWebSite.Areas.ViewModels.Department
{
    public class CreateDepartmentVM
    {
        [Required(ErrorMessage ="Department Name is required")]
        public string DepartmentName { get; set; }
    }
}
