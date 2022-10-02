using Contacts.Library;

namespace Contacts.CLI.Systems;

public class Message : IMessage
{
    /// <summary>
    /// Helper method to display a message with a color
    /// </summary>
    private void WriteMessage(string message, ConsoleColor color = ConsoleColor.Green)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(message);
        Console.ResetColor();
    }
    
    public void Help()
    {
        WriteMessage("\n------- Contacts v1.0.0 -------\n", ConsoleColor.Magenta);
        WriteMessage("\tAdd/Remove");
        Console.WriteLine("\tadd [birthdate?] [first_name?] [last_name?] [phone?] [email?] -> Add a new contact\n" +
                          "\trm [email | first_name | last_name | phone] -> Remove a contact by email address\n");
        WriteMessage("\tSearch");
        Console.WriteLine("\tlist -> Get list of your contacts\n" +
                          "\tsort [field] -> Sort your list by a field\n" +
                          "\tsearch [field? default=fullname] [value] -> Search a contact\n");
        WriteMessage("\tOther");
        Console.WriteLine("\thelp -> Get this message");
        WriteMessage("\n-------------------------------", ConsoleColor.Magenta);
    }

    public void DisplayContacts(List<Contact> contacts)
    {
        WriteMessage("\nContacts\n");
        foreach (var contact in contacts)
        {
            Console.WriteLine(contact);
        }
    }

    public void DisplayError(Exception exception)
    {
        WriteMessage($"\nError: {exception.Message}", ConsoleColor.Red);
    }
}