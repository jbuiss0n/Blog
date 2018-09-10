using Jbuisson.Blog.Core.Command.PostCommands;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Jbuisson.Blog.Core.Command
{
    public class CommandResolver : ICommandResolver
    {
        private readonly IServiceProvider m_serviceProvider;

        public CommandResolver(IServiceProvider serviceProvider)
        {
            m_serviceProvider = serviceProvider;
        }

        public async Task<TResult> Publish<TCommand, TResult>(TCommand command)
            where TCommand : ICommand<TResult>
            where TResult : CommandResult
        {
            var validator = m_serviceProvider.GetService<ICommandValidator<TCommand, TResult>>();
            var handler = m_serviceProvider.GetService<ICommandHandler<TCommand, TResult>>();

            var result = await validator.Validate(command);

            if (!result.IsValid)
                return result;

            return await handler.Execute(command, result);
        }
    }
}
