using GourmetGrillApi.api.DAL;
using Microsoft.EntityFrameworkCore;
using ProyectoFinalGourmetGrill.Services;
using Shared.Interfaces;
using Shared.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var ConStr = builder.Configuration.GetConnectionString("ConStr") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(ConStr));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();
//Servicios
builder.Services.AddScoped<IServer<Productos>, ProductosService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
