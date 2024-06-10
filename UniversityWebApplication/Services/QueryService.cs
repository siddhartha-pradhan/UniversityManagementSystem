using Microsoft.EntityFrameworkCore;
using UniversityWebApplication.Data;
using UniversityWebApplication.Models;
using UniversityWebApplication.Query;
using UniversityWebApplication.Services.Interface;
using static System.Reflection.Metadata.BlobBuilder;

namespace UniversityWebApplication.Services
{
    public class QueryService : IQueryService
    {
        private readonly ApplicationDbContext _dbContext;

        public QueryService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region Faculty Queries

        public int GetFacultiesCount()
        {
            var faculties = _dbContext.Faculties.AsNoTracking().ToList();

            return faculties.Count();
        }

        public IEnumerable<FacultyBySupervisor> GetAllFaculties()
        {
            var faculties = _dbContext.Faculties.AsNoTracking().ToList();
            var instructors = _dbContext.Instructors.AsNoTracking().ToList();

            var result = from faculty in faculties
                         join instructor in instructors
                         on faculty.SupervisorID equals instructor.ID
                         select new FacultyBySupervisor
                         {
                             ID = faculty.ID,
                             Name = faculty.Name,
                             Supervisor = instructor.Name
                         };

            return result;
        }

        public IEnumerable<FacultyByInstructor> GetEveryFaculties()
        {
            var faculties = _dbContext.Faculties.AsNoTracking().ToList();
            var instructors = _dbContext.Instructors.AsNoTracking().ToList();

            var result = from faculty in faculties
                         join instructor in instructors
                         on faculty.SupervisorID equals instructor.ID into ins
                         from instructor in ins.DefaultIfEmpty()
                         select new FacultyByInstructor
                         {
                             ID = faculty.ID,
                             Name = faculty.Name,
                             Supervisor = instructor == null ? "No supervisor" : instructor.Name
                         };

            return result;
        }

        public IEnumerable<FacultyBySupervisor> GetAllOrderedFaculties()
        {
            var faculties = _dbContext.Faculties.AsNoTracking().ToList();
            var instructors = _dbContext.Instructors.AsNoTracking().ToList();

            var result = from faculty in faculties
                         join instructor in instructors
                         on faculty.SupervisorID equals instructor.ID
                         orderby faculty.Name
                         select new FacultyBySupervisor
                         {
                             ID = faculty.ID,
                             Name = faculty.Name,
                             Supervisor = instructor.Name
                         };

            return result;
        }

        public IEnumerable<FacultyBySupervisor> GetAllFilteredFaculties(string name)
        {
            var faculties = _dbContext.Faculties.AsNoTracking().ToList();
            var instructors = _dbContext.Instructors.AsNoTracking().ToList();

            var result = from faculty in faculties
                         join instructor in instructors
                         on faculty.SupervisorID equals instructor.ID
                         where faculty.Name == name
                         orderby faculty.Name
                         select new FacultyBySupervisor
                         {
                             ID = faculty.ID,
                             Name = faculty.Name,
                             Supervisor = instructor.Name
                         };

            return result;
        }

        public IEnumerable<FacultyByCourses> GetAllFacultiesByCourses()
        {
            var faculties = _dbContext.Faculties.AsNoTracking().ToList();
            var instructors = _dbContext.Instructors.AsNoTracking().ToList();
            var courses = _dbContext.Courses.AsNoTracking().ToList();

            var result = from faculty in faculties
                         join instructor in instructors
                         on faculty.SupervisorID equals instructor.ID into ins
                         join course in courses
                         on faculty.ID equals course.FacultyID into fac
                         from instructor in ins.DefaultIfEmpty()
                         select new FacultyByCourses
                         {
                             ID = faculty.ID,
                             Name = faculty.Name,
                             Supervisor = instructor == null ? "No Supervisor" : instructor.Name,
                             Courses = fac.ToList()
                         };

            return result;
        }

        #endregion

        #region Course Queries

        public int GetCourseCount()
        {
            var count = _dbContext.Courses.Count();

            return count;
        }

        public IEnumerable<CourseByFaculty> GetAllCourses()
        {
            var faculties = _dbContext.Faculties.AsNoTracking().ToList();
            var instructors = _dbContext.Instructors.AsNoTracking().ToList();
            var courses = _dbContext.Courses.AsNoTracking().ToList();

            var result = from course in courses
                         join faculty in faculties
                         on course.FacultyID equals faculty.ID
                         join instructor in instructors
                         on faculty.SupervisorID equals instructor.ID
                         select new CourseByFaculty
                         {
                             ID = course.ID,
                             Title = course.Title,
                             Credit = course.Credits,
                             Faculty = faculty.Name,
                             Supervisor = instructor.Name
                         };

            return result;
        }

