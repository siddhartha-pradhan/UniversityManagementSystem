using System.ComponentModel.DataAnnotations;
using UniversityWebApplication.Models;

namespace UniversityWebApplication.ViewModels.Student
{
    public class StudentAdd
    {
        public string Name { get; set; }

        public DateTime EnrollmentDate { get; set; }

        public ICollection<Enrollment.EnrollmentAdd> Enrollments { get; set; }
    }
}
