using Xunit;
using AZDiscordBot.Discord;
using Discord;

namespace AZDiscordBot.xUnit.Tests
{
    public class SocketConfigTests
    {
        [Fact]
        public void ConfigDefaultTests()
        {
            const LogSeverity expected = LogSeverity.Verbose;

            var actual = SocketConfig.GetDefault().LogLevel;

            Assert.Equal(expected, actual);           
        }

        [Fact]
        public void ConfigNewTests()
        {
            var actual = SocketConfig.GetNew();

            Assert.NotNull(actual);           
        }
    }
}