        public IEnumerable<CourseByFaculty> GetAllOrderedCourses()
        {
            var faculties = _dbContext.Faculties.AsNoTracking().ToList();
            var instructors = _dbContext.Instructors.AsNoTracking().ToList();
            var courses = _dbContext.Courses.AsNoTracking().ToList();

            var result = from course in courses
                         join faculty in faculties
                         on course.FacultyID equals faculty.ID
                         join instructor in instructors
                         on faculty.SupervisorID equals instructor.ID
                         orderby course.Title
                         select new CourseByFaculty
                         {
                             ID = course.ID,
                             Title = course.Title,
                             Credit = course.Credits,
                             Faculty = faculty.Name,
                             Supervisor = instructor.Name
                         };

            return result;
        }

        public IEnumerable<CourseByFaculty> GetAllFilteredCourses(string name)
        {
            var faculties = _dbContext.Faculties.AsNoTracking().ToList();
            var instructors = _dbContext.Instructors.AsNoTracking().ToList();
            var courses = _dbContext.Courses.AsNoTracking().ToList();

            var result = from course in courses
                         join faculty in faculties
                         on course.FacultyID equals faculty.ID
                         join instructor in instructors
                         on faculty.SupervisorID equals instructor.ID
                         where course.Title == name
                         orderby course.Title
                         select new CourseByFaculty
                         {
                             ID = course.ID,
                             Title = course.Title,
                             Credit = course.Credits,
                             Faculty = faculty.Name,
                             Supervisor = instructor.Name
                         };

            return result;
        }

        public IEnumerable<CourseByInstructor> GetAllCourseInstructor()
        {
            var assignments = _dbContext.CourseAssignments.AsNoTracking().ToList();
            var courses = _dbContext.Courses.AsNoTracking().ToList();

            var result = from course in courses
                         join assignment in assignments
                         on course.ID equals assignment.CourseID
                         orderby course.Title
                         group course by new
                         {
                             course.Title,
                             assignment.CourseID
                         } into values
                         select new CourseByInstructor
                         {
                             ID = values.Key.CourseID,
                             Title = values.Key.Title,
                             TotalInstructors = values.Count()
                         };

            return result;
        }

        public IEnumerable<CourseByInstructors> GetAllCourseInstructors()
        {
            var assignments = _dbContext.CourseAssignments.AsNoTracking().ToList();
            var courses = _dbContext.Courses.AsNoTracking().ToList();
            var instructors = _dbContext.Instructors.AsNoTracking().ToList();

            var result = from course in courses
                         select new CourseByInstructors
                         {
                             ID = course.ID,
                             Title = course.Title,
                             Instructors = (from instructor in instructors
                                            join assignment in assignments
                                            on instructor.ID equals assignment.InstructorID
                                            where assignment.CourseID == course.ID
                                            select instructor).ToList()
                         };

            return result;
        }

        public IEnumerable<CourseByStudents> GetAllCourseStudents()
        {
            var enrollments = _dbContext.Enrollments.AsNoTracking().ToList();
            var courses = _dbContext.Courses.AsNoTracking().ToList();
            var students = _dbContext.Students.AsNoTracking().ToList();

            //var result = from course in courses
            //             join enrollment in enrollments
            //             on course.ID equals enrollment.CourseID
            //             join student in students
            //             on enrollment.StudentID equals student.ID

            //             select new CourseByStudents
            //             {
            //                 ID = course.ID,
            //                 Title = course.Title,
            //                 Students = egroup.AsNoTracking().ToList()
            //             };

            var result = from course in courses
                         select new CourseByStudents
                         {
                             ID = course.ID,
                             Title = course.Title,
                             Students = (from student in students
                                         join enrollment in enrollments
                                         on student.ID equals enrollment.StudentID
                                         where enrollment.CourseID == course.ID
                                         select student).ToList()
                         };

            return result;
        }

        public IEnumerable<CourseByMarks> GetAllCourseMarks()
        {
            var courses = _dbContext.Courses.AsNoTracking().ToList();
            var enrollments = _dbContext.Enrollments.AsNoTracking().ToList();

            var result = from course in courses
                         join enrollment in enrollments
                         on course.ID equals enrollment.CourseID
                         orderby course.Title
                         group enrollment by new
                         {
                             enrollment.CourseID,
                             course.Title
                         } into eGroup
                         select new CourseByMarks
                         {
                             Title = eGroup.Key.Title,
                             Average = eGroup.Average(x => x.Marks),
                             Max = eGroup.Max(x => x.Marks),
                             Min = eGroup.Min(x => x.Marks) != null ? eGroup.Min(x => x.Marks) : 0,
                         };

            return result;
        }

