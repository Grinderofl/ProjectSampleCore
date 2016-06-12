namespace ProjectSampleCore.Infrastructure.CommandBus.Impl
{
    public class CommandBus : ICommandBus
    {
        private readonly ICommandHandlerExecutor _commandHandlerExecutor;

        public CommandBus(ICommandHandlerExecutor commandHandlerExecutor)
        {
            _commandHandlerExecutor = commandHandlerExecutor;
        }

        public void Send<T>(T command)
        {
            _commandHandlerExecutor.Execute(command);
        }
    }
}