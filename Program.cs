using essay_se_dotnetfw;
using essay_se_dotnetfw.Data;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
// builder.Services.AddControllers();
// builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();
// StudentManager _manager = new("server=localhost;port=3306;database=ASP_web_empty;user=duyaiti;password=12345678");
// app.MapGet("/", () => _manager.GetAllStudents());

// if (app.Environment.IsDevelopment())
// {
// }
// app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
// app.MapControllerRoute(
//     name: "controller",
//     // pattern: "{controller=student}/{id?}"
//     pattern: "api/[controller]"
// );
app.Run();
