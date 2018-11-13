using Unity;
using AZDiscordBot.Storage;
using AZDiscordBot.Storage.Implementations;

namespace AZDiscordBot
{
    public static class Unity
    {
        private static UnityContainer _container;

        public static void RegisterTypes()
        {
            _container = new UnityContainer();
            _container.RegisterType<IDataStorage, InMemoryStorage>();
        }
    }
}
