using UniversityWebApplication.Data;
using UniversityWebApplication.Models;
using UniversityWebApplication.Repositories.Base;
using UniversityWebApplication.Repositories.Interface;

namespace UniversityWebApplication.Repositories
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public StudentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void Update(Student student)
        {
            var studentFromDb = _dbContext.Students.FirstOrDefault(i => i.ID == student.ID);
            studentFromDb.Name = student.Name;
            studentFromDb.EnrollmentDate = student.EnrollmentDate;
            studentFromDb.Enrollments = student.Enrollments;
        }
    }
}
