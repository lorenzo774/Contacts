using System.Text;

namespace Contacts.CLI.Config;

public static class ConsoleConfig
{
    /// <summary>
    /// Set console encoding to UTF8
    /// </summary>
    public static void Configure()
    {
        Console.OutputEncoding = Encoding.UTF8;
    }
}