using Contacts.Data;
using Contacts.Library;

namespace Contacts.CLI.Commands;

public interface IAddContactCommand : ICommand { }

public class AddContactCommand : IAddContactCommand
{
    private readonly IDataAccess _dataAccess;

    public AddContactCommand(IDataAccess dataAccess)
    {
        _dataAccess = dataAccess;
    }
    
    public void Execute(List<string> args)
    {
        _dataAccess.AddContact(new Contact()
        {
            Birthdate = Convert.ToDateTime(args[0]), 
            FirstName = args[1],
            LastName = args[2],
            Phone = args[3],
            Email = args[4]
        });
    }
}