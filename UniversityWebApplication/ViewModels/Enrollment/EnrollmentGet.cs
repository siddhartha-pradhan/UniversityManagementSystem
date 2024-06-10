using UniversityWebApplication.ViewModels.Course;

namespace UniversityWebApplication.ViewModels.Enrollment
{
    public class EnrollmentGet
    {
        public int CourseID { get; set; }

        public int? Marks { get; set; }

        public CourseGet Course { get; set; }
    }
}
