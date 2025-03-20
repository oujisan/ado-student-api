using student_data_web_api.Models;
using student_data_web_api.Helpers;
using Npgsql;

namespace student_data_web_api.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly string _connectionString;
        private string _errorMessage;
        public StudentRepository(IConfiguration configuration) 
        {
            _connectionString = configuration.GetConnectionString("WebApiDatabase");
        }

        public List<Student> GetAll()
        {
            List<Student> students = new List<Student>();
            string query = "SELECT * FROM users.students";
            using (SqlDbHelper dbHelper = new SqlDbHelper(_connectionString))
            try
            {
                using (NpgsqlCommand command = dbHelper.NpgsqlCommand(query))
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        students.Add(new Student()
                        {
                            Student_id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Nim = reader.GetString(2),
                            Prodi = reader.GetString(3),
                            Semester = reader.GetInt32(4),
                            Email = reader.GetString(5),
                            Password = reader.GetString(6)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                    _errorMessage = ex.Message;
            }
            return students;
        }

        public Student GetById(int id)
        {
            Student student = null;
            string query = "SELECT * FROM users.students WHERE student_id = @id";
            using (SqlDbHelper dbHelper = new SqlDbHelper(_connectionString))
            try
            {
                using (NpgsqlCommand command = dbHelper.NpgsqlCommand(query))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            student = new Student
                            {
                                Student_id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Nim = reader.GetString(2),
                                Prodi = reader.GetString(3),
                                Semester = reader.GetInt32(4),
                                Email = reader.GetString(5),
                                Password = reader.GetString(6)
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _errorMessage = ex.Message;
            }
            return student;
        }

        public Student Add(Student student)
        {
            string query = "INSERT INTO users.students (name, nim, prodi, semester, email, password) VALUES (@name, @nim, @prodi, @semester, @email, @password)";
            using (SqlDbHelper dbHelper = new SqlDbHelper(_connectionString))
                try
                {
                    using (NpgsqlCommand command = dbHelper.NpgsqlCommand(query))
                    {
                        command.Parameters.AddWithValue("@name", student.Name);
                        command.Parameters.AddWithValue("@nim", student.Nim);
                        command.Parameters.AddWithValue("@prodi", student.Prodi);
                        command.Parameters.AddWithValue("@semester", student.Semester);
                        command.Parameters.AddWithValue("@email", student.Email);
                        command.Parameters.AddWithValue("@password", student.Password);
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    _errorMessage = ex.Message;
                }
            return student;
        }

        public Student Update(Student student, int id)
        {
            string query = "UPDATE users.students SET name=@name, nim=@nim, prodi=@prodi, semester=@semester, email=@email, password=@password WHERE student_id=@id";
            using (SqlDbHelper dbHelper = new SqlDbHelper(_connectionString))
                try
                {
                    using (NpgsqlCommand command = dbHelper.NpgsqlCommand(query))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        command.Parameters.AddWithValue("@name", student.Name);
                        command.Parameters.AddWithValue("@nim", student.Nim);
                        command.Parameters.AddWithValue("@prodi", student.Prodi);
                        command.Parameters.AddWithValue("@semester", student.Semester);
                        command.Parameters.AddWithValue("@email", student.Email);
                        command.Parameters.AddWithValue("@password", student.Password);
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    _errorMessage = ex.Message;
                }
            return student;
        }

        public bool? Delete(int id)
        {
            string query = "DELETE FROM users.students WHERE student_id = @id_student";
            using (SqlDbHelper dbHelper = new SqlDbHelper(_connectionString))
                try
                {
                    using (NpgsqlCommand command = dbHelper.NpgsqlCommand(query))
                    {
                        command.Parameters.AddWithValue("@id_student", id);
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected == 0)
                        {
                            return null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    _errorMessage = ex.Message;
                    return false;
                }
            return true;
        }

        public bool IsEmailExists(Student student, int id)
        {
            bool result = false;
            string query = "SELECT COUNT(*) FROM users.students WHERE email = @Email AND student_id <> @Id";

            try
            {
                using (SqlDbHelper dbHelper = new SqlDbHelper(_connectionString))
                using (NpgsqlCommand command = dbHelper.NpgsqlCommand(query))
                {
                    command.Parameters.AddWithValue("@Email", student.Email);
                    command.Parameters.AddWithValue("@Id", id);

                    result = (long)command.ExecuteScalar() > 0;
                }
            }
            catch (Exception ex)
            {
                _errorMessage = ex.Message;
            }

            return result;
        }


        public bool IsNimExists(Student student, int id)
        {
            bool result = false;
            string query = "SELECT COUNT(*) FROM users.students WHERE nim = @Nim AND student_id <> @Id";
            using (SqlDbHelper dbHelper = new SqlDbHelper(_connectionString))
            try
            {
                using (NpgsqlCommand command = dbHelper.NpgsqlCommand(query))
                {
                    command.Parameters.AddWithValue("@Nim", student.Nim);
                    command.Parameters.AddWithValue("@Id", id);

                    result = (long)command.ExecuteScalar() > 0;
                }
            }
            catch (Exception ex)
            {
                _errorMessage = ex.Message;
            }
            return result;
        }
    }
}