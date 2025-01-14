using System.ComponentModel.DataAnnotations;
using ClinicWebSite.Models;

namespace ClinicWebSite.Areas.ViewModels.Doctor
{
    public class CreateDoctorVM
    {
        [Required]
        public string DoctorName { get; set; }

        [Required]
        public string DepartmentName { get; set; }

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
