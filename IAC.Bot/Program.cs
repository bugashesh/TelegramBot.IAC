using System;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace IAC.Bot
{
    class Program
    {
        private static readonly string botToken = Environment.GetEnvironmentVariable("BOT_TOKEN");

        private const string startCommand = "/start";
        private const string randomCommand = "/random";

        static void Main() => ConfigureBot().GetAwaiter().GetResult();

        private static async Task ConfigureBot()
        {
            Console.WriteLine("Starting bot...");
            BotClient.Instance.On(startCommand, HandleStartCommandAsync);
            BotClient.Instance.On(randomCommand, HandleRandomAsync);
            await BotClient.Instance.StartBotAsync(botToken);
        }

        private static async Task HandleStartCommandAsync(ITelegramBotClient client, Message message)
        {
            await client.SendTextMessageAsync(message.Chat.Id, "You used command: /start");
        }

        private static async Task HandleRandomAsync(ITelegramBotClient client, Message message)
        {
            var random = new Random();
            await client.SendTextMessageAsync(message.Chat.Id, "Random number: " + random.Next(0, 101));
        }
    }
}