using Telegram.Bot.Types;
using UnityBot.Bot.Models.Entities;
using UnityBot.Bot.Models.Enums;

namespace UnityBot.Bot.Services.UserServices
{
    public interface IUserService
    {
        Task CreateUser(UserModel user);
        Task<UserModel> GetUser(long ChatId);
        Task ChangeStatus(long ChatId,Status st);
    }
}
