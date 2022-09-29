using System.ComponentModel.DataAnnotations;

namespace Contacts.Library;

public class Contact
{
    public DateTime Birthdate { get; init; }
    public string? FirstName { get; init; } = "";
    public string? LastName { get; init; } = "";
    [Phone]
    public string? Phone { get; init; } = "";
    [EmailAddress]
    public string? Email { get; init; } = "user@example.com";
    private string FullName => $"{FirstName} {LastName}";

    public override string ToString() => $"Birthdate: {Birthdate}\t" +
                                         $"Fullname: {FullName}\t" +
                                         $"Phone: {Phone}\t" +
                                         $"Email: {Email}";
}