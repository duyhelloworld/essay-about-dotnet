namespace essay_se_dotnetfw.Models;

public class Student
{
    private int Id { get; set; }
    private string? Name { get; set; }

    private string? Email { get; set; }

    private DateOnly DatOfBirth { get; set; }
    
}
