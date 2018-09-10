using HotChocolate.Resolvers;
using HotChocolate.Types;
using Jbuisson.Blog.Core.Domain;
using Jbuisson.Blog.Core.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jbuisson.Blog.GraphQL.Types
{
    public class CommentType : ObjectType<Comment>
    {
        public static async Task<IEnumerable<Comment>> GetComments(IResolverContext context)
        {
            var post = context.Parent<Post>();

            var first = context.Argument<int>("first");
            var offset = context.Argument<int>("offset");

            return await context
                .Service<IQuery<Comment>>()
                .For<Post>(post.Id)
                .Fetch(first, offset);
        }
    }
}
