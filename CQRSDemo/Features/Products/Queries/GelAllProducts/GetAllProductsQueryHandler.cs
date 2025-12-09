using CQRSDemo.Data;
using CQRSDemo.Models.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRSDemo.Features.Products.Queries.GelAllProducts;

public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<ProductDto>>
{
    private readonly AppDbContext _context;

    public GetAllProductsQueryHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        return await _context.Products
            .AsNoTracking()
            .Select(p => new ProductDto(p.Id, p.Name, p.Price, p.Stock, p.CreatedAt))
            .ToListAsync(cancellationToken);
    }
}
