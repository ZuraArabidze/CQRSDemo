namespace CQRSDemo.CQRS.Infrastructure;

public interface ICommandDispatcher
{
    Task<TResult> Dispatch<TCommand, TResult>(TCommand command) where TCommand : ICommand<TResult>;
}
