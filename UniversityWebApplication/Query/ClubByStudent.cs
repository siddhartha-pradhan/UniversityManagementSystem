using UniversityWebApplication.Models;

namespace UniversityWebApplication.Query
{
    public class ClubByStudent
    {
        public string Club { get; set; }    

        public List<Student> Students { get; set; }
    }
}
