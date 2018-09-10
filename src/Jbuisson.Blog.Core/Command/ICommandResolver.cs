using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Jbuisson.Blog.Core.Command
{
    public interface ICommandResolver
    {
        Task<TResult> Publish<TCommand, TResult>(TCommand command)
            where TCommand : ICommand<TResult>
            where TResult : CommandResult;
    }
}
