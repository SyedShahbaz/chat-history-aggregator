using PowerDiaryDataAggregator.Entities;

namespace PowerDiaryDataAggregator.Interfaces;

public interface IChatFetcher
{
    Task<string> GetChats(string granularity);
}