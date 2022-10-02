using Contacts.CLI.Systems;
using Contacts.Data;

namespace Contacts.CLI.Commands;

public interface IGetContactCommand : ICommand { }

public class GetContactCommand : IGetContactCommand
{
    private readonly IDataAccess _dataAccess;
    private readonly IMessage _message;
    
    public GetContactCommand(IDataAccess dataAccess, IMessage message)
    {
        _dataAccess = dataAccess;
        _message = message;
    }
    
    public void Execute(List<string> args)
    {
        if (args.Count == 0)
        {
            throw new Exception("No arguments specified");
        }
        
        var contact = _dataAccess.GetContactByEmail(args[0]);
        if (contact == null)
        {
            throw new Exception("Contact not found");
        }
        _message.DisplayContact(contact);
    }
}