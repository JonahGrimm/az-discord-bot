using System.Threading.Tasks;

namespace AZDiscordBot
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var bot = Unity.Resolve<AZDiscordBotClass>();
            await bot.Start();
        }
    }
}
