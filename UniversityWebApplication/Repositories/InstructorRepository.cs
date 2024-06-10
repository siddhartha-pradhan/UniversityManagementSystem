using UniversityWebApplication.Data;
using UniversityWebApplication.Models;
using UniversityWebApplication.Repositories.Base;
using UniversityWebApplication.Repositories.Interface;

namespace UniversityWebApplication.Repositories
{
    public class InstructorRepository : Repository<Instructor>, IInstructorRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public InstructorRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext; 
        }

        public void Update(Instructor instructor)
        {
            var instructorFromDb = _dbContext.Instructors.FirstOrDefault(x => x.ID == instructor.ID);
            instructorFromDb.Name = instructor.Name;
            instructorFromDb.CourseAssignments = instructor.CourseAssignments;
        }
    }
}
