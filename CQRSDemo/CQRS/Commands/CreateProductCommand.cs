using CQRSDemo.CQRS.Infrastructure;

namespace CQRSDemo.CQRS.Commands;

public record CreateProductCommand(string Name, decimal Price, int Stock) : ICommand<int>;

