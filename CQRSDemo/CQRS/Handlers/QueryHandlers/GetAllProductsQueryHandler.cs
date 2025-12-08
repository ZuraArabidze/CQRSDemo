using CQRSDemo.CQRS.Infrastructure;
using CQRSDemo.CQRS.Queries;
using CQRSDemo.Data;
using CQRSDemo.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace CQRSDemo.CQRS.Handlers.QueryHandlers;

public class GetAllProductsQueryHandler : IQueryHandler<GetAllProductsQuery, List<ProductDto>>
{
    private readonly AppDbContext _dbContext;

    public GetAllProductsQueryHandler(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<ProductDto>> Handle(GetAllProductsQuery query)
    {
        return await _dbContext.Products
            .AsNoTracking()
            .Select(p => new ProductDto(p.Id, p.Name, p.Price, p.Stock, p.CreatedAt))
            .ToListAsync();
    }
}
