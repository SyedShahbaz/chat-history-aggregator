using System.Text;
using PowerDiaryDataAggregator.DTOs;
using PowerDiaryDataAggregator.Entities;
using PowerDiaryDataAggregator.Enums;
using PowerDiaryDataAggregator.Interfaces;
using PowerDiaryDataAggregator.Resources;

namespace PowerDiaryDataAggregator.Services;

public class OutputBuilder : IOutputBuilder
{
    public string BuildHourlyOutput(List<ChatStatisticsDto> chatsStatistics)
    {
        var stringBuilder = new StringBuilder();
        foreach (var stat in chatsStatistics)
        {
            stringBuilder.AppendFormat(Resource.Hourly_Time, stat.Day, stat.Time).AppendLine();
            stringBuilder.AppendFormat(Resource.Hourly_PeopleEntered, stat.PersonsEntered).AppendLine();
            stringBuilder.AppendFormat(Resource.Hourly_PeopleExited, stat.PersonsExited).AppendLine();
            stringBuilder.AppendFormat(Resource.Hourly_CommentsMade , stat.CommentsMade).AppendLine();
            stringBuilder.AppendFormat(Resource.Hourly_HighFive , stat.DistinctHiFiveSenders, stat.DistinctHiFiveReceivers);
            stringBuilder.AppendLine().AppendLine();
        }
        return stringBuilder.ToString();
    }

    public string BuildMinutelyOutput(List<ChatHistory> chatsStatistics)
    {
        var stringBuilder = new StringBuilder();
        foreach (var stat in chatsStatistics)
        {
            switch (stat.EventType)
            {
                case (int)EventTypes.EnterRoom:
                    stringBuilder.AppendFormat(Resource.Minutely_PersonEntered, stat.TimeStamp, stat.PersonName).AppendLine();
                    break;
                case (int)EventTypes.LeftRoom:
                    stringBuilder.AppendFormat(Resource.Minutely_PersonExited, stat.TimeStamp, stat.PersonName).AppendLine();
                    break;
                case (int)EventTypes.MadeComment:
                    stringBuilder.AppendFormat(Resource.Minutely_CommentsMade, stat.TimeStamp, stat.PersonName, stat.EventDetails).AppendLine();
                    break;
                case (int)EventTypes.HighFive:
                    stringBuilder.AppendFormat(Resource.Minutely_HighFive, stat.TimeStamp, stat.PersonName, stat.AffectedByEvent).AppendLine();
                    break;
                default:
                    stringBuilder.AppendLine();
                    break;
            }
        }
        
        return stringBuilder.ToString();
    }
}