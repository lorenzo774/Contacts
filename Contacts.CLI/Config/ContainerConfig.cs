using System.Reflection;
using Autofac;

namespace Contacts.CLI.Config;

public static class ContainerConfig
{
    public static IContainer Configure()
    {
        var builder = new ContainerBuilder();
        builder.RegisterType<App>().As<IApp>();
        // Register all dependencies
        builder.RegisterAssemblyTypes(
                Assembly.GetExecutingAssembly())
            .AsImplementedInterfaces();
        return builder.Build();
    }
}