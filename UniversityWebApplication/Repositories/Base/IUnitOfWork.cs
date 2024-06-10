using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversityWebApplication.Repositories.Interface;

namespace UniversityWebApplication.Repositories.Base
{
    public interface IUnitOfWork
    {
        IFacultyRepository Faculty { get; }

        ICourseRepository Course { get; }

        IInstructorRepository Instructor { get; }

        IStudentRepository Student { get; }

        void Save();
    }
}
