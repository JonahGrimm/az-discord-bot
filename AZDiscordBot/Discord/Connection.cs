using AZDiscordBot.Discord.Entities;
using Discord;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AZDiscordBot.Discord
{
    public class Connection
    {
        private readonly DiscordSocketClient _client;
        private readonly DiscordLogger _logger;

        public Connection(DiscordLogger logger, DiscordSocketClient client)
        {
            _logger = logger;
            _client = client;
        }

        public async Task ConnectAsync(AZDiscordBotConfig config)
        {
            _client.Log += _logger.Log; //Add a listener? subscriber? to _client.Log
            _client.MessageDeleted += MessageDeleted;
            _client.MessageReceived += MessageReceived;
            _client.MessageUpdated += MessageUpdated;

            await _client.LoginAsync(TokenType.Bot, config.Token); //Log the bot in using the token from AZDiscordBotConfig
            await _client.StartAsync(); //Star the bot?

            await Task.Delay(-1); //Keep bot on until turned off
        }

        private async Task MessageReceived(SocketMessage message)
        {
            if (message.Content == "!ping")
            {
                await message.Channel.SendMessageAsync("Pong!");
            }
            if (message.Content == "!lick")
            {
                await message.Channel.SendMessageAsync("*LickitungBot affectionately licks " + message.Author.Username + "*");
                await message.Channel.SendMessageAsync(message.Author.GetAvatarUrl(ImageFormat.Auto, 2048));
            }
        }

        private async Task MessageDeleted(Cacheable<IMessage, ulong> message, ISocketMessageChannel arg2)
        {
            await message.GetOrDownloadAsync();
            Console.WriteLine("Downloaded!");
        }

        private async Task MessageUpdated(Cacheable<IMessage, ulong> before, SocketMessage after, ISocketMessageChannel channel)
        {
            // If the message was not in the cache, downloading it will result in getting a copy of `after`.
            var message = await before.GetOrDownloadAsync();
            Console.WriteLine($"{message} -> {after}");
            //var logmsg = new LogMessage(LogSeverity.Info, "MessageUpdated", message.Content + "->" + after.Content);
            //await _logger.Log(new LogMessage(LogSeverity.Info, "MessageUpdated", message.Content + "->" + after.Content));
        }
    }
}
