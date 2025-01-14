using System.ComponentModel.DataAnnotations;

namespace ClinicWebSite.Areas.ViewModels.Account
{
    public class RegisterVM
    {
        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string Surname { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(256)]
        public string Username { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(256)]
        public string Email { get; set; }

        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
