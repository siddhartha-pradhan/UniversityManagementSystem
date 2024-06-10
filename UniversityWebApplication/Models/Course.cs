using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityWebApplication.Models
{
    public class Course
    {
        [Key]
        public int ID { get; set; }
    
        public string Title { get; set; }

        [Range(0, 60)]
        public int Credits { get; set; }

        public int FacultyID { get; set; }

        [ForeignKey("FacultyID")]
        public Faculty? Faculty { get; set; }

        public ICollection<Enrollment>? Enrollments { get; set; }

        public ICollection<CourseAssignment>? CourseAssignments { get; set; }
    }
}
