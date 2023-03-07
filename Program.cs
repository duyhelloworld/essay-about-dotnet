using essay_se_dotnetfw;
using essay_se_dotnetfw.Data;
using essay_se_dotnetfw.Models;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllers();
builder.Logging.AddJsonConsole();
// builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();
app.UseRouting();

var apiUrl = "api/student";
StudentManager _manager = new("server=localhost;port=3306;database=ASP_web_empty;user=duyaiti;password=12345678");
// app.MapControllerRoute(
//     name: "student",
//     pattern: apiUrl + "/{studentId}",
//     defaults: new {controller = "Student", action = "GetStudentById"}
// );

app.MapGet(apiUrl + "/{studentId}", (int studentId) => {
    Console.WriteLine("Mapped to Here");
    var student = _manager.GetStudent(studentId);
    if(student is null) {
        Console.WriteLine("Not found student " + studentId);
        return Results.NotFound();
    }
    return Results.Json(student, null, "application/json", 200);
});

app.MapGet(apiUrl, () => 
    {
        Console.WriteLine("Mapped to All");
        return Results.Json(_manager.GetAllStudents());
    }
);

app.MapPost("/", (Student student) =>
{
    _manager.AddStudent(student);
});

app.MapPut("/{id}", (int id, Student input) =>
{
    return Results.NoContent();
});

app.UseAuthorization();
app.MapControllers();
app.Run();
