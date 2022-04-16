using System;
using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerDiaryDataAggregator.DTOs;
using PowerDiaryDataAggregator.Entities;
using PowerDiaryDataAggregator.Services;

namespace PowerDiaryDataAggregatorTests.Services;

[TestClass]
public class DataAggregatorTests
{
    private readonly DataAggregator _dataAggregator;

    public DataAggregatorTests()
    {
        _dataAggregator = new DataAggregator();
    }

    [TestMethod]
    public void AggregateChatsByMinutes_Returns_ChatsAggregatedByMinutes()
    {
        var chatHistory = new List<ChatHistory>()
        {
            new()
            {
                Id = 7,
                EventDetails = "",
                EventType = 8,
                PersonName = "Bob",
                TimeStamp = new DateTime(2022, 12, 21, 5, 9, 1),
                AffectedByEvent = ""
            },
            new()
            {
                Id = 5,
                EventDetails = "",
                EventType = 2,
                PersonName = "Kate",
                TimeStamp = new DateTime(2022, 12, 21, 5, 8, 1),
                AffectedByEvent = ""
            },
            new()
            {
                Id = 3,
                EventDetails = "Hello from the other side",
                EventType = 3,
                PersonName = "Bob",
                TimeStamp = new DateTime(2022, 12, 21, 5, 6, 1),
                AffectedByEvent = ""
            },
            new()
            {
                Id = 4,
                EventDetails = "",
                EventType = 4,
                PersonName = "Bob",
                TimeStamp = new DateTime(2022, 12, 21, 5, 7, 1),
                AffectedByEvent = "Kate"
            },
            new()
            {
                Id = 2,
                EventDetails = "",
                EventType = 1,
                PersonName = "Kate",
                TimeStamp = new DateTime(2022, 12, 21, 5, 5, 1),
                AffectedByEvent = ""
            },
            new()
            {
                Id = 6,
                EventDetails = "",
                EventType = 2,
                PersonName = "Bob",
                TimeStamp = new DateTime(2022, 12, 21, 5, 9, 1),
                AffectedByEvent = ""
            },
            new()
            {
                Id = 1,
                EventDetails = "",
                EventType = 1,
                PersonName = "Bob",
                TimeStamp = new DateTime(2022, 12, 21, 5, 4, 1),
                AffectedByEvent = ""
            },
            new()
            {
                Id = 1,
                EventDetails = "",
                EventType = 1,
                PersonName = "Bob",
                TimeStamp = new DateTime(2022, 12, 22, 5, 4, 1),
                AffectedByEvent = ""
            },
           
        };
        var expectedAggregation = new List<ChatHistory>
        {
            new()
            {
                Id = 1,
                EventDetails = "",
                EventType = 1,
                PersonName = "Bob",
                TimeStamp = new DateTime(2022, 12, 21, 5, 4, 1),
                AffectedByEvent = ""
            },
            new()
            {
                Id = 2,
                EventDetails = "",
                EventType = 1,
                PersonName = "Kate",
                TimeStamp = new DateTime(2022, 12, 21, 5, 5, 1),
                AffectedByEvent = ""
            },
            new()
            {
                Id = 3,
                EventDetails = "Hello from the other side",
                EventType = 3,
                PersonName = "Bob",
                TimeStamp = new DateTime(2022, 12, 21, 5, 6, 1),
                AffectedByEvent = ""
            },
            new()
            {
                Id = 4,
                EventDetails = "",
                EventType = 4,
                PersonName = "Bob",
                TimeStamp = new DateTime(2022, 12, 21, 5, 7, 1),
                AffectedByEvent = "Kate"
            },
            new()
            {
                Id = 5,
                EventDetails = "",
                EventType = 2,
                PersonName = "Kate",
                TimeStamp = new DateTime(2022, 12, 21, 5, 8, 1),
                AffectedByEvent = ""
            },
            new()
            {
                Id = 6,
                EventDetails = "",
                EventType = 2,
                PersonName = "Bob",
                TimeStamp = new DateTime(2022, 12, 21, 5, 9, 1),
                AffectedByEvent = ""
            },
            new()
            {
                Id = 7,
                EventDetails = "",
                EventType = 8,
                PersonName = "Bob",
                TimeStamp = new DateTime(2022, 12, 21, 5, 9, 1),
                AffectedByEvent = ""
            },
            new()
            {
                Id = 1,
                EventDetails = "",
                EventType = 1,
                PersonName = "Bob",
                TimeStamp = new DateTime(2022, 12, 22, 5, 4, 1),
                AffectedByEvent = ""
            },
        };

        var output = _dataAggregator.AggregateChatsByMinutes(chatHistory);

        output.Should().BeEquivalentTo(expectedAggregation);
    }

