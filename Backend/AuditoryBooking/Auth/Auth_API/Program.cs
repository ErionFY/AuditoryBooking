using Auth_API.Common.Configuration;
using Auth_DAL;
using Auth_DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// string connectionString = builder.Configuration.GetConnectionString("AuthConnection");
// builder.Services.AddDbContext<AuthDbContext>(options => { options.UseNpgsql(connectionString); });
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddIdentity<UserExtended, IdentityRole>().AddEntityFrameworkStores <AuthDbContext>();

var app = builder.Build();




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
