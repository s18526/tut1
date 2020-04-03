using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Tutorial3.DAL;
using Tutorial3.Models;

namespace Tutorial3.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        private readonly IDbService _dbService;

        public StudentsController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet]
        public IActionResult Get(string orderBy) => Ok(_dbService.GetStudents());

        [HttpGet("{id}")]
        public IActionResult GetStudent(string id)
        {
            var getById = _dbService.GetById(id);
            if (getById == null) return NotFound();
            return Ok(getById);

        }

        [HttpGet("{studentId}/semesters")]
        public IActionResult GetSemesters(string studentId) => Ok(_dbService.GetSemesters(studentId));

        

        [HttpDelete("{id}")]
        public IActionResult Put(string id)
        {
            _dbService.Delete(id);
            return Ok("Deletion is successful");
        }

        [HttpPut("{id}")]
        public IActionResult Put(string id, Student student)
        {
            _dbService.Update(id, student);
            return Ok("Update is successful");
        }

        [HttpPost]
        public IActionResult Post(Student student) => Ok(_dbService.Add(student));

    }
}