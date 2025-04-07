using student_data_web_api.Services;
using student_data_web_api.Repositories;
using student_data_web_api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Authorization;


namespace student_data_web_api.Controllers
{
    [Route("api/student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [Authorize]
        [HttpGet]
        public ActionResult<List<Student>> GetAll()
        {
            var students = _studentService.GetAll();
            if (!students.Any() || students == null)
            {
                return NoContent();
            }
            return Ok(students);
        }

        [Authorize(Roles ="Admin")]
        [HttpGet("{id}"), Authorize]
        public ActionResult<Student> GetById(int id)
        {
            var student = _studentService.GetById(id);
            if (student == null)
            {
                return NotFound(new { message = "Student not found" });
            }
            return Ok(student);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("add")]
        public ActionResult<Student> Add([FromBody] Models.Student student)
        {
            if (_studentService.GetByEmail(student.Email) != null)
            {
                return BadRequest(new { message = "This Email has already been used." });
            }
            if (_studentService.GetByNim(student.Nim) != null)
            {
                return BadRequest(new { message = "This NIM has already been used." });

            }
            var newStudent = _studentService.Add(student);
            if (newStudent == null)
            {
                return BadRequest(new { message = "Invalid Data" });
            }
            return Ok(newStudent);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("update/{id}"), Authorize]
        public ActionResult<Student> Update(int id, [FromBody] Models.Student student)
        {
            if (_studentService.GetById(id) == null)
            {
                return BadRequest(new {message="ID student not found"});
            }
            if (_studentService.GetByEmail(student.Email) != null)
            {
                return BadRequest(new { message = "This Email has already been used." });
            }
            if (_studentService.GetByNim(student.Nim) != null)
            {
                return BadRequest(new { message = "This NIM has already been used." });

            }

            var updatedStudent = _studentService.Update(student,id);
            if (updatedStudent == null)
            {
                return BadRequest(new { message = "Update data failed" });
            }
            return Ok(updatedStudent);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("delete/{id}"), Authorize]
        public ActionResult DeleteStudent(int id)
        {
            var isDeleted = _studentService.Delete(id);
            if (isDeleted == false)
            {
                return StatusCode(500, new { message = "An error occurred while deleting the data." });
            }
            else if (isDeleted == null)
            {
                return NotFound(new { message = "ID Not Found" });
            }
            return Ok(new { message = "Data has been successfully deleted." });
        }
    }
}