using ElasticCrudExample;
using ElasticCrudExample.ElasticRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddElasticConfig();
builder.Services.AddSingleton<IPlayersRepository, PlayersRepository>();
builder.Services.AddSingleton<IElasticSettings, ElasticSettings>();

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