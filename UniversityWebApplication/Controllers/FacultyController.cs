using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UniversityWebApplication.Models;
using UniversityWebApplication.Repositories.Base;
using UniversityWebApplication.Services.Interface;
using UniversityWebApplication.ViewModels.Faculty;
using UniversityWebApplication.ViewModels.Student;

namespace UniversityWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacultyController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        private readonly IQueryService _service;
        public FacultyController(IUnitOfWork unitOfWork, IMapper mapper, IQueryService service)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _service = service;
        }

        #region API Operations

        [HttpGet("GetFaculties")]
        public IActionResult GetFaculties()
        {
            var faculties = _unitOfWork.Faculty.GetAll();

            return Ok(faculties.Select(faculty => _mapper.Map<FacultyGet>(faculty)));
        }

        [HttpGet("GetFacultyByID")]
        public IActionResult GetFacultyByID(int ID)
        {
            var item = _unitOfWork.Faculty.Get(ID);
            var faculty = _mapper.Map<FacultyGet>(item);

            return Ok(faculty);
        }

        [HttpPost("AddFaculty")]
        public IActionResult Add(FacultyAdd item)
        {
            var faculty = _mapper.Map<Faculty>(item);

            _unitOfWork.Faculty.Add(faculty);
            _unitOfWork.Save();

            return Ok("Faculty successfully added.");
        }

        [HttpPut("UpdateFaculty")]
        public IActionResult Update(FacultyUpdate item)
        {
            var faculty = _mapper.Map<Faculty>(item);

            _unitOfWork.Faculty.Update(faculty);
            _unitOfWork.Save();

            return Ok("Faculty successfully updated.");
        }

        [HttpDelete("DeleteFaculty")]
        public IActionResult Delete(int ID)
        {
            _unitOfWork.Faculty.Remove(ID);
            _unitOfWork.Save();

            return Ok("Faculty successfully deleted.");
        }

        #endregion

        #region LINQ Operations

        [HttpGet("GetAllFaculties")]
        public IActionResult GetAll()
        {
            var faculties = _service.GetAllFaculties();

            return Ok(faculties);
        }

        [HttpGet("GetEveryFaculties")]
        public IActionResult GetEvery()
        {
            var faculties = _service.GetEveryFaculties();

            return Ok(faculties);
        }

        [HttpGet("GetTotalFaculties")]
        public IActionResult GetTotal()
        {
            var facultyCount = _service.GetFacultiesCount();

            return Ok(facultyCount);
        }

        [HttpGet("GetAllFacultiesOnOrder")]
        public IActionResult GetAllOrdered()
        {
            var faculties = _service.GetAllOrderedFaculties();

            return Ok(faculties);
        }

        [HttpGet("GetAllFacultiesOnFilter")]
        public IActionResult GetAllFiltered(string value)
        {
            var faculties = _service.GetAllFilteredFaculties(value);

            return Ok(faculties);
        }

        [HttpGet("GetAllFacultiesCourses")]
        public IActionResult GetAllFacultiesCourses()
        {
            var faculties = _service.GetAllFacultiesByCourses();

            return Ok(faculties);
        }
        #endregion
    }
}
