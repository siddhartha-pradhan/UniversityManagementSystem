using UniversityWebApplication.Data;
using UniversityWebApplication.Models;
using UniversityWebApplication.Repositories.Base;
using UniversityWebApplication.Repositories.Interface;

namespace UniversityWebApplication.Repositories
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CourseRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void Update(Course course)
        {
            var courseFromDb = _dbContext.Courses.FirstOrDefault(u => u.ID == course.ID);
            courseFromDb.Title = course.Title;
            courseFromDb.Credits = course.Credits;
            courseFromDb.FacultyID = course.FacultyID;
        }
    }
}
