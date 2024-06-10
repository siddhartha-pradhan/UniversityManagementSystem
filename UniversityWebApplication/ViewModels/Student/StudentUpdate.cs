namespace UniversityWebApplication.ViewModels.Student
{
    public class StudentUpdate
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public DateTime EnrollmentDate { get; set; }

        public ICollection<Enrollment.EnrollmentAdd> Enrollments { get; set; }
    }
}
