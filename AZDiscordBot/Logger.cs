using System;
using System.Collections.Generic;
using System.Text;

namespace AZDiscordBot
{
    public class Logger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
