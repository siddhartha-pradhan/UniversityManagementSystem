using UniversityWebApplication.ViewModels.Faculty;

namespace UniversityWebApplication.ViewModels.Course
{
    public class CourseGet
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public int Credits { get; set; }

        public int FacultyID { get; set; }

        public FacultyGet Faculty { get; set; }
    }
}
