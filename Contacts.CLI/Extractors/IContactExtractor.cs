namespace Contacts.CLI.Input;

public interface IContactExtractor
{
    Contact Extract(List<string> args);
}