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
                await _userService.CreateUser(user);
            }
            await _userService.ChangeStatus(message.Chat.Id, Models.Enums.Status.SherikKerak);

            await client.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: "🎗 SHERIK KERAK\r\n\r\nSherik kerakligi haqida e'lon joylashtirish uchun bir nechta savollarga javob bering. Har bir javobingiz to'g'ri va ishonchli ma'lumotlardan iborat bo'lishi kerak ekanligiga e'tiborli bo'ling.\r\n\r\nSo'rovnoma yakunida, agarda kiritilgan barcha ma'lumotlar to'g'ri bo'lsa \"✅ To'g'ri\" tugmasini bosing, aksincha bo'lsa \"❌ Noto'g'ri\" tugmasini bosing va so'rovnomani qaytadan to'ldiring.\r\n\r\n1 VARIANT - E'lon tayor bo'lgandan kegin \"To'lov\" qadamiga o'tasiz. To'lov amalga oshirilgach e'lon o'sha zaxotiyoq \"EFFECT | Katta mehnat bozori\" @palonchi kanaliga joylashtiriladi.\r\n|\r\n2 VARIANT - E'lon tayor bo'lgandan kegin \"E'lonni joylash\" tugmasi bosilsa e'lon o'sha zaxotiyoq \"EFFECT | Katta mehnat bozori\" @palonchi kanaliga joylashtiriladi.",
                cancellationToken: cancellationToken);

            await client.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: "\r\n⭐️ Sherik: (100 element)\r\nSherikning Ism Familiyasini yozing.",
                replyMarkup: new ReplyKeyboardRemove(),
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
                       text: @"🧑🏻‍🏫 USTOZ KERAK

Ustoz kerakligi haqida e'lon joylashtirish uchun bir nechta savollarga javob bering. Har bir javobingiz to'g'ri va ishonchli ma'lumotlardan iborat bo'lishi kerak ekanligiga e'tiborli bo'ling.

So'rovnoma yakunida, agarda kiritilgan barcha ma'lumotlar to'g'ri bo'lsa ""✅ To'g'ri"" tugmasini bosing, aksincha bo'lsa ""❌ Noto'g'ri"" tugmasini bosing va so'rovnomani qaytadan to'ldiring.

1 VARIANT - E'lon tayor bo'lgandan kegin ""To'lov"" qadamiga o'tasiz. To'lov amalga oshirilgach e'lon o'sha zaxotiyoq ""EFFECT | Katta mehnat bozori"" @palonchi kanaliga joylashtiriladi.
|
2 VARIANT - E'lon tayor bo'lgandan kegin ""E'lonni joylash"" tugmasi bosilsa e'lon o'sha zaxotiyoq ""EFFECT | Katta mehnat bozori"" @palonchi kanaliga joylashtiriladi.",
                       cancellationToken: cancellationToken);

            await client.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: "\U0001f9d1🏻 Shogirt: (100 element)\r\nShogirtning Ism Familiyasini kiriting.",
                replyMarkup: new ReplyKeyboardRemove(),
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
                       text: "\U0001f9d1🏻‍💼 REZYUME\r\n\r\nRezyume joylashtirish uchun bir nechta savollarga javob bering. Har bir javobingiz to'g'ri va ishonchli ma'lumotlardan iborat bo'lishi kerak ekanligiga e'tiborli bo'ling.\r\n\r\nSo'rovnoma yakunida, agarda kiritilgan barcha ma'lumotlar to'g'ri bo'lsa \"✅ To'g'ri\" tugmasini bosing, aksincha bo'lsa \"❌ Noto'g'ri\" tugmasini bosing va so'rovnomani qaytadan to'ldiring.\r\n\r\n1 VARIANT - E'lon tayor bo'lgandan kegin \"To'lov\" qadamiga o'tasiz. To'lov amalga oshirilgach e'lon o'sha zaxotiyoq \"EFFECT | Katta mehnat bozori\" @palonchi kanaliga joylashtiriladi.\r\n|\r\n2 VARIANT - E'lon tayor bo'lgandan kegin \"E'lonni joylash\" tugmasi bosilsa e'lon o'sha zaxotiyoq \"EFFECT | Katta mehnat bozori\" @palonchi kanaliga joylashtiriladi.",
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
                       text: @"🧑🏻 SHOGIRT KERAK

