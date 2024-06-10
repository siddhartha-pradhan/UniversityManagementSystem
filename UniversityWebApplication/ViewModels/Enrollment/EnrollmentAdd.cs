using System.ComponentModel.DataAnnotations;

namespace UniversityWebApplication.ViewModels.Enrollment
{
    public class EnrollmentAdd
    {
        public int CourseID { get; set; }

        public int? Marks { get; set; }
    }
}
