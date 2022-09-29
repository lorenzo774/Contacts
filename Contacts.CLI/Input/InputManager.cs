namespace Contacts.CLI.Input;

public class InputManager : IInputManager
{
    private readonly ICommandExtractor _commandExtractor;

    public InputManager(ICommandExtractor commandExtractor)
    {
        _commandExtractor = commandExtractor;
    }
    
    public InputResult Read()
    {
        var command = _commandExtractor.Extract();
        var result = new InputResult()
        {
            Command = command, 
            Args = new()
        };
        return result;
    }
}