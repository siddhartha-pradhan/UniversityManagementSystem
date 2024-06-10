using System.ComponentModel.DataAnnotations;

namespace UniversityWebApplication.Models
{
    public class Club
    {
        [Key]
        public string Serial { get; set; }

        public string Entitle { get; set; }
    }
}
