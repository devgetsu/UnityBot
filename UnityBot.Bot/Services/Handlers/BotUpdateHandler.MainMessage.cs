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
                text: "<strong>🎗 SHERIK KERAK</strong>\r\n" +
                "\r\nSherik kerakligi haqida e'lon joylashtirish uchun bir nechta savollarga javob bering. Har bir javobingiz to'g'ri va ishonchli ma'lumotlardan iborat bo'lishi kerak ekanligiga e'tiborli bo'ling.\r\n" +
                "\r\nSo'rovnoma yakunida, agarda kiritilgan barcha ma'lumotlar to'g'ri bo'lsa \"✅ To'g'ri\" tugmasini bosing, aksincha bo'lsa \"❌ Noto'g'ri\" tugmasini bosing va so'rovnomani qaytadan to'ldiring.\r\n" +
                "E'lon tayor bo'lgandan kegin \"E'lonni joylash\" tugmasi bosilsa e'lon o'sha zaxotiyoq \"EFFECT | Katta mehnat bozori\" @palonchi kanaliga joylashtiriladi.",
                 parseMode: ParseMode.Html,
                cancellationToken: cancellationToken);

            await client.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: "\r\n⭐️ <strong>Sherik:</strong> \r\nSherikning Ism Familiyasini yozing.",
                replyMarkup: new ReplyKeyboardRemove(),
                parseMode: ParseMode.Html,
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
                await _userService.CreateUser(user);
            }
            await _userService.ChangeStatus(message.Chat.Id, Models.Enums.Status.UstozKerak);


            await client.SendTextMessageAsync(
                       chatId: message.Chat.Id,
                       text: @"🧑🏻‍🏫 <strong>USTOZ KERAK</strong>

Ustoz kerakligi haqida e'lon joylashtirish uchun bir nechta savollarga javob bering. Har bir javobingiz to'g'ri va ishonchli ma'lumotlardan iborat bo'lishi kerak ekanligiga e'tiborli bo'ling.

So'rovnoma yakunida, agarda kiritilgan barcha ma'lumotlar to'g'ri bo'lsa ""✅ To'g'ri"" tugmasini bosing, aksincha bo'lsa ""❌ Noto'g'ri"" tugmasini bosing va so'rovnomani qaytadan to'ldiring.

 E'lon tayor bo'lgandan kegin ""E'lonni joylash"" tugmasi bosilsa e'lon o'sha zaxotiyoq ""EFFECT | Katta mehnat bozori"" @palonchi kanaliga joylashtiriladi.",
                       parseMode: ParseMode.Html,
                       cancellationToken: cancellationToken);

            await client.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: "\U0001f9d1🏻 <strong>Shogirt:</strong> \r\nShogirtning Ism Familiyasini kiriting.",
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
                       text: "\U0001f9d1🏻‍💼 <strong>REZYUME</strong>\r\n\r\nRezyume joylashtirish uchun bir nechta savollarga javob bering. Har bir javobingiz to'g'ri va ishonchli ma'lumotlardan iborat bo'lishi kerak ekanligiga e'tiborli bo'ling.\r\n\r\nSo'rovnoma yakunida, agarda kiritilgan barcha ma'lumotlar to'g'ri bo'lsa \"✅ To'g'ri\" tugmasini bosing, aksincha bo'lsa \"❌ Noto'g'ri\" tugmasini bosing va so'rovnomani qaytadan to'ldiring.\r\n\r\n1 VARIANT - E'lon tayor bo'lgandan kegin \"To'lov\" qadamiga o'tasiz. To'lov amalga oshirilgach e'lon o'sha zaxotiyoq \"EFFECT | Katta mehnat bozori\" @palonchi kanaliga joylashtiriladi.\r\n|\r\n2 VARIANT - E'lon tayor bo'lgandan kegin \"E'lonni joylash\" tugmasi bosilsa e'lon o'sha zaxotiyoq \"EFFECT | Katta mehnat bozori\" @palonchi kanaliga joylashtiriladi.",
                       cancellationToken: cancellationToken);
            await client.SendTextMessageAsync(
               chatId: message.Chat.Id,
               text: "⭐️ <strong>Ish qidiruvchi:</strong> \r\nIsh qidiruvchining Ism Familiyasini kiriting.",
               replyMarkup: new ReplyKeyboardRemove(),
               cancellationToken: cancellationToken
                );
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
                await _userService.CreateUser(user);
            }
            await _userService.ChangeStatus(message.Chat.Id, Models.Enums.Status.ShogirtKerak);


            await client.SendTextMessageAsync(
                       chatId: message.Chat.Id,
                       text: @"🧑🏻 <strong>SHOGIRT KERAK</strong>

Shogirt kerakligi haqida e'lon joylashtirish uchun bir nechta savollarga javob bering. Har bir javobingiz to'g'ri va ishonchli ma'lumotlardan iborat bo'lishi kerak ekanligiga e'tiborli bo'ling.

So'rovnoma yakunida, agarda kiritilgan barcha ma'lumotlar to'g'ri bo'lsa ""✅ To'g'ri"" tugmasini bosing, aksincha bo'lsa ""❌ Noto'g'ri"" tugmasini bosing va so'rovnomani qaytadan to'ldiring.

E'lon tayor bo'lgandan kegin ""E'lonni joylash"" tugmasi bosilsa e'lon o'sha zaxotiyoq ""EFFECT | Katta mehnat bozori"" @palonchi kanaliga joylashtiriladi.",
                       parseMode: ParseMode.Html,
                       cancellationToken: cancellationToken);

            await client.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: "\U0001f9d1🏻‍🏫 <strong>Ustoz</strong>: \r\nUstozning Ism Familiyasini yozing.",
                parseMode: ParseMode.Html,
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

