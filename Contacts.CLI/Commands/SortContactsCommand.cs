using Contacts.CLI.Systems;
using Contacts.Data;

namespace Contacts.CLI.Commands;

public interface ISortContactsCommand : ICommand { }

public class SortContactsCommand : ISortContactsCommand
{
    private readonly IDataAccess _dataAccess;
    private readonly IMessage _message;

    public SortContactsCommand(IDataAccess dataAccess, IMessage message)
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
        if (string.IsNullOrWhiteSpace(args[0]))
        {
            throw new Exception("No arguments specified");
        }
        var contacts = _dataAccess.GetContacts(args[0]);
        _message.DisplayContacts(contacts);
    }
}