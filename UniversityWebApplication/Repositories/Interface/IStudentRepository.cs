using UniversityWebApplication.Models;
using UniversityWebApplication.Repositories.Base;

namespace UniversityWebApplication.Repositories.Interface
{
    public interface IStudentRepository : IRepository<Student>
    {
        void Update(Student student);
    }
}
