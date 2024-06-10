using UniversityWebApplication.Models;
using UniversityWebApplication.Query;

namespace UniversityWebApplication.Services.Interface
{
    public interface IQueryService
    {
        #region Faculty Queries

        int GetFacultiesCount();

        IEnumerable<FacultyByInstructor> GetEveryFaculties();

        IEnumerable<FacultyBySupervisor> GetAllFaculties();

        IEnumerable<FacultyBySupervisor> GetAllOrderedFaculties();

        IEnumerable<FacultyBySupervisor> GetAllFilteredFaculties(string name);

        IEnumerable<FacultyByCourses> GetAllFacultiesByCourses();

        #endregion

        #region Course Queries
        int GetCourseCount();

        IEnumerable<CourseByFaculty> GetAllCourses();

        IEnumerable<CourseByFaculty> GetAllOrderedCourses();

        IEnumerable<CourseByFaculty> GetAllFilteredCourses(string name);

        IEnumerable<CourseByInstructor> GetAllCourseInstructor();

        IEnumerable<CourseByInstructors> GetAllCourseInstructors();

        IEnumerable<CourseByMarks> GetAllCourseMarks();

        IEnumerable<CourseByStudents> GetAllCourseStudents();

        IEnumerable<CourseByStudent> GetCourseByHighestMarks();

        #endregion

        #region Student Queries
        IEnumerable<Student> GetStudentOnPage(int index);

        IEnumerable<ClubByStudent> GetAllClubsOnStudents();

        IEnumerable<StudentByMarks> GetStudentTotalMarks();

        IEnumerable<StudentByUniversity> GetAllStudents();

        IEnumerable<StudentByMarkings> GetStudentsMarks();

        #endregion
    }
}
