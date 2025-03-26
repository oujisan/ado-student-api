using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using student_data_web_api.Helpers;
using student_data_web_api.Services;
using student_data_web_api.Models;

namespace student_data_web_api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;
        private readonly IStudentService _studentService;
        private JwtHelper _jwtHelper;
        public AuthController(IConfiguration configuration, IStudentService studentService)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("WebApiDatabase");
            _studentService = studentService;
        }

        [HttpPost("register")]
        public ActionResult Register([FromBody] Models.Student student)
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

        [HttpPost("login")]
        public ActionResult Login([FromBody] Models.Login login)
        {
            var studentData = _studentService.GetByEmail(login.Email);
            if (studentData == null)
            {
                return BadRequest(new { message = "No account found with the provided email address." });
            }
            if (studentData.Password != login.Password || studentData.Email != login.Email)
            {
                return BadRequest(new { message = "Invalid email or password." });
            }

            _jwtHelper = new JwtHelper(_configuration);

            var token = _jwtHelper.GenerateJwtToken(studentData);
            return Ok(new { 
                token = token,
                student = new
                {
                    studentData.Student_id,
                    studentData.Name,
                    studentData.Email
                }
            });
        }
    }
}