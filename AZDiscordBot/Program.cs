using AZDiscordBot.Discord;
using AZDiscordBot.Discord.Entities;
using System;

namespace AZDiscordBot
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Unity.RegisterTypes();
            Console.WriteLine("Hello World!");

            var discordBotConfig = new AZDiscordBotConfig
            {
                Token = "ABC",
                SocketConfig = SocketConfig.GetDefault()
            };

            var connection = Unity.Resolve<Connection>();

            Console.ReadKey();
        }
    }
}
