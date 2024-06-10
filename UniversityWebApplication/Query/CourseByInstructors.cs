using UniversityWebApplication.Models;

namespace UniversityWebApplication.Query
{
    public class CourseByInstructors
    {
        public int ID { get; set; }
        
        public string Title { get; set; }

        public IEnumerable<Instructor> Instructors { get; set; }
    }
}
