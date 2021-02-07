using CodeTur.Comum.Commands;

namespace CodeTur.Comum.Handlers.Contracts
{
    public interface IHandlerCommand<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}
