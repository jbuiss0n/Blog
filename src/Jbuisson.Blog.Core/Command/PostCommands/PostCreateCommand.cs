using System;
using System.Collections.Generic;
using System.Text;

namespace Jbuisson.Blog.Core.Command.PostCommands
{
    public class PostCreateCommand : ICommand<PostCreateResult>
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime? DatePublication { get; set; }
    }
}
