using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using UniversityWebApplication.Models;

namespace UniversityWebApplication.ViewModels.Course
{
    public class CourseAdd
    {
        public string Title { get; set; }

        public int Credits { get; set; }

        public int FacultyID { get; set; }
    }
}
