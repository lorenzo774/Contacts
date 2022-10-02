using System.Configuration;
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
            Database = ConfigurationManager.AppSettings["database"],
            Password = ConfigurationManager.AppSettings["password"],
            Server = ConfigurationManager.AppSettings["server"],
            UserID = ConfigurationManager.AppSettings["user"]
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

    public List<Contact> GetContacts(string orderBy = "")
    {
        if (connection == null)
            throw new Exception("Connection error");

        string sql = $"SELECT * FROM contacts " +
                     $"{(orderBy != "" ? "ORDER BY " + orderBy : "" )}";
        var cmd = new MySqlCommand(sql, connection);
        var contacts = new List<Contact>();
        try
        {
            var sqlReader = cmd.ExecuteReader();
            while (sqlReader.Read())
            {
                contacts.Add(new Contact()
                {
                    Email = sqlReader[0].ToString(),
                    FirstName = sqlReader[1].ToString(),
                    LastName = sqlReader[2].ToString(),
                    Birthdate = Convert.ToDateTime(sqlReader[3]),
                    Phone = sqlReader[4].ToString()             
                });
            }
            sqlReader.Close();
        }
        catch (Exception e)
        {
            if (e is MySqlException)
            {
                throw new Exception($"{orderBy} field doesn't exist");
            }
        }
        return contacts;
    }

    public void AddContact(Contact contact)
    {
        if (connection == null)
            throw new Exception("Connection error");
        
        try
        {
            string sql = "INSERT INTO contacts (birthdate, first_name, last_name, phone, email)" +
                         $"VALUES ('{contact.Birthdate.ToString(Settings.TimeFormat)}', '{contact.FirstName}', '{contact.LastName}', '{contact.Phone}', '{contact.Email}')";
            var cmd = new MySqlCommand(sql, connection);
            cmd.ExecuteScalar();
        }
        catch (MySqlException e)
        {
            if (Helper.IsDuplicateException(e))
            {
                throw new Exception($"Contact '{contact.Email}' already exist");
            }
        }
    }

    public void RemoveContact(string email)
    {
        string sql = $"DELETE FROM contacts WHERE email = '{email}'";
        var cmd = new MySqlCommand(sql, connection);
        int rowsAffected = cmd.ExecuteNonQuery();
        if (rowsAffected == 0)
        {
            throw new Exception("Contact not found");
        }
    }
    
    public Contact? GetContactByEmail(string email)
    {
        if (connection == null)
            throw new Exception("Connection error");

        string sql = $"SELECT * FROM contacts WHERE email = '{email}'";
        var cmd = new MySqlCommand(sql, connection);
        var sqlReader = cmd.ExecuteReader();
        Contact? contact = null;
        while (sqlReader.Read())
        {
            contact = new Contact()
            {
                Email = sqlReader[0].ToString(),
                FirstName = sqlReader[1].ToString(),
                LastName = sqlReader[2].ToString(),
                Birthdate = Convert.ToDateTime(sqlReader[3]),
                Phone = sqlReader[4].ToString()
            };
        }
        sqlReader.Close();
        return contact;
    }

    public void UpdateContact(string email, string field, string updatedField)
    {
        if (connection == null)
            throw new Exception("Connection error");

        string sql = $"UPDATE contacts SET {field} = '{updatedField}' WHERE email = '{email}'";
        var cmd = new MySqlCommand(sql, connection);
        try
        {
            if (cmd.ExecuteNonQuery() == 0)
            {
                throw new Exception("Contact not found");
            }
        }
        catch (Exception e)
        {
            if (e is MySqlException)
            {
                throw new Exception($"{field} field doesn't exist");
            }
            throw;
        }
        
    }
}