using Telegram.Bot.Types.ReplyMarkups;

namespace UnityBot.Bot.Services.ReplyKeyboards
{
    public class InlineKeyBoards
    {
        public static Task<InlineKeyboardMarkup> ForMainState()
        {
            List<List<InlineKeyboardButton>> inlineKeyboardButtons = new List<List<InlineKeyboardButton>>{
            new List<InlineKeyboardButton>
            {
                InlineKeyboardButton.WithCallbackData("🏢 Ish joylash", "ish_joylash"),
                InlineKeyboardButton.WithCallbackData("🧑🏻‍💼 Rezyume joylash", "rezyume_joylash"),
            },
            new List<InlineKeyboardButton>
            {
                InlineKeyboardButton.WithCallbackData("🧑🏻 Shogirt kerak", "shogirt_kerak"),
                InlineKeyboardButton.WithCallbackData("🧑🏻‍🏫 Ustoz kerak", "ustoz_kerak"),
            },
            new List<InlineKeyboardButton>
            {
                InlineKeyboardButton.WithCallbackData("🎗 Sherik kerak", "sherik_kerak"),
            },
        };

            InlineKeyboardMarkup inlineKeyboardMarkup = new InlineKeyboardMarkup(inlineKeyboardButtons);
            return Task.FromResult(inlineKeyboardMarkup);
        }

        public static Task<InlineKeyboardMarkup> ForConfirmation()
        {
            List<List<InlineKeyboardButton>> inlineKeyboardButtons = new List<List<InlineKeyboardButton>>{
            new List<InlineKeyboardButton>
            {
                InlineKeyboardButton.WithCallbackData("✅ To'g'ri", "togrri"),
                InlineKeyboardButton.WithCallbackData("❌ Noto'g'ri", "notogrri"),
            }
        };

            InlineKeyboardMarkup inlineKeyboardMarkup = new InlineKeyboardMarkup(inlineKeyboardButtons);
            return Task.FromResult(inlineKeyboardMarkup);
        }

        public static Task<InlineKeyboardMarkup> ForSendToChanel()
        {
            List<List<InlineKeyboardButton>> inlineKeyboardButtons = new List<List<InlineKeyboardButton>>{
            new List<InlineKeyboardButton>
            {
                InlineKeyboardButton.WithCallbackData("✅Elonni Joylash", "joyla"),
                InlineKeyboardButton.WithCallbackData("❌ O'tkazib yuboarish", "skip"),
            }
        };

            InlineKeyboardMarkup inlineKeyboardMarkup = new InlineKeyboardMarkup(inlineKeyboardButtons);
            return Task.FromResult(inlineKeyboardMarkup);
        }
    }
}
