using Contacts.CLI.Input;
using Contacts.Data;

namespace Contacts.CLI.Commands;

public interface IAddContactCommand : ICommand { }

public class AddContactCommand : IAddContactCommand
{
    private readonly IContactExtractor _contactExtractor;
    private readonly IDataAccess _dataAccess;

    public AddContactCommand(IContactExtractor contactExtractor, IDataAccess dataAccess)
    {
        _contactExtractor = contactExtractor;
        _dataAccess = dataAccess;
    }
    
    public void Execute(List<string> args)
    {
        var contact = _contactExtractor.Extract(args);
        _dataAccess.AddContact(contact);
    }
}