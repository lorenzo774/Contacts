using MySql.Data.MySqlClient;

namespace Contacts.Data;

public static class Helper
{
    public static bool IsDuplicateException(MySqlException e) => e.Message.StartsWith("Duplicate entry");
}