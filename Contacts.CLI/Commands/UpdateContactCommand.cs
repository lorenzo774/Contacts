using Contacts.Data;

namespace Contacts.CLI.Commands;

public interface IUpdateContactCommand : ICommand { }

public class UpdateContactCommand : IUpdateContactCommand
{
    private readonly IDataAccess _dataAccess;

    public UpdateContactCommand(IDataAccess dataAccess)
    {
        _dataAccess = dataAccess;
    }
    
    public void Execute(List<string> args)
    {
        if (args.Count < 3)
        {
            throw new Exception("No arguments specified");
        }
        _dataAccess.UpdateContact(args[0], args[1], args[2]);
    }
}