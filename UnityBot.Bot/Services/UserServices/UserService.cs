using Microsoft.EntityFrameworkCore;
using UnityBot.Bot.Models.Entities;
using UnityBot.Bot.Models.Enums;
using UnityBot.Bot.Persistanse;

namespace UnityBot.Bot.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly UnityDbContext _context;

        public UserService(UnityDbContext context)
        {
            _context = context;
        }

        public async void ChangeStatus(long ChatId,Status st)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == ChatId);
            user.Status = st;
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async void CreateUser(UserModel user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<UserModel> GetUser(long ChatId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == ChatId);
            return user;
        }
    }
}
