using CQRSDemo.Data;
using CQRSDemo.Models.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRSDemo.Features.Products.Queries.GetProductById;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDto?>
{
    private readonly AppDbContext _context;

    public GetProductByIdQueryHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ProductDto?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _context.Products
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

        return product == null ? null : new ProductDto(
            product.Id,
            product.Name,
            product.Price,
            product.Stock,
            product.CreatedAt
        );
    }
}
