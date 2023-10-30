namespace QueazyIT.Application.Common.Commands;

public interface ICommand : IMessage
{
}
public interface ICommand<TResult> : IMessage where TResult : class
{
}