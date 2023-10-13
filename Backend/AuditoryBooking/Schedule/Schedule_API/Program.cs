using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Schedule_API.Common.Configurations;
using Schedule_API.DataAccess;
using Schedule_API.DataAccess.Repositories;
using Schedule_API.Services;
using Schedule_API.Services.ControllerServices;
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

builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = JwtConfigurations.Issuer,
            ValidateAudience = true,
            ValidAudience = JwtConfigurations.Audience,
            ValidateLifetime = true,
            IssuerSigningKey = JwtConfigurations.GetSymmetricSecurityKey(),
            
            ValidateIssuerSigningKey = true,
        };
        
    });




//TODO:вынести время таймера в Dev.json
builder.Services.AddScoped<IBookingService,BookingService>();
builder.Services.AddScoped<IScheduleService,ScheduleService>();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
