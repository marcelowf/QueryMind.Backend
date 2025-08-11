namespace QueryMind.Domain.Entities
{
    public class Conversation
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public List<Message>? Messages { get; set; }
        public bool IsDeleted { get; set; }
    }
}