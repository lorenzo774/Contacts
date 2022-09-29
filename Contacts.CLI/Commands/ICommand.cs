namespace Contacts.CLI.Commands;

public interface ICommand
{
    void Execute(List<string> args);
}