using Telegram.Bot.Types;
using UnityBot.Bot.Models.Entities;
using UnityBot.Bot.Models.Enums;

namespace UnityBot.Bot.Services.UserServices
{
    public interface IUserService
    {
        void CreateUser(UserModel user);
        Task<UserModel> GetUser(long ChatId);
        void ChangeStatus(long ChatId,Status st);
    }
}
