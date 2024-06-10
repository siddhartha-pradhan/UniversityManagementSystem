using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityWebApplication.Models
{
    public class Faculty
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }

        public int? SupervisorID { get; set; }

        [ForeignKey("SupervisorID")]
        public Instructor Instructor { get; set; }

        public ICollection<Course> Courses { get; set; }
    }
}
