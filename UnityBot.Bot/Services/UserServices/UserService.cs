using Microsoft.EntityFrameworkCore;
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
    }
}
