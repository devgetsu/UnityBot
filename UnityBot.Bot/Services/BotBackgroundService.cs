
using Telegram.Bot;

namespace UnityBot.Bot.Services
{
    public class BotBackgroundService : BackgroundService
    {
        private readonly ILogger<BotBackgroundService> _logger;
        private readonly TelegramBotClient _client;

        public BotBackgroundService(ILogger<BotBackgroundService> logger, TelegramBotClient client)
        {
            _logger = logger;
            _client = client;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var bot = await _client.GetMeAsync(stoppingToken);

            _logger.LogInformation("Bot starting with this username: {bot.Username}", bot.Username);

            Console.WriteLine($"Bot starting with this username: {bot.Username}");
        }
    }
}
