namespace UniversityWebApplication.ViewModels.Instructor
{
    public class InstructorUpdate
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public ICollection<CourseAssignment.CourseAssignmentAdd> CourseAssignments { get; set; }
    }
}
