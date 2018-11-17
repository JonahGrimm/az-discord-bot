using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Text;

namespace AZDiscordBot.Discord.Entities
{
    public class AZDiscordBotConfig
    {
        public string Token { get; set; }
        public DiscordSocketConfig SocketConfig { get; set; }
    }
}
