using Contacts.CLI.Input;
using Contacts.CLI.Systems;

namespace Contacts.CLI;

/// <summary>
/// Entry point
/// </summary>
public class App : IApp
{
    private readonly IInputManager _inputManager;
    private readonly ICommandManager _commandManager;

    public App(IInputManager inputManager, ICommandManager commandManager)
    {
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
            Console.WriteLine($"Error: {e.Message}");
        }
    }
}