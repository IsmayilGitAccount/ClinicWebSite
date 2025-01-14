using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicWebSite.Models
{
    public class Doctor:BaseEntity
    {
        public string DoctorName { get; set; }
        public string FacebookLink { get; set; }
        public string TwitterLink { get; set; }
        public string InstagramLink { get; set; }
        public string Image { get; set; }

        
        //Relational
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
