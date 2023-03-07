using essay_se_dotnetfw.Data;
using essay_se_dotnetfw.Models;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

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

string apiUrl = "/api/student";
StudentManager _manager = new("server=localhost;port=3306;database=ASP_web_empty;user=duyaiti;password=12345678");
var mapper = new Mapper(_manager);

app.MapGet(apiUrl + "/{id?}", ([FromQuery(Name = "id")] int? id) => {
    if(id.HasValue) {
        return mapper.GetStudentById((int)id);
    } else {
        return mapper.GetAllStudents();
    }
});

app.MapPost(apiUrl, (Student student) =>
{
    Console.WriteLine("Map to Post : " + student);
    _manager.AddStudent(student);
    return Results.Created($"/api/student/{student.Id}", student);
});

app.MapPut(apiUrl, ([FromBody] Student input) =>
{
    Console.WriteLine("Map to Put");
    // if (id != input.Id)
    //     return Results.BadRequest();
    var student = _manager.GetStudent(input.Id);

    if (student is null) {
        return Results.NotFound();
    }
    _manager.UpdateStudent(input);
    return Results.Ok();
});

app.MapDelete(apiUrl, ([FromQuery(Name = "id")] int id) =>
{
    Console.WriteLine("Map to Del");
    
    var student = _manager.GetStudent(id);

    if(student is null)
        return Results.NotFound();

    _manager.DeleteStudent(id);
    return Results.NoContent();
});

app.Run();
