using System.Collections.Generic;

namespace ProjectSampleCore.Infrastructure.CommandBus
{
    public interface ICommandHandlerFactory
    {
        IEnumerable<IHandleCommand<TCommand>> ResolveHandlers<TCommand>();
    }
}