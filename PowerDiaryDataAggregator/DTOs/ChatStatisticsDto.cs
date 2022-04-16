namespace PowerDiaryDataAggregator.DTOs;

public class ChatStatisticsDto
{
    public int Time { get; init; }
    public int Day { get; init; }
    public int PersonsEntered { get; init; }
    public int PersonsExited { get; init; }
    public int CommentsMade { get; init; }
    public int DistinctHiFiveSenders { get; init; }
    public int DistinctHiFiveReceivers { get; init; }
}