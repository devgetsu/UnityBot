using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
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
            return Task.CompletedTask;
        }

        public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            try
            {
                var getchatmember = await botClient.GetChatMemberAsync(LINK, update.Message.From.Id);
                if (getchatmember.Status.ToString() == "Left" || getchatmember.Status.ToString() == null || getchatmember.Status.ToString() == "null" || getchatmember.Status.ToString() == "")
                {
                    InlineKeyboardMarkup inlineKeyboard = new(new[]
                            {
                    new []
                    {
                        InlineKeyboardButton.WithUrl(text: "EFFECT | Katta mehnat bozori", url: LINK),
                    },
                });
                    await botClient.SendTextMessageAsync(
                        chatId: update.Message.Chat.Id,
                        text: "Boshlashdan avval kanalga obuna bo'ling! Va /start buyrug'ini kirting!",
                        replyMarkup: inlineKeyboard,
                        cancellationToken: cancellationToken);
                    return;

                }
                var handler = update.Type switch
                {
                    UpdateType.Message => HandleMessageAsync(botClient, update.Message, cancellationToken),
                    UpdateType.CallbackQuery => HandleCallbackQueryAsync(botClient, update.CallbackQuery, cancellationToken),
                    _ => HandleUnknownMessageAsync(botClient, update, cancellationToken)
                };

                try
                {
                    await ClearMessageMethod(botClient, update.Message, cancellationToken);
                    await ClearUpdateMethod(botClient, update.CallbackQuery, cancellationToken);

                    await handler;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Handler or CLear ex in UpdateAsync");
                }
            }
            catch
            {
                Console.WriteLine("UpdateAysncda xatolik");
                return;
            }
        }

        private async Task HandleUnknownMessageAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            try
            {
                Console.WriteLine("Not impelemented mesage");
            }
            catch
            {
                Console.WriteLine("HandleUnknownMessageAsync error");
            }
        }
    }
}
