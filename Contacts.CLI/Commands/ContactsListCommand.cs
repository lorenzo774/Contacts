using Contacts.CLI.Systems;
using Contacts.Data;

namespace Contacts.CLI.Commands;

public interface IContactsListCommand : ICommand { }

/// <summary>
/// Display contact list from database
/// </summary>
public class ContactsListCommand : IContactsListCommand
{
    private readonly IMessage _message;
    private readonly IDataAccess _dataAccess;

    public ContactsListCommand(IMessage message, IDataAccess dataAccess)
    {
        _message = message;
        _dataAccess = dataAccess;
    }
    
    public void Execute(List<string> args)
    {
        var contacts = _dataAccess.GetContacts();
        _message.DisplayContacts(contacts);
    }
}