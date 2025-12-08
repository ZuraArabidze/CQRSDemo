using CQRSDemo.CQRS.Commands;
using CQRSDemo.CQRS.Handlers.CommandHandlers;
using CQRSDemo.CQRS.Handlers.QueryHandlers;
using CQRSDemo.CQRS.Infrastructure;
using CQRSDemo.CQRS.Queries;
using CQRSDemo.Data;
using CQRSDemo.Models.DTOs;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register CQRS Infrastructure
builder.Services.AddScoped<ICommandDispatcher, CommandDispatcher>();
builder.Services.AddScoped<IQueryDispatcher, QueryDispatcher>();

// Register Command Handlers
builder.Services.AddScoped<ICommandHandler<CreateProductCommand, int>, CreateProductCommandHandler>();
builder.Services.AddScoped<ICommandHandler<UpdateProductCommand, bool>, UpdateProductCommandHandler>();
builder.Services.AddScoped<ICommandHandler<DeleteProductCommand, bool>, DeleteProductCommandHandler>();

// Register Query Handlers
builder.Services.AddScoped<IQueryHandler<GetProductByIdQuery, ProductDto?>, GetProductByIdQueryHandler>();
builder.Services.AddScoped<IQueryHandler<GetAllProductsQuery, List<ProductDto>>, GetAllProductsQueryHandler>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
}

app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
app.Run();
app.Run();
