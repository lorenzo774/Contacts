using System.ComponentModel.DataAnnotations;

namespace Contacts.Library;

public class Contact
{
    public DateTime Birthdate { get; set; }
    public string? FirstName { get; set; } = "";
    public string? LastName { get; set; } = "";
    [Phone]
    public string? Phone { get; set; } = "";
    [EmailAddress]
    public string? Email { get; set; } = "user@example.com";
    private string FullName => $"{FirstName} {LastName}";

    public override string ToString() => $"Birthdate: {Birthdate}\t" +
                                         $"Fullname: {FullName}\t" +
                                         $"Phone: {Phone}\t" +
                                         $"Email: {Email}";
}