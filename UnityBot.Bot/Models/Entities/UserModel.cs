using UnityBot.Bot.Models.Enums;

namespace UnityBot.Bot.Models.Entities
{
    public class UserModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public long ChatId { get; set; }
        public string? Username { get; set; }
        public Status Status { get; set; }
        public IshJoy IshJoylashModel { get; set; } = new IshJoy();
        public int IshJoylashCount { get; set; } = 0;
        public int SherikKerakCount { get; set; } = 0;
        public int RezumeCount { get; set; } = 0;
        public int UstozkerakCount { get; set; } = 0;
        public int ShogirtKerakCount { get; set; } = 0;
    }
}
