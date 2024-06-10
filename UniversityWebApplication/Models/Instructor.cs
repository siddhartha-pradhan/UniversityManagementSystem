using System.ComponentModel.DataAnnotations;

namespace UniversityWebApplication.Models
{
    public class Instructor
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<CourseAssignment> CourseAssignments { get; set; }
    }
}
