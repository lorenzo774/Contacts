using Autofac;
using Contacts.CLI.Commands;
using Contacts.CLI.Systems;
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
        container.RegisterType<Message>().As<IMessage>();
        container.RegisterType<ContactsListCommand>().As<IContactsListCommand>();
        
        return container.Build();
    }
}