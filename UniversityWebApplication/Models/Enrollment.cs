using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityWebApplication.Models
{
    public class Enrollment
    {
        [Key]
        public int ID { get; set; }

        public int StudentID { get; set; }

        public int CourseID { get; set; }

        [Range(0, 100)]
        public int? Marks { get; set; }

        [ForeignKey("StudentID")]
        public Student? Student { get; set; }

        [ForeignKey("CourseID")]
        public Course? Course { get; set; }
    }
}
