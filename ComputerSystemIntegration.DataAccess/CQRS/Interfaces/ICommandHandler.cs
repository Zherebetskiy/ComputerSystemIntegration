namespace ComputerSystemIntegration.DataAccess.CQRS.Interfaces
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        void Execute(TCommand command);
    }
}
