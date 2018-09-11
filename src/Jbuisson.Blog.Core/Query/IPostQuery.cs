using Jbuisson.Blog.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Jbuisson.Blog.Core.Query
{
    public interface IPostQuery : IQuery<Post>
    {
        Task<Post> Find(string title);
    }
}
