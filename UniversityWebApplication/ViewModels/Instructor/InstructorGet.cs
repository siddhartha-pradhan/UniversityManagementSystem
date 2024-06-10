namespace UniversityWebApplication.ViewModels.Instructor
{
    public class InstructorGet
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public ICollection<CourseAssignment.CourseAssignmentGet> CourseAssignments { get; set; }
    }
}
