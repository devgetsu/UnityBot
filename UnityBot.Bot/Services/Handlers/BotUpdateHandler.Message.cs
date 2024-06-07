﻿using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using UnityBot.Bot.Models.Entities;
using UnityBot.Bot.Models.Enums;
using UnityBot.Bot.Services.ReplyKeyboards;
using Update = Telegram.Bot.Types.Update;

namespace UnityBot.Bot.Services.Handlers;

public partial class BotUpdateHandler
{
    private const string LINK = "https://t.me/effect_mehnat_obuna_bot?start=utm_abzXanaVLLeKDNkd";
    private const string BotLINK = "https://t.me/effect_mehnat_bot";
    private const string Moderator = "-1002019788238";
    private const string MainChanel = "-1002230870026";
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
        try
        {

            await client.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: $"<strong>Assalomu alaykum, \"EFFECT | Katta mehnat bozori\" kanali uchun e'lon yaratuvchi botiga xush kelibsiz.\r\n\r\n \"EFFECT | Katta mehnat bozori\" - ish izlayotgan odamlarga vakansiyalarni, ish beruvchilarga esa ishchilarni topishda yordam beradi. Qolaversa bir qator boshqa yo'nalishlarni ham qollab quvvatlaydi.</strong>",
                        parseMode: ParseMode.Html, replyMarkup: await InlineKeyBoards.ForMainState(),
                        cancellationToken: cancellationToken);
            return;
        }
        catch (Exception ex)
        {
            return;
        }
    }
    private async Task HandleLocationMessageAsync(ITelegramBotClient client, Message message, CancellationToken cancellationToken)
    {
        try
        {

            var letitude = message.Location.Latitude;
            var longitude = message.Location.Longitude;

            await client.SendTextMessageAsync(
                   chatId: message.Chat.Id,
                   text: $"Your Latitude {letitude} and Longitude {longitude}",
                   cancellationToken: cancellationToken);
            return;
        }
        catch
        {
            return;
        }
    }
    private async Task HandlePhotoMessageAsync(ITelegramBotClient client, Message message, CancellationToken cancellationToken)
    {
        try
        {

            await client.SendTextMessageAsync(
                   chatId: message.Chat.Id,
                   text: "You Send Unknown Message",
                   cancellationToken: cancellationToken);
            return;
        }
        catch
        {
            return;
        }
    }
    private async Task HandleStickerMessageAsync(ITelegramBotClient client, Message message, CancellationToken cancellationToken)
    {
        try
        {

            await client.SendTextMessageAsync(
                   chatId: message.Chat.Id,
                   text: "You Send Sticker Message",
                   cancellationToken: cancellationToken);
            return;
        }
        catch
        {
            Console.WriteLine("Err StickerMessage asyc");
            return;
        }
    }
    private async Task HandleTextMessageAsnyc(ITelegramBotClient client, Message message, CancellationToken cancellationToken)
    {
        try
        {

            if (message.Text == "/start")
            {
                await _userService.NolRuzumeCount(message.Chat.Id);
                await _userService.NolShogirtKerakCount(message.Chat.Id);
                await _userService.NolUstozKerakCount(message.Chat.Id);
                await _userService.NolSherikKerakCount(message.Chat.Id);
                await _userService.NolIshJoylashCount(message.Chat.Id);

                var msg = await client.SendTextMessageAsync(
         chatId: message.Chat.Id,
         text: $"\r\n<strong>Assalomu alaykum {message.From.FirstName} {message.From.LastName}, \"EFFECT | Katta mehnat bozori\" kanali uchun e'lon yaratuvchi botiga xush kelibsiz.</strong>\r\n\r\nEFFECT | Katta mehnat bozori - ish izlayotgan odamlarga vakansiyalarni, ish beruvchilarga esa ishchilarni topishda yordam beradi. Qolaversa bir qator boshqa yo'nalishlarni ham qollab quvvatlaydi.\r\r\n\n<strong>Yo'nalishlar:</strong>\r\n• \"🏢 Ish joylash\" - ishchi topish uchun.\r\n• \"\U0001f9d1🏻‍💼 Rezyume joylash\" - ish topish uchun.\r\n• \"\U0001f9d1🏻 Shogirt kerak\" - shogirt topish uchun.\r\n• \"\U0001f9d1🏻‍🏫 Ustoz kerak\" - ustoz topish uchun.\r\n• \"🎗 Sherik kerak\" - sherik topish uchun.\r\n\r\n<strong>E'lon berish uchun yo'nalishni tanlang 👇</strong>",
         replyMarkup: await InlineKeyBoards.ForMainState(),
         parseMode: ParseMode.Html,
         cancellationToken: cancellationToken);

                var user = await _userService.GetUser(message.Chat.Id);
                if (user == null)
                {
                    user = new UserModel()
                    {
                        ChatId = message.Chat.Id,
                        Username = message.From.Username,
                        Status = Status.MainPage
                    };
                    await _userService.CreateUser(user);
                }
                user.Messages.Clear();
                user.LastMessages = msg.MessageId;
                return;
            }


            else if (!string.IsNullOrWhiteSpace(message.Text.ToString()))
            {
                await HandleRandomTextAsync(client, message, cancellationToken);
            };
        }
        catch
        {
            return;
        }
    }
    public async Task HandleCallbackQueryAsync(ITelegramBotClient client, CallbackQuery callbackQuery, CancellationToken cancellationToken)
    {
        var myMessage = callbackQuery.Data switch
        {
            "ish_joylash" => HandleIshJoylashAsync(client, callbackQuery.Message, cancellationToken),
            "rezyume_joylash" => HandleRezumeJoylashAsync(client, callbackQuery.Message, cancellationToken),
            "shogirt_kerak" => HandleShogirtKerakAsync(client, callbackQuery.Message, cancellationToken),
            "ustoz_kerak" => HandleUstozkerakAsync(client, callbackQuery.Message, cancellationToken),
            "sherik_kerak" => HandleSherikKerakAsync(client, callbackQuery.Message, cancellationToken),
            "togrri" => TogriElonJoylashAsync(client, callbackQuery.Message, cancellationToken),
            "notogrri" => NotogriElonJoylashAsync(client, callbackQuery.Message, cancellationToken),
            "joyla" => SentToMainChanelAsync(client, callbackQuery.Message, cancellationToken),
            "skip" => SkipFromModeratorsAsync(client, callbackQuery.Message, cancellationToken),
            "noinfo" => NoAdditionalInfo(client, callbackQuery.Message, cancellationToken),
            "talabaekan" => TalabaEkan(client, callbackQuery.Message, cancellationToken),
            "talabaemas" => TalabaEmas(client, callbackQuery.Message, cancellationToken),
            "hatextcorrect" => HandleTextCorrectAsync(client, callbackQuery.Message, cancellationToken),
            "yoqtextincorrect" => NotogriElonJoylashAsync(client, callbackQuery.Message, cancellationToken),
        };

        try
        {
            await myMessage;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }


    #region Clears
    private async Task ClearMessageMethod(ITelegramBotClient botClient, Message message, CancellationToken cancellationToken)
    {
        if (message != null)
        {

            var user = await _userService.GetUser(message.Chat.Id);
            if (user == null)
            {
                await _userService.CreateUser(new UserModel()
                {
                    ChatId = message.Chat.Id,
                    Username = message.From.Username,
                });
            }
            user = await _userService.GetUser(message.Chat.Id);

            if (user.LastMessages != 0)
            {
                await HandleClearAllReplyKeysAsync(botClient, message, user, cancellationToken);
            }
        }
    }
    private async Task ClearUpdateMethod(ITelegramBotClient botClient, CallbackQuery callback, CancellationToken cancellationToken)
    {
        if (callback != null)
        {

            var user = await _userService.GetUser(callback.Message.Chat.Id);
            if (user == null)
            {
                await _userService.CreateUser(new UserModel()
                {
                    ChatId = callback.Message.Chat.Id,
                    Username = callback.From.Username,
                });
            }
            user = await _userService.GetUser(callback.Message.Chat.Id);

            if (user.LastMessages != 0)
            {
                await HandleClearAllReplyKeysAsync(botClient, callback.Message, user, cancellationToken);
            }
        }
    }
    private async Task HandleClearAllReplyKeysAsync(ITelegramBotClient client, Message message, UserModel user, CancellationToken cancellationToken)
    {

        await client.EditMessageReplyMarkupAsync(
            chatId: message.Chat.Id,
            messageId: user.LastMessages,
            replyMarkup: null,
            cancellationToken: cancellationToken);
        user.LastMessages = 0;
    }
    #endregion

    #region Checker

    public async Task HandleTextCorrectAsync(ITelegramBotClient _client, Message message, CancellationToken cancellation)
    {
        var msg = await _client.SendTextMessageAsync(
            chatId: message.Chat.Id,
            text: $"E'lonni joylash narxi: \"BEPUL 🕑\"\r\n\r\nℹ️ E'lon joylashtirilgandan so'ng, u moderatorlar tomonidan ko'rib chiqiladi. Zaruriyat tug'ilganda, ma'lumotlar to'g'riligini tekshirish maqsadida e'lon muallifi bilan bog'laniladi.\r\n\r\nTayyor e'lonni \"EFFECT | Katta mehnat bozori\" kanaliga joylash uchun \"✅ E'lonni joylash\" tugmasini bosing, bekor qilish uchun \"❌ Bekor qilish\" tugmasini bosing 👇",
            replyMarkup: await InlineKeyBoards.ForConfirmation(),
            parseMode: ParseMode.Html,
            cancellationToken: cancellation
            );

        var user = await _userService.GetUser(message.Chat.Id);
        if (user != null)
        {
            user.LastMessages = msg.MessageId;
        }

    }
    #endregion

    #region TalabaUchun
    private async Task TalabaEkan(ITelegramBotClient client, Message message, CancellationToken cancellationToken)
    {
        var user = await _userService.GetUser(message.Chat.Id);
        if (user == null)
        {
            throw new Exception();
        }
        if (user.Status == Status.RezumeJoylash)
        {
            await _userService.IncRezumeCount(message.Chat.Id);
            await HandleRezumeJoylashBotAsync(client, message, user, cancellationToken);
        }
        else if (user.Status == Status.UstozKerak)
        {
            await _userService.IncUstozKerak(message.Chat.Id);
            await HandleUstozKerakBotAsync(client, message, user, cancellationToken);
        }
        user.Messages.Add("Ha");
        return;
    }

    private async Task TalabaEmas(ITelegramBotClient client, Message message, CancellationToken cancellationToken)
    {
        var user = await _userService.GetUser(message.Chat.Id);
        if (user == null)
        {
            throw new Exception();
        }
        if (user.Status == Status.RezumeJoylash)
        {
            await _userService.IncRezumeCount(message.Chat.Id);
            await HandleRezumeJoylashBotAsync(client, message, user, cancellationToken);
        }
        else if (user.Status == Status.UstozKerak)
        {
            await _userService.IncUstozKerak(message.Chat.Id);
            await HandleUstozKerakBotAsync(client, message, user, cancellationToken);
        }
        user.Messages.Add("Yo'q");
        return;
    }
    #endregion

    #region ElonUchun
    private async Task TogriElonJoylashAsync(ITelegramBotClient client, Message message, CancellationToken cancellationToken)
    {
        await client.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: $@"<strong>✅ Sizning e'loningiz ""EFFECT | Katta mehnat bozori"" kanaliga joylashtirildi.</strong>

Bizning xizmatimizdan foydalanganingiz uchun hursandmiz, ishlaringizga rivoj tilaymiz ⭐️",
                        parseMode: ParseMode.Html,
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
        await client.SendTextMessageAsync(
           chatId: message.Chat.Id,
           text: "<strong>Yo'nalishlar:</strong>\r\n• \"🏢 Ish joylash\" - ishchi topish uchun.\r\n• \"\U0001f9d1🏻‍💼 Rezyume joylash\" - ish topish uchun.\r\n• \"\U0001f9d1🏻 Shogirt kerak\" - shogirt topish uchun.\r\n• \"\U0001f9d1🏻‍🏫 Ustoz kerak\" - ustoz topish uchun.\r\n• \"🎗 Sherik kerak\" - sherik topish uchun." +
                "\r\n\r\n<strong>Yangi e'lon berish uchun yo'nalishni tanlang 👇</strong>",
           replyMarkup: await InlineKeyBoards.ForMainState(),
           parseMode: ParseMode.Html,
           cancellationToken: cancellationToken);
        return;
    }
    private async Task NotogriElonJoylashAsync(ITelegramBotClient client, Message message, CancellationToken cancellationToken)
    {
        var msg = await client.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: "❌ E'lon qabul qilinmadi.",
                        cancellationToken: cancellationToken);

        var user = await _userService.GetUser(message.Chat.Id);
        if (user != null)
        {
            user.Messages.Clear();
            await _userService.NolRuzumeCount(message.Chat.Id);
            await _userService.NolIshJoylashCount(message.Chat.Id);
            await _userService.NolShogirtKerakCount(message.Chat.Id);
            await _userService.NolSherikKerakCount(message.Chat.Id);
            await _userService.NolUstozKerakCount(message.Chat.Id);
            await _userService.ChangeStatus(message.Chat.Id, Status.MainPage);

            user.LastMessages = msg.MessageId;
            await client.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: "<strong>Yo'nalishlar:</strong>\r\n• \"🏢 Ish joylash\" - ishchi topish uchun.\r\n• \"\U0001f9d1🏻‍💼 Rezyume joylash\" - ish topish uchun.\r\n• \"\U0001f9d1🏻 Shogirt kerak\" - shogirt topish uchun.\r\n• \"\U0001f9d1🏻‍🏫 Ustoz kerak\" - ustoz topish uchun.\r\n• \"🎗 Sherik kerak\" - sherik topish uchun." +
                "\r\n\r\n<strong>Yangi e'lon berish uchun yo'nalishni tanlang 👇</strong>",
                replyMarkup: await InlineKeyBoards.ForMainState(),
                parseMode: ParseMode.Html,
                cancellationToken: cancellationToken);
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
                chatId: MainChanel,
                text: @$"<strong>🧑🏻‍💼 REZYUME</strong>

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

<strong><a href='{LINK}'>🌐 ""EFFECT | Katta mehnat bozori"" kanaliga obuna bo'lish</a></strong>
•
<strong><a href='{BotLINK}'>⏺ ""EFFECT | Katta mehnat bozori"" kanaliga e'lon joylash</a></strong>",
                parseMode: ParseMode.Html,
                disableWebPagePreview: true,
                cancellationToken: cancellationToken);
            return;
        }
        else if (user.Status == Status.IshJoylash)
        {
            await client.SendTextMessageAsync(
chatId: MainChanel,
text: @$"
<strong>🏢 ISH</strong>

⭐️ Ish beruvchi: {user.Messages[0]} 
📋 Vakansiya nomi: {user.Messages[1]}
⏰ Ish vaqti: {user.Messages[2]}
💰 Ish haqi: {user.Messages[3]}
🌏 Manzil: {user.Messages[4]}

📑 Vakansiya haqida: {user.Messages[5]}

📞 Aloqa: {user.Messages[6]}
✉️ Telegram: @{user.Username}
🕰 Murojaat qilish vaqti: {user.Messages[7]}

📌 Qo'shimcha ma'lumotlar: {user.Messages[8]}

#Ish

<strong><a href='{LINK}'>🌐 ""EFFECT | Katta mehnat bozori"" kanaliga obuna bo'lish</a></strong>
•
<strong><a href='{BotLINK}'>⏺ ""EFFECT | Katta mehnat bozori"" kanaliga e'lon joylash</a></strong>
",
parseMode: ParseMode.Html,
disableWebPagePreview: true,
//replyMarkup: await InlineKeyBoards.ForSendToChanel(),
cancellationToken: cancellationToken);
            return;
        }
        else if (user.Status == Status.UstozKerak)
        {

            await client.SendTextMessageAsync(
                chatId: MainChanel,
                text: @$"
🧑🏻‍🏫 <strong>USTOZ KERAK</strong>

🧑🏻 Shogirt: {user.Messages[0]}
🗓 Tug'ilgan sana: {user.Messages[1]}
💠 Shogirtlik yo'nalishi: {user.Messages[2]}
🌏 Manzil: {user.Messages[3]}
💰 Ish haqi: {user.Messages[4]}

🧑‍🎓 Talaba: {user.Messages[5]}
📑 Shogirt haqida: {user.Messages[6]}

📞 Aloqa: {user.Messages[7]}
✉️ Telegram: @{user.Username}
🕰 Murojaat qilish vaqti: {user.Messages[8]}

📌 Qo'shimcha ma'lumotlar: {user.Messages[9]}

#UstozKerak

<strong><a href='{LINK}'>🌐 ""EFFECT | Katta mehnat bozori"" kanaliga obuna bo'lish</a></strong>
•
<strong><a href='{BotLINK}'>⏺ ""EFFECT | Katta mehnat bozori"" kanaliga e'lon joylash</a></strong>",
                parseMode: ParseMode.Html,
                disableWebPagePreview: true,
                cancellationToken: cancellationToken);


            return;
        }
        else if (user.Status == Status.SherikKerak)
        {
            await client.SendTextMessageAsync(
                   chatId: MainChanel,
                   text: @$"
🎗 <strong>SHERIK KERAK</strong>

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

<strong><a href='{LINK}'>🌐 ""EFFECT | Katta mehnat bozori"" kanaliga obuna bo'lish</a></strong>
•
<strong><a href='{BotLINK}'>⏺ ""EFFECT | Katta mehnat bozori"" kanaliga e'lon joylash</a></strong>",
                   parseMode: ParseMode.Html,
                   disableWebPagePreview: true,
                   //replyMarkup: await InlineKeyBoards.ForSendToChanel(),
                   cancellationToken: cancellationToken);
            return;
        }
        else if (user.Status == Status.ShogirtKerak)
        {
            await client.SendTextMessageAsync(
                chatId: MainChanel,
                text: @$"
🧑🏻 <strong>SHOGIRT KERAK</strong>

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

<strong><a href='{LINK}'>🌐 ""EFFECT | Katta mehnat bozori"" kanaliga obuna bo'lish</a></strong>
•
<strong><a href='{BotLINK}'>⏺ ""EFFECT | Katta mehnat bozori"" kanaliga e'lon joylash</a></strong>",
                parseMode: ParseMode.Html,
                disableWebPagePreview: true,
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