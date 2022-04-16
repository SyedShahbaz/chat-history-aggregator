using Microsoft.EntityFrameworkCore;
using PowerDiaryDataAggregator.Entities;
using PowerDiaryDataAggregator.Interfaces;

namespace PowerDiaryDataAggregator.Data.Repository;

public class ChatRepository : IChatRepository
{
    private readonly DataContext _context;

    public ChatRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ChatHistory>> GetAllChats()
    {
        return await _context.ChatHistory.ToListAsync();
    }
}