Shogirt kerakligi haqida e'lon joylashtirish uchun bir nechta savollarga javob bering. Har bir javobingiz to'g'ri va ishonchli ma'lumotlardan iborat bo'lishi kerak ekanligiga e'tiborli bo'ling.

So'rovnoma yakunida, agarda kiritilgan barcha ma'lumotlar to'g'ri bo'lsa ""✅ To'g'ri"" tugmasini bosing, aksincha bo'lsa ""❌ Noto'g'ri"" tugmasini bosing va so'rovnomani qaytadan to'ldiring.

1 VARIANT - E'lon tayor bo'lgandan kegin ""To'lov"" qadamiga o'tasiz. To'lov amalga oshirilgach e'lon o'sha zaxotiyoq ""EFFECT | Katta mehnat bozori"" @palonchi kanaliga joylashtiriladi.
|
2 VARIANT - E'lon tayor bo'lgandan kegin ""E'lonni joylash"" tugmasi bosilsa e'lon o'sha zaxotiyoq ""EFFECT | Katta mehnat bozori"" @palonchi kanaliga joylashtiriladi.",
                       cancellationToken: cancellationToken);

            await client.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: "\U0001f9d1🏻‍🏫 Ustoz: (100 element)\r\nUstozning Ism Familiyasini yozing.",
                replyMarkup: new ReplyKeyboardRemove(),
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

            switch (user.Status)
            {
                case Status.IshJoylash:
                    await HandleIshJoylashBotAsync(client, message, user, cancellationToken);
                    break;

                case Status.UstozKerak:
                    await _userService.IncUstozKerak(message.Chat.Id);
                    await HandleUstozKerakBotAsync(client, message, user, cancellationToken);
                    break;

                case Status.SherikKerak:
                    await HandleSherikKerakBotAsync(client, message, user, cancellationToken);
                    break;

                case Status.ShogirtKerak:
                    await _userService.IncShogirtKerakCount(message.Chat.Id);
                    await HandleShogirtKerakBotAsync(client, message, user, cancellationToken);
                    break;

                case Status.RezumeJoylash:
                    await _userService.IncRezumeCount(message.Chat.Id);
                    await HandleShogirtKerakBotAsync(client, message, user, cancellationToken);
                    break;

                case Status.MainPage:
                    await client.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: "Yo'nalishlar:\r\n• \"🏢 Ish joylash\" - ishchi topish uchun.\r\n• \"\U0001f9d1🏻‍💼 Rezyume joylash\" - ish topish uchun.\r\n• \"\U0001f9d1🏻 Shogirt kerak\" - shogirt topish uchun.\r\n• \"\U0001f9d1🏻‍🏫 Ustoz kerak\" - ustoz topish uchun.\r\n• \"🎗 Sherik kerak\" - sherik topish uchun.",
                        replyMarkup: await ReplyKeyboardMarkups.ForMainState(),
                        cancellationToken: cancellationToken);
                    break;

                default:
                    // Handle unknown status if necessary
                    break;
            }
        }


        private async Task HandleIshJoylashBotAsync(ITelegramBotClient client, Message message, UserModel user, CancellationToken cancellationToken)
        {
            switch (user.IshJoylashCount)
            {
                case 0:
                    user.IshJoylashModel.IshBeruvchi = message.Text;
                    await _userService.IncIshJoylashCount(message.Chat.Id);
                    goto case 1;

                case 1:
                    user.IshJoylashModel.VakansiyaNomi = message.Text;
                    await client.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: "📋 Vakansiya nomi: (300 element)\r\nVakansiya nomini kiriting.",
                        cancellationToken: cancellationToken);
                    await _userService.IncIshJoylashCount(message.Chat.Id);
                    return;

                case 2:
                    user.IshJoylashModel.VakansiyaNomi = message.Text;
                    await client.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: "💰Ish haqi: (100 element)\r\nIsh haqi miqdori, valyutasi va davriyligini kiriting",
                        cancellationToken: cancellationToken);
                    await _userService.IncIshJoylashCount(message.Chat.Id);
                    return;

                case 3:
                    user.IshJoylashModel.IshHaqi = message.Text;
                    await client.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: "🌏Manzil: (500 element)\r\nIsh joyi manzilini kiriting.",
                        cancellationToken: cancellationToken);
                    await _userService.IncIshJoylashCount(message.Chat.Id);
                    return;

                case 4:
                    user.IshJoylashModel.Location = message.Text;
                    await client.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: "📑Vakansiya haqida:",
                        cancellationToken: cancellationToken);
                    await _userService.IncIshJoylashCount(message.Chat.Id);
                    return;

                case 5:
                    user.IshJoylashModel.VahansiyaHaqida = message.Text;
                    await client.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: "📞Aloqa:",
                        cancellationToken: cancellationToken);
                    await _userService.IncIshJoylashCount(message.Chat.Id);
                    return;

                case 6:
                    user.IshJoylashModel.Aloqa = message.Text;
                    await client.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: "🕰 Murojaat qilish vaqti: (100 element)\r\nMurojaat qilish mumkin bo'lgan vaqtlarni kiriting.",
                        cancellationToken: cancellationToken);
                    await _userService.IncIshJoylashCount(message.Chat.Id);
                    return;

                case 7:
                    user.IshJoylashModel.MurojaatVaqti = message.Text;
                    await client.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: "📌 Qo'shimcha ma'lumotlar:",
                        cancellationToken: cancellationToken);
                    await _userService.IncIshJoylashCount(message.Chat.Id);
                    return;

                case 8:
                    user.IshJoylashModel.Qoshimcha = message.Text;
                    await client.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: @$"4. ISH JOYLASH (poster)

