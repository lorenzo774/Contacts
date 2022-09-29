using Contacts.CLI.Commands;

namespace Contacts.CLI.Input;

public class InputResult
{
    public ICommand? Command { get; init; }
    public List<string> Args { get; init; } = new();
}