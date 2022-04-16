using PowerDiaryDataAggregator.Entities;

namespace PowerDiaryDataAggregator.Interfaces;

public interface IChatRepository
{
    Task<IEnumerable<ChatHistory>> GetAllChats();
}