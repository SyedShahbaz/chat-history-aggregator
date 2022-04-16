using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PowerDiaryDataAggregator.Controllers;
using PowerDiaryDataAggregator.Interfaces;

namespace PowerDiaryDataAggregatorTests.Controllers;

[TestClass]
public class ChatHistoryControllerTests
{
    private readonly Mock<IChatFetcher> _chatFetcher;
    private readonly ChatHistoryController _controller;

    public ChatHistoryControllerTests()
    {
        _chatFetcher = new Mock<IChatFetcher>();
        _controller = new ChatHistoryController(_chatFetcher.Object);
    }

    [TestMethod]
    public void Get_Returns_ChatsStatistics()
    {
        const string statistics = "5pm: 3 comments made, 2 people entered the room, 2 peoples exited the room";
        _chatFetcher.Setup(g => g.GetChats(It.IsAny<string>())).Returns(Task.FromResult<string>(statistics));

        var output = _controller.Get("Hourly");

        output.Result.Should().Be(statistics);
    }

}