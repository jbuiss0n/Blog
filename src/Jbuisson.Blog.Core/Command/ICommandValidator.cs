using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Jbuisson.Blog.Core.Command
{
    public interface ICommandValidator<TCommand, TResult>
        where TCommand : ICommand<TResult>
        where TResult : CommandResult
    {
        Task<TResult> Validate(TCommand command);
    }
}
