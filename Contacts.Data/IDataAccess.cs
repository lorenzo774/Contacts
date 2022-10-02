using Contacts.Library;

namespace Contacts.Data;

public interface IDataAccess
{
    List<Contact> GetContacts(string orderBy = "");
    void AddContact(Contact contact);
    void RemoveContact(string email);
    Contact? GetContactByEmail(string email);
    void UpdateContact(string email, string field, string updatedField);

}