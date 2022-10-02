using Contacts.CLI.Input;
using Contacts.CLI.Systems;

namespace Contacts.CLI;

/// <summary>
/// Entry point
/// </summary>
public class App : IApp
{
    private readonly IMessage _message;
    private readonly IInputManager _inputManager;
    private readonly ICommandManager _commandManager;

    public App(IMessage message, IInputManager inputManager, ICommandManager commandManager)
    {
        _message = message;
        _inputManager = inputManager;
        _commandManager = commandManager;
    }
    
    public void Run()
    {
        try
        {
            var input = _inputManager.Read();
            if (input.Command == null)
            {
                throw new Exception("Command not found");
            }
            _commandManager.Run(input.Command, input.Args);
        }
        catch (Exception e)
        {
            _message.DisplayError(e);
        }
    }
}