namespace QueryMind.Domain.Entities
{
    public class Message
    {
        public int Id { get; set; }
        public string Role { get; set; }
        public string Content { get; set; }
        public string Timestamp { get; set; }
    }
}