namespace UniversityWebApplication.Query
{
    public class StudentByMarkings
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string? MaxCourse { get; set; }

        public int? Max { get; set; }

        public string? MinCourse { get; set; }

        public int? Min { get; set; }
    }
}
