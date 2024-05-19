using UnityBot.Bot.Models.Enums;

namespace UnityBot.Bot.Models.Entities
{
    public class UserModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public long ChatId { get; set; }
        public string? Username { get; set; }
        public Status Status { get; set; }
        public int ishCount { get; set; }
        public int sherikCount { get; set; } = 0;
        public int rezumeCount { get; set; } = 0;
        public int ustozCount { get; set; } = 0;
        public int shogirtCount { get; set; } = 0;
    }
}
