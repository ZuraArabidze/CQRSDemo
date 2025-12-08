using CQRSDemo.CQRS.Infrastructure;
using CQRSDemo.CQRS.Queries;
using CQRSDemo.Data;
using CQRSDemo.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace CQRSDemo.CQRS.Handlers.QueryHandlers;

public class GetProductByIdQueryHandler : IQueryHandler<GetProductByIdQuery, ProductDto>
{
    private readonly AppDbContext _dbContext;

    public GetProductByIdQueryHandler(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ProductDto> Handle(GetProductByIdQuery query)
    {
        var product = await _dbContext.Products
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == query.Id);

        return product == null ? null : new ProductDto(
            product.Id,
            product.Name,
            product.Price,
            product.Stock,
            product.CreatedAt
        );
    }
}
