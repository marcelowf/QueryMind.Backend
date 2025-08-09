namespace QueryMind.Domain.Entities
{
    public class Conversation
    {
        public int Id { get; set; }
        public int userId { get; set; }
        public string Name { get; set; }
        public string Messages { get; set; } // Lista
        public bool IsDeleted { get; set; }
    }
}