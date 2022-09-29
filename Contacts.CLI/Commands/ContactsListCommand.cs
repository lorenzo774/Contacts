namespace Contacts.CLI.Commands;

public interface IContactsListCommand : ICommand { }

/// <summary>
/// Display contact list from database
/// </summary>
public class ContactsListCommand : IContactsListCommand
{
    public void Execute(List<string> args)
    {
        throw new NotImplementedException();
    }
}