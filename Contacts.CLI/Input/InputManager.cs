namespace Contacts.CLI.Input;

public class InputManager : IInputManager
{
    private readonly ICommandExtractor _commandExtractor;
    private readonly IArgumentExtractor _argumentExtractor;

    public InputManager(ICommandExtractor commandExtractor, IArgumentExtractor argumentExtractor)
    {
        _commandExtractor = commandExtractor;
        _argumentExtractor = argumentExtractor;
    }
    
    public InputResult Read()
    {
        var command = _commandExtractor.Extract();
        var args = _argumentExtractor.Extract();
        var result = new InputResult()
        {
            Command = command, 
            Args = args
        };
        return result;
    }
}