using AutoMapper;
using UniversityWebApplication.Models;
using UniversityWebApplication.ViewModels.Course;
using UniversityWebApplication.ViewModels.CourseAssignment;
using UniversityWebApplication.ViewModels.Enrollment;
using UniversityWebApplication.ViewModels.Faculty;
using UniversityWebApplication.ViewModels.Instructor;
using UniversityWebApplication.ViewModels.Student;

namespace UniversityWebApplication.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Course, CourseGet>();
            CreateMap<CourseAdd, Course>();
            CreateMap<CourseUpdate, Course>();

            CreateMap<Faculty, FacultyGet>();
            CreateMap<FacultyAdd, Faculty>();
            CreateMap<FacultyUpdate, Faculty>();

            CreateMap<Instructor, InstructorGet>();
            CreateMap<InstructorAdd, Instructor>();
            CreateMap<InstructorUpdate, Instructor>();

            CreateMap<Student, StudentGet>();
            CreateMap<StudentAdd, Student>();
            CreateMap<StudentUpdate, Student>();

            CreateMap<Enrollment, EnrollmentGet>();
            CreateMap<EnrollmentAdd, Enrollment>();

            CreateMap<CourseAssignment, CourseAssignmentGet>();
            CreateMap<CourseAssignmentAdd, CourseAssignment>();
        }
    }
}