E'lon tayor bo'lgandan kegin ""E'lonni joylash"" tugmasi bosilsa e'lon o'sha zaxotiyoq ""EFFECT | Katta mehnat bozori"" @palonchi kanaliga joylashtiriladi.",
                parseMode: ParseMode.Html,
                cancellationToken: cancellationToken);

            await client.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: "⭐️ <strong>Ish beruvchi:</strong>\r\nTashkilot nomini kiriting. Tashkilot bo'lmasa ish beruvchining Ism Familiyasini yozing.",
                parseMode: ParseMode.Html,
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
                    await HandleRezumeJoylashBotAsync(client, message, user, cancellationToken);
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
                        text: "📋 <strong>Vakansiya nomi:</strong> \r\nVakansiya nomini kiriting.",
                        parseMode: ParseMode.Html,
                        cancellationToken: cancellationToken);
                    await _userService.IncIshJoylashCount(message.Chat.Id);
                    return;

                case 2:
                    user.IshJoylashModel.VakansiyaNomi = message.Text;
                    await client.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: "💰 <strong>Ish haqi:</strong> \r\nIsh haqi miqdori, valyutasi va davriyligini kiriting",
                        parseMode: ParseMode.Html,
                        cancellationToken: cancellationToken);
                    await _userService.IncIshJoylashCount(message.Chat.Id);
                    return;

                case 3:
                    user.IshJoylashModel.IshHaqi = message.Text;
                    await client.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: "🌏 <strong>Manzil:</strong> \r\nIsh joyi manzilini kiriting.",
                        parseMode: ParseMode.Html,
                        cancellationToken: cancellationToken);
                    await _userService.IncIshJoylashCount(message.Chat.Id);
                    return;

                case 4:
                    user.IshJoylashModel.Location = message.Text;
                    await client.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: "📑 <strong>Vakansiya haqida</strong>: \r\nVakansiya haqida qisqacha ma'lumot bering." +
                        " \r\nMisol uchun, nima qilinishi kerakligi haqida yozing.",
                        parseMode: ParseMode.Html,
                        cancellationToken: cancellationToken);
                    await _userService.IncIshJoylashCount(message.Chat.Id);
                    return;

                case 5:
                    user.IshJoylashModel.VahansiyaHaqida = message.Text;
                    await client.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: "📞 <strong>Aloqa:</strong> \r\nBog'lanish uchun telefon raqam yoki elektron pochta manzilini kiriting. Misol uchun:\r\n• +998912345678\r\n• example@gmail.com",
                        parseMode: ParseMode.Html,
                        cancellationToken: cancellationToken);
                    await _userService.IncIshJoylashCount(message.Chat.Id);
                    return;

                case 6:
                    user.IshJoylashModel.Aloqa = message.Text;
                    await client.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: "🕰 <strong>Murojaat qilish vaqti:</strong> \r\nMurojaat qilish mumkin bo'lgan vaqtlarni kiriting.",
                        parseMode: ParseMode.Html,
                        cancellationToken: cancellationToken);
                    await _userService.IncIshJoylashCount(message.Chat.Id);
                    return;

                case 7:
                    user.IshJoylashModel.MurojaatVaqti = message.Text;
                    await client.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: "📌 <strong>Qo'shimcha ma'lumotlar:</strong> \r\nQoshimcha ma'lumotlarni kiriting. Agarda ular yo'q bo'lsa \"Qo'shimcha ma'lumotlar yo'q\" tugmasini bosing.",
                        parseMode: ParseMode.Html,
                        cancellationToken: cancellationToken);
                    await _userService.IncIshJoylashCount(message.Chat.Id);
                    return;

                case 8:
                    user.IshJoylashModel.Qoshimcha = message.Text;
                    await client.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: @$"4. <strong>ISH JOYLASH</strong> 

