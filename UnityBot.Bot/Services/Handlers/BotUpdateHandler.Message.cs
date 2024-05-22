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
    
    
    #region ElonUchun
    private async Task TogriElonJoylashAsync(ITelegramBotClient client, Message message, CancellationToken cancellationToken)
    {
        await client.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: @"E'lonni joylash narxi: ""BEPUL 🕑""

ℹ️ E'lon joylashtirilgandan so'ng, u moderatorlar tomonidan ko'rib chiqiladi. Zaruriyat tug'ilganda, ma'lumotlar to'g'riligini tekshirish maqsadida e'lon muallifi bilan bog'laniladi.

Tayyor e'lonni ""EFFECT | Katta mehnat bozori"" @palonchi kanaliga joylash uchun ""E'lonni joylash"" tugmasini bosing, bekor qilish uchun ""Bekor qilish"" tugmasini bosing 👇",
                        replyMarkup: await InlineKeyBoards.ForMainState(),
                        cancellationToken: cancellationToken);

        var user = await _userService.GetUser(message.Chat.Id);
        if (user != null)
        {
            await SendToModeratorAsync(client, message, cancellationToken);

            user.Messages.Clear();

            await _userService.NolRuzumeCount(message.Chat.Id);
            await _userService.NolIshJoylashCount(message.Chat.Id);
            await _userService.NolSherikKerakCount(message.Chat.Id);
            await _userService.NolShogirtKerakCount(message.Chat.Id);
            await _userService.NolUstozKerakCount(message.Chat.Id);

            await _userService.ChangeStatus(message.Chat.Id, Status.MainPage);
        }
        return;
    }
    private async Task NotogriElonJoylashAsync(ITelegramBotClient client, Message message, CancellationToken cancellationToken)
    {
        await client.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: "❌ E'lon qabul qilinmadi.",
                        replyMarkup: await InlineKeyBoards.ForMainState(),
                        cancellationToken: cancellationToken);
        var user = await _userService.GetUser(message.Chat.Id);
        if (user != null)
        {
            user.Messages.Clear();
            await _userService.NolRuzumeCount(message.Chat.Id);
            await _userService.ChangeStatus(message.Chat.Id, Status.MainPage);
        }
        return;
    }
    private async Task SendToModeratorAsync(ITelegramBotClient client, Message message, CancellationToken cancellationToken)
    {
        var user = await _userService.GetUser(message.Chat.Id);
        if (user == null)
        {
            return;
        }

        if (user.Status == Status.RezumeJoylash)
        {

            await client.SendTextMessageAsync(
                       chatId: Moderator,
                       text: @$"
🧑🏻‍💼 REZYUME

⭐️ Ish qidiruvchi: {user.Messages[0]}
🗓 Tug'ilgan sana: {user.Messages[1]}
💠 Mutaxassislik: {user.Messages[2]}
🌏 Manzil: {user.Messages[3]}
💰 Ish haqi: {user.Messages[4]}

🧑‍🎓 Talaba: {user.Messages[5]}
📑 Ish qidiruvchi haqida: {user.Messages[6]}

📞 Aloqa: {user.Messages[7]}
✉️ Telegram: @{user.Username}
🕰 Murojaat qilish vaqti: {user.Messages[8]}

📌 Qo'shimcha ma'lumotlar: {user.Messages[9]}

#Rezyume

🌐 ""<a href='{LINK}'>EFFECT | Katta mehnat bozori</a>"" kanaliga obuna bo'lish",
                       parseMode: ParseMode.Html,
                       replyMarkup: await InlineKeyBoards.ForSendToChanel(),
                       cancellationToken: cancellationToken);
            return;
        }

        else if (user.Status == Status.IshJoylash)
        {
            await client.SendTextMessageAsync(
chatId: Moderator,
text: @$"4. ISH JOYLASH (poster)

🏢 ISH

⭐️ Ish beruvchi: {user.Messages[0]} 
📋 Vakansiya nomi: {user.Messages[1]}
💰 Ish haqi: {user.Messages[2]}
🌏 Manzil: {user.Messages[3]}

📑 Vakansiya haqida: {user.Messages[4]}

📞 Aloqa: {user.Messages[5]}
✉️ Telegram: @{user.Username}
🕰 Murojaat qilish vaqti: {user.Messages[6]}

📌 Qo'shimcha ma'lumotlar: {user.Messages[7]}

#Ish

🌐 ""EFFECT | Katta mehnat bozori"" kanaliga obuna bo'lish (link | so'zni ichida bo'lishi kerak)",
parseMode: ParseMode.Html,
replyMarkup: await InlineKeyBoards.ForSendToChanel(),
cancellationToken: cancellationToken);
            return;
        }
        else if (user.Status == Status.UstozKerak)
        {
            await client.SendTextMessageAsync(
chatId: Moderator,
text: @$"31. USTOZ KERAK (poster)

🧑🏻‍🏫 USTOZ KERAK

🧑🏻 Shogirt: {user.Messages[0]}
🗓 Tug'ilgan sana: {user.Messages[1]}
💠 Shogirtlik yo'nalishi: {user.Messages[2]}
🌏 Manzil: {user.Messages[3]}
💰 Ish haqi: {user.Messages[4]}

🧑‍🎓 Talaba: {user.Messages[5]}
📑 Shogirt haqida: {user.Messages[6]}

📞 Aloqa: {user.Messages[7]}
✉️ Telegram: {user.Username}
🕰 Murojaat qilish vaqti: {user.Messages[8]}

📌 Qo'shimcha ma'lumotlar: {user.Messages[9]}

#UstozKerak

🌐 ""EFFECT | Katta mehnat bozori"" kanalga obuna bo'lish (link | so'zni ichida bo'lishi kerak)",
parseMode: ParseMode.Html,
replyMarkup: await InlineKeyBoards.ForSendToChanel(),
cancellationToken: cancellationToken);
            return;
        }
        else if (user.Status == Status.SherikKerak)
        {
            await client.SendTextMessageAsync(
                   chatId: Moderator,
                   text: @$" SHERIK KERAK (poster)

🎗 SHERIK KERAK

⭐️ Sherik: {user.Messages[0]}
📋 Sheriklik yo'nalishi: {user.Messages[1]}
💰 Hisob-kitob: {user.Messages[2]}
🌏 Manzil: {user.Messages[3]}

📑 Sheriklik haqida: {user.Messages[4]}

📞 Aloqa: {user.Messages[5]}
✉️ Telegram: @{user.Username}
🕰 Murojaat qilish vaqti: {user.Messages[6]}

📌 Qo'shimcha ma'lumotlar: {user.Messages[7]}
#SherikKerak

🌐 ""EFFECT | Katta mehnat bozori"" kanalga obuna bo'lish (link | so'zni ichida bo'lishi kerak)",
                   parseMode: ParseMode.Html,
                   replyMarkup: await InlineKeyBoards.ForSendToChanel(),
                   cancellationToken: cancellationToken);
            return;
        }
        else if (user.Status == Status.ShogirtKerak)
        {
            await client.SendTextMessageAsync(
                chatId: Moderator,
                text: @$"<strong>SHOGIRT KERAK</strong> 

🧑🏻 SHOGIRT KERAK

🧑🏻‍🏫 Ustoz: {user.Messages[0]}
📋 Ustozlik yo'nalishi: {user.Messages[1]}
💰 Ish haqi: {user.Messages[2]}
🌏 Manzil: {user.Messages[3]}

📑 Ustozlik haqida: {user.Messages[4]}

📞 Aloqa: {user.Messages[5]}
✉️ Telegram: @{user.Username}
🕰 Murojaat qilish vaqti: {user.Messages[6]}

📌 Qo'shimcha ma'lumotlar: {user.Messages[7]}

#ShogirtKerak

🌐 ""<a href='{LINK}'>EFFECT | Katta mehnat bozori</a>"" kanaliga obuna bo'lish",
                parseMode: ParseMode.Html,
                replyMarkup: await InlineKeyBoards.ForSendToChanel(),
                cancellationToken: cancellationToken);
            return;
        }
    }
#endregion

    #region ModeratorlarUchun
    private async Task SentToMainChanelAsync(ITelegramBotClient client, Message message, CancellationToken cancellationToken)
    {
        await client.CopyMessageAsync(
            chatId: MainChanel,
            messageId: message.MessageId,
            fromChatId: message.Chat.Id,
            caption: null,
            parseMode: null,
            disableNotification: false,
            replyToMessageId: 0,
            allowSendingWithoutReply: true,
            cancellationToken: cancellationToken);

        await client.DeleteMessageAsync(
          chatId: Moderator,
          messageId: message.MessageId,
          cancellationToken: cancellationToken);

    }

    
    
    private async Task SkipFromModeratorsAsync(ITelegramBotClient client, Message message, CancellationToken cancellationToken)
    {
        await client.DeleteMessageAsync(
            chatId: Moderator,
            messageId: message.MessageId,
            cancellationToken: cancellationToken);
    }
    #endregion

}