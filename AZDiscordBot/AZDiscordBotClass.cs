using System.Threading.Tasks;
using System;
using AZDiscordBot.Storage;
using AZDiscordBot.Discord;
using AZDiscordBot.Discord.Entities;

namespace AZDiscordBot
{
    public class AZDiscordBotClass
    {
        private readonly IDataStorage _storage;
        private readonly Connection _connection;

        public AZDiscordBotClass(IDataStorage storage, Connection connection)
        {
            _storage = storage;
            _connection = connection;
        }

        public async Task Start()
        {
            await _connection.ConnectAsync(new AZDiscordBotConfig
            {
                Token = _storage.RestoreObject<string>("Config/BotToken")
            });
        }
    }
}