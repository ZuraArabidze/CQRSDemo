using CQRSDemo.CQRS.Infrastructure;
using CQRSDemo.Models.DTOs;

namespace CQRSDemo.CQRS.Queries;

public record GetProductByIdQuery(int Id) : IQuery<ProductDto>;

