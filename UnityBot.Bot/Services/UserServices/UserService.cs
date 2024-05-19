using Microsoft.EntityFrameworkCore;
using Telegram.Bot.Types;
using UnityBot.Bot.Models.Entities;
using UnityBot.Bot.Models.Enums;
using UnityBot.Bot.Persistanse;

namespace UnityBot.Bot.Services.UserServices
{
    public class UserService : IUserService
    {
        private List<UserModel> _users;

        public UserService()
        {
            _users = new List<UserModel>();
        }

        public async Task ChangeStatus(long chatId, Status status)
        {
            var user = _users.FirstOrDefault(x => x.ChatId == chatId);
            if (user != null)
            {
                user.Status = status;
            }
            else
            {
                throw new Exception($"User with ChatId {chatId} not found.");
            }
        }

        public async Task CreateUser(UserModel user)
        {
            _users.Add(user);
        }

        public async Task<UserModel> GetUser(long chatId)
        {
            var user = _users.FirstOrDefault(x => x.ChatId == chatId);
            return user;
        }

        public async Task IncIshCount(long ChatId)
        {
            var user = _users.FirstOrDefault(x => x.ChatId == ChatId);
            if (user != null)
            {
                user.ishCount += 1;
            }
        }

        public async Task IncRezCount(long ChatId)
        {
            var user = _users.FirstOrDefault(x => x.ChatId == ChatId);
            if (user != null)
            {
                user.rezumeCount += 1;
            }
        }

        public async Task IncShkCount(long ChatId)
        {
            var user = _users.FirstOrDefault(x => x.ChatId == ChatId);
            if (user != null)
            {
                user.sherikCount += 1;
            }
        }

        public async Task IncShtCount(long ChatId)
        {
            var user = _users.FirstOrDefault(x => x.ChatId == ChatId);
            if (user != null)
            {
                user.shogirtCount += 1;
            }
        }

        public async Task IncUstCount(long ChatId)
        {
            var user = _users.FirstOrDefault(x => x.ChatId == ChatId);
            if (user != null)
            {
                user.ustozCount += 1;
            }
        }

        public async Task NolIshCount(long ChatId)
        {
            var user = _users.FirstOrDefault(x => x.ChatId == ChatId);
            if (user != null)
            {
                user.ishCount = 0;
            }
        }

        public async Task NolRezCount(long ChatId)
        {
            var user = _users.FirstOrDefault(x => x.ChatId == ChatId);
            if (user != null)
            {
                user.rezumeCount = 0;
            }
        }

        public async Task NolShkCount(long ChatId)
        {
            var user = _users.FirstOrDefault(x => x.ChatId == ChatId);
            if (user != null)
            {
                user.sherikCount = 0;
            }
        }

        public async Task NolShtCount(long ChatId)
        {
            var user = _users.FirstOrDefault(x => x.ChatId == ChatId);
            if (user != null)
            {
                user.shogirtCount = 0;
            }
        }

        public async Task NolUstCount(long ChatId)
        {
            var user = _users.FirstOrDefault(x => x.ChatId == ChatId);
            if (user != null)
            {
                user.ustozCount = 0;
            }
        }
    }
}
