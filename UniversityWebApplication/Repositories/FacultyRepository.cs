using UniversityWebApplication.Data;
using UniversityWebApplication.Models;
using UniversityWebApplication.Repositories.Base;
using UniversityWebApplication.Repositories.Interface;

namespace UniversityWebApplication.Repositories
{
    public class FacultyRepository : Repository<Faculty>, IFacultyRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public FacultyRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void Update(Faculty faculty)
        {
            var facultyFromDb = _dbContext.Faculties.FirstOrDefault(i => i.ID == faculty.ID);
            facultyFromDb.Name = faculty.Name;
            facultyFromDb.SupervisorID = faculty.SupervisorID;
        }
    }
}
