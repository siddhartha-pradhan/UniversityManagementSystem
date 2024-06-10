namespace UniversityWebApplication.ViewModels.Student
{
    public class StudentGet
    {
        public string Name { get; set; }

        public DateTime EnrollmentDate { get; set; }

        public ICollection<Enrollment.EnrollmentGet> Enrollments { get; set; }
    }
}