🏢 ISH

⭐️ Ish beruvchi: {user.IshJoylashModel.IshBeruvchi} 
📋 Vakansiya nomi: {user.IshJoylashModel.VakansiyaNomi}
💰 Ish haqi: {user.IshJoylashModel.IshHaqi}
🌏 Manzil: {user.IshJoylashModel.Location}

📑 Vakansiya haqida: {user.IshJoylashModel.VahansiyaHaqida}

📞 Aloqa: {user.IshJoylashModel.Aloqa}
✉️ Telegram: @{user.Username}
🕰 Murojaat qilish vaqti: {user.IshJoylashModel.MurojaatVaqti}

📌 Qo'shimcha ma'lumotlar: {user.IshJoylashModel.Qoshimcha}

#Ish

🌐 ""EFFECT | Katta mehnat bozori"" kanaliga obuna bo'lish (link | so'zni ichida bo'lishi kerak)");
                    await client.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: "Barcha ma'lumotlar to'g'rimi?",
                        replyMarkup: await ReplyKeyboardMarkups.ForConfirmation(),
                        parseMode: ParseMode.Html,
                        cancellationToken: cancellationToken);
                    await _userService.IncIshJoylashCount(message.Chat.Id);
                    return;

                case 9:
                    if (message.Text == "✅ To'g'ri")
                    {
                        await client.SendTextMessageAsync(
                            chatId: message.Chat.Id,
                            text: @"E'lonni joylash narxi: ""BEPUL 🕑""

ℹ️ E'lon joylashtirilgandan so'ng, u moderatorlar tomonidan ko'rib chiqiladi. Zaruriyat tug'ilganda, ma'lumotlar to'g'riligini tekshirish maqsadida e'lon muallifi bilan bog'laniladi.

Tayyor e'lonni ""EFFECT | Katta mehnat bozori"" @palonchi kanaliga joylash uchun ""E'lonni joylash"" tugmasini bosing, bekor qilish uchun ""Bekor qilish"" tugmasini bosing 👇",
                            replyMarkup: await ReplyKeyboardMarkups.ForMainState(),
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


        private async Task HandleSherikKerakBotAsync(ITelegramBotClient client, Message message, UserModel user, CancellationToken cancellationToken)
        {
            switch (user.SherikKerakCount)
            {
                case 0:
                    user.SherikKerakModel.Sherik = message.Text;
                    await _userService.IncSherikKerak(message.Chat.Id);
                    goto case 1;
                case 1:
                    user.SherikKerakModel.SherikLikYonalishi = message.Text;
                    await client.SendTextMessageAsync(
                       chatId: message.Chat.Id,
                       text: "📋 Sheriklik yo'nalishi: (300 element)\r\nQanday yo'nalish bo'yicha sherik qidirilayotgan bo'lsa, shu yo'nalishni kiriting",
                       cancellationToken: cancellationToken);
                    await _userService.IncSherikKerak(message.Chat.Id);
                    return;
                case 2:
                    user.SherikKerakModel.SherikLikYonalishi = message.Text;
                    await client.SendTextMessageAsync(
                       chatId: message.Chat.Id,
                       text: "💰 Hisob-kitob: (100 element)\r\nHisob-kitob alohida muzokara qilinsa \"Alohida muzokara qilinadi\" deb yozing. Hisob-kitob e'lon qilinsa ma'lumotlarini kiriting.",
                       cancellationToken: cancellationToken);
                    await _userService.IncSherikKerak(message.Chat.Id);
                    return;
                case 3:
                    user.SherikKerakModel.HisobKitob = message.Text;
                    await client.SendTextMessageAsync(
                       chatId: message.Chat.Id,
                       text: "🌏Manzil: (500 element)\r\nQaysi manzil bo'yicha sherik qidirilayotgan bo'lsa, shu manzilni kiriting.",
                       cancellationToken: cancellationToken);
                    await _userService.IncSherikKerak(message.Chat.Id);
                    return;
                case 4:
                    user.SherikKerakModel.Manzil = message.Text;
                    await client.SendTextMessageAsync(
                       chatId: message.Chat.Id,
                       text: "📑Sheriklik haqida: (500 element)\r\nSheriklik haqida qisqacha ma'lumot bering. Misol uchun, nimalar qilinishi haqida yozing.",
                       cancellationToken: cancellationToken);
                    await _userService.IncSherikKerak(message.Chat.Id);
                    return;
                case 5:
                    user.SherikKerakModel.SheriklikHaqida = message.Text;
                    await client.SendTextMessageAsync(
                       chatId: message.Chat.Id,
                       text: "📞 Aloqa: (100 element)\r\nBog'lanish uchun telefon raqam yoki elektron pochta manzilini kiriting.",
                       cancellationToken: cancellationToken);
                    await _userService.IncSherikKerak(message.Chat.Id);
                    return;
                case 6:
                    user.SherikKerakModel.Aloqa = message.Text;
                    await client.SendTextMessageAsync(
                       chatId: message.Chat.Id,
                       text: "🕰 Murojaat qilish vaqti: (100 element)\r\nMurojaat qilish mumkin bo'lgan vaqtlarni kiriting. ",
                       cancellationToken: cancellationToken);
                    await _userService.IncSherikKerak(message.Chat.Id);
                    return;
                case 7:
                    user.SherikKerakModel.MurojaatQilishVaqti = message.Text;
                    await client.SendTextMessageAsync(
                       chatId: message.Chat.Id,
                       text: "📌Qo'shimcha ma'lumotlar: (500 element)",
                       cancellationToken: cancellationToken);
                    await _userService.IncSherikKerak(message.Chat.Id);
                    return;
                case 8:
                    user.SherikKerakModel.QoshimchaMalumotlar = message.Text;
                    await client.SendTextMessageAsync(
                       chatId: message.Chat.Id,
                       text: @$" SHERIK KERAK (poster)

🎗 SHERIK KERAK

⭐️ Sherik: {user.SherikKerakModel.Sherik}
📋 Sheriklik yo'nalishi: {user.SherikKerakModel.SherikLikYonalishi}
💰 Hisob-kitob: {user.SherikKerakModel.HisobKitob}
🌏 Manzil: {user.SherikKerakModel.Manzil}

📑 Sheriklik haqida: {user.SherikKerakModel.SheriklikHaqida}

📞 Aloqa: {user.SherikKerakModel.Aloqa}
✉️ Telegram: @{user.Username}
🕰 Murojaat qilish vaqti: {user.SherikKerakModel.MurojaatQilishVaqti}

📌 Qo'shimcha ma'lumotlar: {user.SherikKerakModel.QoshimchaMalumotlar}
#SherikKerak

🌐 ""EFFECT | Katta mehnat bozori"" kanalga obuna bo'lish (link | so'zni ichida bo'lishi kerak)",
                       cancellationToken: cancellationToken);
                    await _userService.IncSherikKerak(message.Chat.Id);
                    await client.SendTextMessageAsync(
                           chatId: message.Chat.Id,
                           text: "Barcha ma'lumotlar to'g'rimi?",
                           replyMarkup: await ReplyKeyboardMarkups.ForConfirmation(),
                           parseMode: ParseMode.Html,
                           cancellationToken: cancellationToken);
                    await _userService.IncIshJoylashCount(message.Chat.Id);
                    return;

                case 9:
                    if (message.Text == "✅ To'g'ri")
                    {
                        await client.SendTextMessageAsync(
                            chatId: message.Chat.Id,
                            text: @"E'lonni joylash narxi: ""BEPUL 🕑""

ℹ️ E'lon joylashtirilgandan so'ng, u moderatorlar tomonidan ko'rib chiqiladi. Zaruriyat tug'ilganda, ma'lumotlar to'g'riligini tekshirish maqsadida e'lon muallifi bilan bog'laniladi.

Tayyor e'lonni ""EFFECT | Katta mehnat bozori"" @palonchi kanaliga joylash uchun ""E'lonni joylash"" tugmasini bosing, bekor qilish uchun ""Bekor qilish"" tugmasini bosing 👇",
                            replyMarkup: await ReplyKeyboardMarkups.ForMainState(),
                            cancellationToken: cancellationToken);
                    }
                    else if (message.Text == "❌ Noto'g'ri")
                    {
                        await client.SendTextMessageAsync(
                            chatId: message.Chat.Id,
                            text: "❌ E'lon qabul qilinmadi.",
                            replyMarkup: await ReplyKeyboardMarkups.ForMainState(),
                            cancellationToken: cancellationToken);
                    }
                    await _userService.ChangeStatus(message.Chat.Id, Status.MainPage);
                    await _userService.NolIshJoylashCount(message.Chat.Id);
                    return;
            }
        }
        private async Task HandleShogirtKerakBotAsync(ITelegramBotClient client, Message message, UserModel user, CancellationToken cancellationToken)
        {
            if (user.ShogirtKerakCount == 1)
            {
                user.Messages.Add(message.Text!.ToString());

                await client.SendTextMessageAsync(
                  chatId: message.Chat.Id,
                  text: "📋 Ustozlik yo'nalishi: (300 element)\r\nQanday yo'nalish bo'yicha shogirt olinsa, shu yo'nalishni kiriting.",
                  cancellationToken: cancellationToken);

                return;
            }

            if (user.ShogirtKerakCount == 2)
            {
                user.Messages.Add(message.Text!.ToString());

                await client.SendTextMessageAsync(
                  chatId: message.Chat.Id,
                  text: "💰 Ish haqi: (100 element)\r\nIsh haqi yo'q bo'lsa \"Yo'q\" deb yozing. Ish haqi bor bo'lsa miqdori, valyutasi va davriyligini kiriting.",
                  cancellationToken: cancellationToken);
                return;

            }

            if (user.ShogirtKerakCount == 3)
            {
                user.Messages.Add(message.Text!.ToString());

                await client.SendTextMessageAsync(
                  chatId: message.Chat.Id,
                  text: "🌏 Manzil: (500 element)\r\nFaoliyat yuritish manzilini kiriting.",
                  cancellationToken: cancellationToken);
                return;

            }

            if (user.ShogirtKerakCount == 4)
            {
                user.Messages.Add(message.Text!.ToString());

                await client.SendTextMessageAsync(
                  chatId: message.Chat.Id,
                  text: "📑 Ustozlik haqida: (500 element)\r\nUstozlik haqida qisqacha ma'lumot bering.",
                  cancellationToken: cancellationToken);
                return;

            }

            if (user.ShogirtKerakCount == 5)
            {

                user.Messages.Add(message.Text!.ToString());

                await client.SendTextMessageAsync(
                  chatId: message.Chat.Id,
                  text: "📞 Aloqa: (100 element)\r\nBog'lanish uchun telefon raqam yoki elektron pochta manzilini kiriting.",
                  cancellationToken: cancellationToken);
                return;

            }

            if (user.ShogirtKerakCount == 6)
            {

                user.Messages.Add(message.Text!.ToString());

                await client.SendTextMessageAsync(
                  chatId: message.Chat.Id,
                  text: "🕰 Murojaat qilish vaqti: (100 element)\r\nMurojaat qilish mumkin bo'lgan vaqtlarni kiriting.",
                  cancellationToken: cancellationToken);

                return;

            }

            if (user.ShogirtKerakCount == 7)
            {

                user.Messages.Add(message.Text!.ToString());

                await client.SendTextMessageAsync(
                  chatId: message.Chat.Id,
                  text: "📌 Qo'shimcha ma'lumotlar: (500 element)\r\nQoshimcha ma'lumotlarni kiriting.",
                  cancellationToken: cancellationToken);

                return;

            }
            if (user.ShogirtKerakCount == 8)
            {
                user.Messages.Add(message.Text!.ToString());

                await client.SendTextMessageAsync(
                    chatId: message.Chat.Id,
                    text: @$"22. SHOGIRT KERAK (poster)

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

🌐 ""EFFECT | Katta mehnat bozori"" kanalga obuna bo'lish (link | so'zni ichida bo'lishi kerak)");

                await client.SendTextMessageAsync(
                    chatId: message.Chat.Id,
                    text: "Barcha ma'lumotlar to'g'rimi?",
                    replyMarkup: await ReplyKeyboardMarkups.ForConfirmation(),
                    parseMode: ParseMode.Html,
                    cancellationToken: cancellationToken);
                return;
            }
            if (user.ShogirtKerakCount == 9)
            {

                if (message.Text == "✅ To'g'ri")
                {
                    await client.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: @"E'lonni joylash narxi: ""BEPUL 🕑""

ℹ️ E'lon joylashtirilgandan so'ng, u moderatorlar tomonidan ko'rib chiqiladi. Zaruriyat tug'ilganda, ma'lumotlar to'g'riligini tekshirish maqsadida e'lon muallifi bilan bog'laniladi.

Tayyor e'lonni ""EFFECT | Katta mehnat bozori"" @palonchi kanaliga joylash uchun ""E'lonni joylash"" tugmasini bosing, bekor qilish uchun ""Bekor qilish"" tugmasini bosing 👇",
                        replyMarkup: await ReplyKeyboardMarkups.ForMainState(),
                        cancellationToken: cancellationToken);
                    await _userService.ChangeStatus(message.Chat.Id, Status.MainPage);
                }
                else if (message.Text == "❌ Noto'g'ri")
                {
                    await client.SendTextMessageAsync(
                      chatId: message.Chat.Id,
                      text: "❌ E'lon qabul qilinmadi.",
                      replyMarkup: await ReplyKeyboardMarkups.ForMainState(),
                      cancellationToken: cancellationToken);

                    await _userService.ChangeStatus(message.Chat.Id, Status.MainPage);
                }
                user.Messages.Clear();
                await _userService.NolShogirtKerakCount(message.Chat.Id);
                return;
            }
        }

        private async Task HandleUstozKerakBotAsync(ITelegramBotClient client, Message message, UserModel user, CancellationToken cancellationToken)
        {
            switch (user.UstozkerakCount)
            {
                case 0:
                    user.Messages.Add(message.Text!.ToString());
                    await _userService.IncIshJoylashCount(message.Chat.Id);
                    goto case 1;

                case 1:
                    user.Messages.Add(message.Text!.ToString());
                    await client.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: "🗓 Tug'ilgan sana: (50 element)\r\nShogirtning tug'ilgan sanasini kiriting.",
                        cancellationToken: cancellationToken);
                    await _userService.IncIshJoylashCount(message.Chat.Id);
                    return;

                case 2:
                    user.Messages.Add(message.Text!.ToString());
                    await client.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: "💠 Shogirtlik yo'nalishi:\r\nQanday yo'nalish bo'yicha ustoz qidirilayotgan bo'lsa, shu yo'nalishni kiriting.",
                        cancellationToken: cancellationToken);
                    await _userService.IncIshJoylashCount(message.Chat.Id);
                    return;

                case 3:
                    user.Messages.Add(message.Text!.ToString());
                    await client.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: "🌏 Manzil: (500 element)\r\nQaysi manzil bo'yicha ustoz qidirilayotgan bo'lsa, shu manzilni kiriting.",
                        cancellationToken: cancellationToken);
                    await _userService.IncIshJoylashCount(message.Chat.Id);
                    return;

                case 4:
                    user.Messages.Add(message.Text!.ToString());
                    await client.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: "💰 Ish haqi: (100 element)\r\nIsh haqi kerak bo'lmasa \"Ish haqi kerak emas\" deb yozing. Ish haqi kerak bo'lsa miqdori, valyutasi va davriyligini kiriting.",
                        cancellationToken: cancellationToken);
                    await _userService.IncIshJoylashCount(message.Chat.Id);
                    return;

                case 5:
                    user.Messages.Add(message.Text!.ToString());
                    await client.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: "\U0001f9d1‍🎓 Talaba: (10 element)\r\nShogirt talaba bo'lsa \"Ha\" deb yozing, aksincha bo'lsa \"Yo'q\" deb yozing.",
                        cancellationToken: cancellationToken);
                    await _userService.IncIshJoylashCount(message.Chat.Id);
                    return;

                case 6:
                    user.Messages.Add(message.Text!.ToString());
                    await client.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: "📑 Shogirt haqida: (500 element)\r\nShogirt haqida qisqacha ma'lumot bering.",
                        cancellationToken: cancellationToken);
                    await _userService.IncIshJoylashCount(message.Chat.Id);
                    return;

                case 7:
                    user.Messages.Add(message.Text!.ToString());
                    await client.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: "📞 Aloqa: (100 element)\r\nBog'lanish uchun telefon raqam yoki elektron pochta manzilini kiriting.",
                        cancellationToken: cancellationToken);
                    await _userService.IncIshJoylashCount(message.Chat.Id);
                    return;

                case 8:
                    user.Messages.Add(message.Text!.ToString());
                    await client.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: "🕰 Murojaat qilish vaqti: (100 element)\r\nMurojaat qilish mumkin bo'lgan vaqtlarni kiriting.",
                        cancellationToken: cancellationToken);
                    await _userService.IncIshJoylashCount(message.Chat.Id);
                    return;

                case 9:
                    user.Messages.Add(message.Text!.ToString());
                    await client.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: "📌 Qo'shimcha ma'lumotlar: (500 element)\r\nQoshimcha ma'lumotlarni kiriting. ",
                        cancellationToken: cancellationToken);
                    await _userService.IncIshJoylashCount(message.Chat.Id);
                    return;

                case 10:
                    user.Messages.Add(message.Text!.ToString());
                    await client.SendTextMessageAsync(
                        chatId: message.Chat.Id,
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

🌐 ""EFFECT | Katta mehnat bozori"" kanalga obuna bo'lish (link | so'zni ichida bo'lishi kerak)");
                    await client.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: "Barcha ma'lumotlar to'g'rimi?",
                        replyMarkup: await ReplyKeyboardMarkups.ForConfirmation(),
                        parseMode: ParseMode.Html,
                        cancellationToken: cancellationToken);
                    await _userService.IncIshJoylashCount(message.Chat.Id);
                    return;

                case 11:
                    if (message.Text == "✅ To'g'ri")
                    {
                        await client.SendTextMessageAsync(
                            chatId: message.Chat.Id,
                            text: @"E'lonni joylash narxi: ""BEPUL 🕑""

ℹ️ E'lon joylashtirilgandan so'ng, u moderatorlar tomonidan ko'rib chiqiladi. Zaruriyat tug'ilganda, ma'lumotlar to'g'riligini tekshirish maqsadida e'lon muallifi bilan bog'laniladi.

Tayyor e'lonni ""EFFECT | Katta mehnat bozori"" @palonchi kanaliga joylash uchun ""E'lonni joylash"" tugmasini bosing, bekor qilish uchun ""Bekor qilish"" tugmasini bosing 👇",
                            replyMarkup: await ReplyKeyboardMarkups.ForMainState(),
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
                    user.Messages.Clear();
                    await _userService.NolUstozKerakCount(message.Chat.Id);
                    return;
            }
        }
    }
}
