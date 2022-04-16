using Microsoft.EntityFrameworkCore;
using PowerDiaryDataAggregator.Entities;

namespace PowerDiaryDataAggregator.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<ChatHistory> ChatHistory { get; set; }
}