using Microsoft.EntityFrameworkCore;
using Schedule_API.DataAccess;
using Schedule_API.DataAccess.Repositories;
using Schedule_API.Services;
using Schedule_API.Services.Interfaces;
using Schedule_API.Services.Interfaces.IRepositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("ScheduleConnection");
builder.Services.AddDbContext<ScheduleDbContext>(options => { options.UseNpgsql(connectionString); }/*,ServiceLifetime.Singleton*/);

//TODO:вынести время таймера в Dev.json
builder.Services.AddHostedService<RepeatingService>();
builder.Services.AddSingleton<IInTimeApiParser, InTimeApiParser>();
builder.Services.AddSingleton<IRepository, Repository>();

builder.Services.AddHttpClient<IInTimeApiParser, InTimeApiParser>(client =>
{
    client.BaseAddress = new Uri("https://test.intime.kreosoft.space/api/web/");
});
var app = builder.Build();

//TODO: show Enums

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
