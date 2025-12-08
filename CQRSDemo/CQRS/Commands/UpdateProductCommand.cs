using CQRSDemo.CQRS.Infrastructure;

namespace CQRSDemo.CQRS.Commands;

public record UpdateProductCommand(int Id, string Name, decimal Price, int Stock) : ICommand<bool>;

