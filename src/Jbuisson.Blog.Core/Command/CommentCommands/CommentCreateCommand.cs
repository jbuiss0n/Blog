using System;
using System.Collections.Generic;
using System.Text;

namespace Jbuisson.Blog.Core.Command.CommentCommands
{
    public class CommentCreateCommand : ICommand<CommentCreateResult>
    {
        public int Id_Post { get; set; }
    }
}
