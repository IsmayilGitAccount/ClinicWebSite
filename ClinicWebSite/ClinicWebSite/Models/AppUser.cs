using Microsoft.AspNetCore.Identity;

namespace ClinicWebSite.Models
{
    public class AppUser:IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
