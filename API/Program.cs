using AutoMapper;
using DataBase.Contexts;
using DataBase.Repositories;
using DataBase.Repositories.Interfaces;
using Logic.Profiles;
using Logic.Queries;
using Logic.Queries.Interfaces;
using Logic.ReadServices;
using Logic.ReadServices.Interfaces;
using Logic.WriteServices;
using Logic.WriteServices.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true); // устаревшее поведение Даты и Времени в postgreSQL
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<IWebContext, Context>(x => x.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
AutoMapper.IConfigurationProvider config = new MapperConfiguration(cfg =>
{
    cfg.AddProfile<UserProfile>();
});

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IUserWriteService, UserWriteService>();
builder.Services.AddScoped<IUserReadService, UserReadService>();
builder.Services.AddScoped<IUserQuery, UserQuery>();

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
