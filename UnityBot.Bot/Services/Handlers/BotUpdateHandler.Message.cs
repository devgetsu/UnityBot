using Telegram.Bot.Types;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using UnityBot.Bot.Services.ReplyKeyboards;

namespace UnityBot.Bot.Services.Handlers;

public partial class BotUpdateHandler
{
    private async Task HandleMessageAsync(ITelegramBotClient client, Message message, CancellationToken cancellationToken)
    {
        var messageType = message.Type switch
        {
            MessageType.Text => HandleTextMessageAsnyc(client, message, cancellationToken),
            MessageType.Sticker => HandleStickerMessageAsync(client, message, cancellationToken),
            MessageType.Photo => HandlePhotoMessageAsync(client, message, cancellationToken),
            MessageType.Location => HandleLocationMessageAsync(client, message, cancellationToken),
            _ => HandleNotImplementedMessageAsync(client, message, cancellationToken),
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

    private async Task HandleNotImplementedMessageAsync(ITelegramBotClient client, Message message, CancellationToken cancellationToken)
    {
        await client.SendTextMessageAsync(
              chatId: message.Chat.Id,
              text: $"How's Message",
              cancellationToken: cancellationToken);
    }

    private async Task HandleLocationMessageAsync(ITelegramBotClient client, Message message, CancellationToken cancellationToken)
    {
        var letitude = message.Location.Latitude;
        var longitude = message.Location.Longitude;

        await client.SendTextMessageAsync(
               chatId: message.Chat.Id,
               text: $"Your Latitude {letitude} and Longitude {longitude}",
               cancellationToken: cancellationToken);
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
        if (message.Text == "/start")
        {
            await client.SendTextMessageAsync(
                    chatId: message.Chat.Id,
                    text: "Assalomu alaykum, \"EFFECT | Katta mehnat bozori\" @palonchi kanali uchun e'lon yaratuvchi botiga xush kelibsiz.",
                    replyMarkup: await ReplyKeyboardMarkups.ForMainState(),
                    cancellationToken: cancellationToken);
            return;
        }

        var myMessage = message.Text switch
        {
            "🏢 Ish joylash" => HandleIshJoylashAsync(client, message, cancellationToken),
            "🧑🏻 Shogirt kerak" => HandleShogirtKerakAsync(client, message, cancellationToken),
            "🧑🏻‍💼 Rezyume joylash" => HandleRezumeJoylashAsync(client, message, cancellationToken),
            "🧑🏻‍🏫 Ustoz kerak" => HandleUstozkerakAsync(client, message, cancellationToken),
            "🎗 Sherik kerak" => HandleSherikKerakAsync(client, message, cancellationToken),
        };

        try
        {
            await myMessage;
        }
        catch (Exception ex)
        {
            await HandlePollingErrorAsync(client, ex, cancellationToken);
        }
    }
}
