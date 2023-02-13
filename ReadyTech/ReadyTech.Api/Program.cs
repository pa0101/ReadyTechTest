using ReadyTech.Api.Configurations;
using ReadyTech.Api.Models;
using ReadyTech.Api.Models.Interfaces;
using ReadyTech.Api.Services;
using ReadyTech.Api.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ICoffeeMachine, CoffeeMachine>();
builder.Services.AddScoped<IWeatherService, WeatherService>();

builder.Services.Configure<WeatherApiConfiguration>(builder.Configuration.GetSection("WeatherApi"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
