namespace CQRSDemo.CQRS.Infrastructure;

public interface ICommandHandler<TCommand, TResult>
    where TCommand : ICommand<TResult>
{
    Task<TResult> Handle(TCommand command);
}
