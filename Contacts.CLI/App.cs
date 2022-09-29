using Contacts.CLI.Systems;

namespace Contacts.CLI;

public class App : IApp
{
    private readonly IMessage _message;

    public App(IMessage message)
    {
        _message = message;
    }
    
    public void Run()
    {
        _message.Help();
    }
}