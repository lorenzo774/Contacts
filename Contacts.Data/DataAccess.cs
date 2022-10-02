using Contacts.CLI.Config;
using Contacts.Library;
using MySql.Data.MySqlClient;

namespace Contacts.Data;

/// <summary>
/// Data access layer
/// </summary>
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

    public List<Contact> GetContacts()
    {
        if (connection == null)
            throw new Exception("Connection error");

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
                LastName = sqlReader[3].ToString(),
                Phone = sqlReader[4].ToString(),
                Email = sqlReader[5].ToString()               
            });
        }
        sqlReader.Close();
        return contacts;
    }

    public void AddContact(Contact contact)
    {
        string sql = "INSERT INTO contacts (birthdate, first_name, last_name, phone, email)" +
                     $"VALUES ('{contact.Birthdate.ToString(Settings.TimeFormat)}', '{contact.FirstName}', '{contact.LastName}', '{contact.Phone}', '{contact.Email}')";
        var cmd = new MySqlCommand(sql, connection);
        var sqlOperation = cmd.ExecuteScalar();
        Console.WriteLine(sqlOperation);
    }

    public void RemoveContact(Contact contact)
    {
        throw new NotImplementedException();
    }

    public void GetContactByFirstName(string firstName)
    {
        throw new NotImplementedException();
    }

    public void GetContactByPhone(string phone)
    {
        throw new NotImplementedException();
    }

    public void GetContactByLastName(string lastName)
    {
        throw new NotImplementedException();
    }

    public void GetContactByEmail(string email)
    {
        throw new NotImplementedException();
    }
}