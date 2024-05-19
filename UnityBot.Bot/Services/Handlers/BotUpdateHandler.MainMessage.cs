using Telegram.Bot.Types;
using Telegram.Bot;

namespace UnityBot.Bot.Services.Handlers
{
    public partial class BotUpdateHandler
    {
        private async Task HandleSherikKerakAsync(ITelegramBotClient client, Message message, CancellationToken cancellationToken)
        {
            await client.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: "Bu sherik uchun",
                cancellationToken: cancellationToken);
        }

        private async Task HandleUstozkerakAsync(ITelegramBotClient client, Message message, CancellationToken cancellationToken)
        {
            await client.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: "Bu ustoz uchun",
                cancellationToken: cancellationToken);
        }

        private async Task HandleRezumeJoylashAsync(ITelegramBotClient client, Message message, CancellationToken cancellationToken)
        {
            await client.SendTextMessageAsync(
                       chatId: message.Chat.Id,
                       text: "Bu rezume joylash uchun",
                       cancellationToken: cancellationToken);
        }

        private async Task HandleShogirtKerakAsync(ITelegramBotClient client, Message message, CancellationToken cancellationToken)
        {
            await client.SendTextMessageAsync(
                       chatId: message.Chat.Id,
                       text: "Bu shogirt uchun",
                       cancellationToken: cancellationToken);
        }

        private async Task HandleIshJoylashAsync(ITelegramBotClient client, Message message, CancellationToken cancellationToken)
        {
            await client.SendTextMessageAsync(
                       chatId: message.Chat.Id,
                       text: "Bu ish joylash uchun",
                       cancellationToken: cancellationToken);
        }
    }
}
