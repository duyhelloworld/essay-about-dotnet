using essay_se_dotnetfw.Data;
using essay_se_dotnetfw.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace essay_se_dotnetfw.Controllers;

// http://localhost:{PORT}/api/student

[ApiController]
// Mark it is a API Controller
[Route("/api/[controller]")]
// URL of controller
public class StudentController : ControllerBase
{
    private readonly StudentManager _manager;

    public StudentController(StudentManager manager)
    {
        _manager = manager;
    }

    [HttpGet]
    public ActionResult<List<Student>> GetAllStudents()
    {
        return _manager.GetAllStudents();
    }

    [HttpGet("{id:int}")]
    public ActionResult<Student> GetStudentById(int id)
    {
        var student = _manager.GetStudent(id);

        if (student == null)
            return NotFound();
        return student;
    }

    [HttpPost]
    public IActionResult AddStudent([FromBody] Student student)
    {
        _manager.AddStudent(student);
        return CreatedAtAction(nameof(GetStudentById), new { id = student.Id }, student);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateStudent(int id, Student student)
    {
        if (id != student.Id)
            return BadRequest();

        var existingStudent = _manager.GetStudent(id);

        if (existingStudent is null)
            return NotFound();

        // Updated
        _manager.UpdateStudent(student);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteStudent(int id)
    {
        var existingStudent = _manager.GetStudent(id);

        if (existingStudent == null)
            return NotFound();

        _manager.DeleteStudent(id);
        return NoContent();
    }
}