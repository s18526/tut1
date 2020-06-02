using tut5;
using Microsoft.AspNetCore.Mvc;
using tut5.Services;

namespace tut5.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        private IStudentsSerivceDb _studentsSerivceDb;

        public StudentsController(IStudentsSerivceDb studentsSerivceDb)
        {
            _studentsSerivceDb = studentsSerivceDb;
        }

        [HttpGet]
        public IActionResult GetStudents(string orderBy)
        {
            return Ok(_studentsSerivceDb.GetStudents());
        }

        [HttpGet("semesters/{id}")]
        public IActionResult GetSemester(string id)
        {
            var response = _studentsSerivceDb.GetSemester(id);
            if (response == null)
            {
                return NotFound("Record doesn't exists");
            }
            else return Ok(response);
        }
    }
}