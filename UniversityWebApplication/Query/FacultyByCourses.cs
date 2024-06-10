using UniversityWebApplication.Models;

namespace UniversityWebApplication.Query
{
    public class FacultyByCourses
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Supervisor { get; set; }

        public List<Course> Courses { get; set; }   
    }
}
