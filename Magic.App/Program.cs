using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Magic.App.Configuration;
using Magic.App.Middleware;
using Magic.DAL;
using Magic.DTO.Interfaces;
using Magic.Repository.Extensions;
using Magic.Service.Configuration;
using Magic.Service.Extensions;
using Magic.Service.Functions;

var builder = WebApplication.CreateBuilder(args);

var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

builder.Services.AddControllers();
builder.Services.AddDbContextPool<MagicDbContext>(o =>
{
    o.UseNpgsql(config.GetSection("Database").Get<DatabaseConfiguration>().ConnectionString);
    o.LogTo(l => Debug.WriteLine(l), LogLevel.Information);
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ILocker, OptimisticLocker>()
    .Configure<LockerConfiguration>(config.GetSection("Locker"));

builder.Services
    .AddRepositories()
    .AddCustomServices();
var app = builder.Build();
app.UseMiddleware<ExceptionMiddleware>();
app.UseMiddleware<RequestDurationMiddleware>();
app.UseDefaultFiles();
app.UseStaticFiles();
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