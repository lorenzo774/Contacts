using Contacts.Library;

namespace Contacts.Data;

public interface IDataAccess
{
    List<Contact> LoadContacts();
    void AddContact(Contact contact);
    void RemoveContact(Contact contact);
    void GetContactByFirstName(string firstName);        
    void GetContactByPhone(string phone);        
    void GetContactByLastName(string lastName);        
    void GetContactByEmail(string email);        
}