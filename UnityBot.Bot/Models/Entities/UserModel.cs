using UnityBot.Bot.Models.Enums;

namespace UnityBot.Bot.Models.Entities
{
    public class UserModel
    {
        public int Id { get; set; }
        public long ChatId { get; set; }
        public string? Username { get; set; }
        public Status Status { get; set; }
    }
}
