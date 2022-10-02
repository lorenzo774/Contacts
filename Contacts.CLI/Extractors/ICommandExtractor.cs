using Contacts.CLI.Commands;

namespace Contacts.CLI.Input;

public interface ICommandExtractor
{
    ICommand Extract();
}