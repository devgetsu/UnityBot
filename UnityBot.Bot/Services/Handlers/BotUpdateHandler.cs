using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using UnityBot.Bot.Models.Entities;
using UnityBot.Bot.Services.UserServices;

namespace UnityBot.Bot.Services.Handlers
{
    public partial class BotUpdateHandler : IUpdateHandler
    {
        private readonly ILogger<BotUpdateHandler> _logger;
        private readonly IUserService _userService;

        public BotUpdateHandler(ILogger<BotUpdateHandler> logger, UserServices.IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }
        public Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Error occured with telegramBot {exception}");

            return Task.CompletedTask;
        }

        public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            var handler = update.Type switch
            {
                UpdateType.Message => HandleMessageAsync(botClient, update.Message, cancellationToken),
                UpdateType.CallbackQuery => HandleCallbackQueryAsync(botClient, update.CallbackQuery, cancellationToken),
                _ => HandleUnknownMessageAsync(botClient, update, cancellationToken)
            }
            ;
            try
            {
                await handler;
            }
            catch (Exception ex)
            {
                await handler;
            }
        }

        private async Task HandleUnknownMessageAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            try
            {
                Console.WriteLine("Not impelemented mesage");
            }
            catch
            { }
        }
        private async Task HandleClearAllReplyKeysAsync(ITelegramBotClient client, Message message, UserModel user, CancellationToken cancellationToken)
        {
            foreach (var item in user.LastMessages)
            {
                await client.EditMessageReplyMarkupAsync(
                    chatId: message.Chat.Id,
                    messageId: item,
                    replyMarkup: null,
                    cancellationToken: cancellationToken);
            }

            user.LastMessages.Clear();
        }
    }
}
