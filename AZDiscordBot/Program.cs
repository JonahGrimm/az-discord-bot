using AZDiscordBot.Discord;
using AZDiscordBot.Discord.Entities;
using AZDiscordBot.Storage;
using System;
using System.Threading.Tasks;

namespace AZDiscordBot
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            Unity.RegisterTypes();
            Console.WriteLine("Hello World!");

            var storage = Unity.Resolve<IDataStorage>();

            var token = "ABC";
            storage.StoreObject(token, "Config/BotToken");

            Console.WriteLine("Done");

            Console.ReadKey();
            return;

            var connection = Unity.Resolve<Connection>();
            await connection.ConnectAsync(new AZDiscordBotConfig
            {
                Token = storage.RestoreObject<string>("Config/BotToken")
            });

            Console.ReadKey();
        }
    }
}
