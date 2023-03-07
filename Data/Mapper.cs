using essay_se_dotnetfw.Data;

namespace essay_se_dotnetfw.Data {
    public class Mapper
    {
        private StudentManager _manager = new("");
        public Mapper(StudentManager manager){
            _manager = manager;
        }
        public IResult GetAllStudents()
        {
            Console.WriteLine("Mapped to All");
            return Results.Json(_manager.GetAllStudents());
        }

        public IResult GetStudentById(int studentId)
        {
            Console.WriteLine("Mapped to One with id = " + studentId);

            var student = _manager.GetStudent(studentId);
            if (student != null)
                return Results.Json(student);
            Console.WriteLine("Not found student " + studentId);
            return Results.NotFound();
        }
    }
}