    [TestMethod]
    public void AggregateChatsByHourly_Returns_ChatsAggregatedByHourly()
    {
        var chatHistory = new List<ChatHistory>()
        {
            new()
            {
                Id = 7,
                EventDetails = "",
                EventType = 8,
                PersonName = "Bob",
                TimeStamp = new DateTime(2022, 12, 21, 5, 9, 1),
                AffectedByEvent = ""
            },
            new()
            {
                Id = 5,
                EventDetails = "",
                EventType = 2,
                PersonName = "Kate",
                TimeStamp = new DateTime(2022, 12, 21, 5, 8, 1),
                AffectedByEvent = ""
            },
            new()
            {
                Id = 3,
                EventDetails = "Hello from the other side",
                EventType = 3,
                PersonName = "Bob",
                TimeStamp = new DateTime(2022, 12, 21, 5, 6, 1),
                AffectedByEvent = ""
            },
            new()
            {
                Id = 4,
                EventDetails = "",
                EventType = 4,
                PersonName = "Bob",
                TimeStamp = new DateTime(2022, 12, 21, 5, 7, 1),
                AffectedByEvent = "Kate"
            },
            new()
            {
                Id = 2,
                EventDetails = "",
                EventType = 1,
                PersonName = "Kate",
                TimeStamp = new DateTime(2022, 12, 21, 5, 5, 1),
                AffectedByEvent = ""
            },
            new()
            {
                Id = 6,
                EventDetails = "",
                EventType = 2,
                PersonName = "Bob",
                TimeStamp = new DateTime(2022, 12, 21, 5, 9, 1),
                AffectedByEvent = ""
            },
            new()
            {
                Id = 1,
                EventDetails = "",
                EventType = 1,
                PersonName = "Bob",
                TimeStamp = new DateTime(2022, 12, 21, 5, 4, 1),
                AffectedByEvent = ""
            },
            new()
            {
                Id = 9,
                EventDetails = "",
                EventType = 1,
                PersonName = "Jack",
                TimeStamp = new DateTime(2022, 12, 21, 6, 4, 1),
                AffectedByEvent = ""
            },
            new()
            {
                Id = 1,
                EventDetails = "",
                EventType = 1,
                PersonName = "Bob",
                TimeStamp = new DateTime(2022, 12, 22, 5, 4, 1),
                AffectedByEvent = ""
            },
           
        };
        var expected = new List<ChatStatisticsDto>()
        {
            new()
            {
                CommentsMade = 1,
                Day = 21,
                DistinctHiFiveReceivers = 1,
                DistinctHiFiveSenders = 1,
                PersonsEntered = 2,
                PersonsExited = 2,
                Time = 5
            },
            new()
            {
                CommentsMade = 0,
                Day = 21,
                DistinctHiFiveReceivers = 0,
                DistinctHiFiveSenders = 0,
                PersonsEntered = 1,
                PersonsExited = 0,
                Time = 6
            },
            new()
            {
                CommentsMade = 0,
                Day = 22,
                DistinctHiFiveReceivers = 0,
                DistinctHiFiveSenders = 0,
                PersonsEntered = 1,
                PersonsExited = 0,
                Time = 5
            },
        };

        var output = _dataAggregator.AggregateChatsByHourly(chatHistory);

        output.Should().BeEquivalentTo(expected);
    }
}