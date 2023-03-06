namespace essay_se_dotnetfw.Models;

public class Student
{

    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateOnly? DateOfBirth { get; set; }    
    public string? Email { get; set; }
    public string? Address { get; set; }
    public Student(int id, string firstName, string lastName, DateTime dob, string email, string address)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = DateOnly.FromDateTime(dob);
        Email = email;
        Address = address;
    }

    public Student() { }
}