        public IEnumerable<CourseByStudent> GetCourseByHighestMarks()
        {
            var courses = _dbContext.Courses.AsNoTracking().ToList();
            var students = _dbContext.Students.AsNoTracking().ToList();
            var enrollments = _dbContext.Enrollments.AsNoTracking().ToList();

            var result = from course in courses
                         join enrollment in enrollments
                         on course.ID equals enrollment.CourseID into item
                         //join student in students
                         //on item. equals student.ID
                         //group course by course.ID into eGroup
                         select new CourseByStudent
                         {
                             Title = course.Title,
                             Name = (from student in students
                                     join enrollment in item
                                     on student.ID equals enrollment.StudentID
                                     where enrollment.Marks == item.Max(i => i.Marks)
                                     select student.Name).FirstOrDefault(),
                             Marks = item.Max(x => x.Marks) != null ? item.Max(x => x.Marks) : 0
                         };

            //var result = from course in courses
            //             join enrollment in enrollments
            //             on course.ID equals enrollment.CourseID
            //             group enrollment by new
            //             {
            //                 enrollment.CourseID,
            //                 course.Title
            //             } into eGroup
            //             select new CourseByStudent
            //             {
            //                 Title = eGroup.Key.Title,
            //                 Marks = eGroup.Max(x => x.Marks),
            //                 Name = (from student in students
            //                         join enrollment in enrollments
            //                         on student.ID equals enrollment.StudentID
            //                         group enrollment by new
            //                         {
            //                             enrollment.CourseID,
            //                             enrollment.StudentID
            //                         } into grouping
            //                         where grouping.Max(x=>x.Marks) == 
            //                         select student.Name
            //                         )
            //             };

            return result;
        }

        #endregion

        #region Student Queries

        public IEnumerable<Student> GetStudentOnPage(int index)
        {
            var pageSize = 3;
            var students = _dbContext.Students.AsNoTracking().ToList();

            var result = students.Skip((index - 1) * pageSize).Take(pageSize);

            return result;
        }

        public IEnumerable<ClubByStudent> GetAllClubsOnStudents()
        {
            var clubs = _dbContext.Clubs.AsNoTracking().ToList();
            var students = _dbContext.Students.AsNoTracking().ToList();

            var result = from club in clubs
                         join student in students
                         on club.Serial equals student.ClubID into eGroup
                         select new ClubByStudent
                         {
                             Club = club.Entitle,
                             Students = eGroup.ToList(),
                         };

            return result;
        }

        public IEnumerable<StudentByMarks> GetStudentTotalMarks()
        {
            var students = _dbContext.Students.AsNoTracking().ToList();
            var enrollments = _dbContext.Enrollments.AsNoTracking().ToList();
            var clubs = _dbContext.Clubs.AsNoTracking().ToList();

            var result = from student in students
                         join enrollment in enrollments
                         on student.ID equals enrollment.StudentID
                         orderby student.Name
                         group enrollment by student.Name into item
                         select new StudentByMarks
                         {
                             Name = item.Key,
                             Marks = item.Sum(p => p.Marks)
                         };

            return result;
        }


        public IEnumerable<StudentByUniversity> GetAllStudents()
        {
            var clubs = _dbContext.Clubs.AsNoTracking().ToList();
            var students = _dbContext.Students.AsNoTracking().ToList();
            var courses = _dbContext.Courses.AsNoTracking().ToList();
            var faculties = _dbContext.Faculties.AsNoTracking().ToList();
            var enrollments = _dbContext.Enrollments.AsNoTracking().ToList();

            var result = from club in clubs
                         join student in students
                         on club.Serial equals student.ClubID
                         join enrollment in enrollments
                         on student.ID equals enrollment.StudentID
                         join course in courses
                         on enrollment.CourseID equals course.ID
                         join faculty in faculties
                         on course.FacultyID equals faculty.ID
                         select new StudentByUniversity
                         {
                             StudentID = student.ID,
                             Name = student.Name,
                             Club = club.Entitle,
                             Course = course.Title,
                             Faculty = faculty.Name,
                             Marks = enrollment.Marks
                         };

            return result;
        }

        public IEnumerable<StudentByMarkings> GetStudentsMarks()
        {
            var students = _dbContext.Students.AsNoTracking().ToList();
            var enrollments = _dbContext.Enrollments.AsNoTracking().ToList();
            var courses = _dbContext.Courses.AsNoTracking().ToList();

            var result = from student in students
                         join enrollment in enrollments
                         on student.ID equals enrollment.StudentID
                         orderby student.Name
                         group enrollment by new
                         {
                             student.ID,
                             student.Name,
                         } into eGroup
                         select new StudentByMarkings
                         {
                             ID = eGroup.Key.ID,
                             Name = eGroup.Key.Name,
                             Max = eGroup.Max(x => x.Marks) == null ? 0 : eGroup.Max(x => x.Marks),
                             Min = eGroup.Min(x => x.Marks) == null ? 0 : eGroup.Min(x => x.Marks),
                             MaxCourse = (from course in courses
                                          join enrollment in enrollments
                                          on course.ID equals enrollment.CourseID
                                          where eGroup.Max(x => x.Marks) == null
                                          select course.Title).FirstOrDefault() == null ? "No course marks" : (from course in courses
                                                                                                               join enrollment in enrollments
                                                                                                               on course.ID equals enrollment.CourseID
                                                                                                               where enrollment.Marks == eGroup.Max(x => x.Marks)
                                                                                                               select course.Title).FirstOrDefault(),
                             MinCourse = (from course in courses
                                          join enrollment in enrollments
                                          on course.ID equals enrollment.CourseID
                                          where enrollment.Marks == eGroup.Min(x => x.Marks)
                                          select course.Title).FirstOrDefault(),
                         };

            return result;
        }

        #endregion
    }
}
