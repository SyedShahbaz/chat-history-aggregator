using PowerDiaryDataAggregator.DTOs;
using PowerDiaryDataAggregator.Entities;

namespace PowerDiaryDataAggregator.Interfaces;

public interface IDataAggregator
{
    List<ChatHistory> AggregateChatsByMinutes(IEnumerable<ChatHistory> chats);
    List<ChatStatisticsDto> AggregateChatsByHourly(IEnumerable<ChatHistory> chats);
}