using Jbuisson.Blog.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Jbuisson.Blog.Core.Query
{
    public interface ICommentQuery : IQuery<Comment>
    {
        ICommentQuery WithPost(string title);
    }
}
