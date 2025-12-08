using CQRSDemo.CQRS.Commands;
using CQRSDemo.CQRS.Infrastructure;
using CQRSDemo.Data;
using CQRSDemo.Models.Entities;

namespace CQRSDemo.CQRS.Handlers.CommandHandlers;

public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand,int>
{
    private readonly AppDbContext _dbContext;

    public CreateProductCommandHandler(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> Handle(CreateProductCommand command)
    {
        var product = new Product
        {
            Name = command.Name,
            Price = command.Price,
            Stock = command.Stock,
            CreatedAt = DateTime.UtcNow
        };

        _dbContext.Products.Add(product);
        await _dbContext.SaveChangesAsync();

        return product.Id;
    }
}
