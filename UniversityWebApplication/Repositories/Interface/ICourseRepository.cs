using UniversityWebApplication.Models;
using UniversityWebApplication.Repositories.Base;

namespace UniversityWebApplication.Repositories.Interface
{
    public interface ICourseRepository : IRepository<Course>
    {
        void Update(Course course);
    }
}
