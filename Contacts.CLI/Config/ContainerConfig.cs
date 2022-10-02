using System.Reflection;
using Autofac;
using Contacts.Data;

namespace Contacts.CLI.Config;

public static class ContainerConfig
{
    /// <summary>
    /// Register dependencies from assembly
    /// </summary>
    public static IContainer Configure()
    {
        var builder = new ContainerBuilder();
        builder.RegisterType<App>().As<IApp>();
        builder.RegisterAssemblyTypes(
                Assembly.GetExecutingAssembly())
            .AsImplementedInterfaces();
        // Register Data project dependencies
        builder.RegisterType<DataAccess>().As<IDataAccess>();
        
        return builder.Build();
    }
}