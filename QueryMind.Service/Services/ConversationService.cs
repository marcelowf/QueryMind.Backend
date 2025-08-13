using QueryMind.Domain.Entities;
using QueryMind.Infrastructure.Interfaces;
using QueryMind.Service.Interfaces;

namespace QueryMind.Service.Services
{
    public class ConversationService : IConversationService
    {
        private readonly IConversationRepository _conversationRepository;

        public ConversationService(IConversationRepository conversationRepository)
        {
            _conversationRepository = conversationRepository;
        }

        public async Task<Conversation> CreateConversationAsync(string name, int userId)
        {
            var conversation = new Conversation
            {
                Name = name,
                UserId = userId,
                Messages = new List<Message>()
            };

            await _conversationRepository.CreateAsync(conversation);
            return conversation;
        }

        public async Task<bool> DeleteConversationAsync(int conversationId)
        {
            var existing = await _conversationRepository.GetByIdAsync(conversationId);
            if (existing == null) return false;

            await _conversationRepository.DeleteAsync(conversationId);
            return true;
        }

        public async Task<Message> SendMessageAsync(int conversationId, string content)
        {
            // conversationId vai ser para jogar tudo junto na colelction de conversation{Messages[]} do MongoDB
            var conversation = await _conversationRepository.GetByIdAsync(conversationId);
            if (conversation == null)
                throw new Exception("Conversation not found.");

            var message = new Message
            {
                Content = content,
                Timestamp = DateTime.UtcNow
            };

            conversation.Messages.Add(message);
            await _conversationRepository.UpdateAsync(conversationId, conversation);

            return message;
        }

        public async Task<List<Conversation>> GetAllAsync()
        {
            return await _conversationRepository.GetAllAsync();
        }

        public async Task<Conversation?> GetByIdAsync(int id)
        {
            return await _conversationRepository.GetByIdAsync(id);
        }
    }
}
