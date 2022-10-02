using Contacts.Data;

namespace Contacts.CLI.Commands;

public interface IRemoveContactCommand : ICommand { }

public class RemoveContactCommand : IRemoveContactCommand
{
    private readonly IDataAccess _dataAccess;

    public RemoveContactCommand(IDataAccess dataAccess)
    {
        _dataAccess = dataAccess;
    }
    
    public void Execute(List<string> args)
    {
        if (args.Count == 0)
        {
            throw new Exception("No arguments specified");
        }
        string email = args[0];
        if (string.IsNullOrEmpty(email))
        {
            throw new Exception("No arguments specified");
        }
        _dataAccess.RemoveContact(email);
    }
}