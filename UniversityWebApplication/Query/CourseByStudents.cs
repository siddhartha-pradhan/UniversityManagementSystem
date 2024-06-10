using UniversityWebApplication.Models;

namespace UniversityWebApplication.Query
{
    public class CourseByStudents
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public IEnumerable<Student> Students { get; set; }
    }
}
