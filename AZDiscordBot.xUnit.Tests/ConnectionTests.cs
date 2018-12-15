using Xunit;
using AZDiscordBot.Discord;
using AZDiscordBot.Discord.Entities;
using System.Threading.Tasks;
using Discord.Net;

namespace AZDiscordBot.xUnit.Tests
{
    public class ConnectionTests
    {
        [Fact]
        public void ConnectionAsyncTests()
        {
            Assert.ThrowsAsync<HttpException>(AttemptWrongConnect);           
        }

        private async Task AttemptWrongConnect()
        {
            var conn = Unity.Resolve<Connection>();
            await conn.ConnectAsync(new AZDiscordBotConfig {Token = "FAKE-TOKEN"});
        }
    }
}