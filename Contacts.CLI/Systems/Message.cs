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

    public void Warning(string message)
    {
        WriteMessage(message, ConsoleColor.Yellow);
    }
    
    public void Help()
    {
        WriteMessage("\n------- Contacts v1.0.0 -------\n", ConsoleColor.Magenta);
        WriteMessage("\tAdd/Remove/Update");
        Console.WriteLine("\tadd [email] [first_name?] [last_name?] [birthdate?] [phone?] -> Add a new contact\n" +
                          "\trm [email] -> Remove a contact by email address\n" +
                          "\tup [email] [field] [updated_field] -> Update a contact\n");
        WriteMessage("\tSearch");
        Console.WriteLine("\tlist -> Get list of your contacts\n" +
                          "\tsort [field] -> Sort your list by a field\n" +
                          "\tget [email] -> Search a contact by email\n");
        WriteMessage("\tOther");
        Console.WriteLine("\thelp -> Get this message");
        WriteMessage("\n-------------------------------", ConsoleColor.Magenta);
    }

    public void DisplayContacts(List<Contact> contacts)
    {
        WriteMessage("\nContacts 👤👤👤 \n");
        foreach (var contact in contacts)
        {
            Console.WriteLine(contact);
        }    
        if (contacts.Count == 0)
        {
            Warning("No contacts");
        }
    }

    public void DisplayContact(Contact contact)
    {
        WriteMessage("\nContact 👤 \n");
        Console.WriteLine(contact);
    }

    public void DisplayError(Exception exception)
    {
        WriteMessage($"\nError: {exception.Message}", ConsoleColor.Red);
    }
}