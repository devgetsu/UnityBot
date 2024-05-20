using Telegram.Bot.Types;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using UnityBot.Bot.Models.Entities;
using UnityBot.Bot.Services.ReplyKeyboards;
using Telegram.Bot.Types.ReplyMarkups;
using UnityBot.Bot.Models.Enums;

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
                await _userService.CreateUser(user);
            }
            await _userService.ChangeStatus(message.Chat.Id, Models.Enums.Status.RezumeJoylash);


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

            await client.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: "⭐️ Ish beruvchi: (100 element)\r\nTashkilot nomini kiriting. Tashkilot bo'lmasa ish beruvchining Ism Familiyasini yozing.",
                replyMarkup: new ReplyKeyboardRemove(),
                cancellationToken: cancellationToken);
        }

        private async Task HandleRandomTextAsync(ITelegramBotClient client, Message message, CancellationToken cancellationToken)
        {
            var user = await _userService.GetUser(message.Chat.Id);

            if (user == null)
            {
                user = new UserModel()
                {
                    ChatId = message.Chat.Id,
                    Username = message.From.Username,
                    Status = Models.Enums.Status.MainPage
                };
                await _userService.CreateUser(user);
            }

            if (user.Status == Status.IshJoylash)
            {
                await _userService.IncIshJoylashCount(message.Chat.Id);
                await HandleIshJoylashBotAsync(client, message, user, cancellationToken);
            }
            else if (user.Status == Status.UstozKerak)
            {
                await _userService.IncUstozKerak(message.Chat.Id);
            }
            else if (user.Status == Status.SherikKerak)
            {
                await _userService.IncSherikKerak(message.Chat.Id);
            }
            else if (user.Status == Status.ShogirtKerak)
            {
                await _userService.IncShogirtKerakCount(message.Chat.Id);
            }
            else if (user.Status == Status.RezumeJoylash)
            {
                await _userService.IncRezumeCount(message.Chat.Id);
            }
            else if (user.Status == Status.MainPage)
            {
                await client.SendTextMessageAsync(
                    chatId: message.Chat.Id,
                    text: "Xush kelibsiz!");
                await HandleTextMessageAsnyc(client, message, cancellationToken);
            }

        }
        private async Task HandleIshJoylashBotAsync(ITelegramBotClient client, Message message, UserModel user, CancellationToken cancellationToken)
        {
            if (user.IshJoylashCount == 1)
            {
                user.IshJoylashModel.IshBeruvchi = message.Text.ToString();

                await client.SendTextMessageAsync(
                  chatId: message.Chat.Id,
                  text: "📋 Vakansiya nomi: (300 element)\r\nVakansiya nomini kiriting.",
                  cancellationToken: cancellationToken);

                return;
            }

            if (user.IshJoylashCount == 2)
            {

                user.IshJoylashModel.VakansiyaNomi = message.Text;
                await client.SendTextMessageAsync(
                  chatId: message.Chat.Id,
                  text: "💰Ish haqi: (100 element)\r\nIsh haqi miqdori, valyutasi va davriyligini kiriting",
                  cancellationToken: cancellationToken);
                return;

            }

            if (user.IshJoylashCount == 3)
            {
                user.IshJoylashModel.IshHaqi = message.Text;

                await client.SendTextMessageAsync(
                  chatId: message.Chat.Id,
                  text: "🌏Manzil: (500 element)\r\nIsh joyi manzilini kiriting. ",
                  cancellationToken: cancellationToken);
                return;

            }

            if (user.IshJoylashCount == 4)
            {
                user.IshJoylashModel.Location = message.Text;

                await client.SendTextMessageAsync(
                  chatId: message.Chat.Id,
                  text: "📑Vakansiya haqida: ",
                  cancellationToken: cancellationToken);
                return;

            }

            if (user.IshJoylashCount == 5)
            {

                user.IshJoylashModel.VahansiyaHaqida = message.Text;
                await client.SendTextMessageAsync(
                  chatId: message.Chat.Id,
                  text: "📞Aloqa: ",
                  cancellationToken: cancellationToken);
                return;

            }

            if (user.IshJoylashCount == 6)
            {

                user.IshJoylashModel.Aloqa = message.Text;

                await client.SendTextMessageAsync(
                  chatId: message.Chat.Id,
                  text: "📌 Qo'shimcha ma'lumotlar: ",
                  cancellationToken: cancellationToken);

                return;

            }
            if (user.IshJoylashCount == 7)
            {
                user.IshJoylashModel.Qoshimcha = message.Text;
                await client.SendTextMessageAsync(
                    chatId:message.Chat.Id,
                    text: @$"4. ISH JOYLASH (poster)

🏢 ISH

⭐️ Ish beruvchi: 
📋 Vakansiya nomi: {user.IshJoylashModel.VakansiyaNomi}
💰 Ish haqi: {user.IshJoylashModel.IshHaqi}
🌏 Manzil: {user.IshJoylashModel.Location}

📑 Vakansiya haqida: {user.IshJoylashModel.VahansiyaHaqida}

📞 Aloqa: .{user.IshJoylashModel.Aloqa}
✉️ Telegram: {user.Username}
🕰 Murojaat qilish vaqti: {user.IshJoylashModel.MurojaatVaqti}

📌 Qo'shimcha ma'lumotlar: {user.IshJoylashModel.Qoshimcha}

#Ish

🌐 ""-a href=""google.com"" Google EFFECT | Katta mehnat bozori/a"" kanaliga obuna bo'lish (link | so'zni ichida bo'lishi kerak)");
                await client.SendTextMessageAsync(
                    chatId: message.Chat.Id,
                    text: "Barcha ma'lumotlar to'g'rimi?",
                    replyMarkup: await ReplyKeyboardMarkups.ForConfirmation(),
                    parseMode:ParseMode.Html,
                    cancellationToken: cancellationToken);
                return;
            }
            if (user.IshJoylashCount == 8)
            {

                if (message.Text == "✅ To'g'ri")
                {
                    await client.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: @"E'lonni joylash narxi: ""BEPUL 🕑""

ℹ️ E'lon joylashtirilgandan so'ng, u moderatorlar tomonidan ko'rib chiqiladi. Zaruriyat tug'ilganda, ma'lumotlar to'g'riligini tekshirish maqsadida e'lon muallifi bilan bog'laniladi.

Tayyor e'lonni ""EFFECT | Katta mehnat bozori"" @palonchi kanaliga joylash uchun ""E'lonni joylash"" tugmasini bosing, bekor qilish uchun ""Bekor qilish"" tugmasini bosing 👇",
                        replyMarkup: new ReplyKeyboardRemove(),
                        cancellationToken: cancellationToken);
                    await _userService.ChangeStatus(message.Chat.Id, Status.MainPage);
                }
                else if (message.Text == "❌ Noto'g'ri")
                {
                    await client.SendTextMessageAsync(
                      chatId: message.Chat.Id,
                      text: "❌ E'lon qabul qilinmadi.",
                      replyMarkup: new ReplyKeyboardRemove(),
                      cancellationToken: cancellationToken);

                    await _userService.ChangeStatus(message.Chat.Id, Status.MainPage);
                }
                await _userService.NolIshJoylashCount(message.Chat.Id);
                return;
            }
        }
    }
}
