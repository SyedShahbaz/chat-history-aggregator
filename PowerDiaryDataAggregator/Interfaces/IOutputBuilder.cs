using PowerDiaryDataAggregator.DTOs;
using PowerDiaryDataAggregator.Entities;

namespace PowerDiaryDataAggregator.Interfaces;

public interface IOutputBuilder
{
    string BuildHourlyOutput(List<ChatStatisticsDto> chatsStatistics);
    string BuildMinutelyOutput(List<ChatHistory> chatsStatistics);
}