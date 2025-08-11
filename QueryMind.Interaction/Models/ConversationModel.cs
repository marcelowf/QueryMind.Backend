namespace QueryMind.Interaction.Models
{
    public class CreateConversationModel
    {
        public string Name { get; set; }
        public int UserId { get; set; }
    }

    public class DeleteConversationModel
    {
        public int ConversationId { get; set; }
        public int UserId { get; set; }
    }

    public class SendMessageModel
    {
        public int ConversationId { get; set; }
        public string Content { get; set; }
    }
}