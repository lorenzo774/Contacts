namespace Contacts.CLI.Commands;

public interface IContactsListCommand : ICommand { }

public class ContactsListCommand : IContactsListCommand
{
    public void Execute(List<string> arguments)
    {
        throw new NotImplementedException();
    }
}