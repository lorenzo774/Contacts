using Contacts.CLI.Commands;

namespace Contacts.CLI.Input;

public class CommandExtractor : ICommandExtractor
{
    private readonly Dictionary<string, ICommand> _nameCommands;

    public CommandExtractor(IHelpCommand helpCommand)
    {
        _nameCommands = new()
        {
            { "help", helpCommand }
        };
    }
    
    public ICommand Extract()
    {
        return _nameCommands["help"];
    }
}