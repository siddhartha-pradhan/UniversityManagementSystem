namespace UniversityWebApplication.ViewModels.Instructor
{
    public class InstructorAdd
    {
        public string Name { get; set; }

        public ICollection<CourseAssignment.CourseAssignmentAdd> CourseAssignments { get; set; }
    }
}
