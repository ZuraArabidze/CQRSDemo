using CQRSDemo.CQRS.Commands;
using CQRSDemo.CQRS.Infrastructure;
using CQRSDemo.Data;

namespace CQRSDemo.CQRS.Handlers.CommandHandlers;

public class DeleteProductCommandHandler : ICommandHandler<DeleteProductCommand, bool>
{
    private readonly AppDbContext _dbContext;

    public DeleteProductCommandHandler(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> Handle(DeleteProductCommand command)
    {
        var product = await _dbContext.Products.FindAsync(command.Id);
        if (product == null)
        {
            return false;
        }

        _dbContext.Products.Remove(product);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}
