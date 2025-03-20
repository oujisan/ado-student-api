using Microsoft.AspNetCore.Http.HttpResults;
using student_data_web_api.Models;
using student_data_web_api.Repositories;
using System.Text.RegularExpressions;

namespace student_data_web_api.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        public StudentService(IStudentRepository pStudentRepository)
        {
            _studentRepository = pStudentRepository;
        }

        public bool isValidData(Student student)
        {
            if (
                string.IsNullOrWhiteSpace(student.Name) ||
                string.IsNullOrWhiteSpace(student.Nim) ||
                string.IsNullOrWhiteSpace(student.Prodi) ||
                string.IsNullOrWhiteSpace(student.Email) ||
                string.IsNullOrWhiteSpace(student.Password) ||
                !Regex.IsMatch(student.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$") ||
                student.Password.Length <= 8 ||
                student.Semester <= 0 ||
                student.Nim.Length != 12
                )
            {
                return false;
            }
            return true;
        }

        public bool IsEmailExists(Student student, int id)
        {
            return _studentRepository.IsEmailExists(student, id);
        }
        public bool IsNimExists(Student student, int id)
        {
            return _studentRepository.IsNimExists(student, id);
        }

        public List<Student> GetAll()
        {
            return _studentRepository.GetAll();
        }

        public Student GetById(int id)
        {
            return _studentRepository.GetById(id);
        }

        public Student Add(Student student)
        {
            if (!isValidData(student))
            {
                return null;
            }
            return _studentRepository.Add(student);
        }

        public Student Update(Student student, int id)
        {
            if (!isValidData(student))
            {
                return null;
            }
            return _studentRepository.Update(student, id);
        }

        public bool? Delete(int id)
        {
            return _studentRepository.Delete(id);
        }
    }
}
