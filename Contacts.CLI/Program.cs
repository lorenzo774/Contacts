using Autofac;
using Contacts.CLI.Config;
using Contacts.Data;

namespace Contacts.CLI;

public static class Program
{
    private static void Main(string[] _)
    {
        // Config
        DataAccess.Configure();
        ConsoleConfig.Configure();
        
        var container = ContainerConfig.Configure();
        using (var scope = container.BeginLifetimeScope())
        {
            var app = scope.Resolve<IApp>();
            app.Run();
        }
    }
}