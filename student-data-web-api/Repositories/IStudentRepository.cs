using student_data_web_api.Models;

namespace student_data_web_api.Repositories
{
    public interface IStudentRepository
    {
        List<Student> GetAll();
        Student GetById(int id);
        Student GetByEmail(string email);
        Student GetByNim(string nim);
        Student Add(Student student);
        Student Update(Student student, int id);
        bool? Delete(int id);
    }
}
