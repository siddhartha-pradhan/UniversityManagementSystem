using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversityWebApplication.Models;
using UniversityWebApplication.Repositories.Base;
using UniversityWebApplication.Services.Interface;
using UniversityWebApplication.ViewModels.Course;

namespace UniversityWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        private readonly IQueryService _service;

        public CourseController(IUnitOfWork unitOfWork, IMapper mapper, IQueryService service)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _service = service;
        }

        #region API Operations

        [HttpGet("GetCourses")]
        public IActionResult GetCourses()
        {
            var courses = _unitOfWork.Course.GetAll(includeProperties: "Faculty");

            return Ok(courses.Select(course => _mapper.Map<CourseGet>(course)));
        }

        [HttpGet("GetCourseByID")]
        public IActionResult GetCourseByID(int ID)
        {
            var item = _unitOfWork.Course.Get(ID);
            var course = _mapper.Map<CourseGet>(item);

            return Ok(course);
        }

        [HttpPost("AddCourse")]
        public IActionResult Add(CourseAdd item)
        {
            var course = _mapper.Map<Course>(item); 

            _unitOfWork.Course.Add(course);
            _unitOfWork.Save();

            return Ok("Course successfully added.");
        }

        [HttpPut("UpdateCourse")]
        public IActionResult Update(Course item)
        {
            var course = _mapper.Map<Course>(item);

            _unitOfWork.Course.Update(course);
            _unitOfWork.Save();

            return Ok("Course successfully updated.");
        }

        [HttpDelete("DeleteCourse")]
        public IActionResult Delete(int ID)
        {
            _unitOfWork.Course.Remove(ID);
            _unitOfWork.Save();

            return Ok("Course successfully deleted.");
        }

        #endregion

        #region LINQ Operations

        [HttpGet("GetAllCourses")]
        public IActionResult GetAll()
        {
            var result = _service.GetAllCourses();

            return Ok(result);
        }

        [HttpGet("GetCoursesCount")]
        public IActionResult GetTotal()
        {
            var courseCount = _service.GetCourseCount();

            return Ok(courseCount);
        }

        [HttpGet("GetAllCoursesOnOrder")]
        public IActionResult GetAllOrdered()
        {
            var faculties = _service.GetAllOrderedCourses();

            return Ok(faculties);
        }

        [HttpGet("GetAllCoursesOnFilter")]
        public IActionResult GetAllFiltered(string value)
        {
            var faculties = _service.GetAllFilteredCourses(value);

            return Ok(faculties);
        }

        [HttpGet("GetCoursesOnTotalInstructor")]
        public IActionResult GetAllInstructorCourse()
        {
            var result = _service.GetAllCourseInstructor();

            return Ok(result);
        }

        [HttpGet("GetCoursesOnTotalInstructors")]
        public IActionResult GetAllInstructorsCourse()
        {
            var result = _service.GetAllCourseInstructors();

            return Ok(result);
        }

        [HttpGet("GetCoursesOnAverageMarks")]
        public IActionResult GetCoursesOnAverageMarks()
        {
            var result = _service.GetAllCourseMarks();

            return Ok(result);
        }

        [HttpGet("GetAllCoursesStudents")]
        public IActionResult GetAllCoursesStudents()
        {
            var result = _service.GetAllCourseStudents();

            return Ok(result);
        }

        [HttpGet("GetCourseHighestMarks")]
        public IActionResult GetCourseHighestMarks()
        {
            var result = _service.GetCourseByHighestMarks();

            return Ok(result);
        }
        #endregion
    }
}
