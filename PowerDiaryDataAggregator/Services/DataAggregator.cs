using PowerDiaryDataAggregator.DTOs;
using PowerDiaryDataAggregator.Entities;
using PowerDiaryDataAggregator.Enums;
using PowerDiaryDataAggregator.Interfaces;

namespace PowerDiaryDataAggregator.Services;

public class DataAggregator : IDataAggregator
{
    public List<ChatHistory> AggregateChatsByMinutes(IEnumerable<ChatHistory> chats)
    {
        return chats.OrderBy(t => t.TimeStamp.Minute)
            .GroupBy(h => h.TimeStamp.Hour).SelectMany(s => s)
            .OrderBy(t => t.TimeStamp.Day)
            .ToList();
    }

    public List<ChatStatisticsDto> AggregateChatsByHourly(IEnumerable<ChatHistory> chats)
    {
        return chats
            .OrderBy(h => h.TimeStamp.Hour)
            .GroupBy(d => new {d.TimeStamp.Day, d.TimeStamp.Hour})
            .Select(g => new ChatStatisticsDto
            {
                Day = g.Key.Day,
                Time = g.Key.Hour,
                PersonsEntered = g.Count(s => s.EventType == (int)EventTypes.EnterRoom),
                PersonsExited = g.Count(s => s.EventType == (int)EventTypes.LeftRoom),
                CommentsMade = g.Count(s => s.EventType == (int)EventTypes.MadeComment),
                DistinctHiFiveSenders =   g.Where(x => x.EventType == (int) EventTypes.HighFive).Select(y => y.PersonName).Distinct().Count(),
                DistinctHiFiveReceivers = g.Where(x => x.EventType == (int) EventTypes.HighFive).Select(y => y.AffectedByEvent).Distinct().Count()
                
            }).OrderBy(d => d.Day).ToList();
    }
}