using UniversityWebApplication.Models;
using UniversityWebApplication.Repositories.Base;

namespace UniversityWebApplication.Repositories.Interface
{
    public interface IInstructorRepository : IRepository<Instructor>
    {
        void Update(Instructor instructor);
    }
}
