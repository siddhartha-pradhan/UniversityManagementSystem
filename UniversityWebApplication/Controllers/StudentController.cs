using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversityWebApplication.Models;
using UniversityWebApplication.Repositories.Base;
using UniversityWebApplication.Services.Interface;
using UniversityWebApplication.ViewModels.Course;
using UniversityWebApplication.ViewModels.Student;

namespace UniversityWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        private readonly IQueryService _service;

        public StudentController(IUnitOfWork unitOfWork, IMapper mapper, IQueryService service)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _service = service;
        }

        #region API Operations
        [HttpGet("GetStudents")]
        public IActionResult GetStudents()
        {
            var students = _unitOfWork.Student.GetAll(includeProperties: "Enrollments");
            var courses = _unitOfWork.Course.GetAll();
            courses.Select(course => _mapper.Map<CourseGet>(course));
            return Ok(students.Select(student => _mapper.Map<StudentGet>(student)));
        }

        [HttpGet("GetStudentByID")]
        public IActionResult GetStudentByID(int ID)
        {
            var item = _unitOfWork.Student.Get(ID);
            var student = _mapper.Map<StudentGet>(item);
            return Ok(student);
        }

        [HttpPost("AddStudent")]
        public IActionResult Add(StudentAdd item)
        {
            var student = _mapper.Map<Student>(item);
            _unitOfWork.Student.Add(student);
            _unitOfWork.Save();
            return Ok("Student successfully added.");
        }

        [HttpPut("UpdateStudent")]
        public IActionResult Update(Student item)
        {
            var student = _mapper.Map<Student>(item);
            _unitOfWork.Student.Update(student);
            _unitOfWork.Save();
            return Ok("Student successfully updated.");
        }

        [HttpDelete("DeleteStudent")]
        public IActionResult Delete(int ID)
        {
            _unitOfWork.Student.Remove(ID);
            _unitOfWork.Save();
            return Ok("Student successfully deleted.");
        }
        #endregion

        #region LINQ Operations

        [HttpGet("GetStudentsOnPage")]
        public IActionResult GetStudentsOnPage(int index)
        {
            var result = _service.GetStudentOnPage(index);

            return Ok(result);
        }

        [HttpGet("GetClubsOnStudents")]
        public IActionResult GetClubsOnStudents()
        {
            var result = _service.GetAllClubsOnStudents();

            return Ok(result);
        }

        [HttpGet("GetStudentsOnTotalMarks")]
        public IActionResult GetStudentsOnTotalMarks()
        {
            var result = _service.GetStudentTotalMarks();

            return Ok(result);
        }
        
        [HttpGet("GetStudentsDetails")]
        public IActionResult GetStudentsDetails()
        {
            var result = _service.GetAllStudents();

            return Ok(result);
        }

        [HttpGet("GetStudentsMarksDetails")]
        public IActionResult GetStudentsMarksDetails()
        {
            var result = _service.GetStudentsMarks();

            return Ok(result);
        }

        #endregion
    }
}
