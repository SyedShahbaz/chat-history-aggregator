using System;
using System.Collections.Generic;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PowerDiaryDataAggregator.Data;
using PowerDiaryDataAggregator.Data.Repository;
using PowerDiaryDataAggregator.Entities;

namespace PowerDiaryDataAggregatorTests.Repository;

[TestClass]
public class ChatRepositoryTests
{
    [TestMethod]
    public void GetAllChats_Returns_AllChats()
    {
        var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase($"PowerDiary{Guid.NewGuid()}").Options;
        using var context = new DataContext(options);
        var chatsData = new List<ChatHistory>
        {
            new()
            {
                Id = 1,
                EventDetails = "Some Details",
                EventType = 2,
                PersonName = "Bob the builder",
                TimeStamp = new DateTime(2022, 12, 2, 5,4,5),
                AffectedByEvent = "Jade"
            }
        };
        var repository = new ChatRepository(context);
        context.AddRange(chatsData);
        context.SaveChanges();
        
        var chats = repository.GetAllChats();

        chats.Result.Should().BeEquivalentTo(chatsData);
    }
    
}