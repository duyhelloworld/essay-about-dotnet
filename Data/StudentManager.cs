using System.Data;
using essay_se_dotnetfw.Models;
using MySql.Data.MySqlClient;

namespace essay_se_dotnetfw.Data {
public class StudentManager
    {
        private readonly MySqlConnection _conn;

        public StudentManager(string? connectionString)
        {
            _conn = new MySqlConnection(connectionString);
        }

        public List<Student> GetAllStudents()
        {
            List<Student>? students = new();

            string query = "SELECT * FROM students";

            using (MySqlCommand command = new(query, _conn))
            {
                if (_conn.State != ConnectionState.Open) {
                    _conn.Open();
                }
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    students.Add(new Student
                    (
                        reader.GetInt32("id"),
                        reader.GetString("fname"),
                        reader.GetString("lname"),
                        reader.GetString("dob"),
                        reader.GetString("email"),
                        reader.GetString("address")
                    ));
                }
                if(_conn.State != ConnectionState.Closed) {
                    _conn.Close();
                }
            }
            return students;
        }

        public Student? GetStudent(int id)
        {

            _conn.Open();
            string query = "SELECT * FROM students WHERE id = @Id";
            MySqlCommand command = new(query, _conn);

            command.Parameters.AddWithValue("@Id", id);

            MySqlDataReader reader = command.ExecuteReader(); 
            if (reader.Read())
            {
                Student std = new Student
                (
                    id,
                    reader.GetString("fname"),
                    reader.GetString("lname"),
                    reader.GetString("dob"),
                    reader.GetString("email"),
                    reader.GetString("address")
                );
                return std;
            }
            return null;
        }

        public void AddStudent(Student student)
        {
            string query = "INSERT INTO students (fname, lname, dob,  email, address) VALUES (@fname, @lname, @dob, @email, @address)";

            using MySqlCommand command = new(query, _conn);
            command.Parameters.AddWithValue("@fname", student.FirstName);
            command.Parameters.AddWithValue("@lname", student.LastName);
            command.Parameters.AddWithValue("@dob", student.DateOfBirth);
            command.Parameters.AddWithValue("@email", student.Email);
            command.Parameters.AddWithValue("@address", student.Address);

            _conn.Open();

            command.ExecuteNonQuery();

            _conn.Close();
        }

        public Boolean UpdateStudent(Student student)
        {
            string query = "UPDATE student SET fname = @fname, lname = @lname, dob = @dob, email = @email, address = @address WHERE id = @id";
            using MySqlCommand command = new(query, _conn);
            command.Parameters.AddWithValue("@id", student.Id);
            command.Parameters.AddWithValue("@fname", student.FirstName);
            command.Parameters.AddWithValue("@lname", student.LastName);
            command.Parameters.AddWithValue("@dob", student.DateOfBirth);
            command.Parameters.AddWithValue("@email", student.Email);
            command.Parameters.AddWithValue("@address", student.Address);

            _conn.Open();

            int rowAffected = command.ExecuteNonQuery();
            _conn.Close();

            if (rowAffected == 1)
            {
                return true;
            }
            return false;
        }

        public void DeleteStudent(int id)
        {
            string query = "DELETE FROM students WHERE id = @id";
            using MySqlCommand command = new(query, _conn);
            command.Parameters.AddWithValue("@id", id);
            _conn.Open();
            command.ExecuteNonQuery();
            _conn.Close();
        }
    }

}

