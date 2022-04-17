using Microsoft.EntityFrameworkCore;
using PowerDiaryDataAggregator.Data;
using PowerDiaryDataAggregator.Data.Repository;
using PowerDiaryDataAggregator.Interfaces;
using PowerDiaryDataAggregator.Middleware;
using PowerDiaryDataAggregator.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IChatRepository, ChatRepository>();
builder.Services.AddScoped<IChatFetcher, ChatFetcher>();
builder.Services.AddScoped<IDataAggregator, DataAggregator>();
builder.Services.AddScoped<IOutputBuilder, OutputBuilder>();
builder.Services.AddTransient<Seed>();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

SeedData(app);
void SeedData(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();
    using var scope = scopedFactory?.CreateScope();
    var service = scope?.ServiceProvider.GetService<Seed>();
    service?.SeedChats();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();