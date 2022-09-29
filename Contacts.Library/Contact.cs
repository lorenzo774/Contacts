namespace Contacts.Library;

public class Contact
{
    public DateTime Birthdate { get; init; }
    public string? FirstName { get; init; } = "";
    public string? LastName { get; init; } = "";
    private string FullName => $"{FirstName} {LastName}";

    public override string ToString() => $"Birthdate: {Birthdate}\tFullname: {FullName}";
}