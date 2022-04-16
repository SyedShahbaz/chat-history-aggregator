using System;
using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerDiaryDataAggregator.DTOs;
using PowerDiaryDataAggregator.Entities;
using PowerDiaryDataAggregator.Services;
using PowerDiaryDataAggregatorTests.Resources;

namespace PowerDiaryDataAggregatorTests.Services;

[TestClass]
public class OutputBuilderTests
{
    private readonly OutputBuilder _outputBuilder;

    public OutputBuilderTests()
    {
        _outputBuilder = new OutputBuilder();
    }

    [TestMethod]
    public void BuildHourlyOutput_Returns_HourlyOutput()
    {
        var chatsStatistics = new List<ChatStatisticsDto>
        {
            new()
            {
                PersonsExited = 2,
                PersonsEntered = 2,
                Time = 5,
                CommentsMade = 4,
                DistinctHiFiveReceivers = 1,
                DistinctHiFiveSenders = 1
            }
        };
        var expected = Resource.UnitTest_Hourly_Output;

        var output =_outputBuilder.BuildHourlyOutput(chatsStatistics);

        expected.Should().Be(output);
    }

    [TestMethod]
    public void BuildMinutelyOutput_Returns_MinutelyOutput()
    {
        var chatStatistics = new List<ChatHistory>
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
        var expected = Resource.UnitTest_Minutely_Output;
        
        var output = _outputBuilder.BuildMinutelyOutput(chatStatistics);

        expected.Should().Be(output);
    }
}