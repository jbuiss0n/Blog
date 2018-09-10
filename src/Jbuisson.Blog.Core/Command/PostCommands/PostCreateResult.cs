using System;
using System.Collections.Generic;
using System.Text;

namespace Jbuisson.Blog.Core.Command.PostCommands
{
    public class PostCreateResult : CommandResult
    {
        public int Created { get; set; }

        public DateTime CreatedAt { get; set; }

        public string CanonicalTitle { get; set; }
    }
}
