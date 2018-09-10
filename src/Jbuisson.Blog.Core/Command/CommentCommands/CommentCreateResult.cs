using System;
using System.Collections.Generic;
using System.Text;

namespace Jbuisson.Blog.Core.Command.CommentCommands
{
    public class CommentCreateResult : CommandResult
    {
        public int Created { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
