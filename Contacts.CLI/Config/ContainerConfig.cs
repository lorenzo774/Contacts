using Autofac;
using Contacts.Data;

namespace Contacts.CLI.Config;

public static class ContainerConfig
{
    public static IContainer Configure()
    {
        var container = new ContainerBuilder();
        // Register dependencies
        container.RegisterType<App>().As<IApp>();
        container.RegisterType<DataAccess>().As<IDataAccess>();
        
        return container.Build();
    }
}