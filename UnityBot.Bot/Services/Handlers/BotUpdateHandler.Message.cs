using Telegram.Bot.Types;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;

namespace UnityBot.Bot.Services.Handlers;

public partial class BotUpdateHandler
{
    private async Task HandleMessageAsync(ITelegramBotClient client, Message message, CancellationToken cancellationToken)
    {
        var messageType = message.Type switch
        {
            MessageType.Text => HandleTextMessageAsnyc(client, message, cancellationToken),
            MessageType.Sticker => HandleStickerMessageAsync(client, message, cancellationToken),
            _ => HandlePhotoMessageAsync(client, message, cancellationToken),
        };
        try
        {
            await messageType;
        }
        catch (Exception ex)
        {
            await HandlePollingErrorAsync(client, ex, cancellationToken);
        }
    }

    private async Task HandlePhotoMessageAsync(ITelegramBotClient client, Message message, CancellationToken cancellationToken)
    {
        await client.SendTextMessageAsync(
               chatId: message.Chat.Id,
               text: "You Send Unknown Message",
               cancellationToken: cancellationToken);
    }

    private async Task HandleStickerMessageAsync(ITelegramBotClient client, Message message, CancellationToken cancellationToken)
    {
        await client.SendTextMessageAsync(
               chatId: message.Chat.Id,
               text: "You Send Sticker Message",
               cancellationToken: cancellationToken);
    }

    private async Task HandleTextMessageAsnyc(ITelegramBotClient client, Message message, CancellationToken cancellationToken)
    {
        await client.SendTextMessageAsync(
            chatId: message.Chat.Id,
            text: "Hi there!",
            cancellationToken: cancellationToken);
    }
}
