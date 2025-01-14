using System.ComponentModel.DataAnnotations;

namespace ClinicWebSite.Models
{
    public class Department:BaseEntity
    {
        
        public string DepartmentName { get; set; }

        //Relational
        public List<Doctor> Doctors { get; set; }
    }
}
