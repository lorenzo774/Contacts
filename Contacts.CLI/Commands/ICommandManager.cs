using Contacts.CLI.Commands;

namespace Contacts.CLI.Systems;

public interface ICommandManager
{
    void Run(ICommand command, List<string> args);
}