using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace ProjectSampleCore.Infrastructure.CommandBus.Impl
{
    public class CommandHandlerFactory : ICommandHandlerFactory

    {
        private readonly IServiceProvider _serviceProvider;

        public CommandHandlerFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IEnumerable<IHandleCommand<TCommand>> ResolveHandlers<TCommand>()
        {
            return _serviceProvider.GetServices<IHandleCommand<TCommand>>();
        }
    }
}