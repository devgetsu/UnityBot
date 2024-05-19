using Telegram.Bot.Types;
using UnityBot.Bot.Models.Entities;
using UnityBot.Bot.Models.Enums;

namespace UnityBot.Bot.Services.UserServices
{
    public interface IUserService
    {
        Task CreateUser(UserModel user);
        Task<UserModel> GetUser(long ChatId);
        Task ChangeStatus(long ChatId, Status st);
        Task IncIshCount(long ChatId);
        Task IncShtCount(long ChatId);
        Task IncShkCount(long ChatId);
        Task IncRezCount(long ChatId);
        Task IncUstCount(long ChatId);
        Task NolIshCount(long ChatId);
        Task NolShtCount(long ChatId);
        Task NolShkCount(long ChatId);
        Task NolRezCount(long ChatId);
        Task NolUstCount(long ChatId);
    }
}
