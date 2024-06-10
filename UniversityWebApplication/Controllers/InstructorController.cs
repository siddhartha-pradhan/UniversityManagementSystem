using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using UniversityWebApplication.Data;
using UniversityWebApplication.Models;
using UniversityWebApplication.Repositories.Base;
using UniversityWebApplication.ViewModels.Course;
using UniversityWebApplication.ViewModels.Instructor;

namespace UniversityWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        private readonly ApplicationDbContext _dbContext;

        public InstructorController(IUnitOfWork unitOfWork, IMapper mapper, ApplicationDbContext dbContext)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _dbContext = dbContext;
        }

        #region API Operations
        [HttpGet("GetInstructors")]
        public IActionResult GetInstructors()
        {
            var instructors = _unitOfWork.Instructor.GetAll(includeProperties: "CourseAssignments");
            var courses = _unitOfWork.Course.GetAll();
            courses.Select(course => _mapper.Map<CourseGet>(course));
            return Ok(instructors.Select(instructor => _mapper.Map<InstructorGet>(instructor)));
        }

        [HttpGet("GetInstructorByID")]
        public IActionResult GetInstructorByID(int ID)
        {
            var item = _unitOfWork.Instructor.Get(ID);
            var instructor = _mapper.Map<InstructorGet>(item);
            return Ok(instructor);
        }

        [HttpPost("AddInstructor")]
        public IActionResult Add(InstructorAdd item)
        {
            var instructor = _mapper.Map<Instructor>(item);
            _unitOfWork.Instructor.Add(instructor);
            _unitOfWork.Save();
            return Ok("Instructor successfully added.");
        }

        [HttpPut("UpdateInstructor")]
        public IActionResult Update(Instructor item)
        {
            var instructor = _mapper.Map<Instructor>(item);
            _unitOfWork.Instructor.Update(instructor);
            _unitOfWork.Save();
            return Ok("Instructor successfully updated.");
        }

        [HttpDelete("DeleteInstructor")]
        public IActionResult Delete(int ID)
        {
            _unitOfWork.Instructor.Remove(ID);
            _unitOfWork.Save();
            return Ok("Instructor successfully deleted.");
        }
        #endregion

        #region LINQ Operations
        [HttpGet("GetAllInstructors")]
        public IActionResult GetAll()
        {
            var instructors = _unitOfWork.Instructor.GetAll();
            var courses = _unitOfWork.Course.GetAll();
            
            return Ok("Hello World");
        }

        //SELECT i.Name, COUNT(*) AS "Total Courses"
        //FROM Instructors i
        //JOIN CourseAssignments c
        //ON i.ID = c.InstructorID
        //GROUP BY i.Name, c.InstructorID
        //ORDER BY i.Name;

        [HttpGet("GetInstructorCourse")]
        public IActionResult GetInstructorCourse()
        {
            var instructors = _unitOfWork.Instructor.GetAll();
            var courses = _unitOfWork.Course.GetAll();
            var courseAssignments = _dbContext.CourseAssignments.ToList();

            var result = from instructor in instructors
                         join assignment in courseAssignments
                         on instructor.ID equals assignment.InstructorID
                         group instructor by new
                         {
                             instructor.Name,
                             assignment.InstructorID
                         } into item
                         select new
                         {
                             Instructor = item.Key.Name,
                             Courses = item.Count()
                         };
                         

            return Ok(result);
        }
        #endregion
    }
}
