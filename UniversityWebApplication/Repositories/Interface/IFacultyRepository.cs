using UniversityWebApplication.Models;
using UniversityWebApplication.Repositories.Base;

namespace UniversityWebApplication.Repositories.Interface
{
    public interface IFacultyRepository : IRepository<Faculty> 
    {
        void Update(Faculty faculty);
    }
}
