using Telegram.Bot.Types;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using UnityBot.Bot.Models.Entities;

namespace UnityBot.Bot.Services.Handlers
{
    public partial class BotUpdateHandler
    {
        private async Task HandleSherikKerakAsync(ITelegramBotClient client, Message message, CancellationToken cancellationToken)
        {
            if (_userService.GetUser(message.Chat.Id) == null)
            {
                var user = new UserModel()
                {
                    ChatId = message.Chat.Id,
                    Username = message.From.Username,
                    Status = Models.Enums.Status.MainPage
                };
                _userService.CreateUser(user);
            }
            _userService.ChangeStatus(message.Chat.Id, Models.Enums.Status.SherikKerak);



            await client.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: "Bu sherik uchun",
                cancellationToken: cancellationToken);
        }

        private async Task HandleUstozkerakAsync(ITelegramBotClient client, Message message, CancellationToken cancellationToken)
        {
            if (_userService.GetUser(message.Chat.Id) == null)
            {
                var user = new UserModel()
                {
                    ChatId = message.Chat.Id,
                    Username = message.From.Username,
                    Status = Models.Enums.Status.MainPage
                };
                _userService.CreateUser(user);
            }
            _userService.ChangeStatus(message.Chat.Id, Models.Enums.Status.UstozKerak);



            await client.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: "Bu ustoz uchun",
                cancellationToken: cancellationToken);
        }

        private async Task HandleRezumeJoylashAsync(ITelegramBotClient client, Message message, CancellationToken cancellationToken)
        {
            if (_userService.GetUser(message.Chat.Id) == null)
            {
                var user = new UserModel()
                {
                    ChatId = message.Chat.Id,
                    Username = message.From.Username,
                    Status = Models.Enums.Status.MainPage
                };
                _userService.CreateUser(user);
            }
            _userService.ChangeStatus(message.Chat.Id, Models.Enums.Status.RezumeJoylash);


            await client.SendTextMessageAsync(
                       chatId: message.Chat.Id,
                       text: "Bu rezume joylash uchun",
                       cancellationToken: cancellationToken);
        }

        private async Task HandleShogirtKerakAsync(ITelegramBotClient client, Message message, CancellationToken cancellationToken)
        {
            if (_userService.GetUser(message.Chat.Id) == null)
            {
                var user = new UserModel()
                {
                    ChatId = message.Chat.Id,
                    Username = message.From.Username,
                    Status = Models.Enums.Status.MainPage
                };
                _userService.CreateUser(user);
            }
            _userService.ChangeStatus(message.Chat.Id, Models.Enums.Status.ShogirtKerak);


            await client.SendTextMessageAsync(
                       chatId: message.Chat.Id,
                       text: "Bu shogirt uchun",
                       cancellationToken: cancellationToken);
        }

        private async Task HandleIshJoylashAsync(ITelegramBotClient client, Message message, CancellationToken cancellationToken)
        {

            var user = await _userService.GetUser(message.Chat.Id);

            if (user == null)
            {
                user = new UserModel
                {
                    ChatId = message.Chat.Id,
                    Username = message.From.Username,
                    Status = Models.Enums.Status.IshJoylash
                };

                await _userService.CreateUser(user);
            }

            await _userService.ChangeStatus(message.Chat.Id, Models.Enums.Status.IshJoylash);


            await client.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: @"Ish joylashtirish uchun bir nechta savollarga javob bering. Har bir javobingiz to'g'ri va ishonchli ma'lumotlardan iborat bo'lishi kerak ekanligiga e'tiborli bo'ling.

So'rovnoma yakunida, agarda kiritilgan barcha ma'lumotlar to'g'ri bo'lsa ""✅ To'g'ri"" tugmasini bosing, aksincha bo'lsa ""❌ Noto'g'ri"" tugmasini bosing va so'rovnomani qaytadan to'ldiring.

1 VARIANT - E'lon tayor bo'lgandan kegin ""To'lov"" qadamiga o'tasiz. To'lov amalga oshirilgach e'lon o'sha zaxotiyoq ""EFFECT | Katta mehnat bozori"" @palonchi kanaliga joylashtiriladi.
|
2 VARIANT - E'lon tayor bo'lgandan kegin ""E'lonni joylash"" tugmasi bosilsa e'lon o'sha zaxotiyoq ""EFFECT | Katta mehnat bozori"" @palonchi kanaliga joylashtiriladi.",
                parseMode: ParseMode.Html,
                cancellationToken: cancellationToken);

        }
    }
}
