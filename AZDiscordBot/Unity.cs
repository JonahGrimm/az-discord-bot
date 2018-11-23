using Unity;
using AZDiscordBot.Storage;
using AZDiscordBot.Storage.Implementations;
using Unity.Resolution;
using Unity.Lifetime;

namespace AZDiscordBot
{
    public static class Unity
    {
        private static UnityContainer _container;

        public static UnityContainer Container
        {
            get
            {
                if (_container == null)
                    RegisterTypes();
                return _container;
            }
        }

        public static void RegisterTypes()
        {
            _container = new UnityContainer();
            _container.RegisterType<IDataStorage, InMemoryStorage>(new ContainerControlledLifetimeManager());
            _container.RegisterType<ILogger, Logger>(new ContainerControlledLifetimeManager());
            _container.RegisterType<Discord.Connection>(new ContainerControlledLifetimeManager());
        }

        public static T Resolve<T>()
        {
            return (T)Container.Resolve(typeof(T), string.Empty, new CompositeResolverOverride());
        }
    }
}