using System.Text.Json;
using PowerDiaryDataAggregator.Entities;

namespace PowerDiaryDataAggregator.Data;

public class Seed
{
    private readonly DataContext _context;

    public Seed(DataContext context)
    {
        _context = context;
    }
    
    public void SeedChats()
    {
        if ( _context.ChatHistory.Any()) return;

        var chatData = File.ReadAllText("Data/ChatSeedData.json");
        var chats = JsonSerializer.Deserialize<List<ChatHistory>>(chatData);
        
        chats?.ForEach(chat =>
        {
            _context.ChatHistory.Add(chat);
        });
       
        _context.SaveChangesAsync();
    }
}