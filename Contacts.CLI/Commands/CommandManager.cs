using Contacts.CLI.Commands;

namespace Contacts.CLI.Systems;

/// <summary>
/// Run and send arguments to command
/// </summary>
public class CommandManager : ICommandManager
{
    public void Run(ICommand command, List<string> args)
    {
        command.Execute(args);
    }
}