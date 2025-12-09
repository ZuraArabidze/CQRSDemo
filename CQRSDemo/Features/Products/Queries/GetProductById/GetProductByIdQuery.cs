using CQRSDemo.Models.DTOs;
using MediatR;

namespace CQRSDemo.Features.Products.Queries.GetProductById;

public class GetProductByIdQuery : IRequest<ProductDto?>
{
    public int Id { get; set; }
}
