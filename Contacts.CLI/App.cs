using Contacts.Data;

namespace Contacts.CLI;

public class App : IApp
{
    private readonly IDataAccess _dataAccess;
    
    public App(IDataAccess dataAccess)
    {
        _dataAccess = dataAccess;
    }
    
    public void Run()
    {
        Console.WriteLine("Running ...");
        var contacts = _dataAccess.LoadContacts();
        foreach (var contact in contacts)
        {
            Console.WriteLine(contact);
        }
    }
}