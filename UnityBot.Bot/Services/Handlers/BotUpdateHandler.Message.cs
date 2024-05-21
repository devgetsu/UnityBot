using Telegram.Bot.Types;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using UnityBot.Bot.Services.ReplyKeyboards;
using UnityBot.Bot.Services.UserServices;
using UnityBot.Bot.Models.Entities;
using UnityBot.Bot.Models.Enums;
using Microsoft.AspNetCore.Mvc.Filters;

namespace UnityBot.Bot.Services.Handlers;

public partial class BotUpdateHandler
{
    private const string LINK = "https://google.com";
    private const string Moderator = "-1002019788238";
    private const string MainChanel = "-1002108545748";
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
            _logger.LogError(ex.Message, ex);
            await messageType;
        }

    }

    private async Task HandleNotImplementedMessageAsync(ITelegramBotClient client, Message message, CancellationToken cancellationToken)
    {
        await client.SendTextMessageAsync(
                    chatId: message.Chat.Id,
                    text: "Assalomu alaykum, \"EFFECT | Katta mehnat bozori\" @palonchi kanali uchun e'lon yaratuvchi botiga xush kelibsiz.",
                    replyMarkup: await InlineKeyBoards.ForMainState(),
                    cancellationToken: cancellationToken);
        return;
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
            await _userService.NolRuzumeCount(message.Chat.Id);
            await _userService.NolShogirtKerakCount(message.Chat.Id);
            await _userService.NolUstozKerakCount(message.Chat.Id);
            await _userService.NolSherikKerakCount(message.Chat.Id);
            await _userService.NolIshJoylashCount(message.Chat.Id);

            await client.SendTextMessageAsync(
                    chatId: message.Chat.Id,
                    text: $"Assalomu alaykum, <a href='{LINK}'>EFFECT | Katta mehnat bozori</a> @palonchi kanali uchun e'lon yaratuvchi botiga xush kelibsiz.",
                    replyMarkup: await InlineKeyBoards.ForMainState(),
                    parseMode: ParseMode.Html,
                    cancellationToken: cancellationToken);

            var user = new UserModel()
            {
                ChatId = message.Chat.Id,
                Username = message.From.Username,
                Status = Models.Enums.Status.MainPage
            };
            await _userService.CreateUser(user);

            return;
        }


        else if (!string.IsNullOrWhiteSpace(message.Text.ToString()))
        {
            await HandleRandomTextAsync(client, message, cancellationToken);
        };
    }
    public async Task HandleCallbackQueryAsync(ITelegramBotClient client, CallbackQuery callbackQuery, CancellationToken cancellationToken)
    {
        Task myMessage = callbackQuery.Data switch
        {
            "ish_joylash" => HandleIshJoylashAsync(client, callbackQuery.Message, cancellationToken),
            "rezyume_joylash" => HandleRezumeJoylashAsync(client, callbackQuery.Message, cancellationToken),
            "shogirt_kerak" => HandleShogirtKerakAsync(client, callbackQuery.Message, cancellationToken),
            "ustoz_kerak" => HandleUstozkerakAsync(client, callbackQuery.Message, cancellationToken),
            "sherik_kerak" => HandleSherikKerakAsync(client, callbackQuery.Message, cancellationToken),
            "togrri" => TogriElonJoylashAsync(client, callbackQuery.Message, cancellationToken),
            "notogrri" => NotogriElonJoylashAsync(client, callbackQuery.Message, cancellationToken),
            "joyla" => SentToMainChanelAsync(client, callbackQuery.Message, cancellationToken),
            "skip" => SkipFromModeratorsAsync(client, callbackQuery.Message, cancellationToken)
        };

        try
        {
            await myMessage;
        }
        catch (Exception ex)
        {
            await client.SendTextMessageAsync(callbackQuery.Message.Chat.Id, "An error occurred. Please try again later.", cancellationToken: cancellationToken);
            Console.WriteLine(ex);
        }
    }
    private async Task SentToMainChanelAsync(ITelegramBotClient client, Message message, CancellationToken cancellationToken)
    {
        await client.ForwardMessageAsync(
            chatId: MainChanel,
            messageId: message.MessageId,
            fromChatId: message.Chat.Id,
            protectContent: false,
            disableNotification: false,
            cancellationToken: cancellationToken);
    }

    private async Task SkipFromModeratorsAsync(ITelegramBotClient client, Message message, CancellationToken cancellationToken)
    {
        await client.DeleteMessageAsync(
            chatId: MainChanel,
            messageId: message.MessageId,
            cancellationToken: cancellationToken);
    }
}