🏢 <strong>ISH</strong>

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

🌐 ""<a href=''>EFFECT | Katta mehnat bozori</a>"" kanaliga obuna bo'lish",
                        parseMode: ParseMode.Html);
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
                       text: "📋 Sheriklik yo'nalishi: \r\nQanday yo'nalish bo'yicha sherik qidirilayotgan bo'lsa, shu yo'nalishni kiriting",
                       cancellationToken: cancellationToken);
                    await _userService.IncSherikKerak(message.Chat.Id);
                    return;
                case 2:
                    user.SherikKerakModel.SherikLikYonalishi = message.Text;
                    await client.SendTextMessageAsync(
                       chatId: message.Chat.Id,
                       text: "💰 Hisob-kitob: \r\nHisob-kitob alohida muzokara qilinsa \"Alohida muzokara qilinadi\" deb yozing. Hisob-kitob e'lon qilinsa ma'lumotlarini kiriting.",
                       cancellationToken: cancellationToken);
                    await _userService.IncSherikKerak(message.Chat.Id);
                    return;
                case 3:
                    user.SherikKerakModel.HisobKitob = message.Text;
                    await client.SendTextMessageAsync(
                       chatId: message.Chat.Id,
                       text: "🌏Manzil: \r\nQaysi manzil bo'yicha sherik qidirilayotgan bo'lsa, shu manzilni kiriting.",
                       cancellationToken: cancellationToken);
                    await _userService.IncSherikKerak(message.Chat.Id);
                    return;
                case 4:
                    user.SherikKerakModel.Manzil = message.Text;
                    await client.SendTextMessageAsync(
                       chatId: message.Chat.Id,
                       text: "📑Sheriklik haqida: \r\nSheriklik haqida qisqacha ma'lumot bering. Misol uchun, nimalar qilinishi haqida yozing.",
                       cancellationToken: cancellationToken);
                    await _userService.IncSherikKerak(message.Chat.Id);
                    return;
                case 5:
                    user.SherikKerakModel.SheriklikHaqida = message.Text;
                    await client.SendTextMessageAsync(
                       chatId: message.Chat.Id,
                       text: "📞 Aloqa: \r\nBog'lanish uchun telefon raqam yoki elektron pochta manzilini kiriting.",
                       cancellationToken: cancellationToken);
                    await _userService.IncSherikKerak(message.Chat.Id);
                    return;
                case 6:
                    user.SherikKerakModel.Aloqa = message.Text;
                    await client.SendTextMessageAsync(
                       chatId: message.Chat.Id,
                       text: "🕰 Murojaat qilish vaqti: \r\nMurojaat qilish mumkin bo'lgan vaqtlarni kiriting. ",
                       cancellationToken: cancellationToken);
                    await _userService.IncSherikKerak(message.Chat.Id);
                    return;
                case 7:
                    user.SherikKerakModel.MurojaatQilishVaqti = message.Text;
                    await client.SendTextMessageAsync(
                       chatId: message.Chat.Id,
                       text: "📌Qo'shimcha ma'lumotlar: ",
                       cancellationToken: cancellationToken);
                    await _userService.IncSherikKerak(message.Chat.Id);
                    return;
                case 8:
                    user.SherikKerakModel.QoshimchaMalumotlar = message.Text;
                    await client.SendTextMessageAsync(
                       chatId: message.Chat.Id,
                       text: @$" SHERIK KERAK 

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
                  text: "📋 Ustozlik yo'nalishi: \r\nQanday yo'nalish bo'yicha shogirt olinsa, shu yo'nalishni kiriting.",
                  cancellationToken: cancellationToken);

                return;
            }

            if (user.ShogirtKerakCount == 2)
            {
                user.Messages.Add(message.Text!.ToString());

                await client.SendTextMessageAsync(
                  chatId: message.Chat.Id,
                  text: "💰 Ish haqi: \r\nIsh haqi yo'q bo'lsa \"Yo'q\" deb yozing. Ish haqi bor bo'lsa miqdori, valyutasi va davriyligini kiriting.",
                  cancellationToken: cancellationToken);
                return;

            }

            if (user.ShogirtKerakCount == 3)
            {
                user.Messages.Add(message.Text!.ToString());

                await client.SendTextMessageAsync(
                  chatId: message.Chat.Id,
                  text: "🌏 Manzil: \r\nFaoliyat yuritish manzilini kiriting.",
                  cancellationToken: cancellationToken);
                return;

            }

            if (user.ShogirtKerakCount == 4)
            {
                user.Messages.Add(message.Text!.ToString());

                await client.SendTextMessageAsync(
                  chatId: message.Chat.Id,
                  text: "📑 Ustozlik haqida: \r\nUstozlik haqida qisqacha ma'lumot bering.",
                  cancellationToken: cancellationToken);
                return;

            }

            if (user.ShogirtKerakCount == 5)
            {

                user.Messages.Add(message.Text!.ToString());

                await client.SendTextMessageAsync(
                  chatId: message.Chat.Id,
                  text: "📞 Aloqa: \r\nBog'lanish uchun telefon raqam yoki elektron pochta manzilini kiriting.",
                  cancellationToken: cancellationToken);
                return;

            }

            if (user.ShogirtKerakCount == 6)
            {

                user.Messages.Add(message.Text!.ToString());

                await client.SendTextMessageAsync(
                  chatId: message.Chat.Id,
                  text: "🕰 Murojaat qilish vaqti: \r\nMurojaat qilish mumkin bo'lgan vaqtlarni kiriting.",
                  cancellationToken: cancellationToken);

                return;

            }

            if (user.ShogirtKerakCount == 7)
            {

                user.Messages.Add(message.Text!.ToString());

                await client.SendTextMessageAsync(
                  chatId: message.Chat.Id,
                  text: "📌 Qo'shimcha ma'lumotlar: \r\nQoshimcha ma'lumotlarni kiriting.",
                  cancellationToken: cancellationToken);

                return;

            }
            if (user.ShogirtKerakCount == 8)
            {
                user.Messages.Add(message.Text!.ToString());

                await client.SendTextMessageAsync(
                    chatId: message.Chat.Id,
                    text: @$"22. SHOGIRT KERAK 

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
                    await _userService.IncUstozKerak(message.Chat.Id);
                    goto case 1;

                case 1:
                    user.Messages.Add(message.Text!.ToString());
                    await client.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: "🗓 Tug'ilgan sana:\r\nShogirtning tug'ilgan sanasini kiriting.",
                        cancellationToken: cancellationToken);
                    return;

                case 2:
                    user.Messages.Add(message.Text!.ToString());
                    await client.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: "💠 Shogirtlik yo'nalishi:\r\nQanday yo'nalish bo'yicha ustoz qidirilayotgan bo'lsa, shu yo'nalishni kiriting.",
                        cancellationToken: cancellationToken);
                    return;

                case 3:
                    user.Messages.Add(message.Text!.ToString());
                    await client.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: "🌏 Manzil: \r\nQaysi manzil bo'yicha ustoz qidirilayotgan bo'lsa, shu manzilni kiriting.",
                        cancellationToken: cancellationToken);
                    return;

                case 4:
                    user.Messages.Add(message.Text!.ToString());
                    await client.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: "💰 Ish haqi:\r\nIsh haqi kerak bo'lmasa \"Ish haqi kerak emas\" deb yozing. Ish haqi kerak bo'lsa miqdori, valyutasi va davriyligini kiriting.",
                        cancellationToken: cancellationToken);
                    return;

                case 5:
                    user.Messages.Add(message.Text!.ToString());
                    await client.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: "\U0001f9d1‍🎓 Talaba: \r\nShogirt talaba bo'lsa \"Ha\" deb yozing, aksincha bo'lsa \"Yo'q\" deb yozing.",
                        cancellationToken: cancellationToken);
                    return;

                case 6:
                    user.Messages.Add(message.Text!.ToString());
                    await client.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: "📑 Shogirt haqida: \r\nShogirt haqida qisqacha ma'lumot bering.",
                        cancellationToken: cancellationToken);
                    return;

                case 7:
                    user.Messages.Add(message.Text!.ToString());
                    await client.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: "📞 Aloqa: \r\nBog'lanish uchun telefon raqam yoki elektron pochta manzilini kiriting.",
                        cancellationToken: cancellationToken);
                    return;

                case 8:
                    user.Messages.Add(message.Text!.ToString());
                    await client.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: "🕰 Murojaat qilish vaqti: \r\nMurojaat qilish mumkin bo'lgan vaqtlarni kiriting.",
                        cancellationToken: cancellationToken);
                    return;

                case 9:
                    user.Messages.Add(message.Text!.ToString());
                    await client.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: "📌 Qo'shimcha ma'lumotlar: \r\nQoshimcha ma'lumotlarni kiriting. ",
                        cancellationToken: cancellationToken);
                    return;

                case 10:
                    user.Messages.Add(message.Text!.ToString());
                    await client.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: @$"31. USTOZ KERAK 

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
        private async Task HandleRezumeJoylashBotAsync(ITelegramBotClient client, Message message, UserModel user, CancellationToken cancellationToken)
        {
            switch (user.RezumeCount)
            {
                case 0:
                    user.Messages.Add(message.Text!.ToString());
                    await _userService.IncRezumeCount(message.Chat.Id);
                    goto case 1;
                case 1:
                    user.Messages.Add(message.Text!.ToString());
                    await client.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: "🗓 Tug'ilgan sana: \r\nIsh qidiruvchining tug'ilgan sanasini kiriting. ",
                        cancellationToken: cancellationToken);
                    return;

                case 2:
                    user.Messages.Add(message.Text!.ToString());
                    await client.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: "💠 Mutaxassislik:\r\nIsh qidiruvchining mutaxassisligini kiriting. ",
                        cancellationToken: cancellationToken);
                    return;

                case 3:
                    user.Messages.Add(message.Text!.ToString());
                    await client.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: "🌏 Manzil: \r\nIsh qidiruvchining manzilini kiriting.",
                        cancellationToken: cancellationToken);
                    return;


                case 4:
                    user.Messages.Add(message.Text!.ToString());
                    await client.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: "💰 Ish haqi: \r\nIsh qidiruvchiga maqul ish haqini kiriting. Ish haqi miqdori, valyutasi va davriyligini yozing.",
                        cancellationToken: cancellationToken);
                    return;

                case 5:
                    user.Messages.Add(message.Text!.ToString());
                    await client.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: "\U0001f9d1‍🎓 Talaba: \r\nShogirt talaba bo'lsa \"Ha\" deb yozing, aksincha bo'lsa \"Yo'q\" deb yozing.",
                        cancellationToken: cancellationToken);
                    return;
                case 6:
                    user.Messages.Add(message.Text!.ToString());
                    await client.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: "📑 Ish qidiruvchi haqida: \r\nIsh qidiruvchi haqida qisqacha ma'lumot bering. Misol uchun, qanday bilim va qibiliyatlarga ega ekanligi haqida yozing.",
                        cancellationToken: cancellationToken);
                    return;
                case 7:
                    user.Messages.Add(message.Text!.ToString());
                    await client.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: "📞 Aloqa: \r\nBog'lanish uchun telefon raqam yoki elektron pochta manzilini kiriting.",
                        cancellationToken: cancellationToken);
                    return;

                case 8:
                    user.Messages.Add(message.Text!.ToString());
                    await client.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: "🕰 Murojaat qilish vaqti: \r\nMurojaat qilish mumkin bo'lgan vaqtlarni kiriting.",
                        cancellationToken: cancellationToken);
                    return;

                case 9:
                    user.Messages.Add(message.Text!.ToString());
                    await client.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: "📌 Qo'shimcha ma'lumotlar: \r\nQoshimcha ma'lumotlarni kiriting. ",
                        cancellationToken: cancellationToken);
                    return;
                case 10:
                    user.Messages.Add(message.Text!.ToString());
                    await client.SendTextMessageAsync(
                        chatId: message.Chat.Id,
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

🌐 ""EFFECT | Katta mehnat bozori"" kanaliga obuna bo'lish (link | so'zni ichida bo'lishi kerak)");
                    await client.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: "Barcha ma'lumotlar to'g'rimi?",
                        replyMarkup: await ReplyKeyboardMarkups.ForConfirmation(),
                        parseMode: ParseMode.Html,
                        cancellationToken: cancellationToken);
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
                            replyMarkup: await ReplyKeyboardMarkups.ForMainState(),
                            cancellationToken: cancellationToken);
                        await _userService.ChangeStatus(message.Chat.Id, Status.MainPage);
                    }
                    user.Messages.Clear();
                    await _userService.NolRuzumeCount(message.Chat.Id);
                    return;
            }
        }
    }
}
