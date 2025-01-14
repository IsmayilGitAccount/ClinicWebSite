
using System.ComponentModel.DataAnnotations;

namespace ClinicWebSite.Areas.ViewModels
{
    public class CreateDoctorVM
    {
        [Required]
        public string DoctorName { get; set; }

        [Required]
        public int DepartmentId { get; set; }

        public List<ClinicWebSite.Models.Department> Department { get; set; }

        [Required]
        public string Image { get; set; }

        [Required]
        public string FacebookLink { get; set; }

        [Required]
        public string TwitterLink { get; set; }

        [Required]
        public string InstagramLink { get; set; }

        [Required]
        public IFormFile Photo { get; set; }
    }
}
