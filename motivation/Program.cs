using Microsoft.EntityFrameworkCore;
using Motivation.Data;
using Motivation.Interface;
using Motivation.Repository;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddDbContext<MotivateDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString"));
});
//builder.Services.AddHttpClient<OpenAiService>();

builder.Services.AddControllers();



builder.Services.AddTransient<IEmotionRepository, EmotionRepository>();
builder.Services.AddTransient<IQuoteRepository, QuoteRepository>();
builder.Services.AddHttpClient<OpenAiService>();
//builder.Services.AddSingleton<OpenAiService>(); 


var apiKey = builder.Configuration["OpenAI:ApiKey"];
if(string.IsNullOrEmpty(apiKey))
{
    throw new Exception("OpenAI API key is missing in configuration!");
}


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}




app.UseHttpsRedirection();

app.MapControllers();
app.Run();

// record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
// {
//     public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
// }
