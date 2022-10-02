using Contacts.CLI.Commands;

namespace Contacts.CLI.Input;

public class CommandExtractor : ICommandExtractor
{
    private readonly IHelpCommand _helpCommand;
    private readonly Dictionary<string, ICommand> _nameCommands;
    
    private const int CommandIndex = 1;

    public CommandExtractor(
        IHelpCommand helpCommand, 
        IContactsListCommand contactsListCommand,
        IAddContactCommand addContactCommand,
        IUpdateContactCommand updateContactCommand,
        IRemoveContactCommand removeContactCommand,
        IGetContactCommand getContactCommand)
    {
        _helpCommand = helpCommand;
        _nameCommands = new()
        {
            { "help", helpCommand },
            { "add", addContactCommand },            
            { "list", contactsListCommand },
            { "rm", removeContactCommand },
            { "up", updateContactCommand },
            { "get", getContactCommand }
        };
    }
    
    public ICommand Extract()
    {
        var args = Environment.GetCommandLineArgs().ToList();
        if (args.Count <= CommandIndex)
        {
            return _helpCommand;
        }
        string name = args[CommandIndex];
        
        return !_nameCommands.ContainsKey(name) ? _helpCommand : _nameCommands[name];
    }
}