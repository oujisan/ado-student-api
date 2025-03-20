using student_data_web_api.Models;

namespace student_data_web_api.Services
{
    public interface IStudentService
    {
        List<Student> GetAll();
        Student GetById(int id);
        Student Add(Student student);
        Student Update(Student student, int id);
        bool? Delete(int id);

        //Check
        bool isValidData(Student student);
        bool IsEmailExists(Student student, int id);
        bool IsNimExists(Student student, int id);
    }
}
