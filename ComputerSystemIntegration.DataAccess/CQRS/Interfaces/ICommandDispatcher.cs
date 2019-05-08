namespace ComputerSystemIntegration.DataAccess.CQRS.Interfaces
{
    public interface ICommandDispatcher
    {
        void Execute<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
