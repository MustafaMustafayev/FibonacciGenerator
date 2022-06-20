using InterviewTask.API.ActionFilters;
using InterviewTask.BLL.Abstract;
using InterviewTask.BLL.Concrete;
using InterviewTask.Core.Abstract;
using InterviewTask.Core.Concrete;
using InterviewTask.Core.Extensions;
using InterviewTask.Core.Helper;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddMemoryCache();

ConfigurationManager configurationManager = builder.Configuration;

ConfigSettings configSettings = new ConfigSettings();

configurationManager.GetSection("ConfigSettings").Bind(configSettings);

builder.Services.AddSingleton<ConfigSettings>(configSettings);

builder.Services.AddScoped<IUtilService, UtilService>();

builder.Services.AddScoped<IMemoryService, MemoryService>();

builder.Services.AddScoped<IFibonacciService, FibonacciService>();

builder.Services.AddScoped<LogActionFilter>();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ConfigureExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();