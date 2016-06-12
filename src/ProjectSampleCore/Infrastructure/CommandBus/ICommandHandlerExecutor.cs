namespace ProjectSampleCore.Infrastructure.CommandBus
{
    public interface ICommandHandlerExecutor
    {
        void Execute<T>(T command);
    }
}