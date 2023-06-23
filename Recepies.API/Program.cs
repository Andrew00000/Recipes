using Recepies.Application.Repositories;
using Recepies.Application.Services;
using Recepies.Infrastructure.Repository;
using Recepies.Infrastructure.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IRecepiRepository, RecepiRepository>();
builder.Services.AddSingleton<IRecepiService, RecipeService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
