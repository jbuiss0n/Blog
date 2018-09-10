using System;
using System.Collections.Generic;
using System.Linq;

namespace Jbuisson.Blog.Core.Command
{
    public abstract class CommandResult
    {
        public bool IsValid => Exception == null && !ValidationErrors.Any();

        public Exception Exception { get; protected set; }

        public ICollection<ValidationError> ValidationErrors { get; protected set; }

        public CommandResult()
        {
            ValidationErrors = new List<ValidationError>();
        }
    }
}
