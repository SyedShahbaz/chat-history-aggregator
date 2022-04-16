using Microsoft.AspNetCore.Mvc;
using PowerDiaryDataAggregator.Interfaces;

namespace PowerDiaryDataAggregator.Controllers;

[ApiController]
[Route("[controller]")]
public class ChatHistoryController : ControllerBase
{
    private readonly IChatFetcher _chatFetcher;

    public ChatHistoryController(IChatFetcher chatFetcher)
    {
        _chatFetcher = chatFetcher; 
    }
    
    [HttpGet(Name = "GetChatStats")]
    public async Task<string> Get(string granularity)
    {
        return await _chatFetcher.GetChats(granularity);
    }
}