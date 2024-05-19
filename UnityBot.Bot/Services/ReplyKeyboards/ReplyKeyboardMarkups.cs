﻿using Telegram.Bot.Types.ReplyMarkups;

namespace UnityBot.Bot.Services.ReplyKeyboards
{
    public class ReplyKeyboardMarkups
    {
        public static async ValueTask<ReplyKeyboardMarkup> ForMainState()
        {
            List<List<KeyboardButton>> keyboardButtons = new List<List<KeyboardButton>>{
                new List<KeyboardButton>()
                {
                    new KeyboardButton("🏢 Ish joylash"),
                    new KeyboardButton("🧑🏻‍💼 Rezyume joylash"),
                },
                new List<KeyboardButton>()
                {
                    new KeyboardButton("🧑🏻 Shogirt kerak"),
                    new KeyboardButton("🧑🏻‍🏫 Ustoz kerak"),
                },
                new List<KeyboardButton>()
                {
                    new KeyboardButton("🎗 Sherik kerak"),
                },
            };

            ReplyKeyboardMarkup replyKeyboardMarkup = new ReplyKeyboardMarkup(keyboardButtons);

            return replyKeyboardMarkup;
        }

        public static async ValueTask<InlineKeyboardMarkup> ForConfirmation()
        {
            var inlineKeyboard = new InlineKeyboardMarkup(new[]
            {
            new[]
                {
                InlineKeyboardButton.WithCallbackData("✅ To'g'ri", "correct"),
                InlineKeyboardButton.WithCallbackData("❌ Noto'g'ri", "incorrect")
                }
            });

            return inlineKeyboard;
        }

    }

}
