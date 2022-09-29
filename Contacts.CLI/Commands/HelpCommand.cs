using Contacts.CLI.Systems;

namespace Contacts.CLI.Commands;

public interface IHelpCommand : ICommand { }

/// <summary>
/// Display help message
/// </summary>
public class HelpCommand : IHelpCommand
{
    private readonly IMessage _message;

    public HelpCommand(IMessage message)
    {
        _message = message;
    }
    
    public void Execute(List<string> args)
    {
        _message.Help();
    }
}