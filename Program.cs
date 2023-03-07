using essay_se_dotnetfw;
using essay_se_dotnetfw.Data;
using essay_se_dotnetfw.Models;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddControllers();
// builder.Services.AddCors(options =>
// {
//     options.AddPolicy(name: "AllPolicy",
//         policy =>
//         {
//             policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials();
//         });
// });

var app = builder.Build();
// app.UseCors("AllPolicy");
// app.MapGet("/hello", (HttpContext ctx) => $"Hello {ctx.Request.Query["name"]}!");

string apiUrl = "/api/student";
StudentManager _manager = new("server=localhost;port=3306;database=ASP_web_empty;user=duyaiti;password=12345678");
var mapper = new Mapper(_manager);

// app.MapGet(apiUrl, mapper.GetAllStudents);
// app.MapGet(apiUrl + "/{id:int}", mapper.GetStudentById);

app.MapGet(apiUrl + "/{id?}", ([FromQuery(Name = "id")] int? id) => {
    if(id.HasValue) {
        return mapper.GetStudentById((int)id);
    } else {
        return mapper.GetAllStudents();
    }
});

app.MapPost(apiUrl, (Student student) =>
{
    _manager.AddStudent(student);
    return Results.Created($"/api/student/{student.Id}", student);
});

// app.MapPut("/{id}", (int id, Student input) =>
// {
//     return Results.NoContent();
// });

app.MapDelete(apiUrl, (int id) =>
{
    System.Console.WriteLine("Map to Del");
    var student = _manager.GetStudent(id);
    if(student is null)
        return Results.NotFound();
    _manager.DeleteStudent(id);
    return Results.NoContent();
});

// app.UseAuthorization();
// app.MapControllers();
app.Run();
