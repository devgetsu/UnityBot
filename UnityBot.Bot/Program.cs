
using Telegram.Bot;
using Telegram.Bot.Polling;
using UnityBot.Bot.Services;
using UnityBot.Bot.Services.Handlers;

namespace UnityBot.Bot
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddSingleton<IUpdateHandler,BotUpdateHandler>();
            builder.Services.AddSingleton(t => new TelegramBotClient(builder.Configuration.GetValue("BotToken", string.Empty)));
            builder.Services.AddHostedService<BotBackgroundService>();

            var app = builder.Build();


            app.Run();
        }
    }
}
