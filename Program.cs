using essay_se_dotnetfw.Data;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();
StudentManager _manager = new("server=localhost;port=3306;database=ASP_web_empty;user=duyaiti;password=12345678");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // app.UseSwaggerUI();
    app.MapGet("/", () => _manager.GetAllStudents());
}

// app.UseHttpsRedirection();

// app.UseAuthorization();

// app.MapControllers();

app.Run();
