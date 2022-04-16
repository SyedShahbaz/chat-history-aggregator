using PowerDiaryDataAggregator.Enums;
using PowerDiaryDataAggregator.Interfaces;
using PowerDiaryDataAggregator.Resources;

namespace PowerDiaryDataAggregator.Services;

public class ChatFetcher : IChatFetcher
{
    private readonly IChatRepository _chatRepository;
    private readonly IDataAggregator _dataAggregator;
    private readonly IOutputBuilder _outputBuilder;

    public ChatFetcher(IChatRepository chatRepository, IDataAggregator dataAggregator, IOutputBuilder outputBuilder)
    {
        _chatRepository = chatRepository;
        _dataAggregator = dataAggregator;
        _outputBuilder = outputBuilder;
    }

    public Task<string> GetChats(string granularity)
    {
        var status = Enum.TryParse(granularity, true, out AggregationLevel aggregationLevel);

        if (!status)
            throw new KeyNotFoundException(Resource.KeyNotFoundExceptionMessage);

        return aggregationLevel switch
        {
            AggregationLevel.Hourly => GetStatsAggregatedByHour(),
            AggregationLevel.Minutes => GetStatsAggregatedByMinute(),
            _ => throw new KeyNotFoundException(Resource.KeyNotFoundExceptionMessage)
        };

    }
    
    private async Task<string> GetStatsAggregatedByHour()
    {
        var chats = await _chatRepository.GetAllChats();
        var stats = _dataAggregator.AggregateChatsByHourly(chats);
        return _outputBuilder.BuildHourlyOutput(stats);
    }
    
    private async Task<string> GetStatsAggregatedByMinute()
    {
        var chats = await _chatRepository.GetAllChats();
        var stats = _dataAggregator.AggregateChatsByMinutes(chats);
        return _outputBuilder.BuildMinutelyOutput(stats);
    }
}

