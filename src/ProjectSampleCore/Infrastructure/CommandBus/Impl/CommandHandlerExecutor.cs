namespace ProjectSampleCore.Infrastructure.CommandBus.Impl
{
    public class CommandHandlerExecutor : ICommandHandlerExecutor
    {
        private readonly ICommandHandlerFactory _commandHandlerFactory;

        public CommandHandlerExecutor(ICommandHandlerFactory commandHandlerFactory)
        {
            _commandHandlerFactory = commandHandlerFactory;
        }

        public void Execute<T>(T command)
        {
            var handlers = _commandHandlerFactory.ResolveHandlers<T>();
            foreach(var handler in handlers)
                handler.Handle(command);
        }
    }
}