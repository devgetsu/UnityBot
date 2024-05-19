namespace UnityBot.Bot.Models.Entities
{
    public class IshJoy
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string IshBeruvchi { get; set; }
        public string VakansiyaNomi { get; set; }
        public string IshHaqi { get; set; }
        public string Location { get; set; }
        public string VahansiyaHaqida { get; set; }
        public string Aloqa { get; set; }
        public string MurojaatVaqti {  get; set; }
        public string Qoshimcha {  get; set; }
    }
}
