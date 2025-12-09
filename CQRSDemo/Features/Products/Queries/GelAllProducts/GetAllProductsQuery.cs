using CQRSDemo.Models.DTOs;
using MediatR;

namespace CQRSDemo.Features.Products.Queries.GelAllProducts;

public class GetAllProductsQuery : IRequest<List<ProductDto>>
{
}
