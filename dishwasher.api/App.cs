using dishwasher.api.Data;
using dishwasher.api.Models;
using dishwasher.api.Repository;
using exercise.wwwapi.Endpoints;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddScoped<IRepository<ProgramModel, Guid>, ProgramRepository>();
builder.Services.AddDbContext<DataContext>(options => options.UseInMemoryDatabase("Programs")); // If using in-memory
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.ConfigureGenericModelEndpoint();

app.Run();
