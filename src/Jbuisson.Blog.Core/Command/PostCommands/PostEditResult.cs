using System;
using System.Collections.Generic;
using System.Text;

namespace Jbuisson.Blog.Core.Command.PostCommands
{
    public class PostEditResult : CommandResult
    {
        public DateTime UpdatedAt { get; set; }

        public string CanonicalTitle { get; set; }
    }
}
