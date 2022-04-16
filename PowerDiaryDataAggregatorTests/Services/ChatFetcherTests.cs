using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PowerDiaryDataAggregator.DTOs;
using PowerDiaryDataAggregator.Entities;
using PowerDiaryDataAggregator.Interfaces;
using PowerDiaryDataAggregator.Services;
using PowerDiaryDataAggregatorTests.Resources;

namespace PowerDiaryDataAggregatorTests.Services;

[TestClass]
public class ChatFetcherTests
{
    private readonly Mock<IChatRepository> _chatRepository;
    private readonly Mock<IDataAggregator> _dataAggregator;
    private readonly Mock<IOutputBuilder> _outputBuilder;
    private readonly ChatFetcher _chatFetcher;

    public ChatFetcherTests()
    {
        _chatRepository = new Mock<IChatRepository>();
        _dataAggregator = new Mock<IDataAggregator>();
        _outputBuilder = new Mock<IOutputBuilder>();
        _chatFetcher = new ChatFetcher(_chatRepository.Object, _dataAggregator.Object, _outputBuilder.Object);
    }

    [TestMethod]
    public void GetChats_Returns_KeyNotFoundException()
    {
        Action action = () => _chatFetcher.GetChats("Unknown");
        action.Should().Throw<KeyNotFoundException>().WithMessage(Resource.KeyNotFoundExceptionMessage);
    }

    [TestMethod]
    public void GetChats_Returns_HourlyStats()
    {
        var chats = new List<ChatHistory>
        {
            new()
            {
                Id = 1,
                EventDetails = "",
                EventType = 1,
                PersonName = "Bob",
                TimeStamp = DateTime.Now,
                AffectedByEvent = ""
            }
        };

        var stats = new List<ChatStatisticsDto>
        {
            new()
            {
                PersonsEntered = 1,
                PersonsExited = 1,
                DistinctHiFiveReceivers = 0,
                DistinctHiFiveSenders = 0,
                Time = 5,
                CommentsMade = 0
            }
        };

        const string outputString = "1 Person entered the room, 1 person exited the room";

        _chatRepository.Setup(g => g.GetAllChats())
            .Returns(Task.FromResult<IEnumerable<ChatHistory>>(chats));
        _dataAggregator.Setup(a => a.AggregateChatsByHourly(It.IsAny<IEnumerable<ChatHistory>>()))
            .Returns(stats);
        _outputBuilder.Setup(b => b.BuildHourlyOutput(It.IsAny<List<ChatStatisticsDto>>()))
            .Returns(outputString);

        var actual = _chatFetcher.GetChats("Hourly");

        actual.Result.Should().Be(outputString);

    }
    
    [TestMethod]
    public void GetChats_Returns_MinutelyStats()
    {
        var chats = new List<ChatHistory>
        {
            new()
            {
                Id = 1,
                EventDetails = "",
                EventType = 1,
                PersonName = "Bob",
                TimeStamp = DateTime.Now,
                AffectedByEvent = ""
            }
        };

        var stats = new List<ChatHistory>
        {
            new()
            {
                Id = 1,
                EventDetails = "",
                EventType = 1,
                PersonName = "Bob",
                TimeStamp = DateTime.Now,
                AffectedByEvent = ""
            }
        };

        const string outputString = "5PM: Bob enters the room";

        _chatRepository.Setup(g => g.GetAllChats())
            .Returns(Task.FromResult<IEnumerable<ChatHistory>>(chats));
        _dataAggregator.Setup(a => a.AggregateChatsByMinutes(It.IsAny<IEnumerable<ChatHistory>>()))
            .Returns(stats);
        _outputBuilder.Setup(b => b.BuildMinutelyOutput(It.IsAny<List<ChatHistory>>()))
            .Returns(outputString);

        var actual = _chatFetcher.GetChats("Minutes");

        actual.Result.Should().Be(outputString);

    }
}