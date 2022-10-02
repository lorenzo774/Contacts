namespace Contacts.CLI.Systems;

public interface IMessage
{
    void Help();
    void DisplayContacts(List<Contact> contacts);
    void DisplayContact(Contact contacts);
    void DisplayError(Exception exception);
}