using System;
using System.Collections.Generic;
using System.Text;

namespace Jbuisson.Blog.Core.Command.PostCommands
{
    public class PostEditCommand : ICommand<PostEditResult>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime? DatePublication { get; set; }
    }
}
