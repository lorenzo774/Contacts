using Contacts.Library;
using MySql.Data.MySqlClient;

namespace Contacts.Data;

public class DataAccess : IDataAccess
{
    private static MySqlConnection? connection;
    
    /// <summary>
    /// Configure connection object
    /// </summary>
    public static void Configure()
    {
        var cnBuilder = new MySqlConnectionStringBuilder()
        {
            Database = "Contacts",
            Password = "bellissima_password",
            Server = "localhost",
            UserID = "root"
        };
        connection = new MySqlConnection(cnBuilder.ConnectionString);
        try
        {
            connection.Open();
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error: {e.Message}");
        }
    }

    public List<Contact> LoadContacts()
    {
        if (connection == null)
        {
            throw new Exception("Connection error");
        }
        string sql = "SELECT * FROM contacts";
        var cmd = new MySqlCommand(sql, connection);
        var sqlReader = cmd.ExecuteReader();
        var contacts = new List<Contact>();
        while (sqlReader.Read())
        {
            contacts.Add(new Contact()
            {
                Birthdate = Convert.ToDateTime(sqlReader[1]),
                FirstName = sqlReader[2].ToString(),
                LastName = sqlReader[3].ToString()
            });
        }
        sqlReader.Close();
        return contacts;
    }
}