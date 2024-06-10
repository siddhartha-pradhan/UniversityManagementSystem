using UniversityWebApplication.Data;
using UniversityWebApplication.Repositories.Interface;

namespace UniversityWebApplication.Repositories.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            Faculty = new FacultyRepository(_dbContext);
            Course = new CourseRepository(_dbContext);
            Instructor = new InstructorRepository(_dbContext);
            Student = new StudentRepository(_dbContext);
        }

        public IFacultyRepository Faculty { get; set; }
        public ICourseRepository Course { get; set; }
        public IInstructorRepository Instructor { get; set; }
        public IStudentRepository Student { get; set; }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
