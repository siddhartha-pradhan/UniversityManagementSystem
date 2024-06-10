using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityWebApplication.Models
{
    public class CourseAssignment
    {
        public int InstructorID { get; set; }

        public int CourseID { get; set; }

        [ForeignKey("InstructorID")]
        public Instructor Instructor { get; set; }

        [ForeignKey("CourseID")]
        public Course Course { get; set; }
    }
}