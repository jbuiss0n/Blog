using HotChocolate.Types;
using Jbuisson.Blog.Core.Domain;
using Jbuisson.Blog.Core.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jbuisson.Blog.GraphQL.Types
{
    public class PostType : ObjectType<Post>
    {
        protected override void Configure(IObjectTypeDescriptor<Post> descriptor)
        {
            descriptor.Field(post => post.Comments)
                .Type<ListType<CommentType>>()
                .Argument("first", desc => desc.DefaultValue(10))
                .Argument("offset", desc => desc.DefaultValue(0))
                .Resolver(context => CommentType.GetComments(context).Result);
        }
    }
}
