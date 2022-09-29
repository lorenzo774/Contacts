using MySql.Data.MySqlClient;

namespace Contacts.CLI;

public static class Program
{
    private static void Main(string[] args)
    {
        var connection = new MySqlConnectionStringBuilder()
        {
            Database = "Contacts",
            Password = "bellissima_password",
            Server = "localhost",
            UserID = "root"
        };
        var mySqlConnection = new MySqlConnection(connection.ConnectionString);
        try
        {
            mySqlConnection.Open();
            ReadContacts(mySqlConnection);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error: {e.Message}");
        }
        mySqlConnection.Close();
        Console.WriteLine("Done");        
    }

    private static void ReadContacts(MySqlConnection mySqlConnection)
    {
        string sql = "SELECT * FROM contacts";
        var cmd = new MySqlCommand(sql, mySqlConnection);
        var sqlReader = cmd.ExecuteReader();
        Console.WriteLine("--------------------------------- Contacts ---------------------------------");
        while (sqlReader.Read())
        {
            Console.WriteLine($"Id: {sqlReader[0]}\t" +
                              $"Birthdate: {sqlReader[1]}\t" +
                              $"First name: {sqlReader[2]} " +
                              $"Last name: {sqlReader[3]}");
        }
        Console.WriteLine("----------------------------------------------------------------------------");
        sqlReader.Close();
    }
}