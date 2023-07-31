using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TodoApi.Models;
using BookApi.Models;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration; // allows both to access and to set up the config
IWebHostEnvironment environment = builder.Environment;
// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<TodoContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDbContext<BookContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

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
