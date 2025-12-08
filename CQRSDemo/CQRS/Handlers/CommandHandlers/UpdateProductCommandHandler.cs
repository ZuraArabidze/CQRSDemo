using CQRSDemo.CQRS.Commands;
using CQRSDemo.CQRS.Infrastructure;
using CQRSDemo.Data;

namespace CQRSDemo.CQRS.Handlers.CommandHandlers;

public class UpdateProductCommandHandler : ICommandHandler<UpdateProductCommand, bool>
{
    private readonly AppDbContext _dbContext;

    public UpdateProductCommandHandler(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> Handle(UpdateProductCommand command)
    {
        var product = await _dbContext.Products.FindAsync(command.Id);
        if (product == null)
        {
            return false;
        }
        product.Name = command.Name;
        product.Price = command.Price;
        product.Stock = command.Stock;
        product.UpdatedAt = DateTime.UtcNow;

        await _dbContext.SaveChangesAsync();
        return true;
    }
}
