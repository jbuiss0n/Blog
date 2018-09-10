using System;
using System.Collections.Generic;
using System.Text;

namespace Jbuisson.Blog.Core.Command.PostCommands
{
    public class PostDeleteCommand : ICommand<PostDeleteResult>
    {
        public int Id { get; set; }
    }
}
