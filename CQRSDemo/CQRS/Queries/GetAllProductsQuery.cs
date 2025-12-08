using CQRSDemo.CQRS.Infrastructure;
using CQRSDemo.Models.DTOs;

namespace CQRSDemo.CQRS.Queries;

public record GetAllProductsQuery() : IQuery<List<ProductDto>>;
