using CQRSDemo.CQRS.Infrastructure;

namespace CQRSDemo.CQRS.Commands;

public record DeleteProductCommand(int Id) : ICommand<bool>;

