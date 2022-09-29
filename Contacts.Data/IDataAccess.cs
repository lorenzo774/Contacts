using Contacts.Library;

namespace Contacts.Data;

public interface IDataAccess
{
    List<Contact> LoadContacts();
}