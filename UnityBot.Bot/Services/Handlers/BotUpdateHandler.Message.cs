using Telegram.Bot.Types;
using Telegram.Bot;

namespace UnityBot.Bot.Services.Handlers;

public partial class BotUpdateHandler
{
    private async Task HandleMessageAsync(ITelegramBotClient client, Message message, CancellationToken cancellationToken)
    {
        await client.SendTextMessageAsync(
            chatId: message.Chat.Id,
            text: "Hi there!",
            cancellationToken: cancellationToken);
    }
